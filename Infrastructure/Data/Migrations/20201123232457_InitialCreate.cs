using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoOffersCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoOffersCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: false),
                    NumberOfPhotos = table.Column<int>(nullable: false),
                    IsAlbumIncluded = table.Column<bool>(nullable: false),
                    PhotoOfferCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoOffers_PhotoOffersCategories_PhotoOfferCategoryId",
                        column: x => x.PhotoOfferCategoryId,
                        principalTable: "PhotoOffersCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoOffers_PhotoOfferCategoryId",
                table: "PhotoOffers",
                column: "PhotoOfferCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoOffers");

            migrationBuilder.DropTable(
                name: "PhotoOffersCategories");
        }
    }
}
