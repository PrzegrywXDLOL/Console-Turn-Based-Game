using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based_Game__Console_
{
    internal class Player
    {
        public string name;
        public int hp;
        public int damage;
        public int heal;
        public int healsAvailable;
        public bool dead = false;
        public bool block = false;
        public int blocksAvailable;

        public Player() { }
        public void SetStats(string Name, int HP, int Damage, int Heal, int BlocksAvailable, int HealsAvailable)
        {
            name = Name;
            hp = HP;
            damage = Damage;
            heal = Heal;
            blocksAvailable = BlocksAvailable;
            healsAvailable = HealsAvailable;
        }

        public void DealDmg()
        {
            if (block && blocksAvailable > 0)
            {
                Console.WriteLine("Damage blocked");
                block = false;
            }
            else
                hp -= damage;
            
            if (hp <= 0)
                dead = true;
        }

        public void PlayerHeal()
        {
            if (healsAvailable > 0)
            {
                hp += heal;
                healsAvailable--;
            }
            else
                Console.WriteLine("No heals available");
        }

        public bool IsDead()
        {
            return dead;
        }

        public void Block()
        {
            block = true;
        }

        public void PrintStats()
        {
            Console.WriteLine("------------------Stats------------------");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("HP: " + hp);
            Console.WriteLine("Heal: " + heal);
            Console.WriteLine("Heals Available: " + healsAvailable);
            Console.WriteLine("Blocks Available: " + blocksAvailable);
            Console.WriteLine("-----------------------------------------");
        }
    }
}
