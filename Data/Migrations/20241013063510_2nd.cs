using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTJobMatch.Data.Migrations
{
    public partial class _2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCV_CV_CVID",
                table: "JobCV");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCV_Job_JobId",
                table: "JobCV");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobCV",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CVID",
                table: "JobCV",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployerId",
                table: "Job",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Job",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApplicantId",
                table: "CV",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "CV",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role0",
                column: "ConcurrencyStamp",
                value: "d41ce586-aaf4-4433-92e5-bc0b0c2729c1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1",
                column: "ConcurrencyStamp",
                value: "d1fcc5e4-899f-453c-ab2c-2aee603f4f14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2",
                column: "ConcurrencyStamp",
                value: "6802501b-47d1-480a-a73e-24d81d9a58c8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9e04f6a-a0e5-406a-9fb3-775f15a9f4db", "AQAAAAEAACcQAAAAEBcbkPfminUkYXh5VQIpT9gyuDqXyBtGnpQj16wlEj0UPMUpCe2q+AvwzKQrMT3EFw==", "28035b3c-d8f5-43a0-9a4e-89d27be916c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8a548a6-ea1c-486b-a935-8a487f41c94c", "AQAAAAEAACcQAAAAEGCy5DhnH9Hgay85iia/PFhRjyCv2apymPH5WSnPCjDf/Nll33GsXQVzdaiAD43mbw==", "9b7abc32-1fd0-483b-b960-ec822407f444" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d72a2f3d-3a39-4d41-a107-9985a0fefba7", "AQAAAAEAACcQAAAAEJI0rv8ZpB8PVc1enmzVRIkLUcMdvbPfNfbl2uqR+okn4vDhxszH0uEOCTHvJxAw5A==", "35338a90-5f96-4c34-af4a-4eb50c830445" });

            migrationBuilder.CreateIndex(
                name: "IX_Job_EmployerId",
                table: "Job",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_CV_ApplicantId",
                table: "CV",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CV_AspNetUsers_ApplicantId",
                table: "CV",
                column: "ApplicantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_AspNetUsers_EmployerId",
                table: "Job",
                column: "EmployerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCV_CV_CVID",
                table: "JobCV",
                column: "CVID",
                principalTable: "CV",
                principalColumn: "CVID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCV_Job_JobId",
                table: "JobCV",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CV_AspNetUsers_ApplicantId",
                table: "CV");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_AspNetUsers_EmployerId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCV_CV_CVID",
                table: "JobCV");

            migrationBuilder.DropForeignKey(
                name: "FK_JobCV_Job_JobId",
                table: "JobCV");

            migrationBuilder.DropIndex(
                name: "IX_Job_EmployerId",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_CV_ApplicantId",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "CV");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "CV");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "JobCV",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CVID",
                table: "JobCV",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_JobCV_CV_CVID",
                table: "JobCV",
                column: "CVID",
                principalTable: "CV",
                principalColumn: "CVID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobCV_Job_JobId",
                table: "JobCV",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
