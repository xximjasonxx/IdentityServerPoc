using System.ComponentModel.DataAnnotations;

namespace IdentityServerWeb.Models
{
    public class LoginRequestModel
    {
        public LoginRequestModel()
        {

        }

        public LoginRequestModel(string returnUrl)
        {
            ReturnUrl = returnUrl;
        }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        //[Required]
        public string ReturnUrl { get; set; }
    }
}