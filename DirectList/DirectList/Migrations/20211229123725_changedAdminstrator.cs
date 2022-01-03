using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectList.Migrations
{
    public partial class changedAdminstrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adminstrator_Restaurants_RestaurantId",
                table: "Adminstrator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adminstrator",
                table: "Adminstrator");

            migrationBuilder.RenameTable(
                name: "Adminstrator",
                newName: "Adminstrators");

            migrationBuilder.RenameIndex(
                name: "IX_Adminstrator_RestaurantId",
                table: "Adminstrators",
                newName: "IX_Adminstrators_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adminstrators",
                table: "Adminstrators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adminstrators_Restaurants_RestaurantId",
                table: "Adminstrators",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adminstrators_Restaurants_RestaurantId",
                table: "Adminstrators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adminstrators",
                table: "Adminstrators");

            migrationBuilder.RenameTable(
                name: "Adminstrators",
                newName: "Adminstrator");

            migrationBuilder.RenameIndex(
                name: "IX_Adminstrators_RestaurantId",
                table: "Adminstrator",
                newName: "IX_Adminstrator_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adminstrator",
                table: "Adminstrator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adminstrator_Restaurants_RestaurantId",
                table: "Adminstrator",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
