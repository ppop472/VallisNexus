using System;
using System.Collections.Generic;
using VallisNexus.DataAccess;
using VallisNexus.Models;

namespace VallisNexus.Paginas
{
    internal class ProgrammaTonen
    {
        public void ToonProgramma()
        {
            bool doorlopen = true;

            while (doorlopen)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("==================");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Programma");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("==================");

                int teller = 1;

                Podium podium = new Podium();
                List<Podium> podiums = podium.GetAllePodiumMetOptreden();
                List<OptredenDTO> alleoptredenDTO = new List<OptredenDTO>();

                foreach (Podium p in podiums)
                {
                    Console.WriteLine($"Podium: {p.naam}\n");

                    if (p.optredens.Count == 0)
                    {
                        Console.WriteLine($"Er zijn geen optredens.\n");
                    }
                    else
                    {
                        foreach (Optreden optreden in p.optredens)
                        {
                            OptredenDTO optredenDTO = new OptredenDTO(teller,optreden.id,optreden.starttijd,optreden.eindtijd,optreden.createdAt,optreden.updatedAt,optreden.deletedAt, optreden.artiest);
                            alleoptredenDTO.Add(optredenDTO);

                            Console.WriteLine($"    {optredenDTO.teller}. {optreden.artiest.naam}");
                            Console.WriteLine($"       Starttijd: {optredenDTO.starttijd}");
                            Console.WriteLine($"       Eindtijd: {optredenDTO.eindtijd}\n");

                            teller++;
                        }
                    }
                    Console.WriteLine("---------------------------");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Voeg optreden toe aan persoonlijk schema");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("2.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Persoonlijk programma bekijken");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("3.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Terug naar hoofdmenu");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("==================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Maak uw keuze: ");

                string keuze = Console.ReadLine();

                if (keuze == "1")
                {
                    Console.Write("Voer het nummer van het optreden in: ");
                    int nummer = Convert.ToInt32(Console.ReadLine());

                    Optreden optreden = new Optreden();

                    if (nummer >= 1 && nummer <= optreden.GetAantalOptredens())
                    {
                        foreach (OptredenDTO optredenDTO in alleoptredenDTO)
                        {
                            if (optredenDTO.teller == nummer)
                            {
                                optredenDTO.VoegFavorieteOptredenToe(optredenDTO);

                                Console.WriteLine("Het optreden is toegevoegd aan je persoonlijke programma.");
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
                    PersoonlijkProgramma persoonlijkProgramama = new PersoonlijkProgramma();
                    persoonlijkProgramama.ToonPersoonlijkProgramma();
                }
                else if (keuze == "3")
                {
                    doorlopen = false;
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze.");
                    Console.ReadKey();
                }
            }
        }
    }
}