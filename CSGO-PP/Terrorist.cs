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
        internal class Terrorist
        {
            public string name { get; set; }
            public bool isDead { get; set; }

            public Terrorist()
            {
                name = "Terrorist";
                isDead = false;
            }



            public void Attack(CounterTerrorist ct)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n------> T ATTACK <-----");
                if (!Program.BombIsPlanted)
                {
                    if(FindBombSite()) PlantBomb();
                }
                if (KillCounterTerrorist(ct))
                {
                    ct.isDead = true;
                    Console.WriteLine($"{ct.name} ble skutt og drept");
                } else Console.WriteLine($"{name} bommet");
            }


            public bool PlantBomb()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("****Bomben er plantet****");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Program.BombIsPlanted = true;
                return true;
            }

            public bool FindBombSite()
            {
                Console.WriteLine("Beveger seg mot bombspot A");
                if (Program.IsSuccessful(10)) return true;
                return false;
            }

            public bool KillCounterTerrorist(CounterTerrorist ct)
            {
                if (Program.IsSuccessful(7)) return true;
                return false;
            }
        }
    }

}
