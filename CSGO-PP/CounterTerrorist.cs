using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_PP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Oppgave_CSGO
    {
        internal class CounterTerrorist
        {
            public string name { get; set; }
            public bool isDead { get; set; }

            public CounterTerrorist()
            {
                name = "CounterTerrorist";
                isDead = false;
            }

            public void Attack(Terrorist terrorist)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n------> CT ATTACK <-----");
                if (KillTerrorist())
                {
                    terrorist.isDead = true;
                    Console.WriteLine($"{terrorist.name} ble skutt og drept");
                } else Console.WriteLine($"{name} bommet");
            }

            public bool KillTerrorist()
            {
                var successRate = !Program.BombIsPlanted ? 5 : 3;
                if (Program.IsSuccessful(successRate)) return true;
                return false;

            }

            public void DefuseBomb()
            {

            }

        }

    }

}
