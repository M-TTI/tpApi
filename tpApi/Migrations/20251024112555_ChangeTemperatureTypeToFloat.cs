using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTemperatureTypeToFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "temperature",
                table: "forecast",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "temperature",
                table: "forecast",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");
        }
    }
}
