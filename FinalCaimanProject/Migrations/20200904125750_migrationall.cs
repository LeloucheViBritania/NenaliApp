using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalCaimanProject.Migrations
{
    public partial class migrationall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(nullable: true),
                    ContactPname = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<int>(nullable: false),
                    ContactSite = table.Column<string>(nullable: true),
                    ContactFonction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    ProjetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetName = table.Column<string>(nullable: true),
                    IsArchieved = table.Column<bool>(nullable: false),
                    ProjetDateDebut = table.Column<DateTime>(nullable: false),
                    ProjetDateFin = table.Column<DateTime>(nullable: false),
                    ProjetDescription = table.Column<string>(nullable: true),
                    ProjetProgressBar = table.Column<int>(nullable: false),
                    ProjetCahierCharge = table.Column<string>(nullable: true),
                    ProjetMoney = table.Column<int>(nullable: false),
                    ProjetObservationFinal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.ProjetId);
                });

            migrationBuilder.CreateTable(
                name: "Specialites",
                columns: table => new
                {
                    SpecialiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialiteName = table.Column<string>(nullable: true),
                    SpecialiteColor = table.Column<string>(nullable: true),
                    SpecialiteInfo = table.Column<string>(nullable: true),
                    Url_Image = table.Column<string>(nullable: true),
                    ImageSpecialite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialites", x => x.SpecialiteId);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    TransportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranportName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.TransportId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    UserPnom = table.Column<string>(nullable: true),
                    UserSexe = table.Column<string>(nullable: true),
                    UserMail = table.Column<string>(nullable: true),
                    UserPhone = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "NotePs",
                columns: table => new
                {
                    NotePId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotePDescription = table.Column<string>(nullable: true),
                    NotePDate = table.Column<DateTime>(nullable: false),
                    ProjetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotePs", x => x.NotePId);
                    table.ForeignKey(
                        name: "FK_NotePs_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "ProjetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(nullable: true),
                    MemberPnom = table.Column<string>(nullable: true),
                    MemberSex = table.Column<string>(nullable: true),
                    MemberDescription = table.Column<string>(nullable: true),
                    MemberNaissance = table.Column<DateTime>(nullable: false),
                    MemberLieuNaissance = table.Column<string>(nullable: true),
                    MemberMail = table.Column<string>(nullable: true),
                    MemberPhone = table.Column<int>(nullable: false),
                    MemberImageName = table.Column<string>(nullable: true),
                    MemberIsArchived = table.Column<bool>(nullable: false),
                    MemberStatus = table.Column<string>(nullable: true),
                    MemberCommune = table.Column<string>(nullable: true),
                    MemberQuartier = table.Column<string>(nullable: true),
                    MemberMissonFin = table.Column<int>(nullable: false),
                    MemberDateArchive = table.Column<DateTime>(nullable: false),
                    MemberMissionActive = table.Column<int>(nullable: false),
                    MemberNote = table.Column<int>(nullable: false),
                    TransportId = table.Column<int>(nullable: false),
                    SpecialiteId = table.Column<int>(nullable: false),
                    IsChecked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Specialites_SpecialiteId",
                        column: x => x.SpecialiteId,
                        principalTable: "Specialites",
                        principalColumn: "SpecialiteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "TransportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    CompetenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetenceName = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.CompetenceId);
                    table.ForeignKey(
                        name: "FK_Competences_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjetMembers",
                columns: table => new
                {
                    MemberId = table.Column<int>(nullable: false),
                    ProjetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetMembers", x => new { x.MemberId, x.ProjetId });
                    table.ForeignKey(
                        name: "FK_ProjetMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetMembers_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "ProjetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                columns: table => new
                {
                    SocialNetworkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetworkName = table.Column<string>(nullable: true),
                    NetworkLink = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.SocialNetworkId);
                    table.ForeignKey(
                        name: "FK_SocialNetworks_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competences_MemberId",
                table: "Competences",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_SpecialiteId",
                table: "Members",
                column: "SpecialiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TransportId",
                table: "Members",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_NotePs_ProjetId",
                table: "NotePs",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetMembers_ProjetId",
                table: "ProjetMembers",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_MemberId",
                table: "SocialNetworks",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "NotePs");

            migrationBuilder.DropTable(
                name: "ProjetMembers");

            migrationBuilder.DropTable(
                name: "SocialNetworks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projets");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Specialites");

            migrationBuilder.DropTable(
                name: "Transports");
        }
    }
}
