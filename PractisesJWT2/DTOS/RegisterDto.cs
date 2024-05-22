using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PractisesJWT2.DTOS
{
    public class RegisterDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? E_Mail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password" , ErrorMessage = "No Confirmation with password pls try again!")]
        public string? ConfirmPassword { get; set; }

        public string? Address { get; set; }



    }
}
