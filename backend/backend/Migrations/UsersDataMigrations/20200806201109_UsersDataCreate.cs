using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations.UsersDataMigrations
{
    public partial class UsersDataCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersDatas",
                columns: table => new
                {
                    Address = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    AdditionalPhone = table.Column<int>(nullable: false),
                    HandlingReason = table.Column<string>(nullable: false),
                    Coment = table.Column<string>(nullable: true),
                    SelectedTariffs = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDatas", x => x.Address);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersDatas");
        }
    }
}
