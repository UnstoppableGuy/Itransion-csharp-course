using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionPR.Data.Migrations
{
    public partial class remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55cff527-48ad-4400-a1b6-2aab3f9159ee", "a8d17970-e068-4896-8819-9cee00c65d5e", "super admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8fa8b2f0-cbde-4e32-ae94-7add4aac9601", "47f9222e-2756-4391-8761-95bec92d5dd7", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8440ca5-d0dd-48c9-8974-2e638da65253", "fc3b888e-0e67-47d5-98b8-98410030afe1", "user", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55cff527-48ad-4400-a1b6-2aab3f9159ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fa8b2f0-cbde-4e32-ae94-7add4aac9601");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8440ca5-d0dd-48c9-8974-2e638da65253");

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
    }
}
