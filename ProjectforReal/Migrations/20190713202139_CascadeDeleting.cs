using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectforReal.Migrations
{
    public partial class CascadeDeleting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogUserIdentity_User",
                table: "Blogs");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogUserIdentity_User",
                table: "Blogs",
                column: "User",
                principalTable: "BlogUserIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogUserIdentity_User",
                table: "Blogs");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogUserIdentity_User",
                table: "Blogs",
                column: "User",
                principalTable: "BlogUserIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
