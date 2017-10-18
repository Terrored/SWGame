using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGame
{
    class Sith:Character
    {
        Random random = new Random();
        public Sith(string name, int attack_power, int spell_power, int hp, int Offensive_Stance) :base(name,attack_power,spell_power,hp)
        {
            
            this.Offensive_Stance = Offensive_Stance;
        }

        public Character opponent { get; set; }
        public int Offensive_Stance { get; set; }

        public string Attack_Move()
        {
            int dmg = random.Next(0, Attack_Power);
            opponent.HP = opponent.HP - dmg -Offensive_Stance ;
            

            return Name + " wykonał cięcie mieczem świetlnym zadając " + dmg + " obrażeń. Dodatkowo zadał " + Offensive_Stance + " obrażeń pasywnie.\n" ;
        }

        public string Force_Lightning()
        {
            int dmg = random.Next(0, Spell_Power);
            opponent.HP = opponent.HP - dmg ;

            return Name + " użył błyskawicy mocy " + dmg + " obrażeń.\n";
        }

    }
}
