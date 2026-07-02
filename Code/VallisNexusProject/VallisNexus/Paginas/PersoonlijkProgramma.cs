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

                Podium podium = new Podium();
                List<Optreden> alleFavorieteOptredens = podium.GetAllePodiumMetFavorietOptreden();
                List<OptredenDTO> alleFavorieteOptredenDTO = new List<OptredenDTO>();

                foreach (var favorieteOptreden in alleFavorieteOptredens)
                {
                    OptredenDTO optredenDTO = new OptredenDTO(teller, favorieteOptreden.podium, favorieteOptreden.id, favorieteOptreden.starttijd, favorieteOptreden.eindtijd, favorieteOptreden.createdAt, favorieteOptreden.updatedAt, favorieteOptreden.deletedAt, favorieteOptreden.artiest);
                    alleFavorieteOptredenDTO.Add(optredenDTO);
                    teller++;
                    Console.WriteLine($"{optredenDTO.teller}. {optredenDTO.artiest.naam}: Van {optredenDTO.starttijd} Tot {optredenDTO.eindtijd} Bij {optredenDTO.podium.naam}\n");
                }
                Console.Write("--------------------------------------------------------------------\n");
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
                    Optreden optreden = new Optreden();
                    Console.WriteLine("Voer het nummer van de artiestin: ");
                    try
                    {
                        int nummer = Convert.ToInt32(Console.ReadLine());

                        if (nummer >= 1 && nummer <= optreden.GetAantalOptredens())
                        {
                            foreach (OptredenDTO optredenDTO in alleFavorieteOptredenDTO)
                            {

                                if (optredenDTO.teller == nummer)
                                {
                                    optredenDTO.VerwijderFavorieteOptreden(optredenDTO);

                                    Console.WriteLine("Het optreden is verwijderd van je persoonlijke programma.");
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
                    
                    catch(System.FormatException ex)
                    {
                        Console.WriteLine("Ongeldig nummer.\n");
                        Console.WriteLine("Druk op een toets om verder te gaan...");
                        Console.ReadKey();
                    }                    
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
