using System;
using VallisNexus.Paginas;

public class HoofdMenu
{
	public void ToonHoofdMenu()
	{
        bool doorlopen = true;

            while (doorlopen)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("==================");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("VALLIS NEXUS");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("==================\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welkom bij het hoofdmenu!");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Programma tonen");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("2. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Persoonlijk schema");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("3. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Toon plattegrond");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("4. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Meer informatie");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("5. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Programma sluiten");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("==================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Maak uw keuze: ");

                string keuze = Console.ReadLine();
                
                Console.ResetColor();


            if (keuze != "1" &&
                keuze != "2" &&
                keuze != "3" &&
                keuze != "4" &&
                keuze != "5")
            {
                Console.WriteLine("Ongeldige keuze. Probeer opnieuw. Druk op een knop om verder te gaan.\n--------------------------------------------------------------------------\n");
                Console.ReadKey();
                continue;
            }

            if (keuze == "1")
            {
                    ProgrammaTonen programmatonen = new ProgrammaTonen();
                    Console.Clear();
                    programmatonen.ToonProgramma();
                }
            
            if (keuze == "2")
            {
                PersoonlijkProgramma persoonlijkProgramma = new PersoonlijkProgramma();
                Console.Clear();
                persoonlijkProgramma.ToonPersoonlijkProgramma();
            }


            if (keuze == "3")
            {
                ToonPlattegrond plattegrond = new ToonPlattegrond();
                Console.Clear();
                plattegrond.PlattegrondTonen();
                
            }

            if (keuze == "4")
            {
                MeerInformatie meerInformatie = new MeerInformatie();
                Console.Clear();
                meerInformatie.ToonMeerInformatie();
            }



            if (keuze == "5")
            {
                Console.WriteLine("Programma wordt afgesloten.");
                doorlopen = false;
            }
        }
	}
}
