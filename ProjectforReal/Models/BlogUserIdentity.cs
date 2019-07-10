using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectforReal.Models
{
    public class BlogUserIdentity: IdentityUser
    { 
        public Blog Blog { get; set; }



    }
}
