using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace wallet_guardian_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WalletGuardianAPIDb");

            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kategories",
                schema: "WalletGuardianAPIDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Icon = table.Column<long>(type: "bigint", nullable: false),
                    Color = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategories", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MonthlyBudgetStatistics",
                schema: "WalletGuardianAPIDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Income = table.Column<double>(type: "double", nullable: false),
                    AdditionalIncomes = table.Column<double>(type: "double", nullable: false),
                    CarOdometerReadingFirstDayOfMonth = table.Column<double>(type: "double", nullable: false),
                    CarOdometerReadingLastDayOfMonth = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBudgetStatistics", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shops",
                schema: "WalletGuardianAPIDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subcategories",
                schema: "WalletGuardianAPIDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    OnceAYear = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    KategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Kategories_KategoryId",
                        column: x => x.KategoryId,
                        principalSchema: "WalletGuardianAPIDb",
                        principalTable: "Kategories",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Purchases",
                schema: "WalletGuardianAPIDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    BillCost = table.Column<double>(type: "double", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: false),
                    MonthlyBudgetStatisticId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Kategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "WalletGuardianAPIDb",
                        principalTable: "Kategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_MonthlyBudgetStatistics_MonthlyBudgetStatisticId",
                        column: x => x.MonthlyBudgetStatisticId,
                        principalSchema: "WalletGuardianAPIDb",
                        principalTable: "MonthlyBudgetStatistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Purchases_Shops_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "WalletGuardianAPIDb",
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalSchema: "WalletGuardianAPIDb",
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CategoryId",
                schema: "WalletGuardianAPIDb",
                table: "Purchases",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_MonthlyBudgetStatisticId",
                schema: "WalletGuardianAPIDb",
                table: "Purchases",
                column: "MonthlyBudgetStatisticId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ShopId",
                schema: "WalletGuardianAPIDb",
                table: "Purchases",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SubcategoryId",
                schema: "WalletGuardianAPIDb",
                table: "Purchases",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_KategoryId",
                schema: "WalletGuardianAPIDb",
                table: "Subcategories",
                column: "KategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases",
                schema: "WalletGuardianAPIDb");

            migrationBuilder.DropTable(
                name: "MonthlyBudgetStatistics",
                schema: "WalletGuardianAPIDb");

            migrationBuilder.DropTable(
                name: "Shops",
                schema: "WalletGuardianAPIDb");

            migrationBuilder.DropTable(
                name: "Subcategories",
                schema: "WalletGuardianAPIDb");

            migrationBuilder.DropTable(
                name: "Kategories",
                schema: "WalletGuardianAPIDb");
        }
    }
}
