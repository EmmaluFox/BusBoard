using System;

namespace BusBoard
{
    public class ChooseMode
    {
        private const int Option1 = 1;
        private const int Option2 = 2;

        public static void ChooseFindMode()
        {
            Console.WriteLine("Find a bus stop by:\n1: PostCode\n2:TFL Stop ID\n");
            var choose = Console.ReadLine();
            if (choose != null)
            {
                bool integer = int.TryParse(choose, out int option);
                if (integer)
                {
                    if (option == Option1)
                    {
                        BusStop.FindByPostCode();
                    } else if (option == Option2)
                    {
                        BusStop.FindByStopId();
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
        }
        
    }
}