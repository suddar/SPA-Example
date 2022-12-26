using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPA_Example.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Thumbnai",
                table: "ResourceObjects",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbnai",
                table: "ResourceObjects");
        }
    }
}
