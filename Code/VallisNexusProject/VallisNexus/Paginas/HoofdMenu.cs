using System;

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
            Console.WriteLine("Welkom bij het hoofdmenu!\n 1. Programma tonen\n 2. Persoonlijk schema\n 3. Toon plattegrond\n 4. Meer informatie\n 5. Programma sluiten\n Maak uw keuze: ");
            string keuze = Console.ReadLine();
			if (keuze == "5")
			{
				doorlopen = false;
			}

			}
	}



	public HoofdMenu()
	{
	}
}
