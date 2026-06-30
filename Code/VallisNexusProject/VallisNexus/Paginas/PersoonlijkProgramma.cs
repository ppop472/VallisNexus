using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.Models;
using VallisNexus.DataAccess;
using System.IO;
using Newtonsoft.Json;
namespace VallisNexus.Paginas
{
    internal class PersoonlijkProgramma
    {
        public void ToonPersoonlijkProgramma()
        {
            DBOptreden dbOptreden = new DBOptreden();
            // Id van de gebruiker, voor nu is het 3 omdat er geen inlog is.

            DBFavoriet dbFavoriet = new DBFavoriet();
            List<Favoriet> favorieten = dbFavoriet.GetAlleFavoriet();



            //List<Podium> podiums = dbOptreden.GetOptredenMetId(2);
            //int teller = 1;
            //Console.Clear();
            //Console.WriteLine($"Persoonlijke Schema\n");
            //foreach (var podium in podiums)
            //{
            //    Console.WriteLine($"Podium: {podium.naam}\n");

            //    if (podium.optredens.Count == 0)
            //    {
            //        Console.WriteLine($"Er zijn geen optredens.\n");
            //    }
            //    else
            //    {
            //        foreach (OptredenDTO optreden in podium.optredens)
            //        {
            //            Console.WriteLine($"   {teller}. {optreden.artiestNaam}");
            //            Console.WriteLine($"   Starttijd: {optreden.starttijd}");
            //            Console.WriteLine($"   Eindtijd: {optreden.eindtijd}\n");

            //            teller++;
            //            optreden.teller = teller;

            //        }
            //    }
            //    Console.WriteLine("---------------------------");
            //}

            bool plattegrondTonen = true;

            while (plattegrondTonen)
            {


                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Terug naar hoofdmenu");
                Console.WriteLine("Maak keuze: ");

                string keuze = Console.ReadLine();

                if (keuze == "1")
                {
                    Console.WriteLine("Je gaat nu terug naar het hoofdmenu");
                    Console.Clear();
                    plattegrondTonen = false;
                }
            }
        }
    }
}
