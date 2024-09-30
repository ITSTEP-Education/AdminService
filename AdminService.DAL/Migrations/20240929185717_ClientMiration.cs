using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ClientMiration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientsdata",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientsdata", x => x.id);
                    table.CheckConstraint("age", "age > 18");
                });

            migrationBuilder.CreateTable(
                name: "clientorders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeEngeeniring = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timeStudy = table.Column<int>(type: "int", nullable: false),
                    sumPay = table.Column<float>(type: "real", nullable: false),
                    FK_ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientorders", x => x.id);
                    table.ForeignKey(
                        name: "FK_clientorders_clientsdata_FK_ClientId",
                        column: x => x.FK_ClientId,
                        principalTable: "clientsdata",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrder_ClientDataId",
                table: "clientorders",
                column: "FK_ClientId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientorders");

            migrationBuilder.DropTable(
                name: "clientsdata");
        }
    }
}
