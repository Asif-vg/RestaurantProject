using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectList.Migrations
{
    public partial class changedRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ntext",
                table: "Restaurants",
                newName: "About");

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Restaurants",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "About",
                table: "Restaurants",
                newName: "ntext");

            migrationBuilder.AlterColumn<string>(
                name: "ntext",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);
        }
    }
}
