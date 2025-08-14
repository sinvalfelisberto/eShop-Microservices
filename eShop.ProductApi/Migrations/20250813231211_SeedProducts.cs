using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
            "values ('Caderno', 7.55, 'Caderno simples', 10, 'caderno1.jpg', 1)");

            mb.Sql("insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
            "values ('Lápis', 3.45, 'Lápis Preto', 20, 'lapis1.jpg', 1)");

            mb.Sql("insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
            "values ('Clips', 5.33, 'Clips para papel', 50, 'clips1.jpg', 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from products");
        }
    }
}
