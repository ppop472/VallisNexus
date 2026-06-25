using System;
using VallisNexus.Paginas;

public class HoofdMenu
{

	public void ToonHoofdMenu()
	{
        //// Voorbeelden Artiest(en)
        //DBArtiest dbartiest = new DBArtiest();
        //List<Artiest> artiesten = dbartiest.GetArtiesten();

        //Artiest artiest = dbartiest.GetArtiestMetId(1);


        //// Voorbeelden Podium(en)
        //DBPodium dbPodium = new DBPodium();
        //List<Podium> podiums = dbPodium.GetPodium();

        //Podium podium = dbPodium.GetPodiumMetId(1);


        //// Voorbeelden Optreden
        //DBOptreden dbOptreden = new DBOptreden();
        //List<OptredenDTO> optreden = dbOptreden.GetOptreden(); // Je krijgt alle id's + de naam van de podium en naam van de artiest


        bool doorlopen = true;
        
        
            while (doorlopen)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("==================");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("VALLIS NEXUS");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("==================");
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

                Console.Write("\nMaak uw keuze: ");
                Console.ResetColor();
            string keuze = Console.ReadLine();


            if (keuze != "1" &&
                keuze != "2" &&
                keuze != "3" &&
                keuze != "4" &&
                keuze != "5")
            {
                Console.WriteLine("Ongeldige keuze. Probeer opnieuw.\n--------------------------------------------------\n");
                continue;
            }

            if (keuze == "1")
                {
                    ProgrammaTonen programmatonen = new ProgrammaTonen();
                    programmatonen.ToonProgramma();
                }



                if (keuze == "5")
                {
                    Console.WriteLine("Programma wordt afgesloten.");
                    doorlopen = false;
                }

            }
        
      
	}



	public HoofdMenu()
	{
	}
}
