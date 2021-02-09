using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    public class Book
    {
        public string Title { get; set; }
        public int Price { get; set; }
    }

    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() {Title = "Title 1", Price = 5},
                new Book() {Title = "Title 2", Price = 7},
                new Book() {Title = "Title 3", Price = 17}
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            // Predicate is like a delegate, returns boolean value
            // All find methods accept a predicate
            // the code inside this method will iterate the collection
            // and for each object, will pass that object to a predicate
            // that determines if the condition is satisfied
            var cheapBooks = books.FindAll(IsCheaperThan10Dollars);

            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }

            // Lambda expression to above code
            var newCheapBooks = books.FindAll(b => b.Price < 10);
            // read as: book goes to book.Price is less than 10
            // this single line of code is the same as the static
            // method below. nice.
        }

        // Predicate method
        static bool IsCheaperThan10Dollars(Book book)
        {
            return book.Price < 10;
        }

        static void LambdaDemo()
        {
            // write a method that receives a number and returns
            // the square of that number

            // syntax for lambda expressions:
            // args => expression
            // assign to delegate
            //number => number * number;

            Func<int, int> square = number => number * number;

            // () => .... *no arguments*
            // x => .... *one argument*
            // (x, y) => ... *more than one*

            Console.WriteLine(square(5));

            const int factor = 5;

            Func<int, int> multipler = n => n * factor;

            var result = multipler(10);

            Console.WriteLine(result);
        }

        // You could write a method like this...
        static int Square(int number)
        {
            return number * number;
        }
    }
}
