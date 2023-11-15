using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    public class Numbers
    {
        public void PlayGame()
        {
            Random random = new Random();
            int numerPicks = random.Next(1, 101); 
            int userPicks = 0;

            Console.WriteLine("Zgadnij liczbę od 1 do 100");
            while (userPicks != numerPicks)
            {
                string userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out userPicks))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wpisz liczbę.");
                    Console.ResetColor();
                    continue;
                }

                if (userPicks > numerPicks)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Moja liczba jest trochę mniejsza niż {userPicks} :)");
                    Console.ResetColor();
                }
                else if (userPicks < numerPicks)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Moja liczba jest trochę większa niż {userPicks} :)");
                    Console.ResetColor();
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Zgadłeś/aś, moja liczba to: {numerPicks}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     \\o/     ");
            Console.WriteLine("      |      ");
            Console.WriteLine("     / \\    ");
            

        }
    }
}
