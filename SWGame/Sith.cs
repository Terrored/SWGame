using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SWGame
{
    class Sith:Character
    {
        Random random = new Random();
        public Sith(string name, int attack_power, int spell_power, int hp,bool turn, System.Windows.Controls.Image image, int Offensive_Stance) :base(name,attack_power,spell_power,hp,turn,image)
        {
            
            this.Offensive_Stance = Offensive_Stance;
        }

       // public Character opponent { get; set; }
        public int Offensive_Stance { get; set; }

        public override string  Attack_Move()
        {
            
                int dmg = random.Next(0, Attack_Power);
                opponent.HP = opponent.HP - dmg - Offensive_Stance;

            if (opponent.HP <= 0)
            {
                return Name + " zadał konczące uderzenie mieczem świetlnym zadając " + dmg + " obrażeń oraz zabijając " + opponent.Name + ".\n";
            }
            return Name + " wykonał cięcie mieczem świetlnym zadając " + dmg + " obrażeń. Dodatkowo zadał " + Offensive_Stance + " obrażeń pasywnie.\n";
        }

        public override string Force()
        {
            int dmg = random.Next(0, Spell_Power);
            opponent.HP = opponent.HP - dmg ;
            if (opponent.HP <= 0)
            {
                return Name + " zadał konczące uderzenie błyskawicą mocy zadając " + dmg + " obrażeń oraz zabijając " + opponent.Name + ".\n";
            }

            return Name + " użył błyskawicy mocy " + dmg + " obrażeń.\n";
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
