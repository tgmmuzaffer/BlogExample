﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Name { get; set; }
    }
}
