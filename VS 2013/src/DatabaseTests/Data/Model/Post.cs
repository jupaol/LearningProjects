using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PostId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public Guid BlogId { get; set; }

        public Blog Blog { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
