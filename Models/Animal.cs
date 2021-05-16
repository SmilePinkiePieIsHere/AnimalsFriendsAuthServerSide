using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalsFriends.Models
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }
        
        public string CurrentStatus { get; set; }
        
        public string Species { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public string ProfileImg { get; set; }

        public Guid UserId { get; set; }
        
        public virtual User User { get; set; }

        public virtual ICollection<Post> Post { get; set; } = new HashSet<Post>();  
    }
}
