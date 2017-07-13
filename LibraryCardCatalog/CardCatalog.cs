using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace LibraryCardCatalog
{
    public class CardCatalog
    {
        private string _fileName;
        private List<Book> Books = new List<Book>();
        
        public CardCatalog(string fileName)
        {

        }
        public void ListBooks()
        {
           foreach(Book b in Books)
            {
                Console.WriteLine("{0} - {1}", b.Author, b.Title);
            }
        }

        public void AddBook (Book b)
        {
            Books.Add(b);
        }

        public void Save ()
        {

        }
    }
}
