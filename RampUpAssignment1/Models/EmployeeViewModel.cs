using System.ComponentModel.DataAnnotations;

namespace RampUpAssignment1.Models
{
    public class EmployeeViewModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Gender")]
        [Display(Name = "Gender(M or F)")]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /*[Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        [MaxLength(15, ErrorMessage = "Password cannot be greater than 15 characters")]
        [MinLength(6, ErrorMessage = "Password cannot be less than 6 characters")]
        public string Password { get; set; }*/
    }
}
