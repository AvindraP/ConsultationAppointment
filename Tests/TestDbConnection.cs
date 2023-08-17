using ConsultationAppointment.Model;
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
            AppDbContext context = new AppDbContext(TestDBConnection.GetConnection());
            if(context!=null )
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            Assert.NotNull(context);
            Assert.Empty(context.Appointments);
        }
    }
}
