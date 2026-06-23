using System;

public class HoofdMenu
{

	public void ToonHoofdMenu()
	{	
		
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
