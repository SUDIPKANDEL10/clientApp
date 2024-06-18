using System;
using System.ComponentModel.DataAnnotations;

namespace clientApp.Models
{
    public class ClientModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string DOB { get; set; }

        [Required]
        public string Education { get; set; }

        [Required]
        public string PreferedContact { get; set; }

    }
}
