using ConsultationAppointment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tests.Helper;

namespace Tests
{
    public  class TestDbConnection
    {
        [Fact]
        public void checkConnection()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "appointmentDatabase")
                .Options;

            // Act & Assert
            using (var context = new AppDbContext(options))
            {
                try
                {
                    context.Database.EnsureCreated();

                    Assert.True(true);
                }
                catch (Exception ex)
                {
                    Assert.False(true, $"Database connection test failed: {ex.Message}");
                }
            }
        }
    }
}
