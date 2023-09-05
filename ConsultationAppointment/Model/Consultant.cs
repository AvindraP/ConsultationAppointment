using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace ConsultationAppointment.Model
{
    public class Consultant
    {
        [Key]
        public int ConsultantId { get; set; }

        [StringLength(75)]
        public string ConsultantFirstName { get; set; } = "";

        [StringLength(75)]
        public string ConsultantLastName { get; set; } = "";

        [StringLength(75)]
        public string ConsultantContactNo { get; set; } = "";

        public string Date { get; set; } = "";

        [StringLength(75)]
        public string StartTime { get; set; } = "";

        [StringLength(75)]
        public string EndTime { get; set; } = "";

        //[ForeignKey("AppointmentId")]
        //public string AppointmentId { get; set; } = "";
    }
}
