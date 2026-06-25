using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.DataAccess;
using VallisNexus.Models;
namespace VallisNexus.Paginas
{
    internal class ProgrammaTonen
    {
        public void ToonProgramma()
        {
        
                Console.Clear();


                DBOptreden dbOptreden = new DBOptreden();
                List<OptredenDTO> optredens = dbOptreden.GetOptreden();

                bool doorlopen = true;

                foreach (var optreden in optredens)
                {
                    Console.WriteLine($"Artiest: {optreden.artiestNaam}");
                    Console.WriteLine($"Podium: {optreden.podiumNaam}");
                    Console.WriteLine($"Starttijd: {optreden.starttijd}");
                    Console.WriteLine($"Eindtijd: {optreden.eindtijd}");
                    Console.WriteLine("---------------------------");
                }

            Console.WriteLine();
            Console.WriteLine("1. Persoonlijk schema");
            Console.WriteLine("2. Terug naar hoofdmenu");
            Console.WriteLine("Maak uw keuze: ");

            string keuze = Console.ReadLine();

            if (keuze == "1")
            {
                Console.WriteLine("Persoonlijk schema wordt getoond...");
            }
            else if (keuze == "2")
            {   
                Console.Clear();
                doorlopen = false;
            }
            else
            {
                Console.WriteLine("Ongeldige keuze. Probeer het opnieuw.");
                Console.ReadKey();
             
            }



        }
}   }
