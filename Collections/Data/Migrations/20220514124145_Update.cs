using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionPR.Data.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentWhen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c3181bb-3e0c-4b49-a1c4-ec80ebdbe721", "f8bd7756-2a27-4b6c-beb4-6163b1f853b2", "user", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa71b488-f282-435c-95bc-747f050c2d91", "8068b083-2305-4da4-ba75-29ac98930390", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f79d8a4d-f2f2-4a7f-8063-4bcc500eac9e", "f7143e2d-c8b9-4cef-9e19-c38f81382e77", "super admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c3181bb-3e0c-4b49-a1c4-ec80ebdbe721");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa71b488-f282-435c-95bc-747f050c2d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f79d8a4d-f2f2-4a7f-8063-4bcc500eac9e");
        }
    }
}
