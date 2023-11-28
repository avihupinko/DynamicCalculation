using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DynamicActions.Migrations
{
    /// <inheritdoc />
    public partial class db_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Expression = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DynamicActionType = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynamicActionHistorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Y = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Result = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DynamicActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicActionHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicActionHistorys_DynamicActions_DynamicActionId",
                        column: x => x.DynamicActionId,
                        principalTable: "DynamicActions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DynamicActions",
                columns: new[] { "Id", "Created", "DynamicActionType", "Expression", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "X + Y", "SUM" },
                    { 2, new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "X - Y", "SUB" },
                    { 3, new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "String.Concat(X, Y)", "Concat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DynamicActionHistorys_DynamicActionId",
                table: "DynamicActionHistorys",
                column: "DynamicActionId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicActions_Name",
                table: "DynamicActions",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicActionHistorys");

            migrationBuilder.DropTable(
                name: "DynamicActions");
        }
    }
}
