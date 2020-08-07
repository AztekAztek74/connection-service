using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations.EarlyCompletionMigrations
{
    public partial class EarlyCompletionCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EarlyCompletions",
                columns: table => new
                {
                    EarlyCompletionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EarlyCompletionPhone = table.Column<int>(nullable: false),
                    EarlyCompletionCause = table.Column<string>(nullable: true),
                    OtherInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarlyCompletions", x => x.EarlyCompletionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EarlyCompletions");
        }
    }
}
