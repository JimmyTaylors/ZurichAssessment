using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZurichAssessment.Migrations
{
    /// <inheritdoc />
    public partial class V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePlanOtherInfo_InsurancePlans_InsurancePlanId",
                table: "InsurancePlanOtherInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsurancePlanOtherInfo",
                table: "InsurancePlanOtherInfo");

            migrationBuilder.RenameTable(
                name: "InsurancePlanOtherInfo",
                newName: "InsurancePlanOtherInfos");

            migrationBuilder.RenameIndex(
                name: "IX_InsurancePlanOtherInfo_InsurancePlanId",
                table: "InsurancePlanOtherInfos",
                newName: "IX_InsurancePlanOtherInfos_InsurancePlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsurancePlanOtherInfos",
                table: "InsurancePlanOtherInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePlanOtherInfos_InsurancePlans_InsurancePlanId",
                table: "InsurancePlanOtherInfos",
                column: "InsurancePlanId",
                principalTable: "InsurancePlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePlanOtherInfos_InsurancePlans_InsurancePlanId",
                table: "InsurancePlanOtherInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsurancePlanOtherInfos",
                table: "InsurancePlanOtherInfos");

            migrationBuilder.RenameTable(
                name: "InsurancePlanOtherInfos",
                newName: "InsurancePlanOtherInfo");

            migrationBuilder.RenameIndex(
                name: "IX_InsurancePlanOtherInfos_InsurancePlanId",
                table: "InsurancePlanOtherInfo",
                newName: "IX_InsurancePlanOtherInfo_InsurancePlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsurancePlanOtherInfo",
                table: "InsurancePlanOtherInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePlanOtherInfo_InsurancePlans_InsurancePlanId",
                table: "InsurancePlanOtherInfo",
                column: "InsurancePlanId",
                principalTable: "InsurancePlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
