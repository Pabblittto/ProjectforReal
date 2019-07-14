using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectforReal.Migrations
{
    public partial class UserFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogUserIdentity_Blogs_BlogId",
                table: "BlogUserIdentity");

            migrationBuilder.DropIndex(
                name: "IX_BlogUserIdentity_BlogId",
                table: "BlogUserIdentity");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "BlogUserIdentity");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_User",
                table: "Blogs",
                column: "User",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogUserIdentity_User",
                table: "Blogs",
                column: "User",
                principalTable: "BlogUserIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogUserIdentity_User",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_User",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "BlogUserIdentity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogUserIdentity_BlogId",
                table: "BlogUserIdentity",
                column: "BlogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogUserIdentity_Blogs_BlogId",
                table: "BlogUserIdentity",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
