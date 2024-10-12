using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTJobMatch.Data.Migrations
{
    public partial class theone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role0",
                column: "ConcurrencyStamp",
                value: "bda21360-9c8c-40eb-801b-57c7b2dcbf90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1",
                column: "ConcurrencyStamp",
                value: "8c31071b-c32d-47ed-8ab8-e5d255166bc3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2",
                column: "ConcurrencyStamp",
                value: "677dbf42-543a-490d-8451-4a8db7e8997d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09c48197-1b2e-4c9c-b92d-8a6d23b4f040", "AQAAAAEAACcQAAAAEICVNydNMN0eYBYq5CWn+EH4psl2a0/JeMVYo1jm/+9gmBzMGdpimd3/qztBbsDluA==", "f5a2b516-7884-45ae-a1e9-e230ff97d2a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "789f367e-cadc-4822-b26c-887beefae822", "AQAAAAEAACcQAAAAEAopoRrTrD5YQGcOJhMF+Ei9JZ+V2BH0fYFd7R8/wvOSp+LK+pK/AV8dCONl29MVFg==", "c53b28a2-1a1f-412a-bcda-9d38949fd304" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4fff80e-1046-4a75-b3e4-37a33eace9cd", "AQAAAAEAACcQAAAAEOlax6qxz29q28L82FdlEcj3XdQd64ymv7gkyuAT9S9wg+OdWNuwjkc4uesdziy3fw==", "abe1d638-44e5-4a91-a49b-bbfff6a8cc7c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
