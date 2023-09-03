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
                .UseInMemoryDatabase(databaseName: "appointmentDatabase") // Use in-memory database for testing
                .Options;

            // Act & Assert
            using (var context = new AppDbContext(options))
            {
                // Attempt to perform a database operation, e.g., query or migration
                try
                {
                    context.Database.EnsureCreated(); // This can be any database operation

                    // If the operation succeeds, the connection is valid
                    Assert.True(true); // You can use any suitable assertion here
                }
                catch (Exception ex)
                {
                    // If an exception occurs, the connection is not valid
                    Assert.False(true, $"Database connection test failed: {ex.Message}");
                }
            }
        }
    }
}
