using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CheckSkillsASP.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WasCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "WasCreated" },
                values: new object[,]
                {
                    { 1, 0, "New York", "e96c0f78-7d41-4bce-bed4-4b643b91ab3f", "USA", "johndoe@example.com", false, false, null, "Johnny", null, null, null, null, false, null, false, "JohnDoe", new DateTime(2024, 3, 3, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 0, "London", "0d670bc3-90e2-4d95-9139-fbf7ba55c14a", "UK", "alicesmith@example.com", false, false, null, "AliSmith", null, null, null, null, false, null, false, "AliceSmith", new DateTime(2024, 3, 3, 12, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 0, "Madrid", "dd78c70f-dbfa-43a6-9e29-f8f39aeafc5a", "Spain", "carlosgomez@example.com", false, false, null, "GomezC", null, null, null, null, false, null, false, "CarlosGomez", new DateTime(2024, 3, 3, 12, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 0, "Tokyo", "d4dfd894-0030-4962-a081-b977b9a7015c", "Japan", "yukisato@example.com", false, false, null, "YukiSan", null, null, null, null, false, null, false, "YukiSato", new DateTime(2024, 3, 3, 12, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 0, "Prague", "303e5fb2-c60c-4e8c-b92d-029c09b9786e", "Czech Republic", "elenakovac@example.com", false, false, null, "Lena", null, null, null, null, false, null, false, "ElenaKovac", new DateTime(2024, 3, 3, 12, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 0, "Cairo", "45f764ce-d6ef-4245-9bd1-c39106cbe716", "Egypt", "mohammedali@example.com", false, false, null, "TheGreatest", null, null, null, null, false, null, false, "MohammedAli", new DateTime(2024, 3, 3, 12, 25, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 0, "Paris", "b2805698-d260-48e4-86e1-267cb17e01d6", "France", "sophiemiller@example.com", false, false, null, "SophieM", null, null, null, null, false, null, false, "SophieMiller", new DateTime(2024, 3, 3, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 0, "Mumbai", "02c091cd-5d25-44ce-aafe-9c7bfaabfee1", "India", "rajpatel@example.com", false, false, null, "RajP", null, null, null, null, false, null, false, "RajPatel", new DateTime(2024, 3, 3, 12, 35, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 0, "Buenos Aires", "c792dd6d-c751-4ad2-b0d7-5576cdfbeff8", "Argentina", "luisafernandez@example.com", false, false, null, "LuisaF", null, null, null, null, false, null, false, "LuisaFernandez", new DateTime(2024, 3, 3, 12, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 0, "Osaka", "51dae046-383b-4a7c-98aa-02c2a468257c", "Japan", "kenjitanaka@example.com", false, false, null, "KTanaka", null, null, null, null, false, null, false, "KenjiTanaka", new DateTime(2024, 3, 3, 12, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 0, "Moscow", "57a15f76-6e21-4428-a4e0-9d044e766429", "Russia", "anastasiaivanova@example.com", false, false, null, "AnaIvanova", null, null, null, null, false, null, false, "AnastasiaIvanova", new DateTime(2024, 3, 3, 12, 50, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 0, "Barcelona", "9f7b80cc-fd56-424d-abf2-4c85f6993a0b", "Spain", "antoniolopez@example.com", false, false, null, "TonyLopez", null, null, null, null, false, null, false, "AntonioLopez", new DateTime(2024, 3, 3, 12, 55, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 0, "Delhi", "6fa54dd2-26a4-435b-8c09-cd531331073a", "India", "priyaverma@example.com", false, false, null, "PriyaV", null, null, null, null, false, null, false, "PriyaVerma", new DateTime(2024, 3, 3, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 0, "Buenos Aires", "3a2d004f-c67e-4e54-91d3-6a9eda121303", "Argentina", "javierrodriguez@example.com", false, false, null, "JaviRod", null, null, null, null, false, null, false, "JavierRodriguez", new DateTime(2024, 3, 3, 13, 5, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 0, "Sydney", "701dd64f-ae5f-4a35-8cca-117a797e9d61", "Australia", "emilyjohnson@example.com", false, false, null, "EmJ", null, null, null, null, false, null, false, "EmilyJohnson", new DateTime(2024, 3, 3, 13, 10, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 0, "Sofia", "c2315a02-4de9-43ca-968b-e44e59a5878c", "Bulgaria", "ivanivanov@example.com", false, false, null, "IvanI", null, null, null, null, false, null, false, "IvanIvanov", new DateTime(2024, 3, 3, 13, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 0, "Mexico City", "0e7b52bf-272c-42cc-b48d-03a5d849b62a", "Mexico", "sofiamartinez@example.com", false, false, null, "SofiaM", null, null, null, null, false, null, false, "SofiaMartinez", new DateTime(2024, 3, 3, 13, 20, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
