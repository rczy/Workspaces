using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Workspaces.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workspaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workspaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    WorkspaceId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Workspaces_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "Workspaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Leadership" },
                    { 2, "Managers" },
                    { 3, "HR" },
                    { 4, "Support" },
                    { 5, "Developers" }
                });

            migrationBuilder.InsertData(
                table: "Workspaces",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 1, 10, "10th Floor Office" },
                    { 2, 40, "Ground Floor Room" },
                    { 3, 20, "Basement" },
                    { 4, -1, "Home Office" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, "Mr. Boss", 1 },
                    { 2, "Zooroid Madshine", 1 },
                    { 3, "Bodori Hoborider", 2 },
                    { 4, "Fluffbuns Wigglesniff", 2 },
                    { 5, "Chewaboo Droopyseed", 2 },
                    { 6, "Beaniebs Boombag", 3 },
                    { 7, "Bittyitt HippyFadden", 3 },
                    { 8, "Dingspitz Woolham", 4 },
                    { 9, "Humlu Madborn", 4 },
                    { 10, "Weewax Pieham", 4 },
                    { 11, "Figman Wigglebrain", 4 },
                    { 12, "Binwee Sockhill", 5 },
                    { 13, "Beaniepants Beaniegold", 5 },
                    { 14, "Figby Madson", 5 },
                    { 15, "Jambo Messyman", 5 }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Date", "EmployeeId", "WorkspaceId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 1, 15), 1, 1 },
                    { 2, new DateOnly(2024, 1, 15), 2, 1 },
                    { 3, new DateOnly(2024, 1, 15), 3, 1 },
                    { 4, new DateOnly(2024, 1, 15), 4, 2 },
                    { 5, new DateOnly(2024, 1, 15), 5, 2 },
                    { 6, new DateOnly(2024, 1, 15), 6, 2 },
                    { 7, new DateOnly(2024, 1, 15), 7, 2 },
                    { 8, new DateOnly(2024, 1, 15), 8, 2 },
                    { 9, new DateOnly(2024, 1, 15), 9, 2 },
                    { 10, new DateOnly(2024, 1, 15), 10, 2 },
                    { 11, new DateOnly(2024, 1, 15), 11, 2 },
                    { 12, new DateOnly(2024, 1, 15), 12, 3 },
                    { 13, new DateOnly(2024, 1, 15), 13, 3 },
                    { 14, new DateOnly(2024, 1, 15), 14, 3 },
                    { 15, new DateOnly(2024, 1, 15), 15, 3 },
                    { 16, new DateOnly(2024, 1, 16), 1, 4 },
                    { 17, new DateOnly(2024, 1, 16), 2, 1 },
                    { 18, new DateOnly(2024, 1, 16), 3, 1 },
                    { 19, new DateOnly(2024, 1, 16), 4, 1 },
                    { 20, new DateOnly(2024, 1, 16), 5, 1 },
                    { 21, new DateOnly(2024, 1, 16), 6, 1 },
                    { 22, new DateOnly(2024, 1, 16), 7, 2 },
                    { 23, new DateOnly(2024, 1, 16), 8, 2 },
                    { 24, new DateOnly(2024, 1, 16), 9, 2 },
                    { 25, new DateOnly(2024, 1, 16), 10, 3 },
                    { 26, new DateOnly(2024, 1, 16), 11, 3 },
                    { 27, new DateOnly(2024, 1, 16), 12, 4 },
                    { 28, new DateOnly(2024, 1, 16), 13, 4 },
                    { 29, new DateOnly(2024, 1, 16), 14, 1 },
                    { 30, new DateOnly(2024, 1, 16), 15, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_EmployeeId_Date",
                table: "Assignments",
                columns: new[] { "EmployeeId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_WorkspaceId",
                table: "Assignments",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamId",
                table: "Employees",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Workspaces");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
