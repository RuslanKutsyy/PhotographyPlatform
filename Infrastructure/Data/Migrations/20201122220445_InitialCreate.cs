using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotoshootCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoshootCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photoshoots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(nullable: false),
                    PhotoshootCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photoshoots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photoshoots_PhotoshootCategories_PhotoshootCategoryId",
                        column: x => x.PhotoshootCategoryId,
                        principalTable: "PhotoshootCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photoshoots_PhotoshootCategoryId",
                table: "Photoshoots",
                column: "PhotoshootCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photoshoots");

            migrationBuilder.DropTable(
                name: "PhotoshootCategories");
        }
    }
}
