using Microsoft.EntityFrameworkCore.Migrations;

namespace ZfssUZData.Migrations
{
    public partial class _20_01_2018_ChangeTablesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefits_BenefitStatuses_BenefitStatusId",
                table: "HomeLoanBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefits_BenefitStatuses_BenefitStatusId",
                table: "SocialServiceBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefits_SocialServiceKinds_SocialServiceKindId",
                table: "SocialServiceBenefits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialServiceKinds",
                table: "SocialServiceKinds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BenefitStatuses",
                table: "BenefitStatuses");

            migrationBuilder.RenameTable(
                name: "UserGroups",
                newName: "UserGroup");

            migrationBuilder.RenameTable(
                name: "SocialServiceKinds",
                newName: "SocialServiceKind");

            migrationBuilder.RenameTable(
                name: "BenefitStatuses",
                newName: "BenefitStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialServiceKind",
                table: "SocialServiceKind",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BenefitStatus",
                table: "BenefitStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefits_BenefitStatus_BenefitStatusId",
                table: "HomeLoanBenefits",
                column: "BenefitStatusId",
                principalTable: "BenefitStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefits_BenefitStatus_BenefitStatusId",
                table: "SocialServiceBenefits",
                column: "BenefitStatusId",
                principalTable: "BenefitStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefits_SocialServiceKind_SocialServiceKindId",
                table: "SocialServiceBenefits",
                column: "SocialServiceKindId",
                principalTable: "SocialServiceKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefits_BenefitStatus_BenefitStatusId",
                table: "HomeLoanBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefits_BenefitStatus_BenefitStatusId",
                table: "SocialServiceBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefits_SocialServiceKind_SocialServiceKindId",
                table: "SocialServiceBenefits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialServiceKind",
                table: "SocialServiceKind");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BenefitStatus",
                table: "BenefitStatus");

            migrationBuilder.RenameTable(
                name: "UserGroup",
                newName: "UserGroups");

            migrationBuilder.RenameTable(
                name: "SocialServiceKind",
                newName: "SocialServiceKinds");

            migrationBuilder.RenameTable(
                name: "BenefitStatus",
                newName: "BenefitStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialServiceKinds",
                table: "SocialServiceKinds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BenefitStatuses",
                table: "BenefitStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefits_BenefitStatuses_BenefitStatusId",
                table: "HomeLoanBenefits",
                column: "BenefitStatusId",
                principalTable: "BenefitStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefits_BenefitStatuses_BenefitStatusId",
                table: "SocialServiceBenefits",
                column: "BenefitStatusId",
                principalTable: "BenefitStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefits_SocialServiceKinds_SocialServiceKindId",
                table: "SocialServiceBenefits",
                column: "SocialServiceKindId",
                principalTable: "SocialServiceKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
