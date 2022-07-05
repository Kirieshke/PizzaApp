using System.ComponentModel.DataAnnotations;

namespace PizzaApp.ViewModels
{
    public class RegisterViewModel
    {
            
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<string> Errors { get; set; }
    }
}
