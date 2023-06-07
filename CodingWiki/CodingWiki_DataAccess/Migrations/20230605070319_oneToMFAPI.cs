using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class oneToMFAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Books_fluent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fluent_Publisher",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Publisher", x => x.Publisher_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_fluent_Publisher_Id",
                table: "Books_fluent",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_fluent_Fluent_Publisher_Publisher_Id",
                table: "Books_fluent",
                column: "Publisher_Id",
                principalTable: "Fluent_Publisher",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_fluent_Fluent_Publisher_Publisher_Id",
                table: "Books_fluent");

            migrationBuilder.DropTable(
                name: "Fluent_Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Books_fluent_Publisher_Id",
                table: "Books_fluent");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Books_fluent");
        }
    }
}
