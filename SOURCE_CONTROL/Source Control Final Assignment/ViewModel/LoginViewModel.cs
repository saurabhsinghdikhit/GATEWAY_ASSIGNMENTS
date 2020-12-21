using System.ComponentModel.DataAnnotations;


namespace LoginRegistrationInMVCWithDatabase.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter Employee Email")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Password")]
        [StringLength(maximumLength: 20, ErrorMessage = "Passowrd should be between 6-20 character", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}