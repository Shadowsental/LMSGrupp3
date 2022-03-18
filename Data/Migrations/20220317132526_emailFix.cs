using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSGrupp3.Data.Migrations
{
    public partial class emailFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "28bb29aa-f9df-435e-9453-4b2414b05e9a", 0, "85d77c50-0777-45b5-8256-d2f3959665ba", null, "Myriam_Kohler@gmail.com", false, "Barrett", "Farrell", false, null, null, null, null, null, false, "28f5bf84-2b95-4ad6-9b50-3481efecb5cd", false, null },
                    { "50b40697-5960-4fbe-865f-cd4c69682d0f", 0, "7b099e77-959c-43ae-b39a-4bca90c7c178", null, "Johnathan24@hotmail.com", false, "Benedict", "Bernier", false, null, null, null, null, null, false, "17fa1a6f-2558-4338-b09a-42a4e72de53b", false, null },
                    { "9307c606-af01-472a-9de9-fa101e4dc966", 0, "7bf8c9be-7c52-4ea0-bc2c-297c79bb6184", null, "Benton_Lemke@yahoo.com", false, "Laila", "Volkman", false, null, null, null, null, null, false, "efe31303-da56-48c7-9f37-3437baf958fe", false, null },
                    { "c47d3d54-3ee9-4409-a80f-45bd38157f6c", 0, "c1685684-fabf-4257-a0c4-5e9a7a7af16b", null, "Deangelo37@hotmail.com", false, "Wava", "Treutel", false, null, null, null, null, null, false, "c0ac9b9b-a2cf-4173-8778-9ea225eeef0f", false, null },
                    { "d3ccd8b7-982f-4c4c-8716-a60e0d73c802", 0, "c2d0a905-1031-4f60-baa1-a11c902c7038", null, "Talon.Miller93@yahoo.com", false, "Friedrich", "Rutherford", false, null, null, null, null, null, false, "61f60b7f-0403-4be7-aa51-c1fbfb9d04fc", false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28bb29aa-f9df-435e-9453-4b2414b05e9a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "50b40697-5960-4fbe-865f-cd4c69682d0f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9307c606-af01-472a-9de9-fa101e4dc966");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c47d3d54-3ee9-4409-a80f-45bd38157f6c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3ccd8b7-982f-4c4c-8716-a60e0d73c802");

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
    }
}
