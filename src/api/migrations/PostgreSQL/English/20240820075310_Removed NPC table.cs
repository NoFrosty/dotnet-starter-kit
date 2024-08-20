using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSH.Starter.WebApi.Migrations.PostgreSQL.English
{
    /// <inheritdoc />
    public partial class RemovedNPCtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Npcs",
                schema: "english");

            migrationBuilder.DropColumn(
                name: "NpcId",
                schema: "english",
                table: "Beans");

            migrationBuilder.RenameColumn(
                name: "AmountOfBean",
                schema: "english",
                table: "Beans",
                newName: "AmountOfBeanRoxy");

            migrationBuilder.AddColumn<int>(
                name: "AmountOfBeanBeebee",
                schema: "english",
                table: "Beans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfBeanBurn",
                schema: "english",
                table: "Beans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfBeanCube",
                schema: "english",
                table: "Beans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfBeanFurry",
                schema: "english",
                table: "Beans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfBeanLuna",
                schema: "english",
                table: "Beans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfBeanMuzzy",
                schema: "english",
                table: "Beans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfBeanNova",
                schema: "english",
                table: "Beans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfBeanOllie",
                schema: "english",
                table: "Beans",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfBeanBeebee",
                schema: "english",
                table: "Beans");

            migrationBuilder.DropColumn(
                name: "AmountOfBeanBurn",
                schema: "english",
                table: "Beans");

            migrationBuilder.DropColumn(
                name: "AmountOfBeanCube",
                schema: "english",
                table: "Beans");

            migrationBuilder.DropColumn(
                name: "AmountOfBeanFurry",
                schema: "english",
                table: "Beans");

            migrationBuilder.DropColumn(
                name: "AmountOfBeanLuna",
                schema: "english",
                table: "Beans");

            migrationBuilder.DropColumn(
                name: "AmountOfBeanMuzzy",
                schema: "english",
                table: "Beans");

            migrationBuilder.DropColumn(
                name: "AmountOfBeanNova",
                schema: "english",
                table: "Beans");

            migrationBuilder.DropColumn(
                name: "AmountOfBeanOllie",
                schema: "english",
                table: "Beans");

            migrationBuilder.RenameColumn(
                name: "AmountOfBeanRoxy",
                schema: "english",
                table: "Beans",
                newName: "AmountOfBean");

            migrationBuilder.AddColumn<Guid>(
                name: "NpcId",
                schema: "english",
                table: "Beans",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Npcs",
                schema: "english",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npcs", x => x.Id);
                });
        }
    }
}
