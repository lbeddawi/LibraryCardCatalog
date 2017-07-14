using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace LibraryCardCatalog
{
    [Serializable()]
    public class CardCatalog
    {
        private string _fileName;
        private List<Book> Books = new List<Book>();
        
        public CardCatalog(string fileName)
        {
            this._fileName = fileName;
        }
        /// <summary>
        /// Iterates over the instance's Books list
        /// Prints out each book's author and title
        /// </summary>
        public void ListBooks()
        {
            //// clear console
            //Console.Clear();
           Console.WriteLine("\nHere are all the books in this library catalog:");
           Console.WriteLine("---------------------------------------------");
           foreach(Book b in Books)
            {
                Console.WriteLine("{0} --- {1}", b.Author, b.Title);
            }

            // wait for user to press enter
            Console.WriteLine("\nPress any key to go back to the menu:");
            Console.ReadLine();
        }
        /// <summary>
        /// Adds the passed Book object to the instance's Books List 
        /// </summary>
        /// <param name="b">The blue component.</param>
        public void AddBook (Book b)
        {
            Books.Add(b);
            Console.WriteLine("\nAdded {0} by {1} to the catalog!\n",b.Title,b.Author);
        }

        public void Save ()
        {
            Program.Serialize(_fileName,this);
        }
    }
}
