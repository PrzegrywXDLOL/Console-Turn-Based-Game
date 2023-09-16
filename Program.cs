using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based_Game__Console_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            Player player2 = new Player();
            int[,] characterStats = { {5, 5, 3, 2, 3},
                                      {7, 4, 2, 3, 2},
                                      {4, 3, 5, 1, 5}};
            int TurnCounter = 0;
            int Player1Choice;
            int Player2Choice;
            bool p1c;
            bool p2c;
            bool gameover = false;
            bool TurnEnded = false;
            int currentPlayer = 1;

            Console.WriteLine(@"Choose Your character (1-3):
1. Assasin: HP - 5, Damage - 5, Heal - 3, Heals Available - 3, Blocks Available - 2
2. Knight: HP - 7, Damage - 4, Heal - 2, Heals Available - 2, Blocks Available - 3
3. Mage: HP - 4, Damage - 3, Heal - 5, Heals Available - 5, Blocks Available - 1");

            Console.WriteLine("Player 1: ");

            //checking if user chose good character (no a,b,c, etc. and in range from 1 to 3)
            //if not program will tell him to choose again

            do
            {
                p1c = int.TryParse(Console.ReadLine(), out Player1Choice);
                if (Player1Choice < 4 && Player1Choice > 0)
                {
                    if (!p1c)
                        Console.WriteLine("Wrong choice, try again");
                }
                else
                {
                    Console.WriteLine("Wrong choice, try again");
                    p1c = false;
                }
                
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
                {
                    Console.WriteLine("Wrong choice, try again");
                    p2c = false;
                }    

            } while (!p2c);

            //variables made only to apply damage stats to players (for example player1
            //will get damage stat of player2)

            int p1d = Player1Choice - 1;
            int p2d = Player2Choice - 1;

            Console.Clear();

            //applying stats to players according to chosen characters

            switch (Player1Choice)
            {
                case 1:
                    player1.SetStats("Assasin", characterStats[0, 0], characterStats[p2d, 1], characterStats[0, 2], characterStats[0, 3], characterStats[0, 4]);
                    break;
                case 2:
                    player1.SetStats("Knight", characterStats[1, 0], characterStats[p2d, 1], characterStats[1, 2], characterStats[1, 3], characterStats[1, 4]);
                    break;
                case 3:
                    player1.SetStats("Mage", characterStats[2, 0], characterStats[p2d, 1], characterStats[2, 2], characterStats[2, 3], characterStats[2, 4]);
                    break;
            }

            switch (Player2Choice)
            {
                case 1:
                    player2.SetStats("Assasin", characterStats[0, 0], characterStats[p1d, 1], characterStats[0, 2], characterStats[0, 3], characterStats[0, 4]);
                    break;
                case 2:
                    player2.SetStats("Knight", characterStats[1, 0], characterStats[p1d, 1], characterStats[1, 2], characterStats[1, 3], characterStats[1, 4]);
                    break;
                case 3:
                    player2.SetStats("Mage", characterStats[2, 0], characterStats[p1d, 1], characterStats[2, 2], characterStats[2, 3], characterStats[2, 4]);
                    break;
            }

            //Turn system and actual game

            do
            {
                Console.WriteLine("------------------Turn " + (TurnCounter++) + "-----------------");

                //loop for players moves

                do
                {
                    Console.WriteLine(@"Possible moves (1-4):
1. Attack
2. Block
3. Heal
4. Stats (doesn't end move)");

                    Console.WriteLine("Player's " + currentPlayer + " move:");

                } while (!TurnEnded);

                //checking if one of players are dead

                if (player2.IsDead())
                {
                    Console.WriteLine("Congratulations, Player 1 wins as " + player1.name + " in " + TurnCounter + " turns.");
                    gameover = true;
                }
                else if (player1.IsDead())
                {
                    Console.WriteLine("Congratulations, Player 2 wins as " + player2.name + " in " + TurnCounter + " turns.");
                    gameover = true;
                }

                Console.WriteLine("-----------------------------------------");

            } while (!gameover);

            Console.ReadKey();


        }
    }
}