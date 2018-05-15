using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace getfit.Migrations
{
    public partial class updatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserExercises",
                newName: "UserExerciseId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Exercises",
                newName: "ExerciseId");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "UserExercises",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTimeStamp",
                table: "Exercises",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedTimeStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedTimeStamp",
                table: "UserExercises");

            migrationBuilder.DropColumn(
                name: "UpdatedTimeStamp",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserExerciseId",
                table: "UserExercises",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "Exercises",
                newName: "Id");
        }
    }
}
