using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddPhotoOfferType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoOfferTypeId",
                table: "PhotoOffers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PhotoOffersTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoOffersTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoOffers_PhotoOfferTypeId",
                table: "PhotoOffers",
                column: "PhotoOfferTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoOffers_PhotoOffersTypes_PhotoOfferTypeId",
                table: "PhotoOffers",
                column: "PhotoOfferTypeId",
                principalTable: "PhotoOffersTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoOffers_PhotoOffersTypes_PhotoOfferTypeId",
                table: "PhotoOffers");

            migrationBuilder.DropTable(
                name: "PhotoOffersTypes");

            migrationBuilder.DropIndex(
                name: "IX_PhotoOffers_PhotoOfferTypeId",
                table: "PhotoOffers");

            migrationBuilder.DropColumn(
                name: "PhotoOfferTypeId",
                table: "PhotoOffers");
        }
    }
}
