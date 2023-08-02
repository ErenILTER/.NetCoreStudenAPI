using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentClub",
                columns: table => new
                {
                    IDCard = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentClubId = table.Column<int>(type: "integer", nullable: false),
                    StudentClubName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClub", x => x.IDCard);
                });

            migrationBuilder.CreateTable(
                name: "StudentInformation",
                columns: table => new
                {
                    IDCard = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    StudentName = table.Column<string>(type: "text", nullable: false),
                    StudentSurname = table.Column<string>(type: "text", nullable: false),
                    StudentAge = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInformation", x => x.IDCard);
                });

            migrationBuilder.CreateTable(
                name: "StudentClubsStudentInformations",
                columns: table => new
                {
                    StudentClubIDCard = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentInformationIDCard = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClubsStudentInformations", x => new { x.StudentClubIDCard, x.StudentInformationIDCard });
                    table.ForeignKey(
                        name: "FK_StudentClubsStudentInformations_StudentClub_StudentClubIDCa~",
                        column: x => x.StudentClubIDCard,
                        principalTable: "StudentClub",
                        principalColumn: "IDCard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClubsStudentInformations_StudentInformation_StudentI~",
                        column: x => x.StudentInformationIDCard,
                        principalTable: "StudentInformation",
                        principalColumn: "IDCard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClubsStudentInformations_StudentInformationIDCard",
                table: "StudentClubsStudentInformations",
                column: "StudentInformationIDCard");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentClubsStudentInformations");

            migrationBuilder.DropTable(
                name: "StudentClub");

            migrationBuilder.DropTable(
                name: "StudentInformation");
        }
    }
}
