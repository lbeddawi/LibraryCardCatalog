using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace LibraryCardCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Please enter a file name");
            
            string FileName = Console.ReadLine();
            CardCatalog c = new CardCatalog(FileName);


            // make sure to add a defensive mechanism against the entry of the user
            DisplayMenu();
            string Selection = Console.ReadLine();
            
            int Choice = Convert.ToInt32(Selection);

            //bool result = Int32.TryParse(Selection, out Choice);
            
            
            while(Choice!=3)
            {
                if(Choice==1)
                {
                    c.ListBooks();

                }
                else if(Choice==2)
                {
                    Console.WriteLine("Please enter an author");
                    string UserAuthor = Console.ReadLine();
                    Console.WriteLine("Please enter an title");
                    string UserTitle = Console.ReadLine();
                    Book NewBook = new Book(UserAuthor, UserTitle);
                    c.AddBook(NewBook);
                }

            }
            
            {
                
            }

        }
        public static void DisplayMenu()
        {
            Console.WriteLine("Please choose an option");
            Console.WriteLine("1. List all books");
            Console.WriteLine("2. Add a book");
            Console.WriteLine("3. Save and exit");
        }

    }
}
