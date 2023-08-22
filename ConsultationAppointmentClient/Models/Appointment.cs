using System.ComponentModel.DataAnnotations;

namespace ConsultationAppointmentClient.Models
{

    //public class Rootobject
    //{
    //    public Class1[] Property1 { get; set; }
    //}

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

        [StringLength(75)]
        public string Date { get; set; } = "";

        [StringLength(75)]
        public string Time { get; set; } = "";

    }
