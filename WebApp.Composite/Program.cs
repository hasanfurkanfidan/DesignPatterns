using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Composite.DataAccess;
using WebApp.Composite.Entities;

namespace BaseProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var identityDbContext = scope.ServiceProvider.GetRequiredService<Context>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            identityDbContext.Database.Migrate();
            var newUser = new AppUser
            {
                UserName = "User1",
                Email = "furkanfidan.job@gmail.com"
            };
            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(newUser, "Password12*").Wait();


                var newCategory1 = new Category() { Name = "Suç Romanlarý", ReferenceId = 0, UserId = newUser.Id };
                var newCategory2 = new Category() { Name = "Cinayet Romanlarý", ReferenceId = 0, UserId = newUser.Id };
                var newCategory3 = new Category() { Name = "Polisiye Romanlarý", ReferenceId = 0, UserId = newUser.Id };

                identityDbContext.Categories.AddRange(newCategory1, newCategory2, newCategory3);
                identityDbContext.SaveChanges();

                var subCategory1 = new Category() { Name = "Suç Romanlarý1", ReferenceId = newCategory1.Id, UserId = newUser.Id };
                var subCategory2 = new Category() { Name = "Cinayet Romanlarý1", ReferenceId = newCategory2.Id, UserId = newUser.Id };
                var subCategory3 = new Category() { Name = "Polisiye Romanlarý1", ReferenceId = newCategory3.Id, UserId = newUser.Id };

                identityDbContext.Categories.AddRange(subCategory1, subCategory2, subCategory3);
                identityDbContext.Categories.AddRange(subCategory1, subCategory2, subCategory3);

                var subCategory4 = new Category() { Name = "Cinayet Romanlarý1.1", ReferenceId = subCategory2.Id, UserId = newUser.Id };

                identityDbContext.Categories.AddRange(subCategory4);

                identityDbContext.SaveChanges();
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
