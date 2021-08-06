using BaseProject.DataAccess;
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
using WebApp.Template.Entities;

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
                    Email = "furkanfidan.job@gmail.com",
                    ImageAdress="/img/primeuser.jpg",
                    Description = "Lorem Ipsum is simply dummy text " +
                    "of the printing and typesetting industry." +
                    " Lorem Ipsum has been the industry's standard dummy" +
                    " text ever since the 1500s, when an unknown printer took a " +
                    "galley of type and scrambled it to make a type specimen book." +
                    " It has survived not only five centuries, but also the leap into " +
                    "electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser
                {
                    UserName = "User2",
                    Description = "Lorem Ipsum is simply dummy text " +
                    "of the printing and typesetting industry." +
                    " Lorem Ipsum has been the industry's standard dummy" +
                    " text ever since the 1500s, when an unknown printer took a " +
                    "galley of type and scrambled it to make a type specimen book." +
                    " It has survived not only five centuries, but also the leap into " +
                    "electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    ImageAdress = "/img/primeuser.jpg",
                    Email = "user2.job@gmail.com"
                }, "Password12*"
                
                ).Wait();
                userManager.CreateAsync(new AppUser
                {
                    UserName = "User3",
                    ImageAdress= "/img/primeuser.jpg",
                    Description = "Lorem Ipsum is simply dummy text " +
                    "of the printing and typesetting industry." +
                    " Lorem Ipsum has been the industry's standard dummy" +
                    " text ever since the 1500s, when an unknown printer took a " +
                    "galley of type and scrambled it to make a type specimen book." +
                    " It has survived not only five centuries, but also the leap into " +
                    "electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Email = "user3.job@gmail.com"
                }, "Password12*").Wait();
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
