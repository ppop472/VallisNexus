using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.Models;
using VallisNexus.DataAccess;
using System.IO;
using Newtonsoft.Json;
using VallisNexus.Paginas;

namespace VallisNexus.Paginas
{
    internal class PersoonlijkProgramma
    {
        public void ToonPersoonlijkProgramma()
        {
            Console.Clear();

            Console.WriteLine(@"
+------------------------------------------------------------------+
|                      Persoonlijke Schema                         |
+------------------------------------------------------------------+"+"\n");

            List<OptredenDTO> optredenDTOLijst = new List<OptredenDTO>();

            DBOptreden optreden = new DBOptreden();

            DBFavoriet dBFavoriet = new DBFavoriet();
            List<Favoriet> favorietLijst = dBFavoriet.GetAlleFavoriet();
            foreach (var favoriet in favorietLijst)
            {
                optredenDTOLijst.Add(optreden.GetOptredenVoorFavoriete(favoriet.optredenId));
            }
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in optredenDTOLijst)
            {

                Console.WriteLine($"- {item.artiestNaam}: Van |{item.starttijd}|  Tot |{item.eindtijd}| Locatie: {item.podiumNaam}\n");
            }

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
