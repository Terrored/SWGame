using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SWGame
{
     abstract class Character
    {
        public string Name { get; private set; }
        public int Attack_Power { get; private set; }

        public int Spell_Power { get;private set; }

        public int HP { get;  set; }

        public bool Turn { get; set; }

        public System.Windows.Controls.Image Image { get; set; }

        public Character(string name, int attack_power, int spell_power, int hp, bool turn, System.Windows.Controls.Image image)
        {
            Name = name;
            Attack_Power = attack_power;
            Spell_Power = spell_power;
            HP = hp;
            Turn = turn;
            Image = image;
        }

        abstract public string Attack_Move();
        abstract public string Force();
        public Character opponent { get; set; }



    }
}
