using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Examples.Charge.Infra.Data.Configuration.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Example",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Example", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "dbo",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.BusinessEntityID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberType",
                schema: "dbo",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberType", x => x.BusinessEntityID);
                });

            migrationBuilder.CreateTable(
                name: "PersonPhone",
                schema: "dbo",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    PhoneNumberTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPhone", x => new { x.BusinessEntityID, x.PhoneNumber, x.PhoneNumberTypeID });
                    table.ForeignKey(
                        name: "FK_PersonPhone_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "dbo",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID",
                        column: x => x.PhoneNumberTypeID,
                        principalSchema: "dbo",
                        principalTable: "PhoneNumberType",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Example",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Example 1" },
                    { 2, "Example 2" },
                    { 3, "Example 3" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Person",
                columns: new[] { "BusinessEntityID", "Name" },
                values: new object[] { 1, "User One" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PhoneNumberType",
                columns: new[] { "BusinessEntityID", "Name" },
                values: new object[,]
                {
                    { 1, "Local phone" },
                    { 2, "Cellphone" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PersonPhone",
                columns: new[] { "BusinessEntityID", "PhoneNumber", "PhoneNumberTypeID" },
                values: new object[] { 1, "(19)99999-2883", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PersonPhone",
                columns: new[] { "BusinessEntityID", "PhoneNumber", "PhoneNumberTypeID" },
                values: new object[] { 1, "(19)99999-4021", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_PhoneNumberTypeID",
                schema: "dbo",
                table: "PersonPhone",
                column: "PhoneNumberTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Example",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonPhone",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PhoneNumberType",
                schema: "dbo");
        }
    }
}
