using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSGrupp3.Data.Migrations
{
    public partial class emailErrorFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "06991b31-739b-4a8e-a284-f2c90aacbbca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "716839c0-9d9f-47ec-b553-46c5ae2575c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7efcfbfa-4d50-4011-a2bf-c7dc49a968d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0e68646-e579-47f0-afa1-05ea5774ae7b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf412391-660f-47c5-9fcd-c5333b136079");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CourseId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4514d949-3f63-40fa-a592-41526ea21b8f", 0, "df678bd8-60c2-42b9-8789-f7e83b5a7ba2", null, "Theo.Spencer@yahoo.com", false, "Berneice", "Jones", false, null, null, null, null, null, false, "403bb734-d780-46fe-bed4-6ae0063e3c73", false, null },
                    { "5888db30-a2ec-42bc-b9b5-9d5586fab98d", 0, "ba08a488-597a-4a11-b682-bbfa6b0fa505", null, "Ned_Towne@gmail.com", false, "Moshe", "Smitham", false, null, null, null, null, null, false, "e9435773-00d0-458c-9d99-3dea0b12a6b4", false, null },
                    { "633afb46-0fed-4602-bb6a-87099b7c1e51", 0, "8dbabab6-4b03-45ff-8a78-5ded6c803710", null, "Rene41@hotmail.com", false, "Faye", "Grady", false, null, null, null, null, null, false, "e54cf98b-63f5-467e-8cfe-a015d476d2a9", false, null },
                    { "7eeb7e2a-9b25-4cd3-b78e-47f3a4947b85", 0, "7c549b41-2880-48a2-be63-048e01869c90", null, "Adelle.Ebert@yahoo.com", false, "Brianne", "Collins", false, null, null, null, null, null, false, "4d34f54a-275f-4b0b-87e8-7206cd85bf8c", false, null },
                    { "cbf15935-c367-436e-8ad5-11c89aeba4e5", 0, "cadd7f32-d865-4169-8e0b-261bc86f0dee", null, "Mark.Thiel@hotmail.com", false, "Earlene", "Bartell", false, null, null, null, null, null, false, "3bf64473-d1b5-48d9-88c6-571f63e4b699", false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4514d949-3f63-40fa-a592-41526ea21b8f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5888db30-a2ec-42bc-b9b5-9d5586fab98d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "633afb46-0fed-4602-bb6a-87099b7c1e51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7eeb7e2a-9b25-4cd3-b78e-47f3a4947b85");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cbf15935-c367-436e-8ad5-11c89aeba4e5");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CourseId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "06991b31-739b-4a8e-a284-f2c90aacbbca", 0, "3895e7fe-b7ef-490a-87df-6420b397a7e6", null, null, false, "Jodie", "Heaney", false, null, null, null, null, null, false, "ac4c9d5e-0612-48dd-85db-848fbcc88a3d", false, null },
                    { "716839c0-9d9f-47ec-b553-46c5ae2575c4", 0, "75775c43-242f-46d5-9d1d-b683000f756a", null, null, false, "Gracie", "Yost", false, null, null, null, null, null, false, "0a591c5e-81dd-4601-af3a-470dc3f3e112", false, null },
                    { "7efcfbfa-4d50-4011-a2bf-c7dc49a968d4", 0, "0dbf1e33-c21f-421c-80a2-a454e46c50c3", null, null, false, "Nestor", "Ruecker", false, null, null, null, null, null, false, "c73043c0-dcee-4cde-8723-642fd6a20f0b", false, null },
                    { "a0e68646-e579-47f0-afa1-05ea5774ae7b", 0, "11251477-a197-4c3c-bbaa-cc56c9930f98", null, null, false, "Kendall", "Gottlieb", false, null, null, null, null, null, false, "722d364d-1c72-4009-8f7a-72e06b5b46f9", false, null },
                    { "cf412391-660f-47c5-9fcd-c5333b136079", 0, "b368eb00-cbd4-4de6-bdc9-66e002671ce1", null, null, false, "Harley", "Russel", false, null, null, null, null, null, false, "da417ecc-e3d3-4ded-98e5-35e068b37d8e", false, null }
                });
        }
    }
}
