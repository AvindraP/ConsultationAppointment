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

        [Required(ErrorMessage = "Need to enter your First Name")]
        [Display(Name = "First Name")]
        [StringLength(75)]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Need to enter your Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(75)]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "Need to enter your NIC")]
        [Display(Name = "NIC")]
        [StringLength(maximumLength: 10, MinimumLength = 4,ErrorMessage ="NIC number should have 10 characters")]
        [RegularExpression(@".*[xv]$", ErrorMessage = "Must end with letter V or X")]
        public string Nic { get; set; } = "";
        //(maximumLength: 10, MinimumLength = 4)

        [Required(ErrorMessage = "Need to enter your Address")]
        [Display(Name = "Address")]
        [StringLength(75)]
        public string HomeAddress { get; set; } = "";

        [Required(ErrorMessage = "Need to enter your Contact No")]
        [Display(Name = "Contact No")]
        [StringLength(maximumLength: 10, MinimumLength = 4, ErrorMessage = "Contact number should have 10 characters")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Contact number must be a number.")]
        public string ContactNo { get; set; } = "";

        [Required(ErrorMessage = "Need to enter your Date")]
        [Display(Name = "Date")]
        [StringLength(12)]
        public string Date { get; set; } = "";

        [Required(ErrorMessage = "Need to enter your Time")]
        [Display(Name = "Time")]
        [StringLength(10)]
        public string Time { get; set; } = "";
    }
}