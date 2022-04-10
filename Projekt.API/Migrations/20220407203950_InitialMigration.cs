using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    TimeReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Week = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.TimeReportId);
                    table.ForeignKey(
                        name: "FK_TimeReports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ProjectName" },
                values: new object[] { 1, "Bratz Dolls" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ProjectName" },
                values: new object[] { 2, "Barbie Dolls" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName", "Phone", "ProjectId" },
                values: new object[,]
                {
                    { 1, "prettyprincess@hotmail.com", "Yasmin", "Larian", "0701234567", 1 },
                    { 2, "angel@hotmail.com", "Cloe", "Santon", "0709876543", 1 },
                    { 3, "bunnyboo@hotmail.com", "Sasha", "Mason", "0729874934", 1 },
                    { 4, "koolkat@live.com", "Jade", "Hunter", "0701271244", 1 },
                    { 5, "barbie@hotmail.com", "Barbara", "Roberts", "0737485932", 2 },
                    { 6, "chrissy@hotmail.com", "Christie", "O'Neil", "0767512409", 2 }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "TimeReportId", "EmployeeId", "EndDate", "StartDate", "Week" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 1, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2022, 1, 4, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 4, 8, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 2, new DateTime(2022, 1, 5, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 2, new DateTime(2022, 1, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 7, 8, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 3, new DateTime(2022, 1, 10, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 3, new DateTime(2022, 1, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 4, new DateTime(2022, 1, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, 4, new DateTime(2022, 1, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 5, new DateTime(2022, 1, 17, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, 5, new DateTime(2022, 1, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, 5, new DateTime(2022, 1, 19, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, 5, new DateTime(2022, 1, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, 6, new DateTime(2022, 1, 18, 16, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, 6, new DateTime(2022, 1, 19, 15, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 19, 7, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 15, 6, new DateTime(2022, 1, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectId",
                table: "Employees",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_EmployeeId",
                table: "TimeReports",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
