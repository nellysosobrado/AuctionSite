using System;
using Microsoft.Extensions.Configuration;
using SkysDBDemoDatabas;
using ConsoleApp1.Data;

public class Program
{
    private static void Main(string[] args)
    {
        // 1: Först installerar vi två nuget paket
        //      Microsoft.EntityFrameworkCore.SqlServer
        //      Microsoft.EntityFrameworkCore.Tools

        // 2: Sedan kopierar vi i denna text till nuget console
        // "Server=localhost;Database=RichardsAuctionSite;Trusted_Connection=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Data

        // 3: Nu har vi möjlighet att loopa igenom datat i vår databas
        //using (var dbContext = new RichardsAuctionSiteContext())
        //{
        //    foreach (var user in dbContext.Users.OrderBy(u => u.City))
        //    {
        //        Console.WriteLine($"{user.Name}: {user.City}");
        //    }
        //}

        //// 6: Create a builder to access appsettings.json
        var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
        var config = builder.Build();

        //// Hämta connection string från appsettings.json
        var connectionString = config.GetConnectionString("DefaultConnection");

        //// Starta vår app med connectionstring som en parameter
        var application = new Application(connectionString);
        application.Run();

    }
}