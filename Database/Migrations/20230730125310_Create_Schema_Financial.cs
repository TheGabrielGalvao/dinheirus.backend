using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class Create_Schema_Financial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "financial");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "auth",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "FinancialReleaseType",
                schema: "financial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialReleaseType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialReleaseType_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FinancialRelease",
                schema: "financial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    FinancialReleaseTypeId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialRelease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialRelease_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinancialRelease_FinancialReleaseType_FinancialReleaseTypeId",
                        column: x => x.FinancialReleaseTypeId,
                        principalSchema: "financial",
                        principalTable: "FinancialReleaseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialRelease_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "financial",
                table: "FinancialReleaseType",
                columns: new[] { "Id", "Description", "Name", "Operation", "Status", "UserId", "Uuid" },
                values: new object[,]
                {
                    { 1L, "Recebimento de salário", "Salário", 0, 1, null, new Guid("9e015083-37b2-4fa3-a017-993ad5069ca8") },
                    { 2L, "Pagamento de Aluguel", "Aluguel", 1, 1, null, new Guid("80a4db26-8161-4080-b987-6591cf4c0320") },
                    { 3L, "Outras Receitas", "Outras Receitas", 0, 1, null, new Guid("7f420e97-b563-4378-8088-edb359789ba1") },
                    { 4L, "Outras Despesas", "Outras Despesas", 1, 1, null, new Guid("ac72349e-3292-4468-84e3-63157cef3c63") }
                });

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("9f1ab48a-9783-435e-b600-01f67393782d"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("fadf7195-6ae3-46ba-9e96-afbc203e9a46"));

            migrationBuilder.CreateIndex(
                name: "IX_FinancialRelease_ContactId",
                schema: "financial",
                table: "FinancialRelease",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialRelease_FinancialReleaseTypeId",
                schema: "financial",
                table: "FinancialRelease",
                column: "FinancialReleaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialRelease_UserId",
                schema: "financial",
                table: "FinancialRelease",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialReleaseType_UserId",
                schema: "financial",
                table: "FinancialReleaseType",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialRelease",
                schema: "financial");

            migrationBuilder.DropTable(
                name: "FinancialReleaseType",
                schema: "financial");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "auth",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "UserProfile",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("3f7ebd24-c159-4951-a49b-14702defbadc"));

            migrationBuilder.UpdateData(
                schema: "auth",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Uuid",
                value: new Guid("612bc4a6-d671-42dc-b21b-6eed29955eb9"));
        }
    }
}
