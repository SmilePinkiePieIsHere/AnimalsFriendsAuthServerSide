using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AnimalsFriends.Models
{
    public class Animal
    {
        public Animal()
        {
            Post = new HashSet<Post>();          
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }
        
        public string CurrentStatus { get; set; }
        
        public string Species { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public string ProfileImg { get; set; }

        public int UserId { get; set; }

        //[JsonIgnore]
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Animal")]
        public virtual User User { get; set; }

        [InverseProperty("Post")]
        public virtual ICollection<Post> Post { get; set; }
    }
}
