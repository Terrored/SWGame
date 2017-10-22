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

        public int MaxAttack_Power { get; private set; }

        public int Spell_Power { get;private set; }

        public int MaxSpell_Power { get; private set; }

        public int HP { get;  set; }

        public int MaxHP { get; set; }

        public bool Turn { get; set; }

        public Uri Uri { get; set; }

        public Character opponent { get; set; }


        public Character(string name, int attack_power , int maxattack_power, int spell_power, int maxspell_power, int hp, bool turn, Uri uri)
        {
            Name = name;
            Attack_Power = attack_power;
            MaxAttack_Power = maxattack_power;
            Spell_Power = spell_power;
            MaxSpell_Power = maxspell_power;
            HP = hp;
            Turn = turn;
            Uri = uri;
            
            
        }

        abstract public string Attack_Move();
        abstract public string Force();
        





    }
}
