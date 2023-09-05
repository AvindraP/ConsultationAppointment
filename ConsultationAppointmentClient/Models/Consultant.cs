using System.ComponentModel.DataAnnotations;

namespace ConsultationAppointmentClient.Models
{
    public class Consultant
    {
        [Key]
        public int ConsultantId { get; set; }

        [Required(ErrorMessage = "Need to enter your First Name")]
        [Display(Name = "First Name")]
        [StringLength(75)]
        public string ConsultantFirstName { get; set; } = "";

        [Required(ErrorMessage = "Need to enter your Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(75)]
        public string ConsultantLastName { get; set; } = "";

        [Required(ErrorMessage = "Need to enter consultant Contact No")]
        [Display(Name = "Contact No")]
        [StringLength(maximumLength: 10, MinimumLength = 4, ErrorMessage = "Contact number should have 10 characters")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Contact number must be a number.")]
        public string ConsultantContactNo { get; set; } = "";

        [Required(ErrorMessage = "Need to enter Date")]
        [Display(Name = "Date")]
        [StringLength(12)]
        public string Date { get; set; } = "";

        [Required(ErrorMessage = "Need to enter Consultant Working start Time")]
        [Display(Name = "Start Time")]
        [StringLength(10)]
        public string StartTime { get; set; } = "";

        [Required(ErrorMessage = "Need to enter Consultant Working end Time")]
        [Display(Name = "End Time")]
        [StringLength(10)]
        public string EndTime { get; set; } = "";
    }
}
