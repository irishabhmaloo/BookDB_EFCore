using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class preMod7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO SubCategories VALUES ('Cat 1')");
            migrationBuilder.Sql("INSERT INTO SubCategories VALUES ('Cat 2')");
            migrationBuilder.Sql("INSERT INTO SubCategories VALUES ('Cat 3')");
            migrationBuilder.Sql("INSERT INTO SubCategories VALUES ('Cat 4')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
