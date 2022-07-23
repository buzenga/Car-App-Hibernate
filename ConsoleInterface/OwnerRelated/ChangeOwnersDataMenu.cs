using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.ConsoleInterface.OwnerRelated
{
    public class ChangeOwnersDataMenu
    {
        static string[] availableOptions = {
            "Change first name",
            "Change last name",
            "Back"
        };

        static int currentMode = 0;
        public static void StartChangeOwnersDataMenu()
        { 
            bool running = true;
            while (running == true)
            {
                Console.CursorVisible = false;

                DisplayMenu();
                ChangeMode();
                running = RunChosenMode();

            }
            currentMode = 0;
        }

        private static bool RunChosenMode()
        {
            switch (currentMode)
            {
                case 0: Console.Clear(); OwnersOperations.ChangeOwnersFirstName(); break;
                case 1: Console.Clear(); OwnersOperations.ChangeOwnersLastName(); break;
                case 3: break;
            }
            return false;
        }
        private static void ChangeMode()
        {
            do
            {
                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.UpArrow)
                {
                    currentMode = currentMode > 0 ? currentMode - 1 : availableOptions.Length - 1;
                    DisplayMenu();
                }
                else if (button.Key == ConsoleKey.DownArrow)
                {
                    currentMode = (currentMode + 1) % availableOptions.Length;
                    DisplayMenu();
                }
                else if (button.Key == ConsoleKey.Escape)
                {
                    currentMode = availableOptions.Length - 1;
                    break;
                }
                else if (button.Key == ConsoleKey.Enter)
                {
                    break;
                }
            } while (true);


        }

        static void DisplayMenu()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(">>>> Choose option <<<<\n\n");

            for (int i = 0; i < availableOptions.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                if (i == currentMode)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.WriteLine(availableOptions[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(availableOptions[i]);
                }
            }
        }
    }
}
