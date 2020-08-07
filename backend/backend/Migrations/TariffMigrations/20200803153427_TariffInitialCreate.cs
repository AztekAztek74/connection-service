using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations.TariffMigrations
{
    public partial class TariffInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    ServiceName = table.Column<string>(maxLength: 150, nullable: false),
                    ServicePrice = table.Column<int>(maxLength: 10, nullable: false),
                    ServiceDescription = table.Column<string>(maxLength: 250, nullable: false),
                    AccessibleCities = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.ServiceName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tariffs");
        }
    }
}
