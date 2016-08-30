using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardSoftMVC.Models
{
    public class BlogDetails
    {
        public HardSoftMVC.Models.Post Post {  get; set;  }
        public List<Tag> Tags { get; set; }
    }
}