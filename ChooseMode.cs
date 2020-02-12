using System;

namespace BusBoard
{
    public static class ChooseMode
    {
        private const int Option1 = 1;
        private const int Option2 = 2;

        public static int ChooseFindMode()
        {
            Console.WriteLine("Find a bus stop by:\n1:PostCode\n2:TFL Stop ID\n");
            var choose = Console.ReadLine();
            var choice = 0;
            if (choose != null)
            {
                var integer = int.TryParse(choose, out var option);
                if (integer)
                {
                    if (option == Option1)
                        choice = Option1;
                    else if (option == Option2) choice = Option2;
                }
                else
                {
                    Console.WriteLine("Sorry, I don't understand...\n");
                    choice = ChooseFindMode();
                }
            }
            else
            {
                Console.WriteLine("Sorry, I don't understand...\n");
                choice = ChooseFindMode();
            }

            return choice;
        }
    }
}