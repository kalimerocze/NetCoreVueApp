using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VueApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clanek",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Nadpis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PublikovanoDne = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PublikovanoDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    VytvorenoDne = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    ProPrihlasene = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Priloha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Poradi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    TypClanku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneOd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanek", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");

            migrationBuilder.CreateTable(
                name: "Odkaz",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Popis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    TypOdkazu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    SkupinaOdkazu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    BlokOdkazu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Poradi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Zverejnit = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    NoveOkno = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    ProPrihlasene = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneOd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odkaz", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");

            migrationBuilder.CreateTable(
                name: "Soubor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieSoubor")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    NazevSouboru = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieSoubor")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    ClanekId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieSoubor")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    SlozkaSouboru = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieSoubor")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieSoubor")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneOd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieSoubor")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soubor", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieSoubor")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");

            migrationBuilder.CreateTable(
                name: "TypClanku",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypClanku")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Hodnota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypClanku")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypClanku")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneOd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypClanku")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypClanku", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypClanku")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");

            migrationBuilder.CreateTable(
                name: "TypOdkazu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypOdkazu")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Hodnota = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypOdkazu")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypOdkazu")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneOd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypOdkazu")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypOdkazu", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypOdkazu")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clanek")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieClanek")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");

            migrationBuilder.DropTable(
                name: "Odkaz")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieOdkaz")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");

            migrationBuilder.DropTable(
                name: "Soubor")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieSoubor")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");

            migrationBuilder.DropTable(
                name: "TypClanku")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypClanku")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");

            migrationBuilder.DropTable(
                name: "TypOdkazu")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieTypOdkazu")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");
        }
    }
}
