using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalsFriends.Models
{
    public class User
    {
        public User()
        {
            Animal = new HashSet<Animal>();
            Post = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(256)]
        public string Password { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Animal> Animal { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Post> Post { get; set; }
    }
}
