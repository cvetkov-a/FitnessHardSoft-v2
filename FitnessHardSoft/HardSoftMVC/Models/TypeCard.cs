﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HardSoftMVC.Models
{
    public class TypeCard
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual List<Card> CardsWithThatType { get; set; }
    }
}