using Microsoft.EntityFrameworkCore.Migrations;

namespace ZfssUZData.Migrations
{
    public partial class _24_02_2020_AddRejectionDateToSocialServiceBenefit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "SocialServiceBenefit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "SocialServiceBenefit");
        }
    }
}
