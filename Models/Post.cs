using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static AnimalsFriends.Helpers.Classes;

namespace AnimalsFriends.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string PreviewImg { get; set; }

        //can make it class later on
        public BlogCategory Category { get; set; }

        //Author
        public int UserId { get; set; }

        public DateTime PublishedOn { get; set; }

        //For Causes
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        //For Posts
        public int? AnimalId { get; set; }

        //[JsonIgnore]
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Post")]
        public virtual User User { get; set; }

        [ForeignKey(nameof(AnimalId))]
        [InverseProperty("Post")]
        public virtual Animal Animal { get; set; }
    }
}
