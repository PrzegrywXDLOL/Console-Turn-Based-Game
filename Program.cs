using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based_Game__Console_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int TurnCounter = 0;
            int Player1Choice;
            int Player2Choice;
            bool p1c = false;
            bool p2c = false;

            Console.WriteLine(@"Choose Your character:
1. Assasin: HP - 5, Damage - 5, Heal - 3, Heals Available - 3, Blocks Available - 2
2. Knight: HP - 7, Damage - 4, Heal - 2, Heals Available - 2, Blocks Available - 3
3. Mage: HP - 4, Damage - 3, Heal - 5, Heals Available - 5, Blocks Available - 1");

            Console.WriteLine("Player 1: ");

            do
            {
                p1c = int.TryParse(Console.ReadLine(), out Player1Choice);
                if (Player1Choice < 4 && Player1Choice > 0)
                {
                    if (!p1c)
                        Console.WriteLine("Wrong choice, try again");
                }
                else
                    Console.WriteLine("Wrong choice, try again");
                
            } while (!p1c);
            

            Console.WriteLine("Player 2: ");

            do
            {
                p2c = int.TryParse(Console.ReadLine(), out Player2Choice);
                if (Player2Choice < 4 && Player2Choice > 0)
                {
                    if (!p2c)
                        Console.WriteLine("Wrong choice, try again");
                }
                else
                    Console.WriteLine("Wrong choice, try again");

            } while (!p2c);

            Player player1 = new Player();
            Player player2 = new Player();


            Console.ReadKey();


        }
    }
}
