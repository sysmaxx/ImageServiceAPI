using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageServiceApi.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "Latin1_General_CI"),
                    MimeType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "Latin1_General_CI"),
                    PhysicalDirectory = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "Latin1_General_CI"),
                    PhysicalFileName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "Latin1_General_CI"),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                })
                .Annotation("Relational:Collation", "Latin1_General_CI");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
