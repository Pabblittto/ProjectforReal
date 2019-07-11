using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectforReal.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogUserIdentity_BlogUserIdentityId1",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogUserIdentityId1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogUserIdentityId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogUserIdentityId1",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "BlogUserIdentityId",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BlogUserIdentityId1",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogUserIdentityId1",
                table: "Blogs",
                column: "BlogUserIdentityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogUserIdentity_BlogUserIdentityId1",
                table: "Blogs",
                column: "BlogUserIdentityId1",
                principalTable: "BlogUserIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
