using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Book> books = new BookRepository().GetBooks();

            // LINQ Extension Methods
            var totalPrice = books.Sum(b => b.Price);
            var minPrice = books.Min(b => b.Price);

            books.Where();
            books.Single()
            books.SingleOrDefault();

            books.First();
            books.FirstOrDefault();

            books.Last();
            books.LastOrDefault();

            books.Min();
            books.Max();
            books.Average();
            books.Sum();
            books.Count();

            books.Skip(5).Take(3);

            Console.WriteLine(totalPrice);
            Console.WriteLine(minPrice);
        }

        static void LinqBasics()
        {
            IEnumerable<Book> books = new BookRepository().GetBooks();

            // How to check for books under 10 dollars without LINQ
            //var cheapBooks = new List<Book>();
            //foreach (var book in books)
            //{
            //    if (book.Price < 10)
            //        cheapBooks.Add(book);
            //}

            // With LINQ
            // LINQ Extension Methods
            var cheapBooks = books
                                .Where(b => b.Price < 10)
                                .OrderBy(b => b.Title)
                                .Select(b => b.Title);

            // LINQ Query Operators
            var cheaperBooks = from b in books
                               where b.Price < 10
                               orderby b.Title
                               select b.Title;

            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book);
                //Console.WriteLine(book.Title + " " + book.Price);
            }
        }
    }
}
