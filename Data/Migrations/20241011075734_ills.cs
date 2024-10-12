using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTJobMatch.Data.Migrations
{
    public partial class ills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "role0", "7261105f-cc3c-4348-a491-619ce5f5041e", "Adminstator", "ADMINSTRATOR" },
                    { "role1", "6ff2b46b-797e-490f-a39b-a2c66b33d3ba", "Jobseeker", "JOBSEEKER" },
                    { "role2", "6f768925-7fea-430f-a448-e6da04c64ba0", "Employer", "EMPLOYER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user0", 0, "30956a96-bc57-400c-b2d3-b66ff6321f5d", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEIef57GbOaGWuRN1hvL/hYiMnZDIQS0e9O09Sz+vAyOAY8qAbHvoP6oENLO5Cf9V9A==", null, false, "8987579a-e3c4-4b60-b526-6f40f2acb146", false, "admin@gmail.com" },
                    { "user1", 0, "1dc4e43f-993a-4b6e-8845-acb0ab74e431", "jobseeker@gmail.com", true, false, null, "JOBSEEKER@GMAIL.COM", "JOBSEEKER@GMAIL.COM", "AQAAAAEAACcQAAAAEIdx8FHdcNXQ/+iB0QHoHLz3t4oKgnlMGyDsf7Tut8hXVH3508s4Oh5vViwbjMCd/w==", null, false, "9e56481d-a435-45eb-807c-bce0a27ced26", false, "jobseeker@gmail.com" },
                    { "user2", 0, "ea1a4c12-1d0e-42af-8ea5-d061a24f5400", "employer@gmail.com", true, false, null, "EMPLOYER@GMAIL.COM", "EMPLOYER@GMAIL.COM", "AQAAAAEAACcQAAAAEJ7q8Pqp9UGCAVYO2rQIlvEipECtcQiwdHdYJnBOeFjHHoJApgZr33gN2Q5RWOeCsA==", null, false, "ca1b4e99-c690-4020-af76-7fc01eb1c940", false, "employer@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "user0", "role0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "user1", "role1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "user2", "role2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "user0", "role0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "user1", "role1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "user2", "role2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2");
        }
    }
}
