using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ConsultationAppointment.Model
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [StringLength(75)]
        public string FirstName { get; set; } = "";

        [StringLength(75)]
        public string LastName { get; set; } = "";

        [StringLength(75)]
        public string Nic { get; set; } = "";

        [StringLength(75)]
        public string HomeAddress { get; set; } = "";

        [StringLength(75)]
        public string ContactNo { get; set; } = "";

        //[DisplayName("Date of Birth")]
        public string Date { get; set; } = "";

        [StringLength(75)]
        public string Time { get; set; } = "";


    }
}
