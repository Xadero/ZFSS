using Microsoft.EntityFrameworkCore.Migrations;

namespace ZfssUZData.Migrations
{
    public partial class _20_01_2018_ChangeTablesNamesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefits_AspNetUsers_AcceptingUserId",
                table: "HomeLoanBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefits_BenefitStatus_BenefitStatusId",
                table: "HomeLoanBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefits_BenefitType_BenefitTypeId",
                table: "HomeLoanBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefits_AspNetUsers_RejectingUserId",
                table: "HomeLoanBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefits_AspNetUsers_SubmittingUserId",
                table: "HomeLoanBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_Relatives_SocialServiceBenefits_SocialServiceBenefitId",
                table: "Relatives");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefits_AspNetUsers_AcceptingUserId",
                table: "SocialServiceBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefits_BenefitStatus_BenefitStatusId",
                table: "SocialServiceBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefits_BenefitType_BenefitTypeId",
                table: "SocialServiceBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefits_AspNetUsers_RejectingUserId",
                table: "SocialServiceBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefits_SocialServiceKind_SocialServiceKindId",
                table: "SocialServiceBenefits");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefits_AspNetUsers_SubmittingUserId",
                table: "SocialServiceBenefits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialServiceBenefits",
                table: "SocialServiceBenefits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeLoanBenefits",
                table: "HomeLoanBenefits");

            migrationBuilder.RenameTable(
                name: "SocialServiceBenefits",
                newName: "SocialServiceBenefit");

            migrationBuilder.RenameTable(
                name: "HomeLoanBenefits",
                newName: "HomeLoanBenefit");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefits_SubmittingUserId",
                table: "SocialServiceBenefit",
                newName: "IX_SocialServiceBenefit_SubmittingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefits_SocialServiceKindId",
                table: "SocialServiceBenefit",
                newName: "IX_SocialServiceBenefit_SocialServiceKindId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefits_RejectingUserId",
                table: "SocialServiceBenefit",
                newName: "IX_SocialServiceBenefit_RejectingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefits_BenefitTypeId",
                table: "SocialServiceBenefit",
                newName: "IX_SocialServiceBenefit_BenefitTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefits_BenefitStatusId",
                table: "SocialServiceBenefit",
                newName: "IX_SocialServiceBenefit_BenefitStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefits_AcceptingUserId",
                table: "SocialServiceBenefit",
                newName: "IX_SocialServiceBenefit_AcceptingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeLoanBenefits_SubmittingUserId",
                table: "HomeLoanBenefit",
                newName: "IX_HomeLoanBenefit_SubmittingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeLoanBenefits_RejectingUserId",
                table: "HomeLoanBenefit",
                newName: "IX_HomeLoanBenefit_RejectingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeLoanBenefits_BenefitTypeId",
                table: "HomeLoanBenefit",
                newName: "IX_HomeLoanBenefit_BenefitTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeLoanBenefits_BenefitStatusId",
                table: "HomeLoanBenefit",
                newName: "IX_HomeLoanBenefit_BenefitStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeLoanBenefits_AcceptingUserId",
                table: "HomeLoanBenefit",
                newName: "IX_HomeLoanBenefit_AcceptingUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialServiceBenefit",
                table: "SocialServiceBenefit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeLoanBenefit",
                table: "HomeLoanBenefit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefit_AspNetUsers_AcceptingUserId",
                table: "HomeLoanBenefit",
                column: "AcceptingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefit_BenefitStatus_BenefitStatusId",
                table: "HomeLoanBenefit",
                column: "BenefitStatusId",
                principalTable: "BenefitStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefit_BenefitType_BenefitTypeId",
                table: "HomeLoanBenefit",
                column: "BenefitTypeId",
                principalTable: "BenefitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefit_AspNetUsers_RejectingUserId",
                table: "HomeLoanBenefit",
                column: "RejectingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefit_AspNetUsers_SubmittingUserId",
                table: "HomeLoanBenefit",
                column: "SubmittingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relatives_SocialServiceBenefit_SocialServiceBenefitId",
                table: "Relatives",
                column: "SocialServiceBenefitId",
                principalTable: "SocialServiceBenefit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefit_AspNetUsers_AcceptingUserId",
                table: "SocialServiceBenefit",
                column: "AcceptingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefit_BenefitStatus_BenefitStatusId",
                table: "SocialServiceBenefit",
                column: "BenefitStatusId",
                principalTable: "BenefitStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefit_BenefitType_BenefitTypeId",
                table: "SocialServiceBenefit",
                column: "BenefitTypeId",
                principalTable: "BenefitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefit_AspNetUsers_RejectingUserId",
                table: "SocialServiceBenefit",
                column: "RejectingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefit_SocialServiceKind_SocialServiceKindId",
                table: "SocialServiceBenefit",
                column: "SocialServiceKindId",
                principalTable: "SocialServiceKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefit_AspNetUsers_SubmittingUserId",
                table: "SocialServiceBenefit",
                column: "SubmittingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefit_AspNetUsers_AcceptingUserId",
                table: "HomeLoanBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefit_BenefitStatus_BenefitStatusId",
                table: "HomeLoanBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefit_BenefitType_BenefitTypeId",
                table: "HomeLoanBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefit_AspNetUsers_RejectingUserId",
                table: "HomeLoanBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeLoanBenefit_AspNetUsers_SubmittingUserId",
                table: "HomeLoanBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_Relatives_SocialServiceBenefit_SocialServiceBenefitId",
                table: "Relatives");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefit_AspNetUsers_AcceptingUserId",
                table: "SocialServiceBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefit_BenefitStatus_BenefitStatusId",
                table: "SocialServiceBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefit_BenefitType_BenefitTypeId",
                table: "SocialServiceBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefit_AspNetUsers_RejectingUserId",
                table: "SocialServiceBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefit_SocialServiceKind_SocialServiceKindId",
                table: "SocialServiceBenefit");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialServiceBenefit_AspNetUsers_SubmittingUserId",
                table: "SocialServiceBenefit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialServiceBenefit",
                table: "SocialServiceBenefit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeLoanBenefit",
                table: "HomeLoanBenefit");

            migrationBuilder.RenameTable(
                name: "SocialServiceBenefit",
                newName: "SocialServiceBenefits");

            migrationBuilder.RenameTable(
                name: "HomeLoanBenefit",
                newName: "HomeLoanBenefits");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefit_SubmittingUserId",
                table: "SocialServiceBenefits",
                newName: "IX_SocialServiceBenefits_SubmittingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefit_SocialServiceKindId",
                table: "SocialServiceBenefits",
                newName: "IX_SocialServiceBenefits_SocialServiceKindId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefit_RejectingUserId",
                table: "SocialServiceBenefits",
                newName: "IX_SocialServiceBenefits_RejectingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefit_BenefitTypeId",
                table: "SocialServiceBenefits",
                newName: "IX_SocialServiceBenefits_BenefitTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefit_BenefitStatusId",
                table: "SocialServiceBenefits",
                newName: "IX_SocialServiceBenefits_BenefitStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialServiceBenefit_AcceptingUserId",
                table: "SocialServiceBenefits",
                newName: "IX_SocialServiceBenefits_AcceptingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeLoanBenefit_SubmittingUserId",
                table: "HomeLoanBenefits",
                newName: "IX_HomeLoanBenefits_SubmittingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeLoanBenefit_RejectingUserId",
                table: "HomeLoanBenefits",
                newName: "IX_HomeLoanBenefits_RejectingUserId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeLoanBenefit_BenefitTypeId",
                table: "HomeLoanBenefits",
                newName: "IX_HomeLoanBenefits_BenefitTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeLoanBenefit_BenefitStatusId",
                table: "HomeLoanBenefits",
                newName: "IX_HomeLoanBenefits_BenefitStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeLoanBenefit_AcceptingUserId",
                table: "HomeLoanBenefits",
                newName: "IX_HomeLoanBenefits_AcceptingUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialServiceBenefits",
                table: "SocialServiceBenefits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeLoanBenefits",
                table: "HomeLoanBenefits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefits_AspNetUsers_AcceptingUserId",
                table: "HomeLoanBenefits",
                column: "AcceptingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefits_BenefitStatus_BenefitStatusId",
                table: "HomeLoanBenefits",
                column: "BenefitStatusId",
                principalTable: "BenefitStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefits_BenefitType_BenefitTypeId",
                table: "HomeLoanBenefits",
                column: "BenefitTypeId",
                principalTable: "BenefitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefits_AspNetUsers_RejectingUserId",
                table: "HomeLoanBenefits",
                column: "RejectingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeLoanBenefits_AspNetUsers_SubmittingUserId",
                table: "HomeLoanBenefits",
                column: "SubmittingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relatives_SocialServiceBenefits_SocialServiceBenefitId",
                table: "Relatives",
                column: "SocialServiceBenefitId",
                principalTable: "SocialServiceBenefits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefits_AspNetUsers_AcceptingUserId",
                table: "SocialServiceBenefits",
                column: "AcceptingUserId",
                principalTable: "AspNetUsers",
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
                name: "FK_SocialServiceBenefits_BenefitType_BenefitTypeId",
                table: "SocialServiceBenefits",
                column: "BenefitTypeId",
                principalTable: "BenefitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefits_AspNetUsers_RejectingUserId",
                table: "SocialServiceBenefits",
                column: "RejectingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefits_SocialServiceKind_SocialServiceKindId",
                table: "SocialServiceBenefits",
                column: "SocialServiceKindId",
                principalTable: "SocialServiceKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialServiceBenefits_AspNetUsers_SubmittingUserId",
                table: "SocialServiceBenefits",
                column: "SubmittingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
