using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace SkysDBDemoDatabas
{
    public class Application
    {
        private readonly string _connectionString;

        public Application(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Run()
        {
            var options = new DbContextOptionsBuilder<RichardsAuctionSiteContext>();
            options.UseSqlServer(_connectionString);
            using (var dbContext = new RichardsAuctionSiteContext(options.Options))
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1. Create new user");
                    Console.WriteLine("2. List all users");
                    Console.WriteLine("3. Update");
                    Console.WriteLine("4. Add bid");
                    Console.WriteLine("5. Show ALL bids per user");
                    Console.WriteLine("0. Avsluta");

                    int sel = Convert.ToInt32(Console.ReadLine());
                    if (sel == 0)
                        break;
                    if (sel == 1)
                    {
                        var user = new User();
                        Console.WriteLine("Ange Användarnamn:");
                        user.UserName = Console.ReadLine();
                        Console.WriteLine("Ange password:");
                        user.Password = Console.ReadLine();
                        Console.WriteLine("Ange namn:");
                        user.Name = Console.ReadLine();
                        Console.WriteLine("Adress:");
                        user.Street = Console.ReadLine();
                        Console.WriteLine("Postal:");
                        user.PostalCode = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Stad:");
                        user.City = Console.ReadLine();

                        // Vi lägger till en statisk 'Bid' för demons skull
                        var bid = new Bid();
                        bid.Amount = 100;
                        bid.Date = new DateTime(2022, 11, 18);
                        user.Bids.Add(bid);

                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                    }
                    if (sel == 2)
                    {
                        foreach (var user in dbContext.Users)
                        {
                            Console.WriteLine($"{user.Name}: {user.City}");
                        }
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                        Console.ReadLine();
                    }
                    if (sel == 3)
                    {
                        // För demons skulle använder vi en statisk 'id'
                        // I verkligheten skulle denna finnas som en parameter
                        var idToUpdate = 4;
                        var user = dbContext.Users.First(u => u.Id == idToUpdate);
                        user.UserName = "AL456";
                        user.Name = "Allison";
                        dbContext.SaveChanges();
                    }
                    if (sel == 4)
                    {
                        var idToUpdate = 4;
                        var user = dbContext.Users.First(u => u.Id == idToUpdate);
                        user.Bids.Add(new Bid
                        {
                            Date = DateTime.UtcNow,
                            Amount = 300
                        });
                        dbContext.SaveChanges(); //insert 
                    }
                    if (sel == 5)
                    {
                        // SELECT * FROM Users INNER JOIN INLOGGNING
                        foreach (var user in dbContext.Users
                                     .Include(u => u.Bids))
                        {
                            Console.WriteLine($"{user.Name}");
                            foreach (var bid in user.Bids)
                            {
                                Console.WriteLine($"{bid.Amount}");
                            }
                        }
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
