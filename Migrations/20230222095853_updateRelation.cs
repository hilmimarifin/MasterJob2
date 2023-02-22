using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterJob.Migrations
{
    /// <inheritdoc />
    public partial class updateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_job_position_title_id",
                table: "job_position",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_job_position_id",
                table: "employee",
                column: "job_position_id");

            migrationBuilder.AddForeignKey(
                name: "employee_fk",
                table: "employee",
                column: "job_position_id",
                principalTable: "job_position",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "job_position_fk",
                table: "job_position",
                column: "title_id",
                principalTable: "job_title",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "employee_fk",
                table: "employee");

            migrationBuilder.DropForeignKey(
                name: "job_position_fk",
                table: "job_position");

            migrationBuilder.DropIndex(
                name: "IX_job_position_title_id",
                table: "job_position");

            migrationBuilder.DropIndex(
                name: "IX_employee_job_position_id",
                table: "employee");
        }
    }
}
