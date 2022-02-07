using System;
using System.Collections.Generic;
using System.Threading;

namespace CSGO_PP
{

    using Oppgave_CSGO;

    internal class Program
    {
        public static bool BombIsPlanted = false;
        public static bool gameOver = false;
        public static bool aliveCt = true;
        public static bool aliveT = true;


        public static void Main()
        {
            // var names[] = {}
            ;
            var terrorists = new List<Terrorist>();
            var counterTerrorists = new List<CounterTerrorist>();

            for (int i = 1; i <= 5; i++)
            {
                terrorists.Add(new Terrorist());
                counterTerrorists.Add(new CounterTerrorist());
            }

            while (!BombIsPlanted)
            {
                //Legge inn en find next alive player ? 
                //  Bomben er ikke plantet. CT og T Leter etter hverandre og prøver å drepe hverandre.

                var aliveTerrorist = FindAliveTerrorist(terrorists);
                var aliveCounterTerrorist = FindAliveCounterTerrorist(counterTerrorists);
                if (aliveTerrorist == -1)
                {
                    Console.WriteLine("CT WIN");
                    gameOver = true;
                    break;
                }
                if (aliveCounterTerrorist == -1)
                {
                    Console.WriteLine("T WIN");
                    gameOver = true;
                    break;
                }
                terrorists[aliveTerrorist].Attack(counterTerrorists[aliveCounterTerrorist]);
                counterTerrorists[aliveCounterTerrorist].Attack(terrorists[aliveTerrorist]);
                Thread.Sleep(1000);
            }

            //Ny while loop med "bomb timer"
            if (!gameOver)
            {
                var defuseCounter = 0;

                for (int i = 15; i >= 0; i--)
                {
                    var aliveTerrorist = FindAliveTerrorist(terrorists);
                    var aliveCounterTerrorist = FindAliveCounterTerrorist(counterTerrorists);

                    if (aliveCounterTerrorist > -1 && aliveTerrorist > -1)
                    {
                        terrorists[aliveTerrorist].Attack(counterTerrorists[aliveCounterTerrorist]);
                        counterTerrorists[aliveCounterTerrorist].Attack(terrorists[aliveTerrorist]);
                    }

                    if (aliveTerrorist == -1 && aliveCounterTerrorist >= 0)
                    {
                        defuseCounter++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("CT Defuser: " + defuseCounter);
                        if (defuseCounter == 5)
                        {
                            gameOver = true;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("CT WIN");
                            break;
                        }
                    }
                    if (defuseCounter < 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nBomb Timer: " + i + "\n");
                    }
                    if (i == 0 || aliveCounterTerrorist == -1)
                    {
                        gameOver = true;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(i == 0 ? "Bomben gikk av" : "Alle CT ble drept");
                        Console.WriteLine("Terrorists Win");
                        break;
                    }


                    Thread.Sleep(700);
                }
            }

        }
        public static int FindAliveTerrorist(List<Terrorist> terrorists)
        {
            var index = terrorists.FindIndex((x) => x.isDead == false);
            var counter = 5 - index;
            aliveT = index != -1 ? true : false;

            if (index == -1 && !BombIsPlanted)
            {
                WinCheck("Counter-Terrorists", index);
            }
            if (index != -1 && aliveCt)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\nDet er {counter} terrorister igjen");
            }

            return index;
        }
        public static int FindAliveCounterTerrorist(List<CounterTerrorist> counterTerrorists)
        {

            var index = counterTerrorists.FindIndex(x => x.isDead == false);
            var counter = 5 - index;
            aliveCt = index != -1 ? true : false;

            if (index == -1)
            {
                WinCheck("Terrorists", index);
            }

            if (index != -1 && aliveT)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Det er {counter} Counter-Terrorister igjen");
            }
            return index;
        }

        public static void WinCheck(string faction, int index)
        {
            if (index == -1)
            {
                Console.ForegroundColor = faction == "Terrorists" ? ConsoleColor.DarkYellow : ConsoleColor.Blue;
                Console.WriteLine($"{faction} Win");
                gameOver = true;
            }
        }

        public static bool IsSuccessful(int maxValue)
        {
            Random rand = new Random();
            return rand.Next(0, maxValue) == 2;

        }
    }
}
