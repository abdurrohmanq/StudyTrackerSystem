using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyTrackerSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Teachers_TeacherId",
                table: "Reminders");

            migrationBuilder.AlterColumn<long>(
                name: "TeacherId",
                table: "Reminders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "StudentId",
                table: "Reminders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Teachers_TeacherId",
                table: "Reminders",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reminders_Teachers_TeacherId",
                table: "Reminders");

            migrationBuilder.AlterColumn<long>(
                name: "TeacherId",
                table: "Reminders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StudentId",
                table: "Reminders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminders_Teachers_TeacherId",
                table: "Reminders",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
