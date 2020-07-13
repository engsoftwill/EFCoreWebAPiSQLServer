using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreWebAPI.Migrations
{
    public partial class HeroisBatalhasSecretId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heros_Battles_BattleId",
                table: "Heros");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Heros_HeroId",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heros",
                table: "Heros");

            migrationBuilder.DropIndex(
                name: "IX_Heros_BattleId",
                table: "Heros");

            migrationBuilder.RenameTable(
                name: "Heros",
                newName: "Heroes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HeroBattles",
                columns: table => new
                {
                    HeroId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroBattles", x => new { x.BattleId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_HeroBattles_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroBattles_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Secretidentitys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RealName = table.Column<string>(nullable: true),
                    HeroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretidentitys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secretidentitys_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroBattles_HeroId",
                table: "HeroBattles",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Secretidentitys_HeroId",
                table: "Secretidentitys",
                column: "HeroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Heroes_HeroId",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "HeroBattles");

            migrationBuilder.DropTable(
                name: "Secretidentitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes");

            migrationBuilder.RenameTable(
                name: "Heroes",
                newName: "Heros");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heros",
                table: "Heros",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Heros_BattleId",
                table: "Heros",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heros_Battles_BattleId",
                table: "Heros",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Heros_HeroId",
                table: "Weapons",
                column: "HeroId",
                principalTable: "Heros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
