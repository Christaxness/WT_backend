using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WTBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsAndActivitiesRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "activities",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "ColumnId",
                table: "activities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "columns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_columns", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activities_ColumnId",
                table: "activities",
                column: "ColumnId");

            migrationBuilder.AddForeignKey(
                name: "FK_activities_columns_ColumnId",
                table: "activities",
                column: "ColumnId",
                principalTable: "columns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activities_columns_ColumnId",
                table: "activities");

            migrationBuilder.DropTable(
                name: "columns");

            migrationBuilder.DropIndex(
                name: "IX_activities_ColumnId",
                table: "activities");

            migrationBuilder.DropColumn(
                name: "ColumnId",
                table: "activities");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "activities",
                newName: "Name");
        }
    }
}
