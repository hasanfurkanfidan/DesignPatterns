using BaseProject.DataAccess;
using BaseProject.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(new AppUser
                {
                    UserName = "User1",
                    Email = "furkanfidan.job@gmail.com"
                }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser
                {
                    UserName = "User2",
                    Email = "user2.job@gmail.com"
                }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser
                {
                    UserName = "User3",
                    Email = "user3.job@gmail.com"
                }, "Password12*").Wait();
            }
            Enumerable.Range(1, 30).ToList().ForEach(x =>
            {
                identityDbContext.Products.Add(new WebApp.Command.Entities.Product
                {
                    Name = $"Product{x}",
                    Stock = x + 50,
                    Price = x * 100
                });
            });
            identityDbContext.SaveChanges();
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
