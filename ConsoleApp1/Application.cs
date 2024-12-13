using System;
using System.Linq;
using ConsoleApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace SkysDBDemoDatabas
{
    // Hanterar applikationslogiken
    public class Application
    {
        private readonly string _connectionString;

        // Konstruktor som tar in anslutningssträngen
        public Application(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Kör applikationen
        public void Run()
        {
            var options = new DbContextOptionsBuilder<NellysAuctionSiteContext>()
                .UseSqlServer(_connectionString, opts => opts.EnableRetryOnFailure())
                .Options;

            using (var dbContext = new NellysAuctionSiteContext(options))
            {
                // Kontrollera om databasen existerar och skapa vid behov
                if (!dbContext.Database.CanConnect())
                {
                    Console.WriteLine("Databasen existerar inte. Försöker skapa...");
                    Console.WriteLine("Tryck valfi knapp för att fortsätta");
                    Console.ReadKey();
                    try
                    {
                        dbContext.Database.EnsureCreated();
                        Console.WriteLine("Databasen har skapats.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fel vid skapande av databasen: {ex.Message}");
                        return;
                        Console.WriteLine("Tryck valfi knapp för att fortsätta");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Databasen, existerar och är nu ansluten.");
                    Console.WriteLine("Tryck valfi knapp för att fortsätta");
                    Console.ReadKey();
                }

                while (true)
                {
                    // Visa meny
                    Console.Clear();
                    Console.WriteLine("1. Skapa ny användare");
                    Console.WriteLine("2. Lista alla användare");
                    Console.WriteLine("3. Uppdatera användare");
                    Console.WriteLine("4. Lägg till ett bid");
                    Console.WriteLine("5. Visa alla bids per användare");
                    Console.WriteLine("0. Avsluta");

                    // Läs val från användaren
                    if (!int.TryParse(Console.ReadLine(), out int sel) || sel < 0 || sel > 5)
                    {
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        continue;
                    }

                    if (sel == 0) break;

                    try
                    {
                        switch (sel)
                        {
                            case 1:
                                CreateUser(dbContext);
                                break;
                            case 2:
                                ListUsers(dbContext);
                                break;
                            case 3:
                                UpdateUser(dbContext);
                                break;
                            case 4:
                                AddBid(dbContext);
                                break;
                            case 5:
                                ShowAllBidsPerUser(dbContext);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ett fel inträffade: {ex.Message}");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                        Console.ReadKey();
                    }
                }
            }
        }

        // Skapa ny användare
        private void CreateUser(NellysAuctionSiteContext dbContext)
        {
            var user = new User();

            Console.WriteLine("Ange användarnamn:");
            user.UserName = Console.ReadLine();
            Console.WriteLine("Ange lösenord:");
            user.Password = Console.ReadLine();
            Console.WriteLine("Ange namn:");
            user.Name = Console.ReadLine();
            Console.WriteLine("Ange adress:");
            user.Street = Console.ReadLine();
            Console.WriteLine("Ange postnummer:");
            user.PostalCode = int.Parse(Console.ReadLine());
            Console.WriteLine("Ange stad:");
            user.City = Console.ReadLine();

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            Console.WriteLine("Användare skapad.");
            Console.WriteLine("Tryck valfi knapp för att fortsätta");
            Console.ReadKey();
        }

        // Lista alla användare
        private void ListUsers(NellysAuctionSiteContext dbContext)
        {
            var users = dbContext.Users.ToList();
            if (!users.Any())
            {
                Console.WriteLine("Inga användare hittades.");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Namn: {user.Name}, Stad: {user.City}");
            }
            Console.WriteLine("Tryck valfi knapp för att fortsätta");
            Console.ReadKey();
        }

        // Uppdatera användare
        private void UpdateUser(NellysAuctionSiteContext dbContext)
        {
            Console.WriteLine("Ange Id på användaren som ska uppdateras:");
            if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
            {
                Console.WriteLine("Ogiltigt Id.");
                return;
            }

            var user = dbContext.Users.FirstOrDefault(u => u.Id == idToUpdate);
            if (user == null)
            {
                Console.WriteLine("Ingen användare hittades med det angivna Id.");
                return;
            }

            Console.WriteLine("Ange nytt användarnamn:");
            user.UserName = Console.ReadLine();
            Console.WriteLine("Ange nytt namn:");
            user.Name = Console.ReadLine();

            dbContext.SaveChanges();
            Console.WriteLine("Användaren har uppdaterats.");
            Console.WriteLine("Tryck valfi knapp för att fortsätta");
            Console.ReadKey();
        }

        // Lägg till ett bid
        private void AddBid(NellysAuctionSiteContext dbContext)
        {
            Console.WriteLine("Ange Id på användaren för bid:");
            if (!int.TryParse(Console.ReadLine(), out int idToUpdate))
            {
                Console.WriteLine("Ogiltigt Id.");
                return;
            }

            var user = dbContext.Users.Include(u => u.Bids).FirstOrDefault(u => u.Id == idToUpdate);
            if (user == null)
            {
                Console.WriteLine("Ingen användare hittades med det angivna Id.");
                return;
            }

            var bid = new Bid
            {
                Date = DateTime.UtcNow,
                Amount = 300 // Exempelvärde
            };
            user.Bids.Add(bid);

            dbContext.SaveChanges();
            Console.WriteLine("Bid har lagts till.");
            Console.WriteLine("Tryck valfi knapp för att fortsätta");
            Console.ReadKey();
        }

        // Visa alla bids per användare
        private void ShowAllBidsPerUser(NellysAuctionSiteContext dbContext)
        {
            var usersWithBids = dbContext.Users.Include(u => u.Bids).ToList();
            if (!usersWithBids.Any())
            {
                Console.WriteLine("Inga användare eller bids hittades.");
                return;
            }

            foreach (var user in usersWithBids)
            {
                Console.WriteLine($"Användare: {user.Name}");
                foreach (var bid in user.Bids)
                {
                    Console.WriteLine($"  - Bid: {bid.Amount}, Datum: {bid.Date}");
                }
            }
            Console.WriteLine("Tryck valfi knapp för att fortsätta");
            Console.ReadKey();
        }
    }
}
