using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleGraphQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.Sql(@"
                INSERT INTO Manufacturers (Id, Name, Country)
                VALUES
                    (1, 'Apple', 'USA'),
                    (2, 'Samsung', 'South Korea'),
                    (3, 'Toyota', 'Japan'),
                    (4, 'BMW', 'Germany'),
                    (5, 'Sony', 'Japan'),
                    (6, 'Microsoft', 'USA'),
                    (7, 'Nestle', 'Switzerland'),
                    (8, 'LOréal', 'France'),
                    (9, 'Huawei', 'China'),
                    (10, 'Lenovo', 'China'),
                    (11, 'Ferrari', 'Italy'),
                    (12, 'Coca-Cola', 'USA'),
                    (13, 'Adidas', 'Germany'),
                    (14, 'Honda', 'Japan'),
                    (15, 'Amazon', 'USA'),
                    (16, 'Samsung Electronics', 'South Korea'),
                    (17, 'Volkswagen', 'Germany'),
                    (18, 'Airbus', 'France'),
                    (19, 'Xiaomi', 'China'),
                    (20, 'Fiat', 'Italy');
                ");
            
            migrationBuilder.Sql(@"
                INSERT INTO Products (Id, Name, ManufacturerId)
                VALUES
                    (1, 'iPhone', 1),
                    (2, 'Galaxy S21', 2),
                    (3, 'Camry', 3),
                    (4, 'X5', 4),
                    (5, 'PlayStation 5', 5),
                    (6, 'Surface Laptop', 6),
                    (7, 'KitKat', 7),
                    (8, 'Lipstick', 8),
                    (9, 'P40 Pro', 9),
                    (10, 'ThinkPad', 10),
                    (11, '488 GTB', 11),
                    (12, 'Coca-Cola Classic', 12),
                    (13, 'Ultraboost', 13),
                    (14, 'CR-V', 14),
                    (15, 'Kindle', 15),
                    (16, 'QLED TV', 16),
                    (17, 'Golf', 17),
                    (18, 'A380', 18),
                    (19, 'Mi 11', 19),
                    (20, '500', 20);
                ");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
