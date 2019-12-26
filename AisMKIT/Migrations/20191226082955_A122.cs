using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class A122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Contacts = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictAgeRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictAgeRestrictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictCountry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictDuration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictDuration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictEduInstType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictEduInstType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictMediaDistribTerritory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictMediaDistribTerritory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictRegion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictRegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictRegiser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Patronic = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictRegiser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictStatus", x => x.Id);
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
                    DepartmentsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DictDistrict",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    DictRegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictDistrict", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictDistrict_DictRegion_DictRegionId",
                        column: x => x.DictRegionId,
                        principalTable: "DictRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DictAgencyPerm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictAgencyPerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictAgencyPerm_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictAwardsPosition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictAwardsPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictAwardsPosition_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictAwardsReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictAwardsReason", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictAwardsReason_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictCinematographyServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictCinematographyServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictCinematographyServices_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictControlType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictControlType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictControlType_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictCultAndArtType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictCultAndArtType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictCultAndArtType_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictFinSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictFinSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictFinSource_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictLegalForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictLegalForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictLegalForm_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictMediaControlResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictMediaControlResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictMediaControlResult_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictMediaFreqRelease",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictMediaFreqRelease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictMediaFreqRelease_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictMediaLangType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictMediaLangType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictMediaLangType_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictMediaSuitPerm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictMediaSuitPerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictMediaSuitPerm_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictMediaType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictMediaType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictMediaType_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictMonumemtSignOfLoss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictMonumemtSignOfLoss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictMonumemtSignOfLoss_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictMonumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictMonumentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictMonumentType_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictMonumentTypologicalType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictMonumentTypologicalType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictMonumentTypologicalType_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictStateAwardsType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictStateAwardsType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictStateAwardsType_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictTheatricalHall",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictTheatricalHall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictTheatricalHall_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DictTourismServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictTourismServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictTourismServices_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictUnitOfMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictUnitOfMeasure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictUnitOfMeasure_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "ListOfCinematographyCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictCountryId = table.Column<int>(nullable: true),
                    Years = table.Column<string>(nullable: true),
                    DictRegiserId = table.Column<int>(nullable: true),
                    DictDurationId = table.Column<int>(nullable: true),
                    DictAgeRestrictionsId = table.Column<int>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCinematographyCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyCertificates_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyCertificates_DictAgeRestrictions_DictAgeRestrictionsId",
                        column: x => x.DictAgeRestrictionsId,
                        principalTable: "DictAgeRestrictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyCertificates_DictCountry_DictCountryId",
                        column: x => x.DictCountryId,
                        principalTable: "DictCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyCertificates_DictDuration_DictDurationId",
                        column: x => x.DictDurationId,
                        principalTable: "DictDuration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyCertificates_DictRegiser_DictRegiserId",
                        column: x => x.DictRegiserId,
                        principalTable: "DictRegiser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfLibraryIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryName = table.Column<string>(nullable: true),
                    DataSozdania = table.Column<DateTime>(nullable: false),
                    CountOfBook = table.Column<string>(nullable: true),
                    CountOfReaders = table.Column<string>(nullable: true),
                    CountOfEmp = table.Column<string>(nullable: true),
                    Knigovydacha = table.Column<string>(nullable: true),
                    AddressData = table.Column<string>(nullable: true),
                    TotalArea = table.Column<string>(nullable: true),
                    SeatLanding = table.Column<string>(nullable: true),
                    EmerCapLib = table.Column<string>(nullable: true),
                    SpecAdapLib = table.Column<string>(nullable: true),
                    OverhaulMade = table.Column<string>(nullable: true),
                    Redecorated = table.Column<string>(nullable: true),
                    Computers = table.Column<string>(nullable: true),
                    InternetConnection = table.Column<string>(nullable: true),
                    ComputersForUsers = table.Column<string>(nullable: true),
                    UserConnection = table.Column<string>(nullable: true),
                    UsersLib = table.Column<string>(nullable: true),
                    RecRetTotal = table.Column<string>(nullable: true),
                    TotalNumOfEx = table.Column<string>(nullable: true),
                    CopKyrg = table.Column<string>(nullable: true),
                    EventsLib = table.Column<string>(nullable: true),
                    Librarians = table.Column<string>(nullable: true),
                    DegEducation = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfLibraryIndicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfLibraryIndicators_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTourismIndicator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(nullable: true),
                    GDP = table.Column<string>(nullable: true),
                    InTurist = table.Column<string>(nullable: true),
                    OutTurist = table.Column<string>(nullable: true),
                    VolumeOfServicesForExport = table.Column<string>(nullable: true),
                    VolumeOfServicesForImport = table.Column<string>(nullable: true),
                    SummOfInvestFromBudget = table.Column<string>(nullable: true),
                    SummOfPrivateDomesticInvest = table.Column<string>(nullable: true),
                    SummOfForeignInvest = table.Column<string>(nullable: true),
                    AverageMonthSalary = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTourismIndicator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTourismIndicator_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCinematography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    FactDistrictId = table.Column<string>(nullable: true),
                    LegalFactAddress = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCinematography", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCinematography_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematography_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematography_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematography_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCultAndArt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictCultAndArtTypeId = table.Column<int>(nullable: false),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCultAndArt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCultAndArt_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCultAndArt_DictCultAndArtType_DictCultAndArtTypeId",
                        column: x => x.DictCultAndArtTypeId,
                        principalTable: "DictCultAndArtType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfCultAndArt_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCultAndArt_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCultAndArt_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfEduInstituts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    DictEduInstTypeId = table.Column<int>(nullable: false),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfEduInstituts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfEduInstituts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfEduInstituts_DictEduInstType_DictEduInstTypeId",
                        column: x => x.DictEduInstTypeId,
                        principalTable: "DictEduInstType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfEduInstituts_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfEduInstituts_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTheatrical",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    LastNameOfArtsDirector = table.Column<string>(nullable: true),
                    FirstNameOfArtsDirector = table.Column<string>(nullable: true),
                    PatronicNameOfArtsDirector = table.Column<string>(nullable: true),
                    NumEmployees = table.Column<int>(nullable: false),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTheatrical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTheatrical_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTheatrical_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTheatrical_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTheatricalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOfTheatricalId = table.Column<int>(nullable: false),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    LastNameOfArtsDirector = table.Column<string>(nullable: true),
                    FirstNameOfArtsDirector = table.Column<string>(nullable: true),
                    PatronicNameOfArtsDirector = table.Column<string>(nullable: true),
                    NumEmployees = table.Column<int>(nullable: false),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTheatricalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTheatricalHistory_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTheatricalHistory_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTheatricalHistory_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTourism",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    FactDistrictId = table.Column<string>(nullable: true),
                    LegalFactAddress = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTourism", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTourism_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourism_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourism_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourism_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Territoryy = table.Column<string>(nullable: true),
                    DictMediaLangTypeId = table.Column<int>(nullable: true),
                    DictMediaTypeId = table.Column<int>(nullable: true),
                    AddressRus = table.Column<string>(nullable: true),
                    AddressKyrg = table.Column<string>(nullable: true),
                    DictMediaFreqReleaseId = table.Column<int>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    EliminationDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictMediaFreqRelease_DictMediaFreqReleaseId",
                        column: x => x.DictMediaFreqReleaseId,
                        principalTable: "DictMediaFreqRelease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictMediaLangType_DictMediaLangTypeId",
                        column: x => x.DictMediaLangTypeId,
                        principalTable: "DictMediaLangType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictMediaType_DictMediaTypeId",
                        column: x => x.DictMediaTypeId,
                        principalTable: "DictMediaType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfMonuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DatingOfMonument = table.Column<string>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    DictMonumentTypeId = table.Column<int>(nullable: false),
                    DictMonumemtSignOfLossId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfMonuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfMonuments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMonuments_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMonuments_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMonuments_DictMonumemtSignOfLoss_DictMonumemtSignOfLossId",
                        column: x => x.DictMonumemtSignOfLossId,
                        principalTable: "DictMonumemtSignOfLoss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfMonuments_DictMonumentType_DictMonumentTypeId",
                        column: x => x.DictMonumentTypeId,
                        principalTable: "DictMonumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfStateAwards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    DictStateAwardsTypeId = table.Column<int>(nullable: false),
                    DictAwardsPositionId = table.Column<int>(nullable: true),
                    DictAwardsReasonId = table.Column<int>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfStateAwards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfStateAwards_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfStateAwards_DictAwardsPosition_DictAwardsPositionId",
                        column: x => x.DictAwardsPositionId,
                        principalTable: "DictAwardsPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfStateAwards_DictAwardsReason_DictAwardsReasonId",
                        column: x => x.DictAwardsReasonId,
                        principalTable: "DictAwardsReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfStateAwards_DictStateAwardsType_DictStateAwardsTypeId",
                        column: x => x.DictStateAwardsTypeId,
                        principalTable: "DictStateAwardsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DictRentObjectType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictUnitOfMeasureId = table.Column<int>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictRentObjectType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictRentObjectType_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DictRentObjectType_DictUnitOfMeasure_DictUnitOfMeasureId",
                        column: x => x.DictUnitOfMeasureId,
                        principalTable: "DictUnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCinematographyHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOfCinematographyId = table.Column<int>(nullable: false),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    FactDistrictId = table.Column<string>(nullable: true),
                    LegalFactAddress = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCinematographyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyHistory_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyHistory_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyHistory_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyHistory_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyHistory_ListOfCinematography_ListOfCinematographyId",
                        column: x => x.ListOfCinematographyId,
                        principalTable: "ListOfCinematography",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCinematographyServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictCinematographyServicesId = table.Column<int>(nullable: false),
                    ListOfCinematographyId = table.Column<int>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: false),
                    DeactivateStatus = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCinematographyServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyServices_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyServices_DictCinematographyServices_DictCinematographyServicesId",
                        column: x => x.DictCinematographyServicesId,
                        principalTable: "DictCinematographyServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyServices_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyServices_ListOfCinematography_ListOfCinematographyId",
                        column: x => x.ListOfCinematographyId,
                        principalTable: "ListOfCinematography",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCouncilTheatrical",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOfTheatricalId = table.Column<int>(nullable: false),
                    LastNameOfArts = table.Column<string>(nullable: true),
                    FirstNameOfArts = table.Column<string>(nullable: true),
                    PatronicNameOfArts = table.Column<string>(nullable: true),
                    DateInArtCouncil = table.Column<DateTime>(nullable: false),
                    DateOutArtCouncil = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCouncilTheatrical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCouncilTheatrical_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCouncilTheatrical_ListOfTheatrical_ListOfTheatricalId",
                        column: x => x.ListOfTheatricalId,
                        principalTable: "ListOfTheatrical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfEventsTheatrical",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOfTheatricalId = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: true),
                    Month = table.Column<string>(nullable: true),
                    DayOfMonth = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    NameOfEvent = table.Column<string>(nullable: true),
                    DictTheatricalHallId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfEventsTheatrical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfEventsTheatrical_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfEventsTheatrical_DictTheatricalHall_DictTheatricalHallId",
                        column: x => x.DictTheatricalHallId,
                        principalTable: "DictTheatricalHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfEventsTheatrical_ListOfTheatrical_ListOfTheatricalId",
                        column: x => x.ListOfTheatricalId,
                        principalTable: "ListOfTheatrical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTourismHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOfTourismId = table.Column<int>(nullable: false),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    FactDistrictId = table.Column<string>(nullable: true),
                    LegalFactAddress = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTourismHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTourismHistory_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourismHistory_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourismHistory_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourismHistory_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourismHistory_ListOfTourism_ListOfTourismId",
                        column: x => x.ListOfTourismId,
                        principalTable: "ListOfTourism",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTourismServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictTourismServicesId = table.Column<int>(nullable: false),
                    ListOfTourismId = table.Column<int>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: false),
                    DeactivateStatus = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTourismServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTourismServices_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourismServices_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfTourismServices_DictTourismServices_DictTourismServicesId",
                        column: x => x.DictTourismServicesId,
                        principalTable: "DictTourismServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfTourismServices_ListOfTourism_ListOfTourismId",
                        column: x => x.ListOfTourismId,
                        principalTable: "ListOfTourism",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfControlMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOfMediaId = table.Column<int>(nullable: false),
                    DictControlTypeId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    StartDatePeriod = table.Column<DateTime>(nullable: true),
                    EndDatePeriod = table.Column<DateTime>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    PatronicName = table.Column<string>(nullable: true),
                    ActDateControl = table.Column<DateTime>(nullable: true),
                    NumberOfAct = table.Column<string>(nullable: true),
                    DictMediaControlResultId = table.Column<int>(nullable: true),
                    NumberOfWarning = table.Column<string>(nullable: true),
                    WarningDate = table.Column<DateTime>(nullable: true),
                    WarningEndDate = table.Column<DateTime>(nullable: true),
                    WarningRemovalDate = table.Column<DateTime>(nullable: true),
                    DateOfPenalty = table.Column<DateTime>(nullable: true),
                    DocNumPenalty = table.Column<string>(nullable: true),
                    PenaltySum = table.Column<string>(nullable: true),
                    DateOfPenaltyPay = table.Column<DateTime>(nullable: true),
                    AnulmentDate = table.Column<DateTime>(nullable: true),
                    NumberOfAnulment = table.Column<string>(nullable: true),
                    DateOfSuit = table.Column<DateTime>(nullable: true),
                    NumberOfSuit = table.Column<string>(nullable: true),
                    DateOfSuitPerm = table.Column<DateTime>(nullable: true),
                    NumberOfSuitPerm = table.Column<string>(nullable: true),
                    DictMediaSuitPermId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfControlMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfControlMedia_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfControlMedia_DictControlType_DictControlTypeId",
                        column: x => x.DictControlTypeId,
                        principalTable: "DictControlType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfControlMedia_DictMediaControlResult_DictMediaControlResultId",
                        column: x => x.DictMediaControlResultId,
                        principalTable: "DictMediaControlResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfControlMedia_DictMediaSuitPerm_DictMediaSuitPermId",
                        column: x => x.DictMediaSuitPermId,
                        principalTable: "DictMediaSuitPerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfControlMedia_ListOfMedia_ListOfMediaId",
                        column: x => x.ListOfMediaId,
                        principalTable: "ListOfMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfMediaHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOfMediaId = table.Column<int>(nullable: false),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Territoryy = table.Column<string>(nullable: true),
                    DictMediaLangTypeId = table.Column<int>(nullable: true),
                    DictMediaTypeId = table.Column<int>(nullable: true),
                    AddressRus = table.Column<string>(nullable: true),
                    AddressKyrg = table.Column<string>(nullable: true),
                    DictMediaFreqReleaseId = table.Column<int>(nullable: true),
                    DictMediaFinSourceId = table.Column<int>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    EliminationDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfMediaHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_DictMediaFreqRelease_DictMediaFreqReleaseId",
                        column: x => x.DictMediaFreqReleaseId,
                        principalTable: "DictMediaFreqRelease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_DictMediaLangType_DictMediaLangTypeId",
                        column: x => x.DictMediaLangTypeId,
                        principalTable: "DictMediaLangType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_DictMediaType_DictMediaTypeId",
                        column: x => x.DictMediaTypeId,
                        principalTable: "DictMediaType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_ListOfMedia_ListOfMediaId",
                        column: x => x.ListOfMediaId,
                        principalTable: "ListOfMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTeleRadio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOfMediaId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    NumberOfPermission = table.Column<int>(nullable: false),
                    PermissionDate = table.Column<DateTime>(nullable: false),
                    DictAgencyPermId = table.Column<int>(nullable: true),
                    DateOfPay = table.Column<DateTime>(nullable: true),
                    NumOfPermGas = table.Column<string>(nullable: true),
                    PermGASDate = table.Column<DateTime>(nullable: true),
                    PermElimGASDate = table.Column<DateTime>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTeleRadio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTeleRadio_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTeleRadio_DictAgencyPerm_DictAgencyPermId",
                        column: x => x.DictAgencyPermId,
                        principalTable: "DictAgencyPerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTeleRadio_ListOfMedia_ListOfMediaId",
                        column: x => x.ListOfMediaId,
                        principalTable: "ListOfMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfMonumetnTypologicalAccessory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOfMonumentsId = table.Column<int>(nullable: false),
                    DictMonumentTypologicalTypeId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfMonumetnTypologicalAccessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfMonumetnTypologicalAccessory_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMonumetnTypologicalAccessory_DictMonumentTypologicalType_DictMonumentTypologicalTypeId",
                        column: x => x.DictMonumentTypologicalTypeId,
                        principalTable: "DictMonumentTypologicalType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfMonumetnTypologicalAccessory_ListOfMonuments_ListOfMonumentsId",
                        column: x => x.ListOfMonumentsId,
                        principalTable: "ListOfMonuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfRents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictRentObjectTypeId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfRents_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfRents_DictRentObjectType_DictRentObjectTypeId",
                        column: x => x.DictRentObjectTypeId,
                        principalTable: "DictRentObjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfRentsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListOfRentsId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfRentsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfRentsHistory_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfRentsHistory_ListOfRents_ListOfRentsId",
                        column: x => x.ListOfRentsId,
                        principalTable: "ListOfRents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetUsers_DepartmentsId",
                table: "AspNetUsers",
                column: "DepartmentsId");

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
                name: "IX_DictAgencyPerm_DictStatusId",
                table: "DictAgencyPerm",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictAwardsPosition_DictStatusId",
                table: "DictAwardsPosition",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictAwardsReason_DictStatusId",
                table: "DictAwardsReason",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictCinematographyServices_DictStatusId",
                table: "DictCinematographyServices",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictControlType_DictStatusId",
                table: "DictControlType",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictCultAndArtType_DictStatusId",
                table: "DictCultAndArtType",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictDistrict_DictRegionId",
                table: "DictDistrict",
                column: "DictRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DictFinSource_DictStatusId",
                table: "DictFinSource",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictLegalForm_DictStatusId",
                table: "DictLegalForm",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictMediaControlResult_DictStatusId",
                table: "DictMediaControlResult",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictMediaFreqRelease_DictStatusId",
                table: "DictMediaFreqRelease",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictMediaLangType_DictStatusId",
                table: "DictMediaLangType",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictMediaSuitPerm_DictStatusId",
                table: "DictMediaSuitPerm",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictMediaType_DictStatusId",
                table: "DictMediaType",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictMonumemtSignOfLoss_DictStatusId",
                table: "DictMonumemtSignOfLoss",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictMonumentType_DictStatusId",
                table: "DictMonumentType",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictMonumentTypologicalType_DictStatusId",
                table: "DictMonumentTypologicalType",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictRentObjectType_DictStatusId",
                table: "DictRentObjectType",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictRentObjectType_DictUnitOfMeasureId",
                table: "DictRentObjectType",
                column: "DictUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_DictStateAwardsType_DictStatusId",
                table: "DictStateAwardsType",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictTheatricalHall_DictStatusId",
                table: "DictTheatricalHall",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictTourismServices_DictStatusId",
                table: "DictTourismServices",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DictUnitOfMeasure_DictStatusId",
                table: "DictUnitOfMeasure",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematography_ApplicationUserId",
                table: "ListOfCinematography",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematography_DictDistrictId",
                table: "ListOfCinematography",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematography_DictFinSourceId",
                table: "ListOfCinematography",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematography_DictLegalFormId",
                table: "ListOfCinematography",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_ApplicationUserId",
                table: "ListOfCinematographyCertificates",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_DictAgeRestrictionsId",
                table: "ListOfCinematographyCertificates",
                column: "DictAgeRestrictionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_DictCountryId",
                table: "ListOfCinematographyCertificates",
                column: "DictCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_DictDurationId",
                table: "ListOfCinematographyCertificates",
                column: "DictDurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_DictRegiserId",
                table: "ListOfCinematographyCertificates",
                column: "DictRegiserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_ApplicationUserId",
                table: "ListOfCinematographyHistory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_DictDistrictId",
                table: "ListOfCinematographyHistory",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_DictFinSourceId",
                table: "ListOfCinematographyHistory",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_DictLegalFormId",
                table: "ListOfCinematographyHistory",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_ListOfCinematographyId",
                table: "ListOfCinematographyHistory",
                column: "ListOfCinematographyId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyServices_ApplicationUserId",
                table: "ListOfCinematographyServices",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyServices_DictCinematographyServicesId",
                table: "ListOfCinematographyServices",
                column: "DictCinematographyServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyServices_DictStatusId",
                table: "ListOfCinematographyServices",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyServices_ListOfCinematographyId",
                table: "ListOfCinematographyServices",
                column: "ListOfCinematographyId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_ApplicationUserId",
                table: "ListOfControlMedia",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_DictControlTypeId",
                table: "ListOfControlMedia",
                column: "DictControlTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_DictMediaControlResultId",
                table: "ListOfControlMedia",
                column: "DictMediaControlResultId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_DictMediaSuitPermId",
                table: "ListOfControlMedia",
                column: "DictMediaSuitPermId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_ListOfMediaId",
                table: "ListOfControlMedia",
                column: "ListOfMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCouncilTheatrical_ApplicationUserId",
                table: "ListOfCouncilTheatrical",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCouncilTheatrical_ListOfTheatricalId",
                table: "ListOfCouncilTheatrical",
                column: "ListOfTheatricalId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultAndArt_ApplicationUserId",
                table: "ListOfCultAndArt",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultAndArt_DictCultAndArtTypeId",
                table: "ListOfCultAndArt",
                column: "DictCultAndArtTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultAndArt_DictDistrictId",
                table: "ListOfCultAndArt",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultAndArt_DictFinSourceId",
                table: "ListOfCultAndArt",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultAndArt_DictLegalFormId",
                table: "ListOfCultAndArt",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEduInstituts_ApplicationUserId",
                table: "ListOfEduInstituts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEduInstituts_DictEduInstTypeId",
                table: "ListOfEduInstituts",
                column: "DictEduInstTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEduInstituts_DictFinSourceId",
                table: "ListOfEduInstituts",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEduInstituts_DictLegalFormId",
                table: "ListOfEduInstituts",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEventsTheatrical_ApplicationUserId",
                table: "ListOfEventsTheatrical",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEventsTheatrical_DictTheatricalHallId",
                table: "ListOfEventsTheatrical",
                column: "DictTheatricalHallId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEventsTheatrical_ListOfTheatricalId",
                table: "ListOfEventsTheatrical",
                column: "ListOfTheatricalId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfLibraryIndicators_ApplicationUserId",
                table: "ListOfLibraryIndicators",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_ApplicationUserId",
                table: "ListOfMedia",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictFinSourceId",
                table: "ListOfMedia",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictLegalFormId",
                table: "ListOfMedia",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictMediaFreqReleaseId",
                table: "ListOfMedia",
                column: "DictMediaFreqReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictMediaLangTypeId",
                table: "ListOfMedia",
                column: "DictMediaLangTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictMediaTypeId",
                table: "ListOfMedia",
                column: "DictMediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_ApplicationUserId",
                table: "ListOfMediaHistory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_DictFinSourceId",
                table: "ListOfMediaHistory",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_DictLegalFormId",
                table: "ListOfMediaHistory",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_DictMediaFreqReleaseId",
                table: "ListOfMediaHistory",
                column: "DictMediaFreqReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_DictMediaLangTypeId",
                table: "ListOfMediaHistory",
                column: "DictMediaLangTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_DictMediaTypeId",
                table: "ListOfMediaHistory",
                column: "DictMediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_ListOfMediaId",
                table: "ListOfMediaHistory",
                column: "ListOfMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_ApplicationUserId",
                table: "ListOfMonuments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_DictDistrictId",
                table: "ListOfMonuments",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_DictFinSourceId",
                table: "ListOfMonuments",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_DictMonumemtSignOfLossId",
                table: "ListOfMonuments",
                column: "DictMonumemtSignOfLossId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_DictMonumentTypeId",
                table: "ListOfMonuments",
                column: "DictMonumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonumetnTypologicalAccessory_ApplicationUserId",
                table: "ListOfMonumetnTypologicalAccessory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonumetnTypologicalAccessory_DictMonumentTypologicalTypeId",
                table: "ListOfMonumetnTypologicalAccessory",
                column: "DictMonumentTypologicalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonumetnTypologicalAccessory_ListOfMonumentsId",
                table: "ListOfMonumetnTypologicalAccessory",
                column: "ListOfMonumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfRents_ApplicationUserId",
                table: "ListOfRents",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfRents_DictRentObjectTypeId",
                table: "ListOfRents",
                column: "DictRentObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfRentsHistory_ApplicationUserId",
                table: "ListOfRentsHistory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfRentsHistory_ListOfRentsId",
                table: "ListOfRentsHistory",
                column: "ListOfRentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfStateAwards_ApplicationUserId",
                table: "ListOfStateAwards",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfStateAwards_DictAwardsPositionId",
                table: "ListOfStateAwards",
                column: "DictAwardsPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfStateAwards_DictAwardsReasonId",
                table: "ListOfStateAwards",
                column: "DictAwardsReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfStateAwards_DictStateAwardsTypeId",
                table: "ListOfStateAwards",
                column: "DictStateAwardsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTeleRadio_ApplicationUserId",
                table: "ListOfTeleRadio",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTeleRadio_DictAgencyPermId",
                table: "ListOfTeleRadio",
                column: "DictAgencyPermId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTeleRadio_ListOfMediaId",
                table: "ListOfTeleRadio",
                column: "ListOfMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatrical_ApplicationUserId",
                table: "ListOfTheatrical",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatrical_DictFinSourceId",
                table: "ListOfTheatrical",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatrical_DictLegalFormId",
                table: "ListOfTheatrical",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatricalHistory_ApplicationUserId",
                table: "ListOfTheatricalHistory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatricalHistory_DictFinSourceId",
                table: "ListOfTheatricalHistory",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatricalHistory_DictLegalFormId",
                table: "ListOfTheatricalHistory",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourism_ApplicationUserId",
                table: "ListOfTourism",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourism_DictDistrictId",
                table: "ListOfTourism",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourism_DictFinSourceId",
                table: "ListOfTourism",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourism_DictLegalFormId",
                table: "ListOfTourism",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_ApplicationUserId",
                table: "ListOfTourismHistory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_DictDistrictId",
                table: "ListOfTourismHistory",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_DictFinSourceId",
                table: "ListOfTourismHistory",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_DictLegalFormId",
                table: "ListOfTourismHistory",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_ListOfTourismId",
                table: "ListOfTourismHistory",
                column: "ListOfTourismId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismIndicator_ApplicationUserId",
                table: "ListOfTourismIndicator",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismServices_ApplicationUserId",
                table: "ListOfTourismServices",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismServices_DictStatusId",
                table: "ListOfTourismServices",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismServices_DictTourismServicesId",
                table: "ListOfTourismServices",
                column: "DictTourismServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismServices_ListOfTourismId",
                table: "ListOfTourismServices",
                column: "ListOfTourismId");
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
                name: "DictMediaDistribTerritory");

            migrationBuilder.DropTable(
                name: "ListOfCinematographyCertificates");

            migrationBuilder.DropTable(
                name: "ListOfCinematographyHistory");

            migrationBuilder.DropTable(
                name: "ListOfCinematographyServices");

            migrationBuilder.DropTable(
                name: "ListOfControlMedia");

            migrationBuilder.DropTable(
                name: "ListOfCouncilTheatrical");

            migrationBuilder.DropTable(
                name: "ListOfCultAndArt");

            migrationBuilder.DropTable(
                name: "ListOfEduInstituts");

            migrationBuilder.DropTable(
                name: "ListOfEventsTheatrical");

            migrationBuilder.DropTable(
                name: "ListOfLibraryIndicators");

            migrationBuilder.DropTable(
                name: "ListOfMediaHistory");

            migrationBuilder.DropTable(
                name: "ListOfMonumetnTypologicalAccessory");

            migrationBuilder.DropTable(
                name: "ListOfRentsHistory");

            migrationBuilder.DropTable(
                name: "ListOfStateAwards");

            migrationBuilder.DropTable(
                name: "ListOfTeleRadio");

            migrationBuilder.DropTable(
                name: "ListOfTheatricalHistory");

            migrationBuilder.DropTable(
                name: "ListOfTourismHistory");

            migrationBuilder.DropTable(
                name: "ListOfTourismIndicator");

            migrationBuilder.DropTable(
                name: "ListOfTourismServices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DictAgeRestrictions");

            migrationBuilder.DropTable(
                name: "DictCountry");

            migrationBuilder.DropTable(
                name: "DictDuration");

            migrationBuilder.DropTable(
                name: "DictRegiser");

            migrationBuilder.DropTable(
                name: "DictCinematographyServices");

            migrationBuilder.DropTable(
                name: "ListOfCinematography");

            migrationBuilder.DropTable(
                name: "DictControlType");

            migrationBuilder.DropTable(
                name: "DictMediaControlResult");

            migrationBuilder.DropTable(
                name: "DictMediaSuitPerm");

            migrationBuilder.DropTable(
                name: "DictCultAndArtType");

            migrationBuilder.DropTable(
                name: "DictEduInstType");

            migrationBuilder.DropTable(
                name: "DictTheatricalHall");

            migrationBuilder.DropTable(
                name: "ListOfTheatrical");

            migrationBuilder.DropTable(
                name: "DictMonumentTypologicalType");

            migrationBuilder.DropTable(
                name: "ListOfMonuments");

            migrationBuilder.DropTable(
                name: "ListOfRents");

            migrationBuilder.DropTable(
                name: "DictAwardsPosition");

            migrationBuilder.DropTable(
                name: "DictAwardsReason");

            migrationBuilder.DropTable(
                name: "DictStateAwardsType");

            migrationBuilder.DropTable(
                name: "DictAgencyPerm");

            migrationBuilder.DropTable(
                name: "ListOfMedia");

            migrationBuilder.DropTable(
                name: "DictTourismServices");

            migrationBuilder.DropTable(
                name: "ListOfTourism");

            migrationBuilder.DropTable(
                name: "DictMonumemtSignOfLoss");

            migrationBuilder.DropTable(
                name: "DictMonumentType");

            migrationBuilder.DropTable(
                name: "DictRentObjectType");

            migrationBuilder.DropTable(
                name: "DictMediaFreqRelease");

            migrationBuilder.DropTable(
                name: "DictMediaLangType");

            migrationBuilder.DropTable(
                name: "DictMediaType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DictDistrict");

            migrationBuilder.DropTable(
                name: "DictFinSource");

            migrationBuilder.DropTable(
                name: "DictLegalForm");

            migrationBuilder.DropTable(
                name: "DictUnitOfMeasure");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "DictRegion");

            migrationBuilder.DropTable(
                name: "DictStatus");
        }
    }
}
