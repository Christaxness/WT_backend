using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WTBackend.Migrations
{
    /// <inheritdoc />
    public partial class MakeDefaultValueforActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ColumnTitle",
                table: "activities",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "New",
                oldClrType: typeof(string),
                oldType: "character varying(100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ColumnTitle",
                table: "activities",
                type: "character varying(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldDefaultValue: "New");
        }
    }
}
