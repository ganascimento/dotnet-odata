using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PockOData.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    District = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchoolId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRoom_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SchoolYear = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subject = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClassRoomId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "City", "District", "Name", "State", "Street" },
                values: new object[,]
                {
                    { new Guid("6c96d428-7619-4d59-a30d-d7547857be36"), "Enidstad", "Kleinburgh", "Parker Stroman", "Hawaii", "Dayana Mall" },
                    { new Guid("91d898c4-f9d1-4a39-8775-9c7822a53daf"), "Thielland", "Lake Bessie", "Fermin Herzog", "Virginia", "Maggio Street" },
                    { new Guid("b89b9c5e-ef4e-4b4c-8002-ea8e0654e5b4"), "Gloverville", "South Juvenalland", "Carmela Renner", "Vermont", "Jeanie Crossroad" },
                    { new Guid("d464aaae-aeb6-4e87-8b74-3b9346baee6d"), "Collinsstad", "Matildafurt", "Hardy Feest", "Illinois", "Loma Streets" }
                });

            migrationBuilder.InsertData(
                table: "ClassRoom",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[,]
                {
                    { new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Room 8", new Guid("6c96d428-7619-4d59-a30d-d7547857be36") },
                    { new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Room 8", new Guid("d464aaae-aeb6-4e87-8b74-3b9346baee6d") },
                    { new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Room 19", new Guid("91d898c4-f9d1-4a39-8775-9c7822a53daf") },
                    { new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Room 11", new Guid("91d898c4-f9d1-4a39-8775-9c7822a53daf") },
                    { new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Room 9", new Guid("b89b9c5e-ef4e-4b4c-8002-ea8e0654e5b4") },
                    { new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Room 16", new Guid("b89b9c5e-ef4e-4b4c-8002-ea8e0654e5b4") },
                    { new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Room 9", new Guid("d464aaae-aeb6-4e87-8b74-3b9346baee6d") },
                    { new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Room 14", new Guid("6c96d428-7619-4d59-a30d-d7547857be36") },
                    { new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Room 9", new Guid("6c96d428-7619-4d59-a30d-d7547857be36") },
                    { new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Room 16", new Guid("b89b9c5e-ef4e-4b4c-8002-ea8e0654e5b4") },
                    { new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Room 18", new Guid("91d898c4-f9d1-4a39-8775-9c7822a53daf") },
                    { new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Room 8", new Guid("d464aaae-aeb6-4e87-8b74-3b9346baee6d") }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "BirthDate", "ClassRoomId", "Name", "SchoolYear" },
                values: new object[,]
                {
                    { new Guid("00e509bd-c077-48fe-aeba-e7aafa282076"), new DateTime(2010, 4, 24, 2, 6, 21, 913, DateTimeKind.Unspecified).AddTicks(4867), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Glen Hodkiewicz", 6 },
                    { new Guid("0166c22d-49f6-407b-8282-514649426791"), new DateTime(2019, 6, 20, 0, 37, 12, 278, DateTimeKind.Unspecified).AddTicks(5772), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Magdalena Macejkovic", 5 },
                    { new Guid("024436ea-1688-4a99-ab70-61a19237e23a"), new DateTime(2016, 8, 20, 4, 38, 20, 348, DateTimeKind.Unspecified).AddTicks(1740), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Marquise Lesch", 4 },
                    { new Guid("02e7c6d1-ea3f-4780-8bb3-280f26372b84"), new DateTime(2019, 7, 24, 2, 30, 57, 763, DateTimeKind.Unspecified).AddTicks(4491), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Orval Jacobs", 5 },
                    { new Guid("03fceb36-acad-4066-b904-5b3752353c6f"), new DateTime(2012, 4, 30, 5, 48, 32, 516, DateTimeKind.Unspecified).AddTicks(698), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Dominic Prohaska", 3 },
                    { new Guid("05f94305-b784-40a4-b282-ec33fe31c3fa"), new DateTime(2010, 12, 3, 7, 53, 31, 222, DateTimeKind.Unspecified).AddTicks(6329), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Karolann Orn", 4 },
                    { new Guid("06131dc4-3417-4035-aed1-7388e94e695b"), new DateTime(2017, 4, 1, 14, 22, 25, 833, DateTimeKind.Unspecified).AddTicks(3336), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Maribel Romaguera", 7 },
                    { new Guid("074d79f9-7092-423f-a753-3383c18f0fef"), new DateTime(2021, 9, 12, 22, 11, 4, 360, DateTimeKind.Unspecified).AddTicks(8850), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Merritt Ondricka", 5 },
                    { new Guid("078fc96e-e18a-4224-b4e2-82a53c1e3d53"), new DateTime(2010, 1, 16, 16, 15, 19, 664, DateTimeKind.Unspecified).AddTicks(6001), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Oma O'Kon", 3 },
                    { new Guid("08b99fce-24d8-4629-bb6a-f9d54d6b6e01"), new DateTime(2018, 9, 12, 14, 38, 13, 455, DateTimeKind.Unspecified).AddTicks(1852), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Liana Dibbert", 3 },
                    { new Guid("09e743cd-0d96-4827-b957-27f1fdf87198"), new DateTime(2020, 12, 26, 5, 51, 14, 831, DateTimeKind.Unspecified).AddTicks(4217), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Rudolph Grady", 4 },
                    { new Guid("0b3428e3-07cd-47e9-9274-31a4bf614344"), new DateTime(2018, 1, 19, 15, 46, 41, 849, DateTimeKind.Unspecified).AddTicks(3842), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Alejandra Batz", 6 },
                    { new Guid("0b6b1cb2-10eb-4140-b2c7-c69c2b697647"), new DateTime(2015, 2, 6, 0, 16, 8, 141, DateTimeKind.Unspecified).AddTicks(1791), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Pauline Botsford", 8 },
                    { new Guid("0d1ad94c-97eb-4105-8299-9e12b635ad28"), new DateTime(2014, 3, 9, 1, 6, 47, 15, DateTimeKind.Unspecified).AddTicks(3504), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Kenya Beahan", 1 },
                    { new Guid("0d2111b8-136f-4c60-a5bd-ff88c61c2fb9"), new DateTime(2014, 9, 10, 4, 17, 8, 443, DateTimeKind.Unspecified).AddTicks(8946), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Cordia Schimmel", 3 },
                    { new Guid("0d87c822-d589-41f8-bbba-53f508871cc9"), new DateTime(2021, 9, 20, 4, 50, 22, 313, DateTimeKind.Unspecified).AddTicks(7686), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Ashlynn Kuhic", 9 },
                    { new Guid("0e3e30c7-e40a-43f8-8f05-b1effa04495d"), new DateTime(2012, 10, 3, 10, 54, 36, 362, DateTimeKind.Unspecified).AddTicks(6156), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Tommie Breitenberg", 4 },
                    { new Guid("0e9684ea-d293-484c-a7a0-c61e741c149e"), new DateTime(2014, 5, 7, 12, 3, 20, 752, DateTimeKind.Unspecified).AddTicks(5521), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Kayden Abshire", 2 },
                    { new Guid("138ac750-6d44-491e-a833-2060c16d9880"), new DateTime(2014, 10, 23, 22, 21, 9, 61, DateTimeKind.Unspecified).AddTicks(2536), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Zelda McLaughlin", 6 },
                    { new Guid("146993f4-fa19-46ee-83a4-a9fadb1147d7"), new DateTime(2015, 8, 30, 2, 12, 55, 397, DateTimeKind.Unspecified).AddTicks(6787), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Agustina Kohler", 3 },
                    { new Guid("14a30822-e33c-40ec-9db2-27a0121eebbd"), new DateTime(2013, 7, 28, 17, 21, 3, 927, DateTimeKind.Unspecified).AddTicks(4417), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Nathen Osinski", 6 },
                    { new Guid("150a726b-7486-40fc-ae1f-492099ddbb74"), new DateTime(2013, 5, 10, 7, 57, 25, 778, DateTimeKind.Unspecified).AddTicks(200), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Clemens Kulas", 4 },
                    { new Guid("1689de64-6d64-4b9d-92df-54b34de39c3b"), new DateTime(2016, 7, 25, 6, 5, 58, 121, DateTimeKind.Unspecified).AddTicks(8115), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Monserrate Balistreri", 3 },
                    { new Guid("16d08e57-b1d9-46d9-9a88-28a0878f916c"), new DateTime(2012, 6, 4, 19, 34, 40, 747, DateTimeKind.Unspecified).AddTicks(9313), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Maggie Walsh", 9 },
                    { new Guid("192098ed-af58-4066-87b1-951f6bcac6d6"), new DateTime(2016, 12, 30, 16, 44, 10, 450, DateTimeKind.Unspecified).AddTicks(5291), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Isidro Stracke", 2 },
                    { new Guid("1c64ba61-ed60-4e5e-85f1-aa711bb592c3"), new DateTime(2010, 1, 31, 17, 32, 49, 126, DateTimeKind.Unspecified).AddTicks(154), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Vicky Haag", 4 },
                    { new Guid("23e94422-0eda-4e0c-8b25-8c126b1f6ef7"), new DateTime(2021, 4, 16, 17, 10, 1, 616, DateTimeKind.Unspecified).AddTicks(9838), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Lorine Bashirian", 3 },
                    { new Guid("23fa0dfe-57db-413f-b511-39ebaa4c2656"), new DateTime(2014, 11, 5, 13, 45, 56, 577, DateTimeKind.Unspecified).AddTicks(7295), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Fredrick Jacobi", 7 },
                    { new Guid("2467e888-c1b8-4513-965b-b6bf953b336b"), new DateTime(2021, 8, 30, 15, 35, 18, 94, DateTimeKind.Unspecified).AddTicks(4016), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Mariela Kuhic", 8 },
                    { new Guid("24a50ec6-7c3c-4e4f-a4fd-87939666c7c9"), new DateTime(2014, 4, 20, 1, 35, 48, 123, DateTimeKind.Unspecified).AddTicks(3594), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Marcel Daugherty", 2 },
                    { new Guid("2727c8eb-04a8-4341-b18b-022843f21a08"), new DateTime(2013, 8, 7, 14, 37, 54, 932, DateTimeKind.Unspecified).AddTicks(8134), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Isaias Shields", 6 },
                    { new Guid("2841a1b6-b6a5-493e-9361-4e5efb7c1ea0"), new DateTime(2018, 1, 26, 16, 9, 19, 645, DateTimeKind.Unspecified).AddTicks(4812), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Torey Denesik", 4 },
                    { new Guid("28fc36d1-88a7-4481-8fa5-c1a8a7257b45"), new DateTime(2013, 9, 24, 17, 37, 13, 697, DateTimeKind.Unspecified).AddTicks(2881), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Orland Schultz", 7 },
                    { new Guid("291b563b-f0ce-4bc0-accc-ee9cc8914aab"), new DateTime(2021, 1, 18, 6, 6, 43, 785, DateTimeKind.Unspecified).AddTicks(1207), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Layne Halvorson", 7 },
                    { new Guid("293531fe-cdad-401b-9bf3-cc3efd780cfd"), new DateTime(2022, 1, 11, 16, 41, 5, 668, DateTimeKind.Unspecified).AddTicks(3966), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Alyson Steuber", 1 },
                    { new Guid("2b3718af-0bba-40bf-8aaf-899f04c3c35a"), new DateTime(2014, 8, 17, 20, 5, 40, 359, DateTimeKind.Unspecified).AddTicks(920), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Sasha Hills", 7 },
                    { new Guid("2c4d6912-9889-49e0-8782-a26e1edc945f"), new DateTime(2012, 3, 23, 23, 58, 52, 262, DateTimeKind.Unspecified).AddTicks(8788), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Kraig Hodkiewicz", 8 },
                    { new Guid("2dc71291-e7b6-495a-b844-cd9ec33310bf"), new DateTime(2017, 2, 21, 23, 27, 30, 187, DateTimeKind.Unspecified).AddTicks(4200), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Gianni Bergstrom", 2 },
                    { new Guid("2e0dcb91-f112-4c41-a3f5-6465d9b78c4b"), new DateTime(2021, 2, 9, 23, 47, 20, 426, DateTimeKind.Unspecified).AddTicks(5630), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Neoma Lang", 9 },
                    { new Guid("2e4bd4bf-9530-4620-b014-2f5dfa2c548f"), new DateTime(2021, 3, 7, 3, 10, 45, 783, DateTimeKind.Unspecified).AddTicks(8253), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Garnett Powlowski", 9 },
                    { new Guid("2edef137-524e-491b-b5ac-5546252d0d75"), new DateTime(2022, 5, 11, 20, 28, 27, 534, DateTimeKind.Unspecified).AddTicks(4301), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Araceli Stiedemann", 9 },
                    { new Guid("2ff5970e-12f0-46a6-8157-d946ae350194"), new DateTime(2019, 10, 20, 13, 49, 46, 932, DateTimeKind.Unspecified).AddTicks(3476), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Tremayne Legros", 8 },
                    { new Guid("30c4b22f-8998-4795-95f2-d3643be88b9f"), new DateTime(2017, 3, 1, 19, 28, 22, 794, DateTimeKind.Unspecified).AddTicks(1206), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Josefa Muller", 8 },
                    { new Guid("31c50e38-58f9-43eb-ac5e-1c48269b21d0"), new DateTime(2021, 2, 28, 2, 0, 1, 737, DateTimeKind.Unspecified).AddTicks(7968), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Magnus Wiza", 6 },
                    { new Guid("326ce84e-e27a-426f-ab6d-fa14fd236b10"), new DateTime(2016, 3, 24, 15, 29, 40, 445, DateTimeKind.Unspecified).AddTicks(9030), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Meda Maggio", 8 },
                    { new Guid("341b9c86-07bb-4af8-9186-c3b4a0a82d5d"), new DateTime(2021, 10, 27, 14, 15, 0, 802, DateTimeKind.Unspecified).AddTicks(2504), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Dedric Hansen", 8 },
                    { new Guid("34615ac0-4310-487d-9c9a-bc40458f1ce2"), new DateTime(2019, 7, 15, 4, 41, 28, 91, DateTimeKind.Unspecified).AddTicks(8140), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Meagan Beatty", 6 },
                    { new Guid("37c6ea56-16c8-4eaf-b337-271830cbbbdc"), new DateTime(2021, 10, 18, 20, 9, 37, 82, DateTimeKind.Unspecified).AddTicks(8734), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Juanita Doyle", 8 },
                    { new Guid("37fbb269-a12c-4c3e-a78c-4fb8d797242c"), new DateTime(2021, 8, 5, 19, 39, 53, 978, DateTimeKind.Unspecified).AddTicks(8053), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Isabell Swaniawski", 2 },
                    { new Guid("39ebc2eb-9dad-4864-8b10-7b47339dd91a"), new DateTime(2015, 3, 11, 14, 56, 11, 71, DateTimeKind.Unspecified).AddTicks(2194), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Audrey Trantow", 7 },
                    { new Guid("3d4fffad-565a-4d6f-90c5-388987451c8a"), new DateTime(2012, 2, 4, 20, 4, 24, 292, DateTimeKind.Unspecified).AddTicks(2178), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Abagail Kunze", 4 },
                    { new Guid("3e8359c7-0f73-4256-87cf-749a5e32b2e7"), new DateTime(2019, 7, 29, 17, 55, 23, 270, DateTimeKind.Unspecified).AddTicks(1939), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Emile Effertz", 2 },
                    { new Guid("3f4c12dc-a7d3-4713-a290-7046eee26ef7"), new DateTime(2012, 2, 7, 20, 43, 15, 71, DateTimeKind.Unspecified).AddTicks(8111), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Jeramy Zemlak", 9 },
                    { new Guid("4061d4f4-e18f-4f59-b96c-be8db6ff63f8"), new DateTime(2017, 11, 29, 3, 56, 11, 452, DateTimeKind.Unspecified).AddTicks(5234), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Nicola McCullough", 9 },
                    { new Guid("40a3f9c6-0194-4fb2-b004-2daa260629f3"), new DateTime(2019, 3, 3, 14, 48, 0, 481, DateTimeKind.Unspecified).AddTicks(4380), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Hanna Schulist", 8 },
                    { new Guid("425c8ea6-168c-4453-b1db-cbb445900136"), new DateTime(2017, 4, 20, 2, 14, 29, 440, DateTimeKind.Unspecified).AddTicks(8416), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Jailyn Block", 2 },
                    { new Guid("432f1715-80f3-4f04-80ec-a5f9daddbef4"), new DateTime(2014, 11, 18, 23, 2, 51, 291, DateTimeKind.Unspecified).AddTicks(3828), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Bud Pacocha", 2 },
                    { new Guid("43d57ca7-3909-44ed-8f43-c748a8b9b039"), new DateTime(2017, 12, 8, 5, 55, 13, 402, DateTimeKind.Unspecified).AddTicks(6448), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Margret Bins", 6 },
                    { new Guid("440e85ee-db45-4b22-b20a-b52838c34961"), new DateTime(2012, 12, 23, 14, 57, 46, 67, DateTimeKind.Unspecified).AddTicks(4676), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Loyal Gislason", 4 },
                    { new Guid("4466222b-f5da-4ac9-9fbd-02345897fa61"), new DateTime(2021, 1, 11, 22, 58, 30, 808, DateTimeKind.Unspecified).AddTicks(5566), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Haleigh Moore", 4 },
                    { new Guid("44f8d29f-f563-4cae-a0e1-9db93aa9925a"), new DateTime(2016, 8, 3, 19, 21, 44, 488, DateTimeKind.Unspecified).AddTicks(3575), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Chadrick Abernathy", 4 },
                    { new Guid("4883354e-e26b-466e-a731-f7d868de4527"), new DateTime(2022, 4, 15, 17, 53, 24, 318, DateTimeKind.Unspecified).AddTicks(6714), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Lonzo Hermiston", 4 },
                    { new Guid("49773375-bbfa-44cf-883a-a4dcb6deac14"), new DateTime(2016, 5, 29, 4, 6, 3, 359, DateTimeKind.Unspecified).AddTicks(1180), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Roma Towne", 2 },
                    { new Guid("49abe479-b7f3-4ffc-9ea0-1f35c5ab9f3e"), new DateTime(2022, 4, 14, 22, 27, 36, 286, DateTimeKind.Unspecified).AddTicks(3958), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Helmer O'Hara", 2 },
                    { new Guid("49ee9315-ad94-4f04-a07b-ac9a9fda6d35"), new DateTime(2021, 1, 5, 15, 43, 58, 89, DateTimeKind.Unspecified).AddTicks(900), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Astrid Streich", 2 },
                    { new Guid("4a1aaf58-66e6-45cf-9ca9-13a7a5168c32"), new DateTime(2019, 11, 26, 11, 31, 31, 13, DateTimeKind.Unspecified).AddTicks(6988), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Marcelino Kuhn", 6 },
                    { new Guid("4a84d71b-31f7-4921-bbc2-5c3ea02e52cf"), new DateTime(2018, 4, 7, 19, 13, 22, 321, DateTimeKind.Unspecified).AddTicks(6378), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Vallie Blanda", 1 },
                    { new Guid("4be7bb64-13fc-4a84-b0f8-c8cfda24e29c"), new DateTime(2015, 6, 4, 8, 21, 18, 736, DateTimeKind.Unspecified).AddTicks(4646), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Jairo Littel", 4 },
                    { new Guid("4cea2c3f-0cd7-4932-8793-93714f633e75"), new DateTime(2017, 9, 3, 15, 18, 34, 219, DateTimeKind.Unspecified).AddTicks(4440), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Chad Thompson", 1 },
                    { new Guid("4d42476e-3d8f-4876-aa13-1257aa2a8e58"), new DateTime(2014, 8, 28, 14, 35, 31, 822, DateTimeKind.Unspecified).AddTicks(3383), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Kyler Waelchi", 2 },
                    { new Guid("4d541003-0815-458c-b8ec-ab68a1a15d27"), new DateTime(2020, 6, 18, 17, 11, 17, 888, DateTimeKind.Unspecified).AddTicks(9525), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Jessie Terry", 2 },
                    { new Guid("4d90cbec-1c79-4ee9-94f4-cc9fa0e1fafb"), new DateTime(2013, 7, 9, 19, 42, 29, 913, DateTimeKind.Unspecified).AddTicks(9315), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Lexie Dickens", 8 },
                    { new Guid("4f4dd93f-f2e2-41de-bf6c-07b0f76b2339"), new DateTime(2013, 9, 23, 14, 51, 50, 969, DateTimeKind.Unspecified).AddTicks(7728), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Daniela Champlin", 4 },
                    { new Guid("5209535e-3034-4035-8fb4-d32805fd9c8f"), new DateTime(2014, 6, 21, 22, 56, 8, 388, DateTimeKind.Unspecified).AddTicks(6542), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Elmira Ortiz", 6 },
                    { new Guid("526c9bdb-4c89-4309-ba9b-29abfa23f567"), new DateTime(2021, 2, 20, 23, 5, 50, 53, DateTimeKind.Unspecified).AddTicks(626), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Jamie Ankunding", 9 },
                    { new Guid("533d9772-7f21-4804-a2a2-7a5369d63fcd"), new DateTime(2020, 3, 12, 23, 28, 3, 657, DateTimeKind.Unspecified).AddTicks(8355), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Ryley Hartmann", 9 },
                    { new Guid("53dbb340-9461-4191-9d60-449f91391e23"), new DateTime(2020, 10, 10, 4, 2, 39, 373, DateTimeKind.Unspecified).AddTicks(2186), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Glen Kreiger", 2 },
                    { new Guid("5468d61b-07cc-42b7-ac56-5927e8767a41"), new DateTime(2015, 2, 11, 23, 46, 56, 293, DateTimeKind.Unspecified).AddTicks(1376), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Corrine Von", 3 },
                    { new Guid("552bbc57-c3d5-46a9-85b2-695234c8002d"), new DateTime(2022, 6, 12, 13, 39, 59, 471, DateTimeKind.Unspecified).AddTicks(6584), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Lauryn Bechtelar", 3 },
                    { new Guid("55567372-87e2-4c56-98bb-adc7368edb1a"), new DateTime(2021, 12, 4, 17, 51, 5, 411, DateTimeKind.Unspecified).AddTicks(6411), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Raegan Terry", 9 },
                    { new Guid("55f0c932-d383-4960-859f-ceba04b2fd8e"), new DateTime(2010, 10, 10, 15, 50, 26, 735, DateTimeKind.Unspecified).AddTicks(6697), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Syble Ernser", 1 },
                    { new Guid("56d721f2-47dd-44a5-95fe-25b700e1ec18"), new DateTime(2020, 9, 26, 16, 55, 57, 472, DateTimeKind.Unspecified).AddTicks(8882), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Simeon Turcotte", 5 },
                    { new Guid("571abd37-2ed0-4b8a-944a-a6ad518cbc53"), new DateTime(2015, 1, 26, 1, 10, 16, 702, DateTimeKind.Unspecified).AddTicks(5174), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Deshaun Ebert", 2 },
                    { new Guid("5a58e6e5-01d4-4469-97e9-56253e2db3db"), new DateTime(2018, 2, 3, 9, 55, 21, 306, DateTimeKind.Unspecified).AddTicks(9081), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Kim Dach", 2 },
                    { new Guid("5a9d30e7-a898-4076-8c04-9adb57cd235e"), new DateTime(2016, 12, 3, 8, 20, 19, 798, DateTimeKind.Unspecified).AddTicks(8601), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Aidan Prohaska", 2 },
                    { new Guid("5b7f098d-0785-477d-984d-2bf6c0f785f8"), new DateTime(2012, 1, 4, 0, 41, 54, 314, DateTimeKind.Unspecified).AddTicks(122), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Mireille Rau", 1 },
                    { new Guid("5b9e23e5-733f-4a16-8b57-817c179482e6"), new DateTime(2021, 8, 18, 10, 30, 1, 235, DateTimeKind.Unspecified).AddTicks(1690), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Ladarius West", 1 },
                    { new Guid("5bb9ded7-05e4-4e58-9edb-0e279716057a"), new DateTime(2018, 9, 26, 19, 42, 7, 836, DateTimeKind.Unspecified).AddTicks(5550), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Angelica Franecki", 7 },
                    { new Guid("5bf459be-d136-4aef-8847-1ab10f5c79d9"), new DateTime(2015, 4, 2, 0, 52, 23, 11, DateTimeKind.Unspecified).AddTicks(6526), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Ariel Romaguera", 5 },
                    { new Guid("5c15a6fa-004d-4e45-8430-7d66fec65cc2"), new DateTime(2011, 10, 26, 15, 22, 38, 913, DateTimeKind.Unspecified).AddTicks(9910), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Shannon Spinka", 8 },
                    { new Guid("5e0fc6b2-b5d9-48d4-aa33-0c56138193b3"), new DateTime(2012, 6, 26, 10, 47, 18, 483, DateTimeKind.Unspecified).AddTicks(3344), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Toney Beahan", 1 },
                    { new Guid("5edf7426-89ec-4b55-8bc4-9ae6c4936c29"), new DateTime(2013, 2, 6, 19, 1, 12, 297, DateTimeKind.Unspecified).AddTicks(4761), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Deonte Kozey", 8 },
                    { new Guid("5fbb041a-d477-4a88-911a-e4556c8b8358"), new DateTime(2017, 4, 22, 2, 47, 45, 430, DateTimeKind.Unspecified).AddTicks(1824), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Bette Collins", 9 },
                    { new Guid("6030e7a0-5e95-42b4-b341-4b5936f3ab55"), new DateTime(2011, 7, 4, 22, 22, 51, 345, DateTimeKind.Unspecified).AddTicks(875), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Alexa Daniel", 5 },
                    { new Guid("6243a0a0-2306-4d1d-8b61-bf0f013a02d1"), new DateTime(2014, 9, 4, 23, 30, 38, 664, DateTimeKind.Unspecified).AddTicks(5931), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Raven Senger", 3 },
                    { new Guid("649261aa-c878-43d8-8d6a-de39e0269a85"), new DateTime(2014, 8, 3, 3, 35, 40, 132, DateTimeKind.Unspecified).AddTicks(4782), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Cheyenne Rau", 9 },
                    { new Guid("64ff2f39-bd56-4098-b667-31c0c1de6de0"), new DateTime(2018, 11, 14, 0, 20, 58, 488, DateTimeKind.Unspecified).AddTicks(5458), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Jennie Buckridge", 3 },
                    { new Guid("66315cca-e4a7-4db4-9328-931ec50c0d93"), new DateTime(2019, 10, 6, 17, 6, 26, 41, DateTimeKind.Unspecified).AddTicks(3915), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Reid Schumm", 2 },
                    { new Guid("67f0aaf3-1ba5-4a21-ae79-d4ec4692a37e"), new DateTime(2016, 12, 8, 8, 5, 56, 593, DateTimeKind.Unspecified).AddTicks(2874), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Trenton Leffler", 7 },
                    { new Guid("69d45d61-8c1d-4145-a6c2-f4ae4cd5e9da"), new DateTime(2021, 10, 3, 2, 38, 10, 133, DateTimeKind.Unspecified).AddTicks(9020), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Dana Rau", 8 },
                    { new Guid("6da6af44-6ee5-4396-b920-35121d20552c"), new DateTime(2021, 5, 1, 9, 27, 51, 350, DateTimeKind.Unspecified).AddTicks(6312), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Jaclyn Keeling", 3 },
                    { new Guid("6f63d577-68ad-4b88-9b40-56ddbe1b4cfd"), new DateTime(2013, 11, 14, 16, 56, 22, 236, DateTimeKind.Unspecified).AddTicks(7590), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Ceasar McClure", 4 },
                    { new Guid("7071665a-edd7-4f16-af90-20c1ff6e4daf"), new DateTime(2019, 11, 18, 1, 1, 37, 442, DateTimeKind.Unspecified).AddTicks(6688), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Matilde Ratke", 6 },
                    { new Guid("71fb58bb-1cc3-4e34-bdab-f0fc63daac05"), new DateTime(2019, 7, 26, 15, 40, 31, 306, DateTimeKind.Unspecified).AddTicks(616), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Francesca Schiller", 6 },
                    { new Guid("7487f84c-c384-4ac8-a733-c9d9c66e5b7b"), new DateTime(2021, 2, 11, 1, 23, 22, 326, DateTimeKind.Unspecified).AddTicks(1472), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Brayan Stamm", 9 },
                    { new Guid("7abb05d6-063e-4b2b-855d-eb956a2e60bb"), new DateTime(2018, 3, 16, 5, 23, 22, 246, DateTimeKind.Unspecified).AddTicks(3383), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Whitney Bruen", 4 },
                    { new Guid("7c56416f-1ca3-4dac-9c4d-37d49e689d57"), new DateTime(2015, 2, 24, 17, 15, 17, 257, DateTimeKind.Unspecified).AddTicks(5304), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Jamel Ernser", 8 },
                    { new Guid("7c72d1cb-954c-453d-840d-1147258cd6d3"), new DateTime(2020, 11, 13, 9, 28, 16, 338, DateTimeKind.Unspecified).AddTicks(7652), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Bennett Kling", 5 },
                    { new Guid("7d631f4f-abc3-4e6e-8607-e8ac82668510"), new DateTime(2018, 2, 3, 7, 54, 50, 950, DateTimeKind.Unspecified).AddTicks(8326), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Vernon Watsica", 9 },
                    { new Guid("7fd5fe13-416d-45cf-8091-546df18732bf"), new DateTime(2018, 12, 12, 4, 59, 55, 785, DateTimeKind.Unspecified).AddTicks(369), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Alexanne Hudson", 5 },
                    { new Guid("80ee1d0d-e0c4-4e31-8827-e41b93d8054c"), new DateTime(2020, 8, 13, 3, 46, 53, 148, DateTimeKind.Unspecified).AddTicks(496), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Maximillian Hauck", 5 },
                    { new Guid("81e22fcb-0570-48f6-bd56-b52fd4d88d95"), new DateTime(2020, 3, 14, 2, 50, 57, 411, DateTimeKind.Unspecified).AddTicks(3170), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Rudolph Kovacek", 2 },
                    { new Guid("8221e311-1f8e-4a72-bf4c-7b1592f7d543"), new DateTime(2018, 2, 12, 23, 21, 0, 325, DateTimeKind.Unspecified).AddTicks(7379), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Chance Zboncak", 2 },
                    { new Guid("83a9559d-71d6-4b2d-85d1-86e2c47c25de"), new DateTime(2014, 11, 11, 2, 14, 31, 994, DateTimeKind.Unspecified).AddTicks(2498), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Anya Reichel", 1 },
                    { new Guid("85e41cc9-f667-4234-af31-5836d6ade1c1"), new DateTime(2012, 10, 13, 11, 46, 15, 611, DateTimeKind.Unspecified).AddTicks(8814), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Rogers Tromp", 6 },
                    { new Guid("8645c977-329a-4824-b1f5-d5a34fca207a"), new DateTime(2018, 7, 27, 11, 22, 13, 335, DateTimeKind.Unspecified).AddTicks(2062), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Marquise Dickens", 4 },
                    { new Guid("86521afa-936e-431c-8415-267e0e905a04"), new DateTime(2018, 3, 9, 3, 17, 8, 855, DateTimeKind.Unspecified).AddTicks(2848), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Jacklyn Goldner", 8 },
                    { new Guid("8924c7fd-37c9-4539-91b0-fba74a02b088"), new DateTime(2020, 5, 26, 6, 45, 25, 337, DateTimeKind.Unspecified).AddTicks(5078), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Bryon Stamm", 1 },
                    { new Guid("8a45b73c-6afb-49f2-b7b2-baae6cd441c6"), new DateTime(2013, 6, 1, 15, 41, 55, 139, DateTimeKind.Unspecified).AddTicks(3151), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Edmund Witting", 1 },
                    { new Guid("8f2d29fa-8dfa-4074-b9f4-46fc38e8e123"), new DateTime(2013, 1, 19, 10, 54, 53, 300, DateTimeKind.Unspecified).AddTicks(8014), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Ezequiel DuBuque", 3 },
                    { new Guid("8f5c4a98-3c23-43e6-a6e6-e73adff9d480"), new DateTime(2021, 4, 2, 14, 1, 39, 356, DateTimeKind.Unspecified).AddTicks(3144), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Dale Pagac", 5 },
                    { new Guid("90188ec8-de40-4340-85c1-ce627a2a7bf4"), new DateTime(2019, 12, 12, 10, 41, 14, 278, DateTimeKind.Unspecified).AddTicks(6100), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Holden Okuneva", 1 },
                    { new Guid("9043842c-6d01-44ae-8246-f019f1fa5c88"), new DateTime(2012, 6, 2, 1, 53, 34, 617, DateTimeKind.Unspecified).AddTicks(6623), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Jennings Haley", 4 },
                    { new Guid("910b2863-e071-4c29-9313-3d51b38fe1a6"), new DateTime(2010, 6, 7, 9, 41, 59, 209, DateTimeKind.Unspecified).AddTicks(2219), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Helga Hudson", 9 },
                    { new Guid("91a4b0b0-2f61-4974-a191-6a081adb727d"), new DateTime(2019, 10, 29, 0, 6, 52, 272, DateTimeKind.Unspecified).AddTicks(3096), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Manuela Daniel", 9 },
                    { new Guid("9273267b-42df-4628-b9da-609be2340779"), new DateTime(2011, 6, 30, 4, 0, 10, 197, DateTimeKind.Unspecified).AddTicks(4853), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Jessica Hahn", 3 },
                    { new Guid("962ed53e-2625-4905-ad9d-88e6653f5ba6"), new DateTime(2017, 8, 15, 11, 46, 0, 534, DateTimeKind.Unspecified).AddTicks(7094), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Shany Weber", 8 },
                    { new Guid("968ec5c8-73b1-465d-8925-c742f71b7b0a"), new DateTime(2017, 12, 4, 12, 30, 22, 556, DateTimeKind.Unspecified).AddTicks(540), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Talia Kreiger", 9 },
                    { new Guid("9744d457-d4f3-4f3b-9a01-2c54a34f3f3a"), new DateTime(2013, 11, 29, 14, 3, 1, 830, DateTimeKind.Unspecified).AddTicks(5758), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Ressie Schimmel", 6 },
                    { new Guid("9ad23489-90c3-42c0-a5ad-89a16eeb413c"), new DateTime(2022, 11, 20, 0, 54, 34, 811, DateTimeKind.Unspecified).AddTicks(5423), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Adriana Reichert", 4 },
                    { new Guid("9c1b8599-f671-4ed3-8542-5b69e7ceb864"), new DateTime(2016, 11, 6, 12, 49, 32, 245, DateTimeKind.Unspecified).AddTicks(1487), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Luisa Rodriguez", 3 },
                    { new Guid("9c696613-44b7-4691-bc57-104de8c7eef8"), new DateTime(2015, 10, 19, 3, 49, 51, 623, DateTimeKind.Unspecified).AddTicks(7587), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Cloyd Hegmann", 6 },
                    { new Guid("9c81ab8d-2197-4f52-b0ee-052d9ced15af"), new DateTime(2019, 5, 13, 6, 6, 4, 338, DateTimeKind.Unspecified).AddTicks(3280), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Alice Reinger", 9 },
                    { new Guid("9d3b95e9-d875-4335-b5e8-c5014c81f9d2"), new DateTime(2013, 6, 11, 18, 52, 18, 786, DateTimeKind.Unspecified).AddTicks(9855), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Freddie Crooks", 7 },
                    { new Guid("9d7794d8-ecf9-4daf-ad05-8c58b099e0a5"), new DateTime(2012, 1, 3, 15, 41, 27, 505, DateTimeKind.Unspecified).AddTicks(757), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Kirk Kuphal", 9 },
                    { new Guid("9d8088cb-5df8-420f-88fd-c98da82e1c26"), new DateTime(2016, 4, 24, 10, 26, 18, 957, DateTimeKind.Unspecified).AddTicks(450), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Aliza Prosacco", 8 },
                    { new Guid("9e096db9-52e8-4f17-8724-24025564b79c"), new DateTime(2016, 9, 3, 7, 29, 6, 84, DateTimeKind.Unspecified).AddTicks(1721), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Brooks Gleichner", 9 },
                    { new Guid("9e125c6d-1c5a-44ba-a6f1-b02de76e9ac9"), new DateTime(2013, 9, 27, 13, 50, 43, 874, DateTimeKind.Unspecified).AddTicks(6855), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Kailee Leffler", 2 },
                    { new Guid("9eb7182f-c1bb-4f8f-8bc3-e56d3bee8edc"), new DateTime(2022, 8, 8, 17, 37, 37, 156, DateTimeKind.Unspecified).AddTicks(9274), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Bret Prosacco", 5 },
                    { new Guid("9fc36305-8a2c-471c-a86d-4f38eeba38af"), new DateTime(2011, 12, 5, 1, 21, 23, 957, DateTimeKind.Unspecified).AddTicks(687), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Darrin Leffler", 4 },
                    { new Guid("a00ca7ad-7b80-4ead-aece-9903832c8d63"), new DateTime(2012, 7, 4, 9, 5, 39, 314, DateTimeKind.Unspecified).AddTicks(8270), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Christelle McGlynn", 6 },
                    { new Guid("a15480fd-766f-4882-93c9-c9d092f86d02"), new DateTime(2017, 3, 12, 15, 19, 32, 717, DateTimeKind.Unspecified).AddTicks(6867), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Loyal Welch", 5 },
                    { new Guid("a18c6a52-e6dc-463a-9030-f16724c84d1a"), new DateTime(2017, 12, 31, 5, 35, 46, 327, DateTimeKind.Unspecified).AddTicks(3228), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Kellen Feest", 6 },
                    { new Guid("a1c8b0ac-c4bb-4b4a-ab82-3e37c6b11ff1"), new DateTime(2022, 6, 13, 10, 42, 43, 443, DateTimeKind.Unspecified).AddTicks(5067), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Kenya Shanahan", 7 },
                    { new Guid("a1f0efa5-c7db-4c31-b139-7b74279614cf"), new DateTime(2016, 5, 5, 1, 45, 21, 932, DateTimeKind.Unspecified).AddTicks(4021), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Santina O'Hara", 8 },
                    { new Guid("a269a878-5219-470c-8c6d-512f69b685b8"), new DateTime(2019, 9, 12, 6, 2, 43, 293, DateTimeKind.Unspecified).AddTicks(998), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Susanna Metz", 4 },
                    { new Guid("a33599d2-d19c-486c-940c-2a9c8c1cc4ab"), new DateTime(2022, 8, 22, 14, 0, 3, 915, DateTimeKind.Unspecified).AddTicks(2724), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Ora Cartwright", 3 },
                    { new Guid("a341b89a-aafe-487e-b45d-b7d3afe8662f"), new DateTime(2013, 1, 22, 23, 51, 48, 193, DateTimeKind.Unspecified).AddTicks(2371), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Andres McGlynn", 7 },
                    { new Guid("a55dc431-2e6f-4742-bcfb-fac26f3c66ea"), new DateTime(2013, 5, 25, 3, 13, 35, 856, DateTimeKind.Unspecified).AddTicks(5719), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Kole Koelpin", 9 },
                    { new Guid("a6971b3a-c79b-4804-9601-bece073ac030"), new DateTime(2018, 1, 23, 15, 26, 24, 190, DateTimeKind.Unspecified).AddTicks(9410), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Lisandro DuBuque", 8 },
                    { new Guid("a6f7d1a0-e5c3-4576-b717-8f50da1609c4"), new DateTime(2015, 8, 23, 18, 16, 40, 996, DateTimeKind.Unspecified).AddTicks(1703), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Bernadine Schuster", 7 },
                    { new Guid("a9bbed45-b726-40a6-8d83-f9b2862ea023"), new DateTime(2011, 6, 12, 18, 43, 52, 889, DateTimeKind.Unspecified).AddTicks(4983), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Electa Shields", 9 },
                    { new Guid("a9e324ac-e6d5-4aff-ae1e-59a99c1124fa"), new DateTime(2017, 9, 26, 18, 45, 19, 346, DateTimeKind.Unspecified).AddTicks(178), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Melissa Marvin", 2 },
                    { new Guid("ac6d2d64-ee35-4af8-9fac-8d5364a353af"), new DateTime(2015, 11, 23, 9, 41, 32, 931, DateTimeKind.Unspecified).AddTicks(8227), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Lynn Dach", 2 },
                    { new Guid("ac742016-6482-4544-8c03-b947b7e35e61"), new DateTime(2014, 6, 6, 9, 13, 2, 448, DateTimeKind.Unspecified).AddTicks(246), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Tatum Ortiz", 9 },
                    { new Guid("aead88e5-df7e-4879-ba0b-0eb966698690"), new DateTime(2022, 12, 3, 2, 58, 5, 435, DateTimeKind.Unspecified).AddTicks(8569), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Lionel Morissette", 7 },
                    { new Guid("afedc14d-12f3-4a8b-a9fc-434bd4c1008f"), new DateTime(2022, 7, 27, 1, 19, 36, 37, DateTimeKind.Unspecified).AddTicks(3094), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Jeremy Christiansen", 1 },
                    { new Guid("b09e0425-ff4b-4511-9e72-23c80c2d5ffb"), new DateTime(2018, 11, 25, 1, 17, 30, 556, DateTimeKind.Unspecified).AddTicks(4490), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Brent King", 5 },
                    { new Guid("b1a8f9ce-a411-48d1-b915-561c71c80e00"), new DateTime(2014, 5, 5, 4, 44, 5, 187, DateTimeKind.Unspecified).AddTicks(4832), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Zachery Orn", 9 },
                    { new Guid("b3955a4c-3bdd-4d53-a813-d4f1a0771853"), new DateTime(2017, 4, 3, 19, 56, 31, 6, DateTimeKind.Unspecified).AddTicks(4792), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Gennaro Ortiz", 9 },
                    { new Guid("b46996cb-7e35-491c-8c20-f8fd8d657b85"), new DateTime(2016, 5, 5, 2, 20, 21, 380, DateTimeKind.Unspecified).AddTicks(8695), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Alec Kohler", 3 },
                    { new Guid("b5f3a831-22e4-4637-b527-da426d23e46a"), new DateTime(2013, 12, 30, 2, 12, 36, 405, DateTimeKind.Unspecified).AddTicks(1552), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Pascale Greenholt", 1 },
                    { new Guid("b66734e8-463c-4580-a137-ab540cb26699"), new DateTime(2015, 8, 12, 15, 12, 14, 205, DateTimeKind.Unspecified).AddTicks(1127), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Una Erdman", 3 },
                    { new Guid("b7ef5fc4-a078-4892-9871-d67786982a78"), new DateTime(2015, 4, 19, 12, 33, 40, 657, DateTimeKind.Unspecified).AddTicks(7815), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Raymond Blanda", 8 },
                    { new Guid("b7f0a086-49ec-438b-8098-2f50390b3b8c"), new DateTime(2013, 10, 21, 2, 55, 26, 213, DateTimeKind.Unspecified).AddTicks(1726), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Kyler Schoen", 7 },
                    { new Guid("b87c284e-719a-407f-a0c6-05bd239597c5"), new DateTime(2015, 1, 29, 9, 24, 33, 153, DateTimeKind.Unspecified).AddTicks(9913), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Oceane Gerlach", 9 },
                    { new Guid("b9f44c8e-e926-4043-b07e-4b5e96d1dc1d"), new DateTime(2010, 12, 25, 6, 5, 16, 941, DateTimeKind.Unspecified).AddTicks(4646), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Lera Fadel", 1 },
                    { new Guid("ba0903f7-e981-415f-ba60-f9e3ca3e5977"), new DateTime(2022, 4, 15, 6, 34, 0, 496, DateTimeKind.Unspecified).AddTicks(3180), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Vida Spencer", 4 },
                    { new Guid("ba38d73d-e256-4496-bf38-7be5c5cfa30c"), new DateTime(2022, 1, 18, 12, 6, 21, 261, DateTimeKind.Unspecified).AddTicks(554), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Bailey Witting", 5 },
                    { new Guid("bcd662cd-8063-456f-ad52-919d8652e411"), new DateTime(2013, 7, 13, 8, 35, 0, 312, DateTimeKind.Unspecified).AddTicks(4099), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Greg Wilkinson", 1 },
                    { new Guid("bd290e00-2582-45ea-a9e2-1a6bba8f9d29"), new DateTime(2017, 7, 12, 8, 13, 37, 652, DateTimeKind.Unspecified).AddTicks(9192), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Jackeline Huels", 8 },
                    { new Guid("bf33ccd8-b494-493b-9882-faa8af0b0e5e"), new DateTime(2018, 11, 13, 23, 29, 32, 560, DateTimeKind.Unspecified).AddTicks(7405), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Rosalee Rau", 5 },
                    { new Guid("bf4cdb36-420e-4c70-8da4-ae4b6be94b2d"), new DateTime(2019, 7, 30, 19, 2, 27, 14, DateTimeKind.Unspecified).AddTicks(632), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Geraldine Schultz", 1 },
                    { new Guid("c13e3964-e75e-4012-932a-4a7e7b511650"), new DateTime(2021, 5, 23, 15, 8, 34, 940, DateTimeKind.Unspecified).AddTicks(1627), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Kenton Rogahn", 4 },
                    { new Guid("c1d89d37-6e5e-4aff-b974-e5d6435034f2"), new DateTime(2022, 9, 23, 18, 55, 3, 457, DateTimeKind.Unspecified).AddTicks(1916), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Gertrude Klein", 9 },
                    { new Guid("c2fd95f2-9c48-4ad1-adfd-d789117a8393"), new DateTime(2015, 1, 22, 21, 45, 50, 846, DateTimeKind.Unspecified).AddTicks(7341), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Alden Tillman", 4 },
                    { new Guid("c3d1ea41-de62-43b0-830d-d360b049bf59"), new DateTime(2022, 6, 14, 10, 11, 27, 129, DateTimeKind.Unspecified).AddTicks(1575), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Webster Schoen", 2 },
                    { new Guid("c4be99f5-9f6c-45bc-b1b4-e5301f3b54a2"), new DateTime(2013, 1, 12, 3, 20, 14, 842, DateTimeKind.Unspecified).AddTicks(2477), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Burdette Dietrich", 6 },
                    { new Guid("c69893c4-b84b-45d3-81ee-d2c2b8399e15"), new DateTime(2018, 3, 28, 15, 6, 19, 1, DateTimeKind.Unspecified).AddTicks(4060), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Green Romaguera", 8 },
                    { new Guid("c8a2cf1c-35cd-4224-8807-7ee15e77f337"), new DateTime(2013, 5, 7, 9, 58, 7, 261, DateTimeKind.Unspecified).AddTicks(4633), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Cesar Effertz", 8 },
                    { new Guid("c97d924b-81ac-455b-b059-a8638ef17f64"), new DateTime(2020, 7, 27, 13, 44, 15, 169, DateTimeKind.Unspecified).AddTicks(9028), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Enid Hoeger", 5 },
                    { new Guid("ccfdfcbb-a6ca-4ea4-84db-72ff60518a06"), new DateTime(2022, 9, 22, 4, 33, 41, 596, DateTimeKind.Unspecified).AddTicks(2413), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Amya Feil", 8 },
                    { new Guid("cdc6a633-999d-4410-8d61-1b53e5981e25"), new DateTime(2018, 9, 1, 23, 32, 46, 882, DateTimeKind.Unspecified).AddTicks(196), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Keshawn Bechtelar", 3 },
                    { new Guid("cdcc73ac-5ccd-4117-bbb2-60d745499561"), new DateTime(2011, 10, 28, 3, 57, 32, 789, DateTimeKind.Unspecified).AddTicks(5668), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Moises Schmidt", 4 },
                    { new Guid("cdf983e7-73b3-4135-a6db-e8be877b1a18"), new DateTime(2019, 10, 13, 6, 38, 5, 187, DateTimeKind.Unspecified).AddTicks(8319), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Filiberto Pollich", 9 },
                    { new Guid("cf740940-0944-46e0-ac88-4d78ddf995b1"), new DateTime(2010, 3, 4, 17, 15, 24, 928, DateTimeKind.Unspecified).AddTicks(7274), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Dell Greenholt", 9 },
                    { new Guid("d007b39c-76c3-42ad-a015-b3cb74c103ae"), new DateTime(2011, 11, 2, 9, 2, 26, 657, DateTimeKind.Unspecified).AddTicks(1523), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Russel Reinger", 3 },
                    { new Guid("d125a102-1eb8-4996-a6b8-4fd313d85b1d"), new DateTime(2022, 7, 7, 11, 52, 57, 502, DateTimeKind.Unspecified).AddTicks(5966), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Brianne Hickle", 3 },
                    { new Guid("d14e7723-08ac-40d2-82da-c7d3616dc42c"), new DateTime(2012, 11, 15, 23, 56, 5, 77, DateTimeKind.Unspecified).AddTicks(5246), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Vallie Cartwright", 7 },
                    { new Guid("d1675fcc-0a8d-482d-bb8f-017dde18e6ee"), new DateTime(2015, 11, 24, 5, 30, 29, 951, DateTimeKind.Unspecified).AddTicks(1233), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Scarlett Roberts", 7 },
                    { new Guid("d1ce0765-249f-45e0-8cb2-200afc1ac2fe"), new DateTime(2021, 11, 9, 1, 12, 27, 673, DateTimeKind.Unspecified).AddTicks(3650), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Cassie McKenzie", 3 },
                    { new Guid("d2ff61a9-ff1d-4933-9d03-ef073540f4fc"), new DateTime(2010, 3, 8, 18, 14, 14, 534, DateTimeKind.Unspecified).AddTicks(8181), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Cloyd Lueilwitz", 6 },
                    { new Guid("d5cd7e30-6d1a-41f3-9a5f-a91679d28f88"), new DateTime(2022, 6, 27, 15, 18, 45, 859, DateTimeKind.Unspecified).AddTicks(4003), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Marguerite Batz", 6 },
                    { new Guid("d7dfd5b7-0faa-4792-8fe8-a2c39fab8c38"), new DateTime(2021, 12, 20, 12, 23, 25, 357, DateTimeKind.Unspecified).AddTicks(2432), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Freeda Koepp", 4 },
                    { new Guid("d86ca97b-27b2-476f-80f5-fd42d395c7cb"), new DateTime(2015, 8, 5, 3, 32, 34, 201, DateTimeKind.Unspecified).AddTicks(4954), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Alessandra Fahey", 9 },
                    { new Guid("d8bbfe0e-b0b4-4b11-836e-c7f691dc1696"), new DateTime(2010, 10, 16, 15, 37, 30, 74, DateTimeKind.Unspecified).AddTicks(552), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Nova Cremin", 1 },
                    { new Guid("d8e0400b-45e8-41cc-abb7-d5aa7bf7301a"), new DateTime(2019, 12, 19, 17, 24, 12, 237, DateTimeKind.Unspecified).AddTicks(4414), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Elenor Gutmann", 7 },
                    { new Guid("d8ee7f14-8adf-4501-90f1-7d6a73b33097"), new DateTime(2019, 2, 26, 2, 32, 46, 710, DateTimeKind.Unspecified).AddTicks(9582), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Mario Rempel", 2 },
                    { new Guid("d8fd02a1-eab1-4aa3-9bd7-d5f8396556c8"), new DateTime(2011, 4, 18, 17, 52, 43, 517, DateTimeKind.Unspecified).AddTicks(1370), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Frances Block", 7 },
                    { new Guid("d93831ba-9b64-4e61-975b-9862ae2e97ec"), new DateTime(2013, 8, 2, 23, 31, 50, 360, DateTimeKind.Unspecified).AddTicks(3951), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Devin Prosacco", 4 },
                    { new Guid("d961187b-26bc-4361-8679-a1156da92c94"), new DateTime(2020, 12, 21, 12, 25, 1, 726, DateTimeKind.Unspecified).AddTicks(9738), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Adrian Schmeler", 4 },
                    { new Guid("d9951127-1489-4500-b7c5-8e12329364a1"), new DateTime(2021, 9, 18, 4, 18, 34, 434, DateTimeKind.Unspecified).AddTicks(7693), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Tamia Homenick", 7 },
                    { new Guid("da1f15dd-4347-4e93-9e88-ddfc5e2aafad"), new DateTime(2021, 8, 20, 14, 41, 28, 473, DateTimeKind.Unspecified).AddTicks(8485), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Chasity Spencer", 6 },
                    { new Guid("db35de0f-e5fb-4501-b97f-05b933b31685"), new DateTime(2021, 8, 13, 1, 2, 21, 511, DateTimeKind.Unspecified).AddTicks(6762), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Aubrey Lynch", 4 },
                    { new Guid("db94f151-c42c-47a7-9257-e42d22fd5dc1"), new DateTime(2019, 6, 24, 16, 26, 3, 961, DateTimeKind.Unspecified).AddTicks(5283), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Ladarius Mayer", 2 },
                    { new Guid("dc3ab657-1299-4297-bfb0-042db0afe010"), new DateTime(2019, 5, 9, 16, 11, 31, 394, DateTimeKind.Unspecified).AddTicks(694), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Abelardo Ziemann", 9 },
                    { new Guid("dcedd237-6bd8-42a9-b8ab-5724cd3cc642"), new DateTime(2015, 8, 19, 16, 38, 51, 155, DateTimeKind.Unspecified).AddTicks(7105), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Josue Gleason", 2 },
                    { new Guid("dd61f086-2093-473c-a606-c01434951221"), new DateTime(2015, 6, 21, 12, 13, 7, 452, DateTimeKind.Unspecified).AddTicks(6763), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Magnus Streich", 2 },
                    { new Guid("df7fc45f-3560-49d6-8298-9ea31e0bdd89"), new DateTime(2022, 11, 3, 20, 36, 26, 369, DateTimeKind.Unspecified).AddTicks(1562), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Maurice Green", 6 },
                    { new Guid("e003809e-3869-4705-a486-fe8ee08e71be"), new DateTime(2019, 8, 5, 6, 21, 25, 95, DateTimeKind.Unspecified).AddTicks(1608), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Eulalia Satterfield", 9 },
                    { new Guid("e0fc84ba-46ba-4123-ae1c-b6f37de23b8c"), new DateTime(2017, 12, 4, 7, 29, 57, 389, DateTimeKind.Unspecified).AddTicks(6804), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Meaghan Turner", 5 },
                    { new Guid("e111d79e-b910-4674-a337-26f9877621d3"), new DateTime(2016, 1, 23, 23, 29, 53, 583, DateTimeKind.Unspecified).AddTicks(58), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Ulises Senger", 1 },
                    { new Guid("e169dad7-4213-4243-bf2b-a83b99c53cf4"), new DateTime(2017, 6, 21, 22, 31, 3, 155, DateTimeKind.Unspecified).AddTicks(1796), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Abdullah Shields", 9 },
                    { new Guid("e27d95c7-2376-424e-ad70-fae4292c2bac"), new DateTime(2011, 4, 18, 13, 54, 36, 336, DateTimeKind.Unspecified).AddTicks(7000), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Ubaldo Lowe", 3 },
                    { new Guid("e2c2ae45-ef5f-46f5-a0f9-7c5bd515e033"), new DateTime(2012, 9, 16, 0, 18, 36, 835, DateTimeKind.Unspecified).AddTicks(8446), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Barbara Murray", 7 },
                    { new Guid("e347fa1a-5a4f-419d-8243-ee256c042130"), new DateTime(2016, 12, 17, 14, 42, 19, 753, DateTimeKind.Unspecified).AddTicks(6769), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Shanie Erdman", 4 },
                    { new Guid("e42bf369-319c-46a4-9151-96a7cb63eb20"), new DateTime(2019, 9, 23, 2, 50, 4, 177, DateTimeKind.Unspecified).AddTicks(1907), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Gladyce Cormier", 3 },
                    { new Guid("e4c19383-df6b-4337-b792-5a61dfaeb473"), new DateTime(2013, 11, 1, 17, 54, 4, 622, DateTimeKind.Unspecified).AddTicks(2289), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Aiyana McLaughlin", 1 },
                    { new Guid("e83e7068-0c64-42c4-a07c-155cd6466f0f"), new DateTime(2019, 5, 25, 10, 26, 36, 254, DateTimeKind.Unspecified).AddTicks(8694), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Caleigh Hills", 1 },
                    { new Guid("e8601dde-4be4-403a-90ba-bb3072f11470"), new DateTime(2019, 7, 31, 19, 34, 58, 647, DateTimeKind.Unspecified).AddTicks(5262), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Mekhi Thiel", 9 },
                    { new Guid("e93c14ed-b60f-41e2-8326-bd07d43d7e8a"), new DateTime(2013, 8, 16, 21, 10, 52, 702, DateTimeKind.Unspecified).AddTicks(5402), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Libbie Lesch", 7 },
                    { new Guid("ec2fe704-560a-4b18-84c5-d06160ef9c85"), new DateTime(2017, 12, 18, 6, 14, 33, 505, DateTimeKind.Unspecified).AddTicks(5882), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Stanley Prohaska", 1 },
                    { new Guid("ed213d42-e6dd-4e67-9731-266b62352bd4"), new DateTime(2012, 8, 5, 7, 58, 6, 828, DateTimeKind.Unspecified).AddTicks(570), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Willis Gaylord", 2 },
                    { new Guid("ee555d3a-166f-4a24-bedf-d53b61e0d8f9"), new DateTime(2020, 5, 23, 7, 22, 49, 78, DateTimeKind.Unspecified).AddTicks(160), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Hipolito Lindgren", 7 },
                    { new Guid("ef4355f4-7bbd-48fd-a839-126e27202e9f"), new DateTime(2021, 10, 14, 14, 8, 40, 281, DateTimeKind.Unspecified).AddTicks(6776), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Terrence Stark", 1 },
                    { new Guid("f33c25a1-53b9-4d50-b2a9-3ba166b1c988"), new DateTime(2013, 7, 15, 23, 15, 38, 831, DateTimeKind.Unspecified).AddTicks(2000), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Berenice Leuschke", 3 },
                    { new Guid("f3915c85-8d4d-4ca8-a5b7-7c6e5c302124"), new DateTime(2012, 9, 19, 4, 8, 0, 853, DateTimeKind.Unspecified).AddTicks(5544), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Jazlyn Goyette", 3 },
                    { new Guid("f571ef1e-9c33-4a44-b1ec-310935016a74"), new DateTime(2022, 9, 18, 7, 17, 30, 111, DateTimeKind.Unspecified).AddTicks(342), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Reynold Conn", 8 },
                    { new Guid("f686a1c9-af8c-4c01-b32f-6b34d7274077"), new DateTime(2020, 2, 21, 13, 37, 29, 20, DateTimeKind.Unspecified).AddTicks(3606), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Eudora Harris", 9 },
                    { new Guid("f732d7b9-0902-4fad-aa6f-68ee1e27bbf6"), new DateTime(2022, 9, 1, 23, 15, 58, 444, DateTimeKind.Unspecified).AddTicks(1526), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Margaretta Toy", 4 },
                    { new Guid("f7d2740b-f060-44dc-826c-982e4c235673"), new DateTime(2020, 8, 8, 22, 3, 48, 821, DateTimeKind.Unspecified).AddTicks(1130), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Alba Rempel", 4 },
                    { new Guid("f894a66d-3317-4f2a-baa0-fe7e91ebb6cf"), new DateTime(2020, 6, 26, 20, 37, 33, 188, DateTimeKind.Unspecified).AddTicks(5766), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Jaylen Rice", 1 },
                    { new Guid("f8cde93e-23c3-4816-8555-b82eb969a275"), new DateTime(2012, 4, 26, 19, 38, 42, 833, DateTimeKind.Unspecified).AddTicks(3100), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Guy Steuber", 1 },
                    { new Guid("f8e969c5-275c-4ee8-a069-dd4022237f52"), new DateTime(2013, 7, 25, 20, 17, 10, 635, DateTimeKind.Unspecified).AddTicks(9041), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Osborne Spinka", 5 },
                    { new Guid("f99e1332-dd3e-407e-9406-aeb39a34d4e7"), new DateTime(2012, 8, 12, 3, 5, 8, 636, DateTimeKind.Unspecified).AddTicks(2965), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Roger Medhurst", 8 },
                    { new Guid("fa4865c1-3a3e-4794-ba94-96a4955d2a12"), new DateTime(2015, 5, 15, 3, 10, 9, 465, DateTimeKind.Unspecified).AddTicks(9358), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Destin Swaniawski", 1 },
                    { new Guid("fb57c8a7-6ff5-43fb-96e7-a08b25c9b55d"), new DateTime(2018, 4, 12, 14, 27, 22, 674, DateTimeKind.Unspecified).AddTicks(6531), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Darrel Nader", 6 },
                    { new Guid("fd498f0d-506d-453d-b366-0b38a496d2a1"), new DateTime(2020, 5, 15, 9, 4, 39, 656, DateTimeKind.Unspecified).AddTicks(3514), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Pietro Ortiz", 8 },
                    { new Guid("fdf5d61e-7f6f-4ff8-b5af-61e836dd8998"), new DateTime(2015, 11, 11, 21, 17, 31, 823, DateTimeKind.Unspecified).AddTicks(9666), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Felipa Donnelly", 3 },
                    { new Guid("febeae1c-25ef-4404-b4e1-e37d33874924"), new DateTime(2020, 12, 8, 12, 12, 12, 605, DateTimeKind.Unspecified).AddTicks(3290), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Jay Spinka", 4 }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "BirthDate", "ClassRoomId", "Name", "Subject" },
                values: new object[,]
                {
                    { new Guid("166bb18a-ceff-4d63-8522-5038066bd823"), new DateTime(1984, 12, 9, 15, 46, 56, 373, DateTimeKind.Unspecified).AddTicks(5805), new Guid("7c4b5589-285b-4047-8426-a6b4321f1360"), "Winston Okuneva", "Sciences" },
                    { new Guid("1df89eff-efa6-4cf0-8df4-28909773f37f"), new DateTime(1984, 11, 11, 0, 43, 10, 8, DateTimeKind.Unspecified).AddTicks(9872), new Guid("9775da1f-5c53-4b15-8cfe-0249b670f4de"), "Kaela Treutel", "History" },
                    { new Guid("22340c83-23be-45b3-a86f-20b332b6f5ae"), new DateTime(1976, 12, 3, 10, 9, 2, 952, DateTimeKind.Unspecified).AddTicks(5762), new Guid("e22eb0d2-c6dc-4d70-a927-bf998e602287"), "Tyrell Boyer", "Sciences" },
                    { new Guid("2dbf3375-4134-41b6-8e37-4fae16474c5c"), new DateTime(1989, 12, 7, 19, 48, 29, 534, DateTimeKind.Unspecified).AddTicks(8735), new Guid("113f3af8-c770-4660-8316-3275db20bec6"), "Rashawn Larson", "Math" },
                    { new Guid("47a12119-c38c-4698-947b-ae6561c877d6"), new DateTime(1987, 7, 31, 6, 58, 3, 762, DateTimeKind.Unspecified).AddTicks(9039), new Guid("8ce8679a-856d-4a2e-b063-6c4ac9fa01cf"), "Ericka Rolfson", "Math" },
                    { new Guid("61dab66b-260c-4f80-abb2-01779280f47b"), new DateTime(1999, 11, 20, 10, 18, 44, 115, DateTimeKind.Unspecified).AddTicks(2436), new Guid("4b01f44e-a92c-4c2d-a26f-67607f5fcf7f"), "Jasmin Trantow", "History" },
                    { new Guid("854c8b86-1d6f-480f-b93a-d2e74a946737"), new DateTime(1986, 9, 22, 5, 4, 44, 591, DateTimeKind.Unspecified).AddTicks(3706), new Guid("1abcb926-d3f2-4985-80c1-e4630abef32e"), "Summer Dickinson", "English" },
                    { new Guid("8c9d5062-e775-485e-877f-34fbb9f6896f"), new DateTime(1992, 6, 18, 16, 2, 48, 346, DateTimeKind.Unspecified).AddTicks(7737), new Guid("ae22250e-388a-4b65-8453-9773f7999195"), "Ed Brekke", "Sciences" },
                    { new Guid("f248381b-97d2-4284-96da-4b88a282d0a4"), new DateTime(1994, 9, 10, 22, 13, 21, 652, DateTimeKind.Unspecified).AddTicks(2170), new Guid("45cbfc2c-5113-4d83-996e-1fcae743f5c6"), "Noel Conroy", "Geography" },
                    { new Guid("f486475d-cd57-452a-9c12-d4863e61d8e1"), new DateTime(1976, 6, 11, 1, 56, 10, 551, DateTimeKind.Unspecified).AddTicks(7976), new Guid("7f39833e-ff96-4f4c-b53e-16b0fc41d12c"), "Orville Senger", "English" },
                    { new Guid("f4a411fd-8d9a-48ef-a533-1305db712184"), new DateTime(1971, 8, 19, 14, 7, 17, 655, DateTimeKind.Unspecified).AddTicks(7691), new Guid("d86d7d2d-f84e-4d85-b553-79c2cc4dcb8f"), "Kyle Bins", "Geography" },
                    { new Guid("f5fb4937-4164-48e2-ac2c-993b69024c42"), new DateTime(1999, 1, 6, 22, 4, 56, 812, DateTimeKind.Unspecified).AddTicks(3612), new Guid("ea5f50a7-7bdb-42ae-bdff-f5430e2ce6bb"), "Shanna Ruecker", "Sciences" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoom_SchoolId",
                table: "ClassRoom",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassRoomId",
                table: "Student",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ClassRoomId",
                table: "Teacher",
                column: "ClassRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "ClassRoom");

            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
