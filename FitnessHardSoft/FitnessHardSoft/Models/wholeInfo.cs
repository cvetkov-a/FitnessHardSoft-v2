using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessHardSoft.Models
{

    public class wholeInfo
    {
        public List<FitnessHardSoft.Models.Post> Posts { get; set; }
        public List<FitnessHardSoft.Models.ApplicationUser> Trainers { get; set; }
    }
}