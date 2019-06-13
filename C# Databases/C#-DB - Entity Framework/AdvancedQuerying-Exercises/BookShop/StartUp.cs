using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                int a = RemoveBooks(db);
                Console.WriteLine(a);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var cmd = Enum.Parse<AgeRestriction>(command, true);

            var books = context
                .Books
                .Where(x => x.AgeRestriction == cmd)
                .OrderBy(x => x.Title)
                .Select(t => t.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var books = context
                .Books
                .Where(x => x.BookCategories.Any(y => categories.Contains(y.Category.Name.ToLower())))
                .OrderBy(x => x.Title)
                .Select(t => t.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value < dateTime)
                .OrderByDescending(r => r.ReleaseDate.Value)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(x => $"{x.FirstName} {x.LastName}"));
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title,
                    AuthorFullName = x.Author.FirstName + " " + x.Author.LastName
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.AuthorFullName})"));
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context
                .Books
                .Count(x => x.Title.Length > lengthCheck);
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    books = x.Books.Sum(y => y.Copies)
                })
                .OrderByDescending(x => x.books)
                .ToList();

            return string.Join(Environment.NewLine,
                authors.Select(x => $"{x.FirstName + " " + x.LastName} - {x.books}"));
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(x => new
                {
                    x.Name,
                    books = x.CategoryBooks.Sum(y => y.Book.Copies * y.Book.Price)
                })
                .OrderByDescending(x => x.books)
                .ThenBy(x => x.Name)
                .ToList();

            return string.Join(Environment.NewLine, categories.Select(x => $"{x.Name} ${x.books}"));
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(x => new
                {
                    x.Name,
                    books = x.CategoryBooks
                        .Select(y => new
                        {
                            y.Book.Title,
                            y.Book.ReleaseDate
                        })
                        .OrderByDescending(y => y.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(books);
            context.SaveChanges();
            return books.Count;

        }
    }
}
