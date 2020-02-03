using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZfssUZData.Migrations
{
    public partial class _03_02_2020_Add_Employment_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfEmployment",
                table: "SocialServiceBenefit",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "SocialServiceBenefit",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfEmployment",
                table: "SocialServiceBenefit");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "SocialServiceBenefit");
        }
    }
}
