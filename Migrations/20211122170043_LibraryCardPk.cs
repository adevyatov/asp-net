using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApi.Migrations
{
    public partial class LibraryCardPk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "book_person_pk",
                table: "library_card");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "library_card",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "library_card_pk",
                table: "library_card",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_library_card_book_id",
                table: "library_card",
                column: "book_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "library_card_pk",
                table: "library_card");

            migrationBuilder.DropIndex(
                name: "IX_library_card_book_id",
                table: "library_card");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "library_card",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "book_person_pk",
                table: "library_card",
                columns: new[] { "book_id", "person_id" });
        }
    }
}
