using System.ComponentModel.DataAnnotations;

namespace Boats.API.Models
{

    public class LoginUserDTO
    {
        //need to add username later because identity requires it. right now we are just using the email as username manually. check the account controller register post function
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 5)]
        public string Password { get; set; }
    }
    public class UserDTO : LoginUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<string> Roles { get; set; }

       


    }
}
