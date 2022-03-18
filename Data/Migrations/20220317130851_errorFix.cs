using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSGrupp3.Data.Migrations
{
    public partial class errorFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CourseId", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6e908768-babe-42d1-be90-7046e0017902", 0, "0836fd32-cf57-4a97-9378-4403ad79beb5", null, "Roberto.Torp@yahoo.com", false, "Kiara", "Bogisich", false, null, null, null, null, null, false, "e8a7a4d6-8908-4095-919f-672b85837007", false, null },
                    { "8410f871-a6f9-4c55-8b4e-7f532a3f1bae", 0, "bc6d28ca-440a-4943-87aa-9cf836076a76", null, "Verla89@gmail.com", false, "Heath", "Harris", false, null, null, null, null, null, false, "17337438-3250-4648-8d5a-7e48f5e2dfc8", false, null },
                    { "afb8d9a5-2332-4394-94b9-5800f5ea1153", 0, "5885211b-93c0-497d-8bc6-8961ab82a74d", null, "Lori_Morissette12@gmail.com", false, "Everett", "Douglas", false, null, null, null, null, null, false, "3f3d21ac-a9ea-4cfe-88bf-8aef6d89f055", false, null },
                    { "b35216db-26d1-4130-bd0a-e51653422043", 0, "1fdb4587-d9bf-4c98-a34c-f1cbba34d226", null, "Kara28@hotmail.com", false, "Jena", "Green", false, null, null, null, null, null, false, "95fdca39-2a3a-4c7f-a36e-eacf3f9756d6", false, null },
                    { "b67c3bc9-79cd-4930-bde3-fed3af186253", 0, "509e00b0-d79f-466e-b181-b049e37a6e6d", null, "Hayden.Braun98@hotmail.com", false, "Ralph", "Konopelski", false, null, null, null, null, null, false, "4a4b8ae2-b947-4521-8a89-92ce5860efb0", false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e908768-babe-42d1-be90-7046e0017902");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8410f871-a6f9-4c55-8b4e-7f532a3f1bae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afb8d9a5-2332-4394-94b9-5800f5ea1153");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b35216db-26d1-4130-bd0a-e51653422043");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b67c3bc9-79cd-4930-bde3-fed3af186253");

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
    }
}
