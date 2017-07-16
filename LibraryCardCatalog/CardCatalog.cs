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
            // clear console
            Console.Clear();

            if (Books.Count == 0)
            {
                Console.WriteLine("There are no books in this catalog.\n");
            }
            else
            {
                Console.WriteLine("You have {0} books in this library catalog:",
                                  Books.Count());
				Console.WriteLine("------------------------------------------");
				foreach (Book b in Books)
				{
					Console.WriteLine("Author: {0}\n" +
                                      "Title: {1}\n", b.Author, b.Title);
				}
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
            Console.WriteLine("\nAdded {0} by {1} to the catalog!\n",
                              b.Title,b.Author);

            PauseMessage();
        }

		/// <summary>
		/// Prompts the user for an author and title.
		/// Uses the user's input to create a new Book object.
        /// Verifies that Author and Title fields are not blank
		/// </summary>
		public Book CreateBook()
		{
            string UserAuthor, UserTitle;
            Console.Clear();
            do
            {
                Console.WriteLine("Please enter an author");
                UserAuthor = Console.ReadLine();
                if (UserAuthor == "")
                {
					Console.Clear();
                    Console.WriteLine("Author cannot be blank.\n");
                }
            }
            while (UserAuthor == "");

            do
            {
                Console.WriteLine("Please enter an title");
                UserTitle = Console.ReadLine();
                if (UserTitle == "")
                {
                    Console.Clear();
                    Console.WriteLine("Title cannot be blank.\n");
                }
            }
            while (UserTitle == "");
			
			return new Book(UserAuthor, UserTitle);
		}

        public void Save ()
        {
            Program.Serialize(_fileName,this);
        }

        /// <summary>
        /// Requires user to press Enter before proceeding
        /// Used after listing books and adding books
        /// </summary>
        public void PauseMessage()
        {
			Console.WriteLine("\nPress Enter to go back to the menu:");
			Console.ReadLine();
        }
    }
}
