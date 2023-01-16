﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmantID",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmantID",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Entries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniversityID",
                table: "Departmants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntryID",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DepartmantID",
                table: "Persons",
                column: "DepartmantID");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_DepartmantID",
                table: "Entries",
                column: "DepartmantID");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_PersonID",
                table: "Entries",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Departmants_UniversityID",
                table: "Departmants",
                column: "UniversityID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EntryID",
                table: "Comments",
                column: "EntryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Entries_EntryID",
                table: "Comments",
                column: "EntryID",
                principalTable: "Entries",
                principalColumn: "EntryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departmants_Universities_UniversityID",
                table: "Departmants",
                column: "UniversityID",
                principalTable: "Universities",
                principalColumn: "UniversityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Departmants_DepartmantID",
                table: "Entries",
                column: "DepartmantID",
                principalTable: "Departmants",
                principalColumn: "DepartmantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Persons_PersonID",
                table: "Entries",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Departmants_DepartmantID",
                table: "Persons",
                column: "DepartmantID",
                principalTable: "Departmants",
                principalColumn: "DepartmantID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Entries_EntryID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departmants_Universities_UniversityID",
                table: "Departmants");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Departmants_DepartmantID",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Persons_PersonID",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Departmants_DepartmantID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_DepartmantID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Entries_DepartmantID",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_PersonID",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Departmants_UniversityID",
                table: "Departmants");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EntryID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DepartmantID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DepartmantID",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "UniversityID",
                table: "Departmants");

            migrationBuilder.DropColumn(
                name: "EntryID",
                table: "Comments");
        }
    }
}
