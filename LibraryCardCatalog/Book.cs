using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace LibraryCardCatalog
{
    public class Book
    {
        public string Title
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public Book(string author, string title)
        {
            this.Title = title;
            this.Author = author;
        }
    }
}
