using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class migstart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryLikes",
                columns: table => new
                {
                    EntryLikeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryID = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryLikes", x => x.EntryLikeID);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    UniversityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.UniversityID);
                });

            migrationBuilder.CreateTable(
                name: "Departmants",
                columns: table => new
                {
                    DepartmantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmantName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmantStatus = table.Column<bool>(type: "bit", nullable: false),
                    UniversityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmants", x => x.DepartmantID);
                    table.ForeignKey(
                        name: "FK_Departmants_Universities_UniversityID",
                        column: x => x.UniversityID,
                        principalTable: "Universities",
                        principalColumn: "UniversityID");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonNickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonTelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonStatus = table.Column<bool>(type: "bit", nullable: false),
                    DepartmantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Persons_Departmants_DepartmantID",
                        column: x => x.DepartmantID,
                        principalTable: "Departmants",
                        principalColumn: "DepartmantID");
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryStatus = table.Column<bool>(type: "bit", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    DepartmantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.EntryID);
                    table.ForeignKey(
                        name: "FK_Entries_Departmants_DepartmantID",
                        column: x => x.DepartmantID,
                        principalTable: "Departmants",
                        principalColumn: "DepartmantID");
                    table.ForeignKey(
                        name: "FK_Entries_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPersonNickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentStatus = table.Column<bool>(type: "bit", nullable: false),
                    EntryID = table.Column<int>(type: "int", nullable: true),
                    EntryScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Entries_EntryID",
                        column: x => x.EntryID,
                        principalTable: "Entries",
                        principalColumn: "EntryID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EntryID",
                table: "Comments",
                column: "EntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Departmants_UniversityID",
                table: "Departmants",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_DepartmantID",
                table: "Entries",
                column: "DepartmantID");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_PersonID",
                table: "Entries",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DepartmantID",
                table: "Persons",
                column: "DepartmantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EntryLikes");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Departmants");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
