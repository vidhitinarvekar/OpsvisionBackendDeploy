using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpsVision_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemovedForeignKeyPrimeCodeEmpAllocationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            //migrationBuilder.DropForeignKey(
              //  name: "FK_ProjectAssignments_Projects_PrimeCode",
                //table: "ProjectAssignments");

            //migrationBuilder.DropForeignKey(
              //  name: "FK_ProjectFteAllocations_Projects_PrimeCode",
                //table: "ProjectFteAllocations");

            //migrationBuilder.DropUniqueConstraint(
              //  name: "AK_Projects_PrimeCode",
                //table: "Projects");

            //migrationBuilder.DropIndex(
              //  name: "IX_Projects_PrimeCode",
                //table: "Projects");

           // migrationBuilder.DropIndex(
             //   name: "IX_ProjectFteAllocations_PrimeCode",
               // table: "ProjectFteAllocations");

           // migrationBuilder.DropIndex(
             //   name: "IX_ProjectAssignments_PrimeCode",
               // table: "ProjectAssignments");

            //migrationBuilder.DropIndex(
              //  name: "IX_EmployeeAllocations_PrimeCode",
                //table: "EmployeeAllocations");

           // migrationBuilder.DropColumn(
             //   name: "PrimeCode",
               // table: "ProjectFteAllocations");

            //migrationBuilder.DropColumn(
              //  name: "PrimeCode",
                //table: "ProjectAssignments");

            //migrationBuilder.DropColumn(
              //  name: "PrimeCode",
                //table: "FteAllocations");

           // migrationBuilder.DropColumn(
             //   name: "PrimeCode",
               // table: "EmployeeAllocations");

            migrationBuilder.AlterColumn<string>(
                name: "PrimeCode",
                table: "Projects",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

           // migrationBuilder.AddColumn<int>(
             //   name: "ProjectId",
               // table: "ProjectFteAllocations",
                //type: "int",
                //nullable: false,
                //defaultValue: 0);

           // migrationBuilder.AddColumn<int>(
             //   name: "ProjectId",
               // table: "ProjectAssignments",
           //     type: "int",
             //   nullable: false,
               // defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "CommittedHours",
                table: "FteAllocations",
                type: "decimal(65,30)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

     //       migrationBuilder.AddColumn<int>(
       //         name: "ProjectId",
         //       table: "FteAllocations",
           //     type: "int",
             //   nullable: false,
               // defaultValue: 0);

   //         migrationBuilder.AddColumn<int>(
     //           name: "ProjectId",
       //         table: "EmployeeAllocations",
         //       type: "int",
           //     nullable: false,
             //   defaultValue: 0);

   //         migrationBuilder.CreateIndex(
     //           name: "IX_ProjectFteAllocations_ProjectId",
       //         table: "ProjectFteAllocations",
         //       column: "ProjectId");

    //        migrationBuilder.CreateIndex(
      //          name: "IX_ProjectAssignments_ProjectId",
        //        table: "ProjectAssignments",
          //      column: "ProjectId");

     //       migrationBuilder.CreateIndex(
       //         name: "IX_FteAllocations_ProjectId",
         //       table: "FteAllocations",
           //     column: "ProjectId");

       //     migrationBuilder.CreateIndex(
         //       name: "IX_EmployeeAllocations_ProjectId",
           //     table: "EmployeeAllocations",
             //   column: "ProjectId");

  //          migrationBuilder.AddForeignKey(
    //            name: "FK_EmployeeAllocations_Projects_ProjectId",
      //          table: "EmployeeAllocations",
        //        column: "ProjectId",
          //      principalTable: "Projects",
            //    principalColumn: "ProjectId",
              //  onDelete: ReferentialAction.Restrict);

   //         migrationBuilder.AddForeignKey(
     //           name: "FK_FteAllocations_Projects_ProjectId",
       //         table: "FteAllocations",
         //       column: "ProjectId",
           //     principalTable: "Projects",
             //   principalColumn: "ProjectId",
               // onDelete: ReferentialAction.Cascade);

  //          migrationBuilder.AddForeignKey(
    //            name: "FK_ProjectAssignments_Projects_ProjectId",
      //          table: "ProjectAssignments",
        //        column: "ProjectId",
          //      principalTable: "Projects",
            //    principalColumn: "ProjectId",
              //  onDelete: ReferentialAction.Restrict);

  //          migrationBuilder.AddForeignKey(
    //            name: "FK_ProjectFteAllocations_Projects_ProjectId",
      //          table: "ProjectFteAllocations",
        //        column: "ProjectId",
          //      principalTable: "Projects",
            //    principalColumn: "ProjectId",
              //  onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAllocations_Projects_ProjectId",
                table: "EmployeeAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_FteAllocations_Projects_ProjectId",
                table: "FteAllocations");

      //      migrationBuilder.DropForeignKey(
        //        name: "FK_ProjectAssignments_Projects_ProjectId",
          //      table: "ProjectAssignments");

   //         migrationBuilder.DropForeignKey(
     //           name: "FK_ProjectFteAllocations_Projects_ProjectId",
       //         table: "ProjectFteAllocations");

            migrationBuilder.DropIndex(
                name: "IX_ProjectFteAllocations_ProjectId",
                table: "ProjectFteAllocations");

        //    migrationBuilder.DropIndex(
          //      name: "IX_ProjectAssignments_ProjectId",
            //    table: "ProjectAssignments");

      //      migrationBuilder.DropIndex(
        //        name: "IX_FteAllocations_ProjectId",
          //      table: "FteAllocations");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAllocations_ProjectId",
                table: "EmployeeAllocations");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectFteAllocations");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectAssignments");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "FteAllocations");

      //      migrationBuilder.DropColumn(
        //        name: "ProjectId",
          //      table: "EmployeeAllocations");

            migrationBuilder.AlterColumn<string>(
                name: "PrimeCode",
                table: "Projects",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PrimeCode",
                table: "ProjectFteAllocations",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PrimeCode",
                table: "ProjectAssignments",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CommittedHours",
                table: "FteAllocations",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimeCode",
                table: "FteAllocations",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PrimeCode",
                table: "EmployeeAllocations",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Projects_PrimeCode",
                table: "Projects",
                column: "PrimeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PrimeCode",
                table: "Projects",
                column: "PrimeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFteAllocations_PrimeCode",
                table: "ProjectFteAllocations",
                column: "PrimeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignments_PrimeCode",
                table: "ProjectAssignments",
                column: "PrimeCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAllocations_PrimeCode",
                table: "EmployeeAllocations",
                column: "PrimeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAllocations_Projects_PrimeCode",
                table: "EmployeeAllocations",
                column: "PrimeCode",
                principalTable: "Projects",
                principalColumn: "PrimeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAssignments_Projects_PrimeCode",
                table: "ProjectAssignments",
                column: "PrimeCode",
                principalTable: "Projects",
                principalColumn: "PrimeCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFteAllocations_Projects_PrimeCode",
                table: "ProjectFteAllocations",
                column: "PrimeCode",
                principalTable: "Projects",
                principalColumn: "PrimeCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
