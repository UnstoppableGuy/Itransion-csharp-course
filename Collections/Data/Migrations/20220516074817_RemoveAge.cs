using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionPR.Data.Migrations
{
    public partial class RemoveAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e4a2d46-337e-494e-a466-af36eb18e3e1", "3c4f784c-586e-419e-8eb4-047ebc10316c", "user", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "873cbe36-6a4d-425c-adba-ab015a4a1ecb", "8fc4ba77-e511-4905-9328-90de62e4fd6e", "super admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf2ea105-0b07-4e4e-8367-529abec7ac3b", "05c5c81a-23cb-498d-bc76-6ddd8c2308de", "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e4a2d46-337e-494e-a466-af36eb18e3e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "873cbe36-6a4d-425c-adba-ab015a4a1ecb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf2ea105-0b07-4e4e-8367-529abec7ac3b");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

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
    }
}
