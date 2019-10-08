using Microsoft.EntityFrameworkCore.Migrations;

namespace kendoui.Migrations
{
    public partial class MenuUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentMenuId",
                table: "Menus",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentMenuId",
                table: "Menus",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
