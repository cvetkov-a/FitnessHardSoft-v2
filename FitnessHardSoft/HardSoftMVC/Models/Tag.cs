using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HardSoftMVC.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string TagName { get; set; }
        public virtual List<Post> Posts { get; set; }
        private int defaultValue = 34;
        public int CountOfSearches { get{return defaultValue;} set{defaultValue=value;} }


    }
}