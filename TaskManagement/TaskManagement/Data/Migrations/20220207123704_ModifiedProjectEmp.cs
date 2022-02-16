using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Data.Migrations
{
    public partial class ModifiedProjectEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmp_Employee_EmployeeId",
                table: "ProjectEmp");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "ProjectEmp");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "ProjectEmp",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmp_Employee_EmployeeId",
                table: "ProjectEmp",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmp_Employee_EmployeeId",
                table: "ProjectEmp");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "ProjectEmp",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmpId",
                table: "ProjectEmp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmp_Employee_EmployeeId",
                table: "ProjectEmp",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
