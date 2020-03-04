using Microsoft.EntityFrameworkCore.Migrations;

namespace ZfssUZData.Migrations
{
    public partial class _04_03_2020_Change_average_Income_Column_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "SEQ_HomeLoanNumber");

            migrationBuilder.DropSequence(
                name: "SEQ_SocialServiceNumber");

            migrationBuilder.DropColumn(
                name: "AvreageIncome",
                table: "SocialServiceBenefit");

            migrationBuilder.CreateSequence<int>(
                name: "SEQ_HomeLoanNumber");

            migrationBuilder.CreateSequence<int>(
                name: "SEQ_SocialServiceNumber");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageIncome",
                table: "SocialServiceBenefit",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "SEQ_HomeLoanNumber");

            migrationBuilder.DropSequence(
                name: "SEQ_SocialServiceNumber");

            migrationBuilder.DropColumn(
                name: "AverageIncome",
                table: "SocialServiceBenefit");

            migrationBuilder.CreateSequence(
                name: "SEQ_HomeLoanNumber");

            migrationBuilder.CreateSequence(
                name: "SEQ_SocialServiceNumber");

            migrationBuilder.AddColumn<decimal>(
                name: "AvreageIncome",
                table: "SocialServiceBenefit",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
