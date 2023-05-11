using HymnCenter.Shared.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace HymnCenter.Server.Models
{
    public class DataGenerator
    {
        public static void Initialize(AppDbContext appDbContext)
        {
            Randomizer.Seed = new Random(32321);
            //appDbContext.Database.EnsureDeleted();
            //appDbContext.Database.EnsureCreated();

            if (!(appDbContext.Hymns.Any()))
            {
                //Create test hymns
                var testHymns = new Faker<Hymn>()
                    .RuleFor(a => a.Title, f => f.Lorem.Word())
                    .RuleFor(a => a.Scale, f => f.Lorem.Word())
                    .RuleFor(a => a.Lyrics, f => f.Lorem.Text());


                var hymns = testHymns.Generate(5);

                foreach (Hymn p in hymns)
                {
                    appDbContext.Hymns.Add(p);
                }
                appDbContext.SaveChanges();
            }

            if (!(appDbContext.Users.Any()))
            {
                var testUsers = new Faker<User>()
                    .RuleFor(u => u.FirstName, u => u.Name.FirstName())
                    .RuleFor(u => u.LastName, u => u.Name.LastName())
                    .RuleFor(u => u.Username, u => u.Internet.UserName())
                    .RuleFor(u => u.Password, u => u.Internet.Password());
                var users = testUsers.Generate(4);

                User customUser = new User()
                {
                    FirstName = "Terry",
                    LastName = "Smith",
                    Username = "admin",
                    Password = "admin"
                };

                users.Add(customUser);

                foreach (User u in users)
                {
                    u.PasswordHash = BCrypt.Net.BCrypt.HashPassword(u.Password);
                    u.Password = "**********";
                    appDbContext.Users.Add(u);
                }
                appDbContext.SaveChanges();
            }

            if (!(appDbContext.Categories.Any()))
            {
                var hymnCategories = new List<Category>
                {
                    new Category()
                    {
                        CategoryName="Entrance"
                    },
                    new Category()
                    {
                        CategoryName="Offerings"
                    },
                    new Category()
                    {
                        CategoryName="PeaceGiving"
                    },
                    new Category()
                    {
                        CategoryName="FirstBlessing"
                    },
                    new Category()
                    {
                        CategoryName="SecondBlessing"
                    },
                    new Category()
                    {
                        CategoryName="Communion"
                    },
                    new Category()
                    {
                        CategoryName="Outrance"
                    }
                };

                foreach (Category hymnCategory in hymnCategories)
                {
                    appDbContext.Categories.Add(hymnCategory);
                }

                appDbContext.SaveChanges();
            }

            if (!(appDbContext.Listings.Any()))
            {
                //Create test listings
                var testListings = new Faker<Listing>()
                    .RuleFor(a => a.Header, f => f.Lorem.Word())
                    .RuleFor(a => a.Date, f => f.Date.Future(1, DateTime.Today))
                    .RuleFor(a => a.Footer, f => f.Lorem.Word());


                var listings = testListings.Generate(2);

                foreach (Listing p in listings)
                {
                    appDbContext.Listings.Add(p);
                }
                appDbContext.SaveChanges();
            }
        }
    }
}