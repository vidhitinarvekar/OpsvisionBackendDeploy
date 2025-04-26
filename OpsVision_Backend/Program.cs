using OpsVision_Backend.Data;
using Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.OpenApi.Models;
using OpsVision_Backend.Services;
using OpsVision_Backend.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
//using System.Security.Cryptography.X509Certificates;


var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on port 443
//builder.WebHost.ConfigureKestrel(options =>
//{
//    var certPath = "C:\\certs\\OpsVisionDevCert.pfx";
//    var certPassword = "StrongPasswordForOpsvisionProject@123";
//    var cert = new X509Certificate2(certPath, certPassword);
//    options.ListenAnyIP(443, listenOptions =>
//    {
//        listenOptions.UseHttps();  // Ensure HTTPS is used on port 443 // inside bracket mention ssl certificate 
//    });
//});

builder.Services.AddDbContext<FteDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 41))));
var configuration = builder.Configuration; // ? Correct way to access Configuration
var services = builder.Services;



// ?? 2. Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

// 2.Add Authentication Schemes: Azure AD and Local JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer("AzureAd", options =>
 {
     options.Authority = "https://login.microsoftonline.com/<TENANT_ID>/v2.0"; // Replace with your actual tenant ID
     options.Audience = "<CLIENT_ID>"; // Replace with your actual client ID
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateLifetime = true
     };
 })
.AddJwtBearer("LocalJwt", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
// 3. Authorization Policy for both schemes
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes("AzureAd", "LocalJwt")
        .RequireAuthenticatedUser()
        .Build();
});
// ?? 3. Register Services
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IProjectFteService, ProjectFteService>();
builder.Services.AddScoped<IProjectFteEmployeeService, ProjectFteEmployeeService>();


// ?? 4. Enable CORS (Allow All for Dev)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// 5. Swagger with JWT Auth
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OpsVision API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Enter 'Bearer' followed by your token."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

// 6. Add Controllers, Swagger, CORS
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// 7. Middleware Pipeline
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();


