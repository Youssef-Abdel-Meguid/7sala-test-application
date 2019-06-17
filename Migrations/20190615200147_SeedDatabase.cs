using Microsoft.EntityFrameworkCore.Migrations;

namespace _7salatestapplication.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql("Insert into categories (Name) values ('Category 1')");
            migrationBuilder.Sql("Insert into categories (Name) values ('Category 2')");
            migrationBuilder.Sql("Insert into categories (Name) values ('Category 3')");

            migrationBuilder.Sql("Insert into products (Name, Price, Description, Image, CategoryId) values ('Product 1', 75.5, 'Haha', 'Image 1', 1)");
            migrationBuilder.Sql("Insert into products (Name, Price, Description, Image, CategoryId) values ('Product 2', 85.5, 'Haha', 'Image 2', 2)");
            migrationBuilder.Sql("Insert into products (Name, Price, Description, Image, CategoryId) values ('Product 3', 95.5, 'Haha', 'Image 3', 3)");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
