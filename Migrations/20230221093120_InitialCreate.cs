using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterJob.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    job_position_id = table.Column<string>(type: "character varying", nullable: true),
                    job_title_id = table.Column<string>(type: "character varying", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    nik = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_position",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying", nullable: false),
                    code = table.Column<string>(type: "character varying", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    title_id = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_position_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_title",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying", nullable: false),
                    code = table.Column<string>(type: "character varying", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_title_pk", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "job_position");

            migrationBuilder.DropTable(
                name: "job_title");
        }
    }
}
