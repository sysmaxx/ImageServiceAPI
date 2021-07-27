using System;
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhysicalDirectory = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhysicalFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())"),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.Sql("CREATE TRIGGER TRG_IMAGE_UpdateModifiedDate ON dbo.Image AFTER UPDATE AS UPDATE dbo.Image SET Modified = sysdatetime() WHERE Id IN (SELECT DISTINCT Id FROM inserted)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
