using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Template.Entities
{
    public class AppUser:IdentityUser
    {
        public string ImageAdress { get; set; }
        public string Description { get; set; }
    }
}
