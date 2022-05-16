using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollectionPR.Data.Migrations
{
    public partial class UpdateStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "10910baf-6742-4475-b433-d4bdd59eabcf", "4fe79c4b-efbc-408d-9195-47dffb7face8", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3525e32d-1de8-48d2-b16f-cdc2b52248e1", "edaa257d-691a-488a-a70c-be76e84b44f8", "super admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49cd4664-11dd-43c1-9827-5dc84460e5be", "7b177d5e-0901-4cac-ac36-b909a3574739", "user", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10910baf-6742-4475-b433-d4bdd59eabcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3525e32d-1de8-48d2-b16f-cdc2b52248e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49cd4664-11dd-43c1-9827-5dc84460e5be");

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
    }
}
