﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectforReal.Models
{
    public class BlogUserIdentity: IdentityUser<string>
    { 
        //public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}
