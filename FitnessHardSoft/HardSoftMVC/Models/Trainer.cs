using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardSoftMVC.Models
{
    public class Trainer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Information { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}