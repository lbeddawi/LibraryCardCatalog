using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibraryCardCatalog
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for filename
            Console.WriteLine("Please enter a file name");
            string FileName = Console.ReadLine();

            // if FileName exists, we must De-Serialize it
            // That is, create a new CardCatalog object
            // If it doesn't exist, then we proceed as usual
            // and save to that file once the user selects the Save option

            CardCatalog c = (File.Exists(FileName)) ? Program.Deserialize(FileName) : new CardCatalog(FileName);

            // display menu and process user input
            int userSelection = GetValidUserInput();



            while (userSelection != 3)
            {
				if (userSelection == 1)
				{
					c.ListBooks();
				}
				else if (userSelection == 2)
				{
					c.AddBook(Program.CreateBook());
				}

                userSelection = GetValidUserInput();
            }

            if (userSelection == 3)
            {
                c.Save();
            }

        }

        /// <summary>
        /// Prompts the user for an author and title
        /// Uses the user's input to create a new Book object
        /// </summary>
        private static Book CreateBook()
        {
            // clear the console
            Console.Clear();

			Console.WriteLine("Please enter an author");
	        string UserAuthor = Console.ReadLine();
	        Console.WriteLine("Please enter an title");
	        string UserTitle = Console.ReadLine();
	        return new Book(UserAuthor, UserTitle);
		}

        /// <summary>
        /// Valid selections are the numbers 1, 2, or 3
        /// User will be prompted until a valid input is received
        /// </summary>
        /// <returns>The valid user input.</returns>
        private static int GetValidUserInput()
        {
            // Clear console
            Console.Clear();

            // Variable to represent the user's selection
            int Choice = 0;

            do
            {
                // display menu
                DisplayMenu();

                // Process and validate user's selection
                string Selection = Console.ReadLine();
                bool IsUserInputValid = Int32.TryParse(Selection, out Choice);

                // If user enters invalid input, display warning && re-prompt
                if (!IsUserInputValid || Choice > 3 || Choice < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number!\n");
                }

            }
            while (Choice <= 0 || Choice > 3);

            return Choice;
        }

        /// <summary>
        /// Displays a menu with from which a user can make a selection
        /// Valid inputs are 1, 2, and 3
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("Please choose an option");
            Console.WriteLine("1. List all books");
            Console.WriteLine("2. Add a book");
            Console.WriteLine("3. Save and exit");
        }

        //Link to relevant MSDN documenation
		//https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute?view=netframework-4.7
		public static void Serialize(string path, CardCatalog c)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Create(path);
            formatter.Serialize(stream, c);
            stream.Close();

        }

        public static CardCatalog Deserialize(string path)
        {
            FileStream stream = File.Open(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            CardCatalog c = (CardCatalog)formatter.Deserialize(stream);
            stream.Close();

            return c;
        }
    }
}
