using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallisNexus.Paginas
{
    public class MeerInformatie
    {
        public void ToonMeerInformatie()
        {
            //Geeft console text kleur
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Meer Informatie");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Kies een onderwerp:");
            Console.Write("1.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tickets");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bereikbaarheid");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Parkeren");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Huisregels");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Contact");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("6.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Terug naar hoofdmenu");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Maak uw keuze: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================");


            bool informatieTonen = true;

            while (informatieTonen)
            {
                string keuzeInvoer = Console.ReadLine();
                if (keuzeInvoer == "1")
                {
                    Console.WriteLine("Tickets");
                }
                if (keuzeInvoer == "2")
                {
                    Console.WriteLine("Bereikbaarheid");
                }
                if (keuzeInvoer == "3")
                {
                    Console.WriteLine("Parkeren");
                }
                if (keuzeInvoer == "4")
                {
                    Console.WriteLine("Huisregels");
                }
                if (keuzeInvoer == "5")
                {
                    Console.WriteLine("Contact");
                }
                if (keuzeInvoer == "6")
                {
                    Console.WriteLine("Je gaat nu terug naar hoofdmenu");
                    Console.Clear();
                    break;
                }
            }

        }

    }
}
