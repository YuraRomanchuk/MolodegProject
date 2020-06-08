using Microsoft.EntityFrameworkCore.Migrations;

namespace MolodegBackend.Migrations
{
    public partial class MainMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Supporter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Liked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supporter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supporter_Placards_CardId",
                        column: x => x.CardId,
                        principalTable: "Placards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supporter_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supporter_CardId",
                table: "Supporter",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Supporter_UserId",
                table: "Supporter",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supporter");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetUsers");
        }
    }
}
