using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectforReal.Migrations
{
    public partial class foreignKeyfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_BlogUserIdentity_OwnerId",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Tags",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_OwnerId",
                table: "Tags",
                newName: "IX_Tags_OwnerID");

            migrationBuilder.AddColumn<bool>(
                name: "PublicTag",
                table: "Tags",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_BlogUserIdentity_OwnerID",
                table: "Tags",
                column: "OwnerID",
                principalTable: "BlogUserIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_BlogUserIdentity_OwnerID",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "PublicTag",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Tags",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_OwnerID",
                table: "Tags",
                newName: "IX_Tags_OwnerId");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_BlogUserIdentity_OwnerId",
                table: "Tags",
                column: "OwnerId",
                principalTable: "BlogUserIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
