using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSH.Starter.WebApi.Migrations.PostgreSQL.English
{
    /// <inheritdoc />
    public partial class AddedProgressTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Progresss",
                schema: "english",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Unit1Progress = table.Column<int>(type: "integer", nullable: false),
                    Unit2Progress = table.Column<int>(type: "integer", nullable: false),
                    Unit3Progress = table.Column<int>(type: "integer", nullable: false),
                    Unit4Progress = table.Column<int>(type: "integer", nullable: false),
                    Unit5Progress = table.Column<int>(type: "integer", nullable: false),
                    Unit6Progress = table.Column<int>(type: "integer", nullable: false),
                    Unit7Progress = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progresss", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Progresss",
                schema: "english");
        }
    }
}
