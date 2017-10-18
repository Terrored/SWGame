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
        public Jedi (string name, int attack_power, int spell_power, int hp, int Defensive_Stance,Sith sith) :base(name,attack_power,spell_power,hp)
        {

            this.sith = sith;
            this.Defensive_Stance = Defensive_Stance;
        }

        public Sith sith;
        

        public int Defensive_Stance { get; set; }
       


        public string Attack_Move()
        {
            int dmg = random.Next(0, Attack_Power);
            sith.HP = sith.HP - dmg;
            
            return Name + " wykonał cięcie mieczem świetlnym zadając " + dmg + " obrażeń.";
        }

        public string Force_Push()
        {
            int dmg = random.Next(0, Spell_Power);
            sith.HP = sith.HP - dmg - Defensive_Stance;
            
            return Name + " wykonał pchięcie mocą zadając " + dmg + " obrażeń. Pasywnie zadał "+Defensive_Stance+" dodatkowych obrażeń";
        }
        
    }
}
