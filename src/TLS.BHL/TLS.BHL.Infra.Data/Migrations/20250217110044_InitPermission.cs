using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEC.ESoft.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updated_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updated_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted_by = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");
        }
    }
}
