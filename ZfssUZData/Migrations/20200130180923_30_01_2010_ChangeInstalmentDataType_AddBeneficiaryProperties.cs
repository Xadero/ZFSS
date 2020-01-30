using Microsoft.EntityFrameworkCore.Migrations;

namespace ZfssUZData.Migrations
{
    public partial class _30_01_2010_ChangeInstalmentDataType_AddBeneficiaryProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AvreageIncome",
                table: "SocialServiceBenefit",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryAddress",
                table: "SocialServiceBenefit",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryName",
                table: "SocialServiceBenefit",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryPhoneNumber",
                table: "SocialServiceBenefit",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Instalment",
                table: "HomeLoanBenefit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryAddress",
                table: "HomeLoanBenefit",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryName",
                table: "HomeLoanBenefit",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryPhoneNumber",
                table: "HomeLoanBenefit",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiaryAddress",
                table: "SocialServiceBenefit");

            migrationBuilder.DropColumn(
                name: "BeneficiaryName",
                table: "SocialServiceBenefit");

            migrationBuilder.DropColumn(
                name: "BeneficiaryPhoneNumber",
                table: "SocialServiceBenefit");

            migrationBuilder.DropColumn(
                name: "BeneficiaryAddress",
                table: "HomeLoanBenefit");

            migrationBuilder.DropColumn(
                name: "BeneficiaryName",
                table: "HomeLoanBenefit");

            migrationBuilder.DropColumn(
                name: "BeneficiaryPhoneNumber",
                table: "HomeLoanBenefit");

            migrationBuilder.AlterColumn<float>(
                name: "AvreageIncome",
                table: "SocialServiceBenefit",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Instalment",
                table: "HomeLoanBenefit",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
