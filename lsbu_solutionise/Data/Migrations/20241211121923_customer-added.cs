using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lsbu_solutionise.Data.Migrations
{
    /// <inheritdoc />
    public partial class customeradded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessPostcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnualRevenue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportNeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HearUs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDatimetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDatimetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
