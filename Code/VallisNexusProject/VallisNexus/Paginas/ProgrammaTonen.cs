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

                DBOptreden dbOptreden = new DBOptreden();
                List<Podium> podiums = dbOptreden.GetOptreden();

                List<OptredenDTO> alleOptredens = new List<OptredenDTO>();
                int teller = 1;

                foreach (var podium in podiums)
                {
                    Console.WriteLine($"Podium: {podium.naam}\n");
                    if(podium.optreden.Count == 0)
                    {
                        Console.WriteLine($"Er zijn geen optredens.\n");
                    }
                    else
                    {
                        foreach (var optreden in podium.optreden)
                        {
                            Console.WriteLine($"    {teller}. {optreden.artiestNaam}");
                            Console.WriteLine($"   Starttijd: {optreden.starttijd}");
                            Console.WriteLine($"   Eindtijd: {optreden.eindtijd}\n");

                            alleOptredens.Add(optreden);
                            teller++;
                        }
                    }
                    Console.WriteLine("---------------------------");
                }

                Console.WriteLine();
                Console.WriteLine("1. Voeg optreden toe aan persoonlijk schema");
                Console.WriteLine("2. Persoonlijk programma bekijken");
                Console.WriteLine("3. Terug naar hoofdmenu");
                Console.Write("Maak uw keuze: ");

                string keuze = Console.ReadLine();

                if (keuze == "1")
                {
                    Console.Write("Voer het nummer van het optreden in: ");
                    int nummer = Convert.ToInt32(Console.ReadLine());

                    if (nummer >= 1 && nummer <= alleOptredens.Count)
                    {
                        PersoonlijkProgramma programma = new PersoonlijkProgramma();
                        programma.LadenPersoonlijkProgramma();

                        programma.PersoonlijkeOptredens.Add(alleOptredens[nummer - 1]);

                        programma.OpslaanPersoonlijkProgramma();

                        Console.WriteLine("Het optreden is toegevoegd aan je persoonlijke programma.");
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
                    Console.Clear();

                    PersoonlijkProgramma programma = new PersoonlijkProgramma();
                    programma.LadenPersoonlijkProgramma();

                    Console.WriteLine("Persoonlijk programma:\n");

                    if (programma.PersoonlijkeOptredens.Count == 0)
                    {
                        Console.WriteLine("Er zijn nog geen optredens toegevoegd.");
                    }
                    else
                    {
                        foreach (var optreden in programma.PersoonlijkeOptredens)
                        {
                            Console.WriteLine($"Artiest: {optreden.artiestNaam}");
                            Console.WriteLine($"Starttijd: {optreden.starttijd}");
                            Console.WriteLine($"Eindtijd: {optreden.eindtijd}");
                            Console.WriteLine("---------------------------");
                        }
                    }

                    Console.WriteLine("Druk op een toets om terug te gaan...");
                    Console.ReadKey();
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