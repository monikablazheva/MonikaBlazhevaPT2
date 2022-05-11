using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int Id { get; private set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required, MaxLength(20)]
        public string Surname { get; set; }

        [Range(18, 81, ErrorMessage = "Age should be between {0} and {1}.")]
        public int Age { get; set; }

        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required, MaxLength(70)]
        public string Password { get; set; }

        [Required, MaxLength(20)]
        public string Email { get; set; }

        public IEnumerable<User> Friends { get; set; }
        public IEnumerable<Hobby> Hobbies { get; set; }
        private User()
        {

        }
        public User(string name, string surname, int age, string username, string password, string email)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
