using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NC.Data.Migrations
{
    /// <inheritdoc />
    public partial class telefones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => new { x.ClientId, x.Number });
                    table.ForeignKey(
                        name: "FK_Phones_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Clients",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
