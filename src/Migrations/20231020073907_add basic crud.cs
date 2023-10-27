using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class addbasiccrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    account = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    bidQuantity = table.Column<double>(nullable: false),
                    askQuantity = table.Column<double>(nullable: false),
                    bid = table.Column<double>(nullable: false),
                    ask = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurvePoint",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cureveId = table.Column<int>(nullable: false),
                    asOfDate = table.Column<DateTime>(nullable: false),
                    term = table.Column<double>(nullable: false),
                    value = table.Column<double>(nullable: false),
                    creationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurvePoint", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    moodysRating = table.Column<string>(nullable: true),
                    sandPRating = table.Column<string>(nullable: true),
                    fitchRaing = table.Column<string>(nullable: true),
                    orderNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    descripton = table.Column<string>(nullable: true),
                    json = table.Column<string>(nullable: true),
                    template = table.Column<string>(nullable: true),
                    sqlStr = table.Column<string>(nullable: true),
                    sqlPart = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    account = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    buyQuantity = table.Column<double>(nullable: false),
                    sellQuantity = table.Column<double>(nullable: false),
                    buyPrice = table.Column<double>(nullable: false),
                    sellPrice = table.Column<double>(nullable: false),
                    benchmark = table.Column<string>(nullable: true),
                    tradeDate = table.Column<DateTime>(nullable: false),
                    security = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    trader = table.Column<string>(nullable: true),
                    book = table.Column<string>(nullable: true),
                    creationName = table.Column<string>(nullable: true),
                    creationDate = table.Column<DateTime>(nullable: false),
                    revisionName = table.Column<string>(nullable: true),
                    revisionDate = table.Column<DateTime>(nullable: false),
                    dealName = table.Column<string>(nullable: true),
                    dealType = table.Column<string>(nullable: true),
                    sourceListId = table.Column<string>(nullable: true),
                    side = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "CurvePoint");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Rule");

            migrationBuilder.DropTable(
                name: "Trade");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
