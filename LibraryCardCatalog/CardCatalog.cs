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
            Console.Clear();
           Console.WriteLine("Here are all the books in this library catalog:");
           Console.WriteLine("---------------------------------------------");
           foreach(Book b in Books)
            {
                Console.WriteLine("{1}\t{0}", b.Author, b.Title);
            }

            PauseMessage();
        }
        /// <summary>
        /// Adds the passed Book object to the instance's Books List 
        /// </summary>
        /// <param name="b">The blue component.</param>
        public void AddBook (Book b)
        {
            Books.Add(b);
            Console.WriteLine("\nAdded {0} by {1} to the catalog!\n",b.Title,b.Author);

            PauseMessage();
        }

		/// <summary>
		/// Prompts the user for an author and title
		/// Uses the user's input to create a new Book object
		/// </summary>
		public Book CreateBook()
		{
			// clear the console
			Console.Clear();

			Console.WriteLine("Please enter an author");
			string UserAuthor = Console.ReadLine();

			Console.WriteLine("Please enter an title");
			string UserTitle = Console.ReadLine();
			return new Book(UserAuthor, UserTitle);
		}

        public void Save ()
        {
            Program.Serialize(_fileName,this);
        }

        /// <summary>
        /// Requires user to press a key before proceeding
        /// Used after listing books and adding books
        /// </summary>
        public void PauseMessage()
        {
			Console.WriteLine("\nPress any key to go back to the menu:");
			Console.ReadLine();
        }
    }
}
