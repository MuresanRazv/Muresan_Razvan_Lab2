using Microsoft.EntityFrameworkCore;
using Muresan_Razvan_Lab2.Models;

namespace Muresan_Razvan_Lab2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new
            LibraryContext(serviceProvider.GetRequiredService
            <DbContextOptions<LibraryContext>>()))
            {
                if (context.Book.Any())
                {
                    return; // BD a fost creata anterior
                }

                if (!context.Author.Any())
                {
                    context.Author.AddRange(
                        new Author
                        {
                            FirstName = "Mihail",
                            LastName = "Sadoveanu"
                        },
                        new Author
                        {
                            FirstName = "George",
                            LastName = "Calinescu"
                        },
                        new Author
                        {
                            FirstName = "Mircea",
                            LastName = "Eliade"
                        }
                    );
                }

                context.Book.AddRange(
                new Book
                {
                    Title = "Baltagul",
                    Author = context.Author.Single(a => a.FirstName == "Mihail" && a.LastName == "Sadoveanu"),
                    Price = Decimal.Parse("22")
                },
                new Book
                {
                    Title = "Enigma Otiliei",
                    Author = context.Author.Single(a => a.FirstName == "George" && a.LastName == "Calinescu"),
                    Price = Decimal.Parse("18")
                },
                new Book
                {
                    Title = "Maytrei",
                    Author = context.Author.Single(a => a.FirstName == "Mircea" && a.LastName == "Eliade"),
                    Price = Decimal.Parse("27")
                }
                );
                context.Genre.AddRange(
                new Genre { Name = "Roman" },
                new Genre { Name = "Nuvela" },
                new Genre { Name = "Poezie" }
                );
                context.Customer.AddRange(
                new Customer
                {
                    Name = "Popescu Marcela",
                    Address = "Str. Plopilor, nr. 24",
                    BirthDate = DateTime.Parse("1979-09-01")
                },
                new Customer
                {
                    Name = "Mihailescu Cornel",
                    Address = "Str. Bucuresti, nr. 45, ap. 2",
                    BirthDate = DateTime.Parse("1969 - 07 - 08")
                }
                );
                context.SaveChanges();
            }
        }
    }
}