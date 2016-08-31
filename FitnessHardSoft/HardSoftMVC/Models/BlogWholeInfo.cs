using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardSoftMVC.Models
{
    public class BlogWholeInfo
    {
        public PagedList.IPagedList<HardSoftMVC.Models.Post> Posts {  get; set;  }
        public List<Tag> Tags { get; set; }
    }
}