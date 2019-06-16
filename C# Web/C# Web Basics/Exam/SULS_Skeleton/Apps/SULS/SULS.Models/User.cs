using SIS.MvcFramework.Attributes.Validation;

namespace SULS.Models
{
    public class User
    {
        public string Id { get; set; }

        [RequiredSis]
        public string Username { get; set; }

        [RequiredSis]
        [EmailSis]
        public string Email { get; set; }

        [RequiredSis]

        public string Password { get; set; }
    }
}