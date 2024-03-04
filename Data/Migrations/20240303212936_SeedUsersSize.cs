using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSkillsASP.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fd1983ee-7a43-472a-acf7-e94529a2687e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2ade2636-c6c9-4313-9806-9c7afbc11b35");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0c7d4b15-b744-4b35-adba-889a18ca67e3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "0100f864-fd6a-48fb-9cc6-f8da91a1ce7a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "18d0e7e3-159e-4bbc-931d-7e96a374fc99");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "75bd7263-af2e-414a-8173-77db0be081ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "eb0ec83d-8a13-4cfe-9201-23b344ab6d7e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "90bf1253-3c30-4103-942b-d9473667ec57");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "c23ad7d1-576e-4603-8361-8a2677281ae8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "0d32c443-5e93-40df-ba0a-130cabde1482");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "35b30ceb-1eed-43a3-8422-b9058fab0d66");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "31ff5151-e017-4fba-a8ac-2263971261f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "106fd072-6586-43d5-a725-2eccd128db29");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "05106ece-75e5-4257-861f-7b678445a884");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "055b04fe-7d19-4aad-b47d-09225b0ce284");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "39f6e686-9f0e-4c9c-ae24-77caf46927a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "8f39ac48-c04e-43bc-b5fa-0eb8ca6da611");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e96c0f78-7d41-4bce-bed4-4b643b91ab3f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0d670bc3-90e2-4d95-9139-fbf7ba55c14a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "dd78c70f-dbfa-43a6-9e29-f8f39aeafc5a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "d4dfd894-0030-4962-a081-b977b9a7015c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "303e5fb2-c60c-4e8c-b92d-029c09b9786e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "45f764ce-d6ef-4245-9bd1-c39106cbe716");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "b2805698-d260-48e4-86e1-267cb17e01d6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "02c091cd-5d25-44ce-aafe-9c7bfaabfee1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "c792dd6d-c751-4ad2-b0d7-5576cdfbeff8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "51dae046-383b-4a7c-98aa-02c2a468257c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "57a15f76-6e21-4428-a4e0-9d044e766429");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "9f7b80cc-fd56-424d-abf2-4c85f6993a0b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "6fa54dd2-26a4-435b-8c09-cd531331073a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "3a2d004f-c67e-4e54-91d3-6a9eda121303");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "701dd64f-ae5f-4a35-8cca-117a797e9d61");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "c2315a02-4de9-43ca-968b-e44e59a5878c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "0e7b52bf-272c-42cc-b48d-03a5d849b62a");
        }
    }
}
