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
        public Jedi (string name, int attack_power, int spell_power, int hp, int Defensive_Stance) :base(name,attack_power,spell_power,hp)
        {

            
            this.Defensive_Stance = Defensive_Stance;
        }

        //public Character opponent;
        

        public int Defensive_Stance { get; set; }
       


        public override string Attack_Move()
        {
            int dmg = random.Next(0, Attack_Power);
            opponent.HP = opponent.HP - dmg;
            if (opponent.HP <= 0)
            {
                return Name + " zadał konczące uderzenie mieczem świetlnym zadając " + dmg + " obrażeń oraz zabijając " + opponent.Name + ".\n";
            }
            return Name + " wykonał cięcie mieczem świetlnym zadając " + dmg + " obrażeń. \n";
        }

        public override string Force()
        {
            int dmg = random.Next(0, Spell_Power);
            opponent.HP = opponent.HP - dmg - Defensive_Stance;
            if (opponent.HP <= 0)
            {
                return Name + " zadał konczące uderzenie pchnięciem mocy zadając  " + dmg + " obrażeń oraz zabijając " + opponent.Name+".\n";
            }

            return Name + " wykonał pchięcie mocą zadając " + dmg + " obrażeń. Pasywnie zadał "+Defensive_Stance+" dodatkowych obrażeń.\n";
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
