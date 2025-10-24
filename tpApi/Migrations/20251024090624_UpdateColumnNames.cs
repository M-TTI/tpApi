using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Forecasts",
                table: "Forecasts");

            migrationBuilder.RenameTable(
                name: "Forecasts",
                newName: "weather");

            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "weather",
                newName: "temperature");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "weather",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Condition",
                table: "weather",
                newName: "condition");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "weather",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "weather",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_weather",
                table: "weather",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_weather",
                table: "weather");

            migrationBuilder.RenameTable(
                name: "weather",
                newName: "Forecasts");

            migrationBuilder.RenameColumn(
                name: "temperature",
                table: "Forecasts",
                newName: "Temperature");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Forecasts",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "condition",
                table: "Forecasts",
                newName: "Condition");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Forecasts",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Forecasts",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forecasts",
                table: "Forecasts",
                column: "Id");
        }
    }
}
