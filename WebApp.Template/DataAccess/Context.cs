using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Template.Entities;

namespace BaseProject.DataAccess
{
    public class Context:IdentityDbContext<AppUser>
    {
        public Context(DbContextOptions<Context>dbContextOptions):base(dbContextOptions)
        {

        }
    }
}
