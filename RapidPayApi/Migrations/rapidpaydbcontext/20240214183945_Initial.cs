using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RapidPayApi.migrations.rapidpaydbcontext
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardLimit = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CardHolderFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardHolderLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardTransactions",
                columns: table => new
                {
                    CardTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    TransactionAmount = table.Column<double>(type: "float", nullable: false),
                    TransactionFee = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    TransactionTotal = table.Column<double>(type: "float", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTransactions", x => x.CardTransactionId);
                });

            migrationBuilder.InsertData(
                table: "CardTransactions",
                columns: new[] { "CardTransactionId", "CardId", "TransactionAmount", "TransactionDate", "TransactionFee", "TransactionTotal" },
                values: new object[,]
                {
                    { 1, 1, 2000.0, new DateTime(2023, 8, 2, 13, 23, 34, 0, DateTimeKind.Unspecified), 16.25, 0.0 },
                    { 2, 1, 2500.0, new DateTime(2023, 12, 18, 16, 2, 52, 0, DateTimeKind.Unspecified), 10.56, 0.0 },
                    { 3, 2, 1500.0, new DateTime(2022, 4, 16, 10, 40, 41, 0, DateTimeKind.Unspecified), 14.26, 0.0 },
                    { 4, 3, 3500.0, new DateTime(2022, 9, 13, 9, 6, 8, 0, DateTimeKind.Unspecified), 3.3599999999999999, 0.0 },
                    { 5, 3, 3000.0, new DateTime(2023, 1, 23, 12, 17, 23, 0, DateTimeKind.Unspecified), 6.6900000000000004, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Balance", "CardHolderFirstName", "CardHolderLastName", "CardLimit", "CardNumber", "CompanyName", "CreatedDate", "ExpirationDate", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, 4500.0, "Steve", "Rogers", 35000.0, "123456789098765", "The Avengers Group", new DateTime(2012, 5, 4, 13, 13, 13, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 30, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 10, 11, 12, 0, DateTimeKind.Unspecified) },
                    { 2, 8000.0, "Han", "Solo", 17000.0, "135792648013579", "Millennium", new DateTime(2002, 8, 11, 19, 18, 17, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 24, 11, 48, 23, 0, DateTimeKind.Unspecified) },
                    { 3, 175639.0, "Bruce", "Wayne", 200000.0, "183729406560492", "Wayne Enterprises", new DateTime(2009, 10, 16, 11, 22, 32, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 11, 56, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CardTransactions");
        }
    }
}
