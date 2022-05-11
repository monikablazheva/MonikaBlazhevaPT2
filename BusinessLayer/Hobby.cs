using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Hobby
    {
        [Key]
        public int Id { get; private set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
        public Field Field { get; set; }
        
        private Hobby()
        {

        }

        public Hobby(string name)
        {
            Name = name;
        }
    }
}