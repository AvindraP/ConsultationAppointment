using ConsultationAppointment.Controllers;
using ConsultationAppointment.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class addAppointment
    {
        [Fact]
        public async Task Create_ValidAppointment_ReturnsOk()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var controller = new AppointmentController(context);

                var appointment = new Appointment
                {
                    AppointmentId = 0,
                    FirstName = "Upash",
                    LastName = "antha",
                    Nic = "97628162v",
                    HomeAddress = "12, polar bear street",
                    ContactNo = "077182712"
                };

                // Act
                var result = await controller.Create(appointment);

                // Assert
                Assert.IsType<OkObjectResult>(result);
            }
        }
    }
}