using System.Collections.Generic;

namespace ExpressProject.Model
{
    public class User
    {
        public int? UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public byte? Age { get; set; }

        public bool Sex { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
