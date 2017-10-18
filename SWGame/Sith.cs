using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWGame
{
    class Sith:Character
    {
        public Sith(string name, int attack_power, int spell_power, int hp, double Offensive_Stance) :base(name,attack_power,spell_power,hp)
        {

            this.Offensive_Stance = Offensive_Stance;
        }

        public double Offensive_Stance { get; private set; }


        public string Attack_Move()
        {
            return "x";
        }

        public string Force_Push()
        {
            return "x";
        }
    }
}
