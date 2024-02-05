using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace first_web_api.Migrations
{
    /// <inheritdoc />
    public partial class PublishedOnField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedOn",
                table: "Books",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishedOn",
                table: "Books");
        }
    }
}
