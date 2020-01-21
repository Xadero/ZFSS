using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZfssUZData.Migrations
{
    public partial class add_benetifts_entities_21_01_2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenefitStatus",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BenefitType",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relatives",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelativeFullName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DegreeOfRelationship = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ApplicationUsersId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatives_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeLoanBenefit",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitNumber = table.Column<long>(nullable: false),
                    LoanCost = table.Column<long>(nullable: false),
                    Instalment = table.Column<int>(nullable: false),
                    Months = table.Column<int>(nullable: false),
                    LoanPurpose = table.Column<string>(nullable: true),
                    BenefitStatusId = table.Column<decimal>(nullable: false),
                    SubmittingDate = table.Column<DateTime>(nullable: false),
                    AcceptingDate = table.Column<DateTime>(nullable: true),
                    RejectingDate = table.Column<DateTime>(nullable: true),
                    BenefitTypeId = table.Column<decimal>(nullable: false),
                    AcceptingUserId = table.Column<string>(nullable: true),
                    RejectingUserId = table.Column<string>(nullable: true),
                    SubmittingUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeLoanBenefit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeLoanBenefit_AspNetUsers_AcceptingUserId",
                        column: x => x.AcceptingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeLoanBenefit_BenefitStatus_BenefitStatusId",
                        column: x => x.BenefitStatusId,
                        principalTable: "BenefitStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeLoanBenefit_BenefitType_BenefitTypeId",
                        column: x => x.BenefitTypeId,
                        principalTable: "BenefitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeLoanBenefit_AspNetUsers_RejectingUserId",
                        column: x => x.RejectingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeLoanBenefit_AspNetUsers_SubmittingUserId",
                        column: x => x.SubmittingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialServiceBenefit",
                columns: table => new
                {
                    Id = table.Column<decimal>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitNumber = table.Column<long>(nullable: false),
                    RelativesId = table.Column<decimal>(nullable: false),
                    BenefitStatusId = table.Column<decimal>(nullable: false),
                    SubmittingDate = table.Column<DateTime>(nullable: false),
                    AcceptingDate = table.Column<DateTime>(nullable: true),
                    RejectingDate = table.Column<DateTime>(nullable: true),
                    AcceptingUserId = table.Column<string>(nullable: true),
                    RejectingUserId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    BenefitTypeId = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialServiceBenefit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefit_AspNetUsers_AcceptingUserId",
                        column: x => x.AcceptingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefit_BenefitStatus_BenefitStatusId",
                        column: x => x.BenefitStatusId,
                        principalTable: "BenefitStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefit_BenefitType_BenefitTypeId",
                        column: x => x.BenefitTypeId,
                        principalTable: "BenefitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefit_AspNetUsers_RejectingUserId",
                        column: x => x.RejectingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefit_Relatives_RelativesId",
                        column: x => x.RelativesId,
                        principalTable: "Relatives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefit_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeLoanBenefit_AcceptingUserId",
                table: "HomeLoanBenefit",
                column: "AcceptingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeLoanBenefit_BenefitStatusId",
                table: "HomeLoanBenefit",
                column: "BenefitStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeLoanBenefit_BenefitTypeId",
                table: "HomeLoanBenefit",
                column: "BenefitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeLoanBenefit_RejectingUserId",
                table: "HomeLoanBenefit",
                column: "RejectingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeLoanBenefit_SubmittingUserId",
                table: "HomeLoanBenefit",
                column: "SubmittingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatives_ApplicationUsersId",
                table: "Relatives",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefit_AcceptingUserId",
                table: "SocialServiceBenefit",
                column: "AcceptingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefit_BenefitStatusId",
                table: "SocialServiceBenefit",
                column: "BenefitStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefit_BenefitTypeId",
                table: "SocialServiceBenefit",
                column: "BenefitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefit_RejectingUserId",
                table: "SocialServiceBenefit",
                column: "RejectingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefit_RelativesId",
                table: "SocialServiceBenefit",
                column: "RelativesId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefit_UserId",
                table: "SocialServiceBenefit",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeLoanBenefit");

            migrationBuilder.DropTable(
                name: "SocialServiceBenefit");

            migrationBuilder.DropTable(
                name: "BenefitStatus");

            migrationBuilder.DropTable(
                name: "BenefitType");

            migrationBuilder.DropTable(
                name: "Relatives");
        }
    }
}
