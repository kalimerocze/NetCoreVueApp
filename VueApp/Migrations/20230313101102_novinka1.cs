using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VueApp.Migrations
{
    /// <inheritdoc />
    public partial class novinka1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Novinka",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Nadpis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PublikovanoDne = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PublikovanoDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    VytvorenoDne = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    ProPrihlasene = table.Column<bool>(type: "bit", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Priloha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    Poradi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    TypClanku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd"),
                    PlatneOd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                        .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novinka", x => x.Id);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Novinka")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "HistorieNovinka")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PlatneDo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PlatneOd");
        }
    }
}
