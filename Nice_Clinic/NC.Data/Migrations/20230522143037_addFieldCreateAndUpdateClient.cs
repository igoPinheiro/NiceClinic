﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NC.Data.Migrations
{
    /// <inheritdoc />
    public partial class addFieldCreateAndUpdateClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sexo",
                table: "Clients",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(char),
                oldType: "character(1)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Clients",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Clients",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Clients");

            migrationBuilder.AlterColumn<char>(
                name: "Sexo",
                table: "Clients",
                type: "character(1)",
                nullable: false,
                defaultValue: ' ',
                oldClrType: typeof(string),
                oldType: "character varying(1)",
                oldMaxLength: 1,
                oldNullable: true);
        }
    }
}
