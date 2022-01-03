using Microsoft.EntityFrameworkCore.Migrations;

namespace DirectList.Migrations
{
    public partial class updatedBlogComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_BlogComments_ParentId",
                table: "BlogComments");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "BlogComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_BlogComments_ParentId",
                table: "BlogComments",
                column: "ParentId",
                principalTable: "BlogComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_BlogComments_ParentId",
                table: "BlogComments");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "BlogComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_BlogComments_ParentId",
                table: "BlogComments",
                column: "ParentId",
                principalTable: "BlogComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
