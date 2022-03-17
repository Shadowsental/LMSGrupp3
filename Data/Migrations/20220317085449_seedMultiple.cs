using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSGrupp3.Data.Migrations
{
    public partial class seedMultiple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8fe5ecac-446d-4e79-af2b-e0d3f4845876");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0b754a61-94dc-448f-a51f-28d5229c5c9d", 0, new DateTime(2021, 11, 29, 16, 31, 35, 636, DateTimeKind.Local).AddTicks(5411), "ff793665-c93f-420a-97b6-2cdcc6a5b98d", "Lenore.Mohr65@gmail.com", false, false, null, "Clovis Franecki", null, null, null, null, false, "0f950afc-5f2c-4634-8b60-527d2ceed95a", false, null },
                    { "19656612-3981-4c41-8092-233f9b8bf345", 0, new DateTime(2021, 8, 8, 5, 2, 24, 491, DateTimeKind.Local).AddTicks(7962), "7bece49a-d3c3-4305-a612-ac401816c582", "Derek.Rowe@gmail.com", false, false, null, "Anissa Kessler", null, null, null, null, false, "3bbd4b5e-3d1d-48bd-a226-861395507b21", false, null },
                    { "33ffe7e1-d9e5-454d-9380-5a9b14e0d16d", 0, new DateTime(2021, 4, 21, 15, 50, 9, 342, DateTimeKind.Local).AddTicks(972), "f4e809b8-d122-4247-84f0-fa08edcaf6a0", "Adaline_Labadie88@yahoo.com", false, false, null, "Garnett Kub", null, null, null, null, false, "0fa7ab3f-0816-418b-95b8-0a8915b8b579", false, null },
                    { "3cd46bb2-1bdb-442f-b779-88944da71d8e", 0, new DateTime(2021, 7, 11, 11, 6, 57, 588, DateTimeKind.Local).AddTicks(3522), "4b26c9a3-cf6b-43a2-8e84-9fa7994b45d5", "Hobart13@gmail.com", false, false, null, "Jaeden Gerlach", null, null, null, null, false, "1569684e-dd51-4c8d-8d1f-73329448d343", false, null },
                    { "5819f250-51fc-4f82-afbe-950a5096d567", 0, new DateTime(2022, 3, 5, 7, 47, 34, 387, DateTimeKind.Local).AddTicks(1314), "f16d64bb-4a96-44cb-b9e0-6c7a07e267dc", "Gladys15@yahoo.com", false, false, null, "Abraham Harris", null, null, null, null, false, "bee99b45-e32b-4fc5-ad8a-01bc52779574", false, null },
                    { "87bc8151-9fa3-4c89-a241-1d3eb5318e35", 0, new DateTime(2021, 4, 10, 16, 0, 38, 601, DateTimeKind.Local).AddTicks(7084), "cacd3d1a-6d01-4d1f-8646-c77c44078773", "Jolie19@hotmail.com", false, false, null, "Doug Purdy", null, null, null, null, false, "8825b3bd-dcb5-4d17-a101-1a1e2718480b", false, null },
                    { "a6334ea1-6e6e-4e5e-bd29-2b37a1d2154f", 0, new DateTime(2021, 5, 4, 3, 36, 20, 328, DateTimeKind.Local).AddTicks(2081), "dc1a0252-0a8c-4306-9303-ff0025e94185", "Elta1@hotmail.com", false, false, null, "Eusebio Bogan", null, null, null, null, false, "696ef932-0ee9-417a-84f7-5177685a96ee", false, null },
                    { "d305260d-85fb-4e01-8f46-1454e8c2d5b7", 0, new DateTime(2021, 12, 27, 19, 24, 40, 692, DateTimeKind.Local).AddTicks(2823), "6bad990f-a178-460e-8b92-20c1650c364f", "Lavon.Welch@hotmail.com", false, false, null, "Josie Zieme", null, null, null, null, false, "619607eb-791d-4b51-abf1-c39bdbf98872", false, null },
                    { "da534f4e-1aad-4dc9-ab8e-ca68bb91584c", 0, new DateTime(2021, 7, 14, 2, 48, 3, 809, DateTimeKind.Local).AddTicks(5474), "11c74497-fdba-4d28-b62d-16ed8bc805a0", "Michale_Ratke@gmail.com", false, false, null, "Clair Jakubowski", null, null, null, null, false, "f5aad4fa-7e9e-4096-89f6-29918b079514", false, null },
                    { "ede7182b-6261-4ec3-b29d-347aa14c85fa", 0, new DateTime(2022, 2, 13, 6, 11, 21, 620, DateTimeKind.Local).AddTicks(5454), "4a0f5c41-7580-4a87-825a-e1fc17d3472f", "Sheila.Cremin@yahoo.com", false, false, null, "Zoie Labadie", null, null, null, null, false, "44aa3159-423a-43d1-9c7b-ceb6797bfd20", false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b754a61-94dc-448f-a51f-28d5229c5c9d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19656612-3981-4c41-8092-233f9b8bf345");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33ffe7e1-d9e5-454d-9380-5a9b14e0d16d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cd46bb2-1bdb-442f-b779-88944da71d8e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5819f250-51fc-4f82-afbe-950a5096d567");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87bc8151-9fa3-4c89-a241-1d3eb5318e35");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a6334ea1-6e6e-4e5e-bd29-2b37a1d2154f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d305260d-85fb-4e01-8f46-1454e8c2d5b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da534f4e-1aad-4dc9-ab8e-ca68bb91584c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ede7182b-6261-4ec3-b29d-347aa14c85fa");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8fe5ecac-446d-4e79-af2b-e0d3f4845876", 0, new DateTime(2021, 12, 12, 11, 13, 54, 87, DateTimeKind.Local).AddTicks(7905), "6f7e1184-c00a-41c6-9d11-602ef9497d38", "Roselyn0@yahoo.com", false, false, null, "Jacquelyn Schimmel", null, null, null, null, false, "38692d21-4886-4e75-8330-f0c47731be5c", false, null });
        }
    }
}
