using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGame
{
    class Jedi : Character
    {
        
        Random random = new Random();
        public Jedi (string name, int attack_power, int maxattack_power, int spell_power, int maxspell_power, int hp, bool turn, Uri uri, int Defensive_Stance) :base(name, attack_power, maxattack_power, spell_power, maxspell_power, hp, turn, uri)
        {

            
            this.Defensive_Stance = Defensive_Stance;
        }

       
        

        public int Defensive_Stance { get; set; }
       


        public override string Attack_Move()
        {
            int dmg = random.Next(Attack_Power, MaxAttack_Power);
            opponent.HP = opponent.HP - dmg;
            if (opponent.HP <= 0)
            {
                return Name + " killed " + opponent.Name + " with his lightsaber dealing "  +dmg + " damage .\n";
            }
            return  Name + " swinged his lightsaber and dealt " + dmg + " damage. \n";
        }

        public override string Force()
        {
            int dmg = random.Next(Spell_Power, MaxSpell_Power);
            opponent.HP = opponent.HP - dmg - Defensive_Stance;
            if (opponent.HP <= 0)
            {
                return Name + " killed " + opponent.Name + " with force push dealing " + (dmg+Defensive_Stance) + " damage .\n";
            }

            return Name + " used force push and dealt " + dmg + " damage. He also dealt additional " + Defensive_Stance +" damage from his passive ability.\n";
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
