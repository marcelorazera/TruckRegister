using System;
using Microsoft.EntityFrameworkCore.Migrations;
using TruckRegister.Domain.Enums;
using TruckRegister.Domain.Helper;

namespace TruckRegister.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.CreateTable(
                name: "tb_truck",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ds_model = table.Column<string>(type: "TEXT", nullable: true),
                    id_truck_model = table.Column<int>(type: "INTEGER", nullable: false),
                    cd_fab_year = table.Column<int>(type: "INTEGER", nullable: false),
                    cd_model_year = table.Column<int>(type: "INTEGER", nullable: false),
                    st_active = table.Column<bool>(type: "INTEGER", nullable: false),
                    dt_created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dt_changed = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_truck", x => x.id);                    
                });

            migrationBuilder.InsertData(
                table: "tb_truck_model",
                columns: new[] { "id", "st_active", "dt_created", "dt_changed", "ds_model" },
                values: new object[] { Guid.NewGuid(), true, new DateTime(2021, 9, 5, 20, 39, 21, 204, DateTimeKind.Local).AddTicks(1100), null, TruckModel.FH.ToDescription()});

            migrationBuilder.InsertData(
                table: "tb_truck_model",
                columns: new[] { "id", "st_active", "dt_created", "dt_changed", "ds_model" },
                values: new object[] { Guid.NewGuid(), true, new DateTime(2021, 9, 5, 20, 39, 21, 225, DateTimeKind.Local).AddTicks(8850), null, TruckModel.FM.ToDescription() });
                       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_truck");            
        }
    }
}
