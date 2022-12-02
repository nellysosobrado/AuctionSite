using System;
using Microsoft.Extensions.Configuration;
using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
        var config = builder.Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        var options = new DbContextOptionsBuilder<RichardsAuctionSiteContext>();
        options.UseSqlServer(connectionString);

        using (var dbContext = new RichardsAuctionSiteContext(options.Options))
        {
            foreach (var user in dbContext.Users.OrderBy(u => u.City))
            {
                Console.WriteLine($"{user.Name}: {user.City}");
            }
        }
    }
}