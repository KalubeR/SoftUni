using SIS.MvcFramework.Attributes.Validation;

namespace SULS.App.BindingModels.Users
{
    public class UserRegisterInputModel
    {
        private const string UsernameErrorMessage = "Invalid username length! Must be between 5 and 20 symbols!";

        private const string PasswordErrorMessage = "Invalid password length! Must be between 6 and 20 symbold!";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        [EmailSis]
        public string Email { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, PasswordErrorMessage)]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }

        
    }
}