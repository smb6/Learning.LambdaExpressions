using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Learning.LambdaExpressions
{
    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {   // Using object initializer during init of list
                new Book() {Title = "Title 1", Price = 5},
                new Book() {Title = "Title 2", Price = 7},
                new Book() {Title = "Title 3", Price = 17}
            };
        }
    }

    public class Book
    {
        public string Title;
        public int Price;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // args => expression
            // () => ...
            // x => ...
            // (x, y, z) => ...
//            number => number*number

            Func<int, int> square = number => number*number;
            
            Console.WriteLine(square(5));
            Console.WriteLine(Square(5));

            const int factor = 5;

            Func<int, int> multiplier = n => n * factor;
            Console.WriteLine(multiplier(10));

            var books = new BookRepository().GetBooks();
            // Using predicate
//            var cheapBooks = books.FindAll(IsCheaperThan10Dollars);
            // Use a Lambda instead of predicate
            // Lambda Operator
            var cheapBooks = books.FindAll(book => book.Price < 10);

            foreach (var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }

            
        }

        static bool IsCheaperThan10Dollars(Book book)
        {
            return book.Price < 10;
        }

        static int Square(int number)
        {
            return number * number;
        }
    }
}
