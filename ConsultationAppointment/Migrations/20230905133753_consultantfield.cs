using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultationAppointment.Migrations
{
    public partial class consultantfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConsultantName",
                table: "Appointments",
                type: "varchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultantName",
                table: "Appointments");
        }
    }
}
