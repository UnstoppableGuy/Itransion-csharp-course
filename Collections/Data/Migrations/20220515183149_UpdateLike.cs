using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionPR.Data.Migrations
{
    public partial class UpdateLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_AspNetUsers_UserId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_UserId",
                table: "Like");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c6ebe1d-de52-4e88-8297-58498ebf8a82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6cd8c14-2c5a-4ce5-a1b1-7c3a2b281b2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba07f41d-0383-4967-b3f6-89da43b0851c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1062603a-9790-43d7-9db7-3b3ce53d2af0", "ff65244a-7412-4a88-a905-71fbb3d3a978", "user", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "713b8554-e714-4ab7-af86-31139d40213a", "5a97064b-833d-4aff-83f0-f24ec48248a5", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98061392-46d4-4877-af47-4e26dcd27974", "2b9b4eb9-975f-4f89-96b8-d2362500cc73", "super admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1062603a-9790-43d7-9db7-3b3ce53d2af0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "713b8554-e714-4ab7-af86-31139d40213a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98061392-46d4-4877-af47-4e26dcd27974");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c6ebe1d-de52-4e88-8297-58498ebf8a82", "6c470ec8-b20f-4354-9d2a-c9d8159c9ae4", "super admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b6cd8c14-2c5a-4ce5-a1b1-7c3a2b281b2a", "24b11301-c34a-4f40-9391-8521bc9fc9f0", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba07f41d-0383-4967-b3f6-89da43b0851c", "596f712a-67ab-4879-a92a-628458f0afc1", "user", null });

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_AspNetUsers_UserId",
                table: "Like",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
