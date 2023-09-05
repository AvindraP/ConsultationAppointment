using ConsultationAppointment.Controllers;
using ConsultationAppointment.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class addConsultant
    {
        [Fact]
        public async Task Create_ValidConsultant_ReturnsOk()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var controller = new ConsultantController(context);

                var consultant = new Consultant
                {
                    ConsultantId = 0,
                    ConsultantFirstName = "Upash",
                    ConsultantLastName = "antha",
                    ConsultantContactNo = "0776263927",
                    Date = "12.11.2023",
                    StartTime = "12.00",
                    EndTime = "15.00"
                };

                // Act
                var result = await controller.Create(consultant);

                // Assert
                Assert.IsType<OkObjectResult>(result);
            }
        }
    }
}