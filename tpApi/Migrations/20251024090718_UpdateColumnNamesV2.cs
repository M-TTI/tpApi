using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNamesV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_weather",
                table: "weather");

            migrationBuilder.RenameTable(
                name: "weather",
                newName: "forecast");

            migrationBuilder.AddPrimaryKey(
                name: "PK_forecast",
                table: "forecast",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_forecast",
                table: "forecast");

            migrationBuilder.RenameTable(
                name: "forecast",
                newName: "weather");

            migrationBuilder.AddPrimaryKey(
                name: "PK_weather",
                table: "weather",
                column: "id");
        }
    }
}
