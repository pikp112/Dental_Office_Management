using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhiteDentalClinic.DataAccess.Migrations
{
    public partial class AddOneToManyRelationAppAndMedServ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointments_MedicalServiceId",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MedicalServiceId",
                table: "Appointments",
                column: "MedicalServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appointments_MedicalServiceId",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MedicalServiceId",
                table: "Appointments",
                column: "MedicalServiceId",
                unique: true);
        }
    }
}
