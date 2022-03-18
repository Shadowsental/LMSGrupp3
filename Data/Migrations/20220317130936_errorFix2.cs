using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSGrupp3.Data.Migrations
{
    public partial class errorFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "09e703d0-94b0-4c45-bd72-5d84677493e6", 0, "2388b947-5139-4e53-bc03-cbc9e81aab3f", null, "Theresa.Kerluke27@gmail.com", false, "Ashly", "Gerlach", false, null, null, null, null, null, false, "603c9e23-ce29-4b30-926d-487d61de6da0", false, null },
                    { "66dd9791-ab41-425b-b172-7a4b8d240179", 0, "82c05246-2bbf-4e0c-94f5-6f00abb9906b", null, "Emmanuelle_Abshire63@hotmail.com", false, "Triston", "Heathcote", false, null, null, null, null, null, false, "e46fab45-d5f8-4909-878e-d5bc063d9d97", false, null },
                    { "a4db891e-6640-4af4-9dfd-fe3bd0da30ab", 0, "692f83b4-6316-45e6-b8ee-a70a1baa446b", null, "Clementine_Wilkinson@hotmail.com", false, "Jamar", "Maggio", false, null, null, null, null, null, false, "f1370eee-3cb6-46a3-b3e1-7d8a6cd3d284", false, null },
                    { "a8f1ed86-3ed3-4c01-a57b-53e3075054af", 0, "c11d86eb-80fa-4f9c-8bde-1d14459e5ca3", null, "Rosalee.Weissnat@yahoo.com", false, "Dora", "Grant", false, null, null, null, null, null, false, "50f66b6b-8774-486f-a432-deccbcef8388", false, null },
                    { "cfa2691f-c011-47f1-9d9d-ccd57665cd99", 0, "bc16cce3-05a2-4cf9-958c-7ac00cb114bc", null, "Jace50@yahoo.com", false, "Shane", "Nader", false, null, null, null, null, null, false, "3b632327-299a-4762-a36f-ed006e9e5935", false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09e703d0-94b0-4c45-bd72-5d84677493e6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66dd9791-ab41-425b-b172-7a4b8d240179");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4db891e-6640-4af4-9dfd-fe3bd0da30ab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8f1ed86-3ed3-4c01-a57b-53e3075054af");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfa2691f-c011-47f1-9d9d-ccd57665cd99");

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
    }
}
