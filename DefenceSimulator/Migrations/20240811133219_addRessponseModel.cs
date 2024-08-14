using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefenceSimulator.Migrations
{
    /// <inheritdoc />
    public partial class addRessponseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_Salvo_salvoId",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "SalvotId",
                table: "Response");

            migrationBuilder.RenameColumn(
                name: "salvoId",
                table: "Response",
                newName: "SalvoId");

            migrationBuilder.RenameIndex(
                name: "IX_Response_salvoId",
                table: "Response",
                newName: "IX_Response_SalvoId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Salvo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Salvo_SalvoId",
                table: "Response",
                column: "SalvoId",
                principalTable: "Salvo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_Salvo_SalvoId",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Salvo");

            migrationBuilder.RenameColumn(
                name: "SalvoId",
                table: "Response",
                newName: "salvoId");

            migrationBuilder.RenameIndex(
                name: "IX_Response_SalvoId",
                table: "Response",
                newName: "IX_Response_salvoId");

            migrationBuilder.AddColumn<int>(
                name: "SalvotId",
                table: "Response",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Salvo_salvoId",
                table: "Response",
                column: "salvoId",
                principalTable: "Salvo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
