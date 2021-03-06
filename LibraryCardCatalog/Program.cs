﻿using System;
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
            Console.WriteLine("Welcome to the Library Card Catalog!");

            // Prompt user for filename
            // Re-prompt if user doesn't enter a valid alphanumeric string
            string FileName;
            do
            {
                Console.WriteLine("Please enter a new or existing file name:");
                FileName = Console.ReadLine();
                if (!System.Text.RegularExpressions.Regex.IsMatch(FileName, @"^[a-zA-Z0-9]+$"))
                {
					Console.Clear();
                    Console.WriteLine("You must specify a file name to continue.\n" + 
                                     "File name can only contain letters and numbers.\n");
                }
            }
            while (!System.Text.RegularExpressions.Regex.IsMatch(FileName, @"^[a-zA-Z0-9]+$"));

            // if FileName exists, we must De-Serialize it
            // That is, create a new CardCatalog object
            // If it doesn't exist, then we proceed as usual
            // and save to that file once the user selects the Save option

            CardCatalog c = (File.Exists(FileName))
                            ? Program.Deserialize(FileName)
                            : new CardCatalog(FileName);
            
            RouteUserRequest(c, GetValidUserInput());
        }

        /// <summary>
        /// Reads the user's selection and calls the appropriate CardCatalog action
        /// </summary>
        /// <param name="c">current CardCatalog object</param>
        /// <param name="userSelection">User's menu choice (could be 1, 2, or 3.</param>
        private static void RouteUserRequest(CardCatalog c, int userSelection)
        {
            while (userSelection != 3)
            {
                if (userSelection == 1)
                {
                    c.ListBooks();
                }
                else if (userSelection == 2)
                {
                    c.AddBook(c.CreateBook());
                }

                userSelection = GetValidUserInput();
            }
            if (userSelection == 3)
            {
                c.Save();
            }
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
        /// Displays a menu with from which a user can make a selection.
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
            try
            {
				FileStream stream = File.Create(path);
				formatter.Serialize(stream, c);
				stream.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        public static CardCatalog Deserialize(string path)
        {
            FileStream stream = File.Open(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
				CardCatalog c = (CardCatalog)formatter.Deserialize(stream);
				stream.Close();
                return c;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new CardCatalog(path);
            }

        }
    }
}
