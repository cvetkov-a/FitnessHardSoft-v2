using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardSoftMVC.Models
{
    public class Card
    {
        public int Id { get; set; }
        public DateTime DateOfCreating { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ApplicationUser Purchaser{ get; set; }
        public virtual TypeCard CardId { get; set; }

    }
}