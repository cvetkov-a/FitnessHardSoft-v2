using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardSoftMVC.Models
{
    public class CookMeIndexViewModel
    {
        public List<Trainer> Trainers { get; set; }
        public List<Post> Posts { get; set; }
        public Contact Contact { get; set; }
    }
}