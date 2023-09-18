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
            bool p1c;
            bool p2c;
            int TurnCounter = 1;
            int Player1Choice;
            int Player2Choice;
            bool gameover = false;
            int PlayersMoves = 0;
            Player currentPlayer;
            Player enemyPlayer;
            bool BoolPlayerChoice;
            int playerChoice;
            int checkAttack = 0;

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
                if (p1c)
                {
                    if (Player1Choice > 3 && Player1Choice < 0)
                    {
                        Console.WriteLine("Wrong choice, try again");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choice, try again");
                } 

            } while (!p1c);


            Console.WriteLine("Player 2: ");

            do
            {
                p2c = int.TryParse(Console.ReadLine(), out Player2Choice);
                if (p2c)
                {
                    if (Player2Choice > 3 && Player2Choice < 0)
                    {
                        Console.WriteLine("Wrong choice, try again");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong choice, try again");
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
                Console.WriteLine("-----------------Turn " + (TurnCounter++) + "------------------");

                

                    Console.WriteLine(@"Possible moves (1-4):
1. Attack
2. Block (have priority)
3. Heal (have priority)
4. Stats (doesn't end move)");

                //loop for players moves

                PlayersMoves = 0;

                do
                {
                    if (PlayersMoves == 1)
                    {
                        currentPlayer = player2;
                        enemyPlayer = player1;
                    }
                    else
                    {
                        currentPlayer = player1;
                        enemyPlayer = player2;
                    }
                    Console.WriteLine(currentPlayer.name + "'s move:");

                    //checking if player chose correct move

                    do
                    {
                        BoolPlayerChoice = int.TryParse(Console.ReadLine(), out playerChoice);
                        if (BoolPlayerChoice)
                        {
                            if (playerChoice > 4 && playerChoice <= 0)
                            {
                                Console.WriteLine("Wrong choice, try again");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong choice, try again");
                        }

                    } while (!BoolPlayerChoice);

                    //finalizing player's move

                    switch (playerChoice)
                    {
                        case 1:
                            currentPlayer.Attack();
                            PlayersMoves++;
                            break;
                        case 2:
                            if (currentPlayer.blocksAvailable > 0)
                            {
                                currentPlayer.Block();
                                Console.WriteLine("Next attack will be blocked");
                                PlayersMoves++;
                            }
                            else
                                currentPlayer.Block();
                            break;
                        case 3:                           
                            if(currentPlayer.healsAvailable > 0)
                            {
                               currentPlayer.PlayerHeal();
                               Console.WriteLine(currentPlayer.name+" healed himself for "+currentPlayer.heal);
                               PlayersMoves++; 
                            }
                            else
                                currentPlayer.PlayerHeal();
                            break;
                        case 4:
                            currentPlayer.PrintStats();
                            break;
                    }

                } while (PlayersMoves <= 1);

                do
                {
                    //part of code responsible for attacking

                    if (player1.IsAttacking())
                    {
                        Console.WriteLine(player1.name + " attacks " + player2.name + " for " + player2.damage);
                        player2.DealDmg();
                        player1.attack = false;
                    }else if (player2.IsAttacking())
                    {
                        Console.WriteLine(player2.name + " attacks " + player1.name + " for " + player1.damage);
                        player1.DealDmg();                        
                        player2.attack = false;
                    }


                    //checking if one of players is dead

                    if (player1.IsDead())
                    {
                        Console.WriteLine("Congratulations, Player 2 wins as " + player2.name + " in " + (TurnCounter - 1) + " turns.");
                        gameover = true;
                        break;
                    }
                    else if (player2.IsDead())
                    {
                        Console.WriteLine("Congratulations, Player 1 wins as " + player1.name + " in " + (TurnCounter - 1) + " turns.");
                        gameover = true;
                        break;
                    }

                    checkAttack++;

                }while (checkAttack <= 1);

                Console.WriteLine("-----------------------------------------");

            } while (!gameover);

            Console.ReadKey();


        }
    }
}