using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Persistence.Migrations
{
    public partial class quiz_new_fields_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Quizzes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "Quizzes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_CategoryId",
                table: "Quizzes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Categories_CategoryId",
                table: "Quizzes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Categories_CategoryId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_CategoryId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Quizzes");
        }
    }
}
