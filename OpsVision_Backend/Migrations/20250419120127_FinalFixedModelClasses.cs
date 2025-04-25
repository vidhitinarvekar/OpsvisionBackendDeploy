using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpsVision_Backend.Migrations
{
    /// <inheritdoc />
    public partial class FinalFixedModelClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmploymentTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentTypes", x => x.TypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HolidayCalenders",
                columns: table => new
                {
                    HolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HolidayName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HolidayDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Region = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HolidayDay = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsNationalHoliday = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayCalenders", x => x.HolidayId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TitleName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LocationName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Region = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ManagementCodes",
                columns: table => new
                {
                    MgtCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodeName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementCodes", x => x.MgtCodeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrganizationalRelationships",
                columns: table => new
                {
                    RelationshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalRelationships", x => x.RelationshipId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShiftName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartTime = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaffClasses",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffClasses", x => x.ClassId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaffStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffStatuses", x => x.StatusId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VendorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StaffNumber = table.Column<int>(type: "int", nullable: true),
                    CUID = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobTitleId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    IsShiftWorker = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EmploymentTypeId = table.Column<int>(type: "int", nullable: true),
                    StaffClassId = table.Column<int>(type: "int", nullable: true),
                    VendorId = table.Column<int>(type: "int", nullable: true),
                    MgtCodeId = table.Column<int>(type: "int", nullable: true),
                    ReportsToStaffId = table.Column<int>(type: "int", nullable: true),
                    RelationshipId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_Staff_EmploymentTypes_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "EmploymentTypes",
                        principalColumn: "TypeId");
                    table.ForeignKey(
                        name: "FK_Staff_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitleId");
                    table.ForeignKey(
                        name: "FK_Staff_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_Staff_ManagementCodes_MgtCodeId",
                        column: x => x.MgtCodeId,
                        principalTable: "ManagementCodes",
                        principalColumn: "MgtCodeId");
                    table.ForeignKey(
                        name: "FK_Staff_OrganizationalRelationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "OrganizationalRelationships",
                        principalColumn: "RelationshipId");
                    table.ForeignKey(
                        name: "FK_Staff_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "ShiftId");
                    table.ForeignKey(
                        name: "FK_Staff_StaffClasses_StaffClassId",
                        column: x => x.StaffClassId,
                        principalTable: "StaffClasses",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_Staff_StaffStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StaffStatuses",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_Staff_Staff_ReportsToStaffId",
                        column: x => x.ReportsToStaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuditTrails",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TableName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ChangeSummary = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrails", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_AuditTrails_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId");
                    table.ForeignKey(
                        name: "FK_AuditTrails_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmploymentHistories",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    FieldChanged = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OldValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NewValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ChangedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentHistories", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_EmploymentHistories_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmploymentHistories_Users_ChangedByUserId",
                        column: x => x.ChangedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrimeCode = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProjectManager = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClassCategory = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClassCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.UniqueConstraint("AK_Projects_PrimeCode", x => x.PrimeCode);
                    table.ForeignKey(
                        name: "FK_Projects_Staff_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReportingHistories",
                columns: table => new
                {
                    ReportHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    OldManagerId = table.Column<int>(type: "int", nullable: true),
                    NewManagerId = table.Column<int>(type: "int", nullable: true),
                    ChangeDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ChangedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportingHistories", x => x.ReportHistoryId);
                    table.ForeignKey(
                        name: "FK_ReportingHistories_Staff_NewManagerId",
                        column: x => x.NewManagerId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportingHistories_Staff_OldManagerId",
                        column: x => x.OldManagerId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportingHistories_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportingHistories_Users_ChangedByUserId",
                        column: x => x.ChangedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TerminationLogs",
                columns: table => new
                {
                    TerminationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ApprovedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminationLogs", x => x.TerminationId);
                    table.ForeignKey(
                        name: "FK_TerminationLogs_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerminationLogs_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmployeeAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrimeCode = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalAllocatedHours = table.Column<double>(type: "double", nullable: false),
                    AllocatedHours = table.Column<double>(type: "double", nullable: false),
                    AssignedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CommitedHours = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAllocations_Projects_PrimeCode",
                        column: x => x.PrimeCode,
                        principalTable: "Projects",
                        principalColumn: "PrimeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeAllocations_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProjectAssignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrimeCode = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssignedByStaffId = table.Column<int>(type: "int", nullable: false),
                    AssigneeStaffId = table.Column<int>(type: "int", nullable: false),
                    AssignmentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RoleAssigned = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAssignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_ProjectAssignments_Projects_PrimeCode",
                        column: x => x.PrimeCode,
                        principalTable: "Projects",
                        principalColumn: "PrimeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAssignments_Staff_AssignedByStaffId",
                        column: x => x.AssignedByStaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectAssignments_Staff_AssigneeStaffId",
                        column: x => x.AssigneeStaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProjectFteAllocations",
                columns: table => new
                {
                    ProjectFteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PrimeCode = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AllocatedFte = table.Column<float>(type: "float", nullable: false),
                    AllocatedHours = table.Column<float>(type: "float", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFteAllocations", x => x.ProjectFteId);
                    table.ForeignKey(
                        name: "FK_ProjectFteAllocations_Projects_PrimeCode",
                        column: x => x.PrimeCode,
                        principalTable: "Projects",
                        principalColumn: "PrimeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectFteAllocations_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FteAllocations",
                columns: table => new
                {
                    FteAllocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    PrimeCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectFteId = table.Column<int>(type: "int", nullable: false),
                    AllocatedHours = table.Column<float>(type: "float", nullable: false),
                    FteCalculated = table.Column<float>(type: "float", nullable: false),
                    IsShiftWorker = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CommittedHours = table.Column<int>(type: "int", nullable: true),
                    CommittedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RemainingHours = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FteAllocations", x => x.FteAllocationId);
                    table.ForeignKey(
                        name: "FK_FteAllocations_ProjectFteAllocations_ProjectFteId",
                        column: x => x.ProjectFteId,
                        principalTable: "ProjectFteAllocations",
                        principalColumn: "ProjectFteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FteAllocations_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompletedHoursLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FteAllocationId = table.Column<int>(type: "int", nullable: false),
                    CompletedHours = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DateLogged = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TaskNote = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedHoursLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedHoursLogs_FteAllocations_FteAllocationId",
                        column: x => x.FteAllocationId,
                        principalTable: "FteAllocations",
                        principalColumn: "FteAllocationId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FteCommittedLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FteAllocationId = table.Column<int>(type: "int", nullable: false),
                    HoursCommitted = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DateCommitted = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FteCommittedLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_FteCommittedLogs_FteAllocations_FteAllocationId",
                        column: x => x.FteAllocationId,
                        principalTable: "FteAllocations",
                        principalColumn: "FteAllocationId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrails_ModifiedByUserId",
                table: "AuditTrails",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrails_StaffId",
                table: "AuditTrails",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedHoursLogs_FteAllocationId",
                table: "CompletedHoursLogs",
                column: "FteAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAllocations_PrimeCode",
                table: "EmployeeAllocations",
                column: "PrimeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAllocations_StaffId",
                table: "EmployeeAllocations",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistories_ChangedByUserId",
                table: "EmploymentHistories",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistories_StaffId",
                table: "EmploymentHistories",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_FteAllocations_ProjectFteId",
                table: "FteAllocations",
                column: "ProjectFteId");

            migrationBuilder.CreateIndex(
                name: "IX_FteAllocations_StaffId",
                table: "FteAllocations",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_FteCommittedLogs_FteAllocationId",
                table: "FteCommittedLogs",
                column: "FteAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignments_AssignedByStaffId",
                table: "ProjectAssignments",
                column: "AssignedByStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignments_AssigneeStaffId",
                table: "ProjectAssignments",
                column: "AssigneeStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignments_PrimeCode",
                table: "ProjectAssignments",
                column: "PrimeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFteAllocations_PrimeCode",
                table: "ProjectFteAllocations",
                column: "PrimeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFteAllocations_StaffId",
                table: "ProjectFteAllocations",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_OwnerId",
                table: "Projects",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PrimeCode",
                table: "Projects",
                column: "PrimeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportingHistories_ChangedByUserId",
                table: "ReportingHistories",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportingHistories_NewManagerId",
                table: "ReportingHistories",
                column: "NewManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportingHistories_OldManagerId",
                table: "ReportingHistories",
                column: "OldManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportingHistories_StaffId",
                table: "ReportingHistories",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DepartmentId",
                table: "Staff",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_EmploymentTypeId",
                table: "Staff",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_JobTitleId",
                table: "Staff",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_LocationId",
                table: "Staff",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_MgtCodeId",
                table: "Staff",
                column: "MgtCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_RelationshipId",
                table: "Staff",
                column: "RelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_ReportsToStaffId",
                table: "Staff",
                column: "ReportsToStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_ShiftId",
                table: "Staff",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StaffClassId",
                table: "Staff",
                column: "StaffClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StatusId",
                table: "Staff",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_VendorId",
                table: "Staff",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminationLogs_ApprovedByUserId",
                table: "TerminationLogs",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminationLogs_StaffId",
                table: "TerminationLogs",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditTrails");

            migrationBuilder.DropTable(
                name: "CompletedHoursLogs");

            migrationBuilder.DropTable(
                name: "EmployeeAllocations");

            migrationBuilder.DropTable(
                name: "EmploymentHistories");

            migrationBuilder.DropTable(
                name: "FteCommittedLogs");

            migrationBuilder.DropTable(
                name: "HolidayCalenders");

            migrationBuilder.DropTable(
                name: "ProjectAssignments");

            migrationBuilder.DropTable(
                name: "ReportingHistories");

            migrationBuilder.DropTable(
                name: "TerminationLogs");

            migrationBuilder.DropTable(
                name: "FteAllocations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProjectFteAllocations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EmploymentTypes");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "ManagementCodes");

            migrationBuilder.DropTable(
                name: "OrganizationalRelationships");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "StaffClasses");

            migrationBuilder.DropTable(
                name: "StaffStatuses");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
