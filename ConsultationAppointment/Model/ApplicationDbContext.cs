using Microsoft.EntityFrameworkCore;

namespace ConsultationAppointment.Model
{
    //inheritd by dbcontxt base class
    public class AppDbContext : DbContext
    {
        //Constructor method
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get;set; }
        public DbSet<Consultant> Consultants { get;set; }

    }
}
