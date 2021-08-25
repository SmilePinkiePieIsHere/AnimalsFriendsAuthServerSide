using System;
using System.ComponentModel.DataAnnotations;
using static AnimalsFriends.Helpers.Classes;

namespace AnimalsFriends.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string PreviewImg { get; set; }
       
        public BlogCategory Category { get; set; }
       
        public string UserId { get; set; }

        public DateTime PublishedOn { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? AnimalId { get; set; }

        public virtual User User { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
