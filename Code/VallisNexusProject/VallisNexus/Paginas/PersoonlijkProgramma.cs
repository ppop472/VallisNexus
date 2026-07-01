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


            List<OptredenDTO> optredenDTOLijst = new List<OptredenDTO>();

            Optreden optreden = new Optreden();

            Favoriet favoriet = new Favoriet();
            List<Favoriet> favorietLijst = favoriet.GetAlleFavoriet();

            foreach (Favoriet fav in favorietLijst)
            {
                optredenDTOLijst.Add(optreden.GetOptredenVoorFavoriete(fav.optredenId));
            }
            Console.ForegroundColor = ConsoleColor.White;

            bool plattegrondTonen = true;

            while (plattegrondTonen)
            {
                int teller = 1;

                Console.Clear();
                Console.WriteLine(@"
+------------------------------------------------------------------+
|                      Persoonlijke Schema                         |
+------------------------------------------------------------------+" + "\n");

                foreach (OptredenDTO optredenDTO in optredenDTOLijst)
                {
                    optredenDTO.SetOptredenDTOTeller(teller);
                    Console.WriteLine($"{optredenDTO.teller}. {optredenDTO.artiestNaam}: Van |{optredenDTO.starttijd}|  Tot |{optredenDTO.eindtijd}| Locatie: {optredenDTO.podiumNaam}\n");
                    teller++;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Favoriet verwijderen");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("2. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Terug naar hoofdmenu");
                Console.WriteLine("Maak keuze: ");

                string keuze = Console.ReadLine();
                if (keuze == "1")
                {
                    Console.WriteLine("Voer het nummer van de artiestin: ");
                    int nummer = Convert.ToInt32(Console.ReadLine());

                    if (nummer >= 1 && nummer <= optredenDTOLijst.Count)
                    {
                        foreach (OptredenDTO optredenDto in optredenDTOLijst)
                        {
                            if (optredenDto.teller == nummer)
                            {
                                favoriet.FavorietVerwijderen(optredenDto.id);
                                Console.Clear();
                                plattegrondTonen = false;
                                Console.WriteLine("Je hebt een favoriete verwijderd.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ongeldig nummer.");
                    }

                    Console.WriteLine("Druk op een toets om verder te gaan...");
                    Console.ReadKey();
                }
                else if (keuze == "2")
                {
                    Console.WriteLine("Je gaat nu terug naar het hoofdmenu");
                    Console.Clear();
                    plattegrondTonen = false;
                }
            }
        }
    }
}
