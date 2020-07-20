using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BNTU_fond.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditories",
                columns: table => new
                {
                    AuditoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FloorId = table.Column<int>(nullable: false),
                    AuditoryNum = table.Column<int>(nullable: false),
                    Places = table.Column<int>(nullable: true),
                    Computers = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditories", x => x.AuditoryId);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    FloorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildingId = table.Column<int>(nullable: false),
                    FloorNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.FloorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditories");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Floors");
        }
    }
}
