using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
// A set of classes for handling a bookstore:
namespace Bookstore
{

    // Describes a book in the book list:
    public struct Book
    {
        public string Title;        // Title of the book.
        public string Author;       // Author of the book.
        public decimal Price;       // Price of the book.
        public bool Paperback;      // Is it paperback?

        public Book(string title, string author, decimal price, bool paperBack)
        {
            Title = title;
            Author = author;
            Price = price;
            Paperback = paperBack;
        }
    }

    // Declare a delegate type for processing a book:
    //每个委托类型都描述参数的数目和类型，以及它可以封装的方法的返回值类型。
    //每当需要一组新的参数类型或新的返回值类型时，都必须声明一个新的委托类型。
    public delegate void ProcessBookDelegate(Book book);

    // Maintains a book database.
    public class BookDB
    {
        // List of all books in the database:
        ArrayList list = new ArrayList();

        // 这个方法用来添加书的信息到list
        public void AddBook(string title, string author, decimal price, bool paperBack)
        {
            list.Add(new Book(title, author, price, paperBack));
        }

        
        public void ProcessPaperbackBooks(ProcessBookDelegate processBook)
        //用ProcessBookDelegate委托创建一个参数，主函数传入方法  
        {
            foreach (Book b in list)
            {
                if (b.Paperback)
                  //委托调用的示例,他的创建是在main中参数传入时完成的
                    processBook(b);  
            }
        }
    }
}


// Using the Bookstore classes:
namespace BookTestClient
{
    using Bookstore;

    // Class to total and average prices of books:
    class PriceTotaller
    {
        int countBooks = 0;
        decimal priceBooks = 0.0m;

        internal void AddBookToTotal(Book book)
        {
            countBooks += 1;
            priceBooks += book.Price;
        }

        internal decimal AveragePrice()
        {
            return priceBooks / countBooks;
        }
    }

    // Class to test the book database:
    class TestBookDB
    {
        // Print the title of the book.
        static void PrintTitle(Book b)     //这是一个静态方法
        {
            System.Console.WriteLine("   {0}", b.Title);
        }

        // Execution starts here.
        static void Main()
        {
            BookDB bookDB = new BookDB();    //

            // Initialize the database with some books:
            AddBooks(bookDB);           //添加书的方法写在最下面

            // Print all the titles of paperbacks:
            System.Console.WriteLine("Paperback Book Titles:");

            //声明了委托类型后，必须创建委托对象并使之与特定方法关联。
            //通过按下面示例中的方式将 PrintTitle 方法传递到 ProcessPaperbackBooks 方法来实现这一点
            //ProcessPaperbackBooks以委托作为参数方便传入方法
            bookDB.ProcessPaperbackBooks(PrintTitle);   //注意这里只是方法引用赋值给委托，所以没有（）

            PriceTotaller totaller = new PriceTotaller();

            //ProcessPaperbackBooks（）的参数是委托类型的，传入的是totaller.AddBookToTotal方法
            //通过遍历将金额相加
            bookDB.ProcessPaperbackBooks(totaller.AddBookToTotal);

            System.Console.WriteLine("Average Paperback Book Price: ${0:#.##}",
                    totaller.AveragePrice());
            Console.ReadKey();
            
        }

        // Initialize the book database with some test books:
        static void AddBooks(BookDB bookDB)
        {
            bookDB.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
            bookDB.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
            bookDB.AddBook("The MS-DOS Encyclopedia", "Ray Duncan", 129.95m, false);
            bookDB.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);
        }
    }
}
/* Output:
Paperback Book Titles:
   The C Programming Language
   The Unicode Standard 2.0
   Dogbert's Clues for the Clueless
Average Paperback Book Price: $23.97
*/
