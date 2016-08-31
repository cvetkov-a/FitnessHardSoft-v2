using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HardSoftMVC.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public virtual List<Tag> Tags { get; set; }
        public string TagsString { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Author_Id { get; set; }

        [ForeignKey("Author_Id")]
        public ApplicationUser Author { get; set; }
    }
}