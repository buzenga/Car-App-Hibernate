using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.ConsoleInterface.CarRelated
{
    public class FindCarsMenu
    {
        static string[] availableOptions = {
            "Find by ID",
            "Find by plate number",
            "Find by producer",
            "Find by model",
            "Back"
        };

        static int currentMode = 0;
        public static void StartFindCarsMenu()
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
                case 0: Console.Clear(); CarOperations.DisplayCarByID() ; break;
                case 1: Console.Clear(); CarOperations.DisplayCarsByPlateNumber(); break;
                case 2: Console.Clear(); CarOperations.DisplayCarsByProducer(); break;
                case 3: Console.Clear(); CarOperations.DisplayCarsByModel(); break;
                case 4: break;
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
