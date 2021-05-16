using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalsFriends.Models
{
    public class User : IdentityUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Animal> Animal { get; set; } = new HashSet<Animal>();

        public virtual ICollection<Post> Post { get; set; } = new HashSet<Post>();
    }
}
