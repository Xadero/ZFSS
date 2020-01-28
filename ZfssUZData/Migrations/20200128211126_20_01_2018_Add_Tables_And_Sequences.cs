using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZfssUZData.Migrations
{
    public partial class _20_01_2018_Add_Tables_And_Sequences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SEQ_HomeLoanNumber");

            migrationBuilder.CreateSequence(
                name: "SEQ_SocialServiceNumber");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PostCode = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    UserGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BenefitStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BenefitType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialServiceKinds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialServiceKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeLoanBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitNumber = table.Column<long>(nullable: false),
                    LoanCost = table.Column<long>(nullable: false),
                    Instalment = table.Column<int>(nullable: false),
                    Months = table.Column<int>(nullable: false),
                    LoanPurpose = table.Column<string>(nullable: false),
                    BenefitStatusId = table.Column<int>(nullable: true),
                    SubmittingDate = table.Column<DateTime>(nullable: false),
                    SubmittingUserId = table.Column<string>(nullable: true),
                    AcceptingDate = table.Column<DateTime>(nullable: true),
                    AcceptingUserId = table.Column<string>(nullable: true),
                    RejectingDate = table.Column<DateTime>(nullable: true),
                    RejectingUserId = table.Column<string>(nullable: true),
                    RejectionReason = table.Column<string>(nullable: true),
                    BenefitTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeLoanBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeLoanBenefits_AspNetUsers_AcceptingUserId",
                        column: x => x.AcceptingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeLoanBenefits_BenefitStatuses_BenefitStatusId",
                        column: x => x.BenefitStatusId,
                        principalTable: "BenefitStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeLoanBenefits_BenefitType_BenefitTypeId",
                        column: x => x.BenefitTypeId,
                        principalTable: "BenefitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeLoanBenefits_AspNetUsers_RejectingUserId",
                        column: x => x.RejectingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeLoanBenefits_AspNetUsers_SubmittingUserId",
                        column: x => x.SubmittingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialServiceBenefits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenefitNumber = table.Column<long>(nullable: false),
                    BenefitStatusId = table.Column<int>(nullable: true),
                    SocialServiceKindId = table.Column<int>(nullable: true),
                    OtherSocialServiceKind = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    AvreageIncome = table.Column<float>(nullable: false),
                    AdditionInformation = table.Column<string>(nullable: true),
                    SubmittingDate = table.Column<DateTime>(nullable: false),
                    SubmittingUserId = table.Column<string>(nullable: true),
                    AcceptingDate = table.Column<DateTime>(nullable: true),
                    AcceptingUserId = table.Column<string>(nullable: true),
                    RejectingDate = table.Column<DateTime>(nullable: true),
                    RejectingUserId = table.Column<string>(nullable: true),
                    BenefitTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialServiceBenefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefits_AspNetUsers_AcceptingUserId",
                        column: x => x.AcceptingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefits_BenefitStatuses_BenefitStatusId",
                        column: x => x.BenefitStatusId,
                        principalTable: "BenefitStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefits_BenefitType_BenefitTypeId",
                        column: x => x.BenefitTypeId,
                        principalTable: "BenefitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefits_AspNetUsers_RejectingUserId",
                        column: x => x.RejectingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefits_SocialServiceKinds_SocialServiceKindId",
                        column: x => x.SocialServiceKindId,
                        principalTable: "SocialServiceKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialServiceBenefits_AspNetUsers_SubmittingUserId",
                        column: x => x.SubmittingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relatives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelativeFullName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DegreeOfRelationship = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: false),
                    SocialServiceBenefitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatives_SocialServiceBenefits_SocialServiceBenefitId",
                        column: x => x.SocialServiceBenefitId,
                        principalTable: "SocialServiceBenefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HomeLoanBenefits_AcceptingUserId",
                table: "HomeLoanBenefits",
                column: "AcceptingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeLoanBenefits_BenefitStatusId",
                table: "HomeLoanBenefits",
                column: "BenefitStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeLoanBenefits_BenefitTypeId",
                table: "HomeLoanBenefits",
                column: "BenefitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeLoanBenefits_RejectingUserId",
                table: "HomeLoanBenefits",
                column: "RejectingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeLoanBenefits_SubmittingUserId",
                table: "HomeLoanBenefits",
                column: "SubmittingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatives_SocialServiceBenefitId",
                table: "Relatives",
                column: "SocialServiceBenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefits_AcceptingUserId",
                table: "SocialServiceBenefits",
                column: "AcceptingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefits_BenefitStatusId",
                table: "SocialServiceBenefits",
                column: "BenefitStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefits_BenefitTypeId",
                table: "SocialServiceBenefits",
                column: "BenefitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefits_RejectingUserId",
                table: "SocialServiceBenefits",
                column: "RejectingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefits_SocialServiceKindId",
                table: "SocialServiceBenefits",
                column: "SocialServiceKindId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialServiceBenefits_SubmittingUserId",
                table: "SocialServiceBenefits",
                column: "SubmittingUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HomeLoanBenefits");

            migrationBuilder.DropTable(
                name: "Relatives");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SocialServiceBenefits");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BenefitStatuses");

            migrationBuilder.DropTable(
                name: "BenefitType");

            migrationBuilder.DropTable(
                name: "SocialServiceKinds");

            migrationBuilder.DropSequence(
                name: "SEQ_HomeLoanNumber");

            migrationBuilder.DropSequence(
                name: "SEQ_SocialServiceNumber");
        }
    }
}
