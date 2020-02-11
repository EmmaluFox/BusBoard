using System;

namespace BusBoard
{
    public class ChooseMode
    {
        private const int Option1 = 1;
        private const int Option2 = 2;

        public static int ChooseFindMode()
        {
            Console.WriteLine("Find a bus stop by:\n1: PostCode\n2:TFL Stop ID\n");
            var choose = Console.ReadLine();
            int choice = 0;
            if (choose != null)
            {
                bool integer = int.TryParse(choose, out int option);
                if (integer)
                {
                    if (option == Option1)
                    {
                        choice = Option1;
                    } else if (option == Option2)
                    {
                        choice = Option2;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, I don't understand...\n");
                    ChooseFindMode();
                }
            }
            else
            {
                Console.WriteLine("Sorry, I don't understand...\n");
                ChooseFindMode();
            }

            return choice;
        }
        
    }
}