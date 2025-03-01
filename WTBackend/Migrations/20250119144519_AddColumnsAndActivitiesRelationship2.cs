using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WTBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsAndActivitiesRelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activities_columns_ColumnId",
                table: "activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_columns",
                table: "columns");

            migrationBuilder.DropIndex(
                name: "IX_activities_ColumnId",
                table: "activities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "columns");

            migrationBuilder.DropColumn(
                name: "ColumnId",
                table: "activities");

            migrationBuilder.AddColumn<string>(
                name: "ColumnTitle",
                table: "activities",
                type: "character varying(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_columns",
                table: "columns",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_activities_ColumnTitle",
                table: "activities",
                column: "ColumnTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_activities_columns_ColumnTitle",
                table: "activities",
                column: "ColumnTitle",
                principalTable: "columns",
                principalColumn: "Title",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activities_columns_ColumnTitle",
                table: "activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_columns",
                table: "columns");

            migrationBuilder.DropIndex(
                name: "IX_activities_ColumnTitle",
                table: "activities");

            migrationBuilder.DropColumn(
                name: "ColumnTitle",
                table: "activities");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "columns",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ColumnId",
                table: "activities",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_columns",
                table: "columns",
                column: "Id");

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
    }
}
