using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagementBackEnd.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false),
                    Zip = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    OrderCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "CustomerId", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, "Daily Item", 1, "Basket", "2lb" },
                    { 11, "Vegetable", 11, "Cabbage", "1lb" },
                    { 10, "Meat", 10, "Chicken Meat", "4lb" },
                    { 9, "Meat", 9, "Moose Meat", "8lb" },
                    { 8, "Meat", 8, "Deer Meat", "7lb" },
                    { 7, "Meat", 7, "Goose Meat", "6lb" },
                    { 12, "Fruit", 12, "Apple", "1lb" },
                    { 5, "Meat", 5, "Bass Meat", "5lb" },
                    { 4, "Meat", 4, "Perch Meat", "3lb" },
                    { 3, "Daily Item", 3, "Needles", "1lb" },
                    { 2, "Daily Item", 2, "Yarn", "2lb" },
                    { 6, "Meat", 6, "Walleye Meat", "1lb" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 10, "NJ", "Newfoundland and Labrador" },
                    { 9, "NU", "Nunavut" },
                    { 8, "NB", "New Brunswick" },
                    { 7, "NT", "Northwest Territories" },
                    { 6, "YT", "Yukon" },
                    { 4, "AB", "Alberta" },
                    { 3, "QC", "Quebec" },
                    { 2, "ON", "Ontario" },
                    { 1, "BC", "British Columbia" },
                    { 11, "NS", "Nova Scotia" },
                    { 5, "MB", "Manitoba" },
                    { 12, "PE", "Prince Edward Island" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Email", "FirstName", "Gender", "LastName", "OrderCount", "ProvinceId", "Zip" },
                values: new object[,]
                {
                    { 1, "1234 Anywhere St.", "Marcus.HighTower@acmecorp.com", "Marcus", "Male", "HighTower", 0, 1, 85229 },
                    { 2, "435 Main St.", "Jesse.Smith@gmail.com", "Jesse", "Female", "Smith", 0, 2, 85230 },
                    { 3, "1 Atomic St.", "Albert.Einstein@outlook.com", "Albert", "Male", "Einstein", 0, 3, 85231 },
                    { 4, "85 Cedar Dr.", "Dan.Wahlin@yahoo.com", "Dan", "Male", "Wahlin", 0, 4, 85232 },
                    { 5, "12 Ocean View St.", "Ward.Bell@gmail.com", "Ward", "Male", "Bell", 0, 5, 85233 },
                    { 6, "1600 Amphitheatre Parkway", "Brad.Green@gmail.com", "Brad", "Male", "Green", 0, 6, 85234 },
                    { 7, "1604 Amphitheatre Parkway", "Igor.Minar@gmail.com", "Igor", "Male", "Minar", 0, 7, 85235 },
                    { 8, "1607 Amphitheatre Parkway", "Miško.Hevery@gmail.com", "Miško", "Male", "Hevery", 0, 8, 85236 },
                    { 9, "346 Cedar Ave.", "Michelle.Avery@acmecorp.com", "Michelle", "Female", "Avery", 0, 9, 85237 },
                    { 10, "4576 Main St.", "Heedy.Wahlin@hotmail.com", "Heedy", "Female", "Wahlin", 0, 10, 85238 },
                    { 11, "964 Point St.", "Thomas.Martin@outlook.com", "Thomas", "Male", "Martin", 0, 11, 85239 },
                    { 12, "98756 Center St.", "Jean.Martin@outlook.com", "Jean", "Female", "Martin", 0, 12, 85240 }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "Price", "Product", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 29.99m, "Basket", 1 },
                    { 2, 2, 9.99m, "Yarn", 1 },
                    { 3, 3, 5.99m, "Needes", 1 },
                    { 4, 4, 499.99m, "Speakers", 1 },
                    { 5, 5, 399.99m, "iPod", 1 },
                    { 6, 6, 329.99m, "Table", 1 },
                    { 7, 7, 129.99m, "Chair", 4 },
                    { 8, 8, 89.99m, "Lamp", 5 },
                    { 9, 9, 59.99m, "Call of Duty", 1 },
                    { 10, 10, 49.99m, "Controller", 1 },
                    { 11, 11, 49.99m, "Gears of War", 1 },
                    { 12, 12, 49.99m, "Lego City", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ProvinceId",
                table: "Customer",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
