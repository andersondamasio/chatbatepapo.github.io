﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ChatClubeMauiApp.Shared.Services
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ChatClubeDbContext>
    {
        public ChatClubeDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ChatClubeMauiApp.Web"))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ChatClubeDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ChatClubeDbContext(optionsBuilder.Options);
        }
    }
}
