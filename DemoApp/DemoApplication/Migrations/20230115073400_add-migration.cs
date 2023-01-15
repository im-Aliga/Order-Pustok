﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApplication.Migrations
{
    public partial class addmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "BookImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "BookImages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
