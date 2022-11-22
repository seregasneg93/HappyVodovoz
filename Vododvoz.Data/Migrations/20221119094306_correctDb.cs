using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vododvoz.Data.Migrations
{
    /// <inheritdoc />
    public partial class correctDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devisions_Employees_EmployeeId",
                table: "Devisions");

            migrationBuilder.DropIndex(
                name: "IX_Devisions_EmployeeId",
                table: "Devisions");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Devisions");

            migrationBuilder.AddColumn<int>(
                name: "DevisionId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DevisionId",
                table: "Employees",
                column: "DevisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Devisions_DevisionId",
                table: "Employees",
                column: "DevisionId",
                principalTable: "Devisions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Devisions_DevisionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DevisionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DevisionId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Devisions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devisions_EmployeeId",
                table: "Devisions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devisions_Employees_EmployeeId",
                table: "Devisions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
