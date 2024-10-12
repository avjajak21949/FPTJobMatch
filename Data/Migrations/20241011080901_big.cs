using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTJobMatch.Data.Migrations
{
    public partial class big : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role0",
                column: "ConcurrencyStamp",
                value: "1f35d497-3738-4555-8060-27af2bb71738");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1",
                column: "ConcurrencyStamp",
                value: "7dbaeef4-020b-44cb-96cf-e94d3e440270");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2",
                column: "ConcurrencyStamp",
                value: "3dc0f0e4-410c-4ce5-9056-3c3dd0ebfa19");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4ed2003-7e1d-4b3b-9c45-a2fed9e800cb", "AQAAAAEAACcQAAAAEHWGiAVeFpCSEPgCl5LZ0y5tkIwK2gh9LYoHeghZSjLvccl8XVV6vBGwC4AS8lBwrg==", "27a7692a-2614-4223-b083-dabc95fdce79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce533782-cbe8-4f0d-b4fe-0fa10cdeb729", "AQAAAAEAACcQAAAAEMrwGDY75pOjnDJV6dALvR1cOAA9BZu3f493VgEdWukbo/DsBab5UKcnl1Czslg8UA==", "6ff96216-b921-4062-8308-343383b6d701" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8183cca8-db94-48c3-8aca-025b895ecd57", "AQAAAAEAACcQAAAAEMS89VF90htRet+EJ21fm5w4jIeDtLRY1C384f2Xu44PIuL4EFPMC3bMqi7uofOPoQ==", "6ee13600-c8d3-4a80-89dc-adb7b84e9bf2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role0",
                column: "ConcurrencyStamp",
                value: "7261105f-cc3c-4348-a491-619ce5f5041e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1",
                column: "ConcurrencyStamp",
                value: "6ff2b46b-797e-490f-a39b-a2c66b33d3ba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2",
                column: "ConcurrencyStamp",
                value: "6f768925-7fea-430f-a448-e6da04c64ba0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30956a96-bc57-400c-b2d3-b66ff6321f5d", "AQAAAAEAACcQAAAAEIef57GbOaGWuRN1hvL/hYiMnZDIQS0e9O09Sz+vAyOAY8qAbHvoP6oENLO5Cf9V9A==", "8987579a-e3c4-4b60-b526-6f40f2acb146" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dc4e43f-993a-4b6e-8845-acb0ab74e431", "AQAAAAEAACcQAAAAEIdx8FHdcNXQ/+iB0QHoHLz3t4oKgnlMGyDsf7Tut8hXVH3508s4Oh5vViwbjMCd/w==", "9e56481d-a435-45eb-807c-bce0a27ced26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea1a4c12-1d0e-42af-8ea5-d061a24f5400", "AQAAAAEAACcQAAAAEJ7q8Pqp9UGCAVYO2rQIlvEipECtcQiwdHdYJnBOeFjHHoJApgZr33gN2Q5RWOeCsA==", "ca1b4e99-c690-4020-af76-7fc01eb1c940" });
        }
    }
}
