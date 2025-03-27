using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZurichAssessment.Migrations
{
    /// <inheritdoc />
    public partial class DBv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "CoverageDetails",
                table: "InsurancePlans");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Benefits",
                table: "InsurancePlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoverageDetails",
                table: "InsurancePlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
