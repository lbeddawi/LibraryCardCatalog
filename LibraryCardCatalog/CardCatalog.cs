using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCardCatalog
{
    public class CardCatalog
    {
        private string _fileName;
        private List<Book> Books;
        
        public CardCatalog(string fileName)
        {

        }
        public void ListBooks(List<Book> bookList)
        {
           foreach(Book b in bookList)
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
