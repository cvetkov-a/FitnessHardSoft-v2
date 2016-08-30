using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HardSoftMVC.Models
{
    public class TypeCard
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public virtual List<Card> CardsWithThatType { get; set; }
    }
}