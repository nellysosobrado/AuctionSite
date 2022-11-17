using System;
using Microsoft.Extensions.Configuration;
using SkysDBDemoDatabas;

public class Program
{
    private static void Main(string[] args)
    {
        // Create a builder to access appsettings.json
        var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
        var config = builder.Build();

        // Hämta connection string från appsettings.json
        var connectionString = config.GetConnectionString("DefaultConnection");

        // Starta vår app med connectionstring som en parameter
        var application = new Application(connectionString);
        application.Run();

    }
}