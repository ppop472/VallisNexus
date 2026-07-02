using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.DataAccess;
using VallisNexus.Models;
using VallisNexus.Paginas;
namespace VallisNexus.Paginas
{
    public class MeerInformatie
    {
        public void ToonMeerInformatie()
        {
            //Geeft console text kleur
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Meer Informatie");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Kies een onderwerp:");
            Console.Write("1.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tickets");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bereikbaarheid");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("3.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Parkeren");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("4.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Huisregels");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("5.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Contact");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("6.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Terug naar hoofdmenu");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Maak uw keuze: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================");


            bool informatieTonen = true;

            while (informatieTonen)
            {
                
                string keuzeInvoer = Console.ReadLine();
                MeerInformatie meerInformatie = new MeerInformatie();
                if (keuzeInvoer == "1")
                {
                    Console.Clear();
                    Console.WriteLine(@"
+------------------------------------------------------------------+
|                            TICKETS                               |
+------------------------------------------------------------------+");

                    Ticket ticket = new Ticket();
                    List<Ticket> tickets = ticket.GetTicket();

                    foreach (Ticket t in tickets)
                    {
                        Console.WriteLine($"Ticket: {t.naam}, Prijs: {t.prijs}\n");
                      
                    }
                    Console.WriteLine("==============================================================\n");
                    meerInformatie.ToonMeerInformatie();
                }
                if (keuzeInvoer == "2")
                {
                    Console.Clear();
                    Console.WriteLine(@"
+------------------------------------------------------------------+
|                         BEREIKBAARHEID                           |
+------------------------------------------------------------------+");
                    Console.WriteLine("Adres: Heerlen, Nederland, VallisNexusStraat 67\n");
                    Console.WriteLine("Openbaar vervoer: Met de trein naar station Heerlen, vanaf daar is het 10 minuten lopen naar het festivalterrein, of 3 minuten met buslijn 67.\n");
                    Console.WriteLine("==============================================================\n");
                    meerInformatie.ToonMeerInformatie();
                }
                if (keuzeInvoer == "3")
                {
                    Console.Clear();
                    Console.WriteLine(@"
+------------------------------------------------------------------+
|                            PARKEREN                              |
+------------------------------------------------------------------+");
                    Console.WriteLine("Er zijn verschillende parkeermogelijkheden beschikbaar in de buurt van het festivalterrein.\n\nParkeren is gratis en wordt aangegeven met borden.");
                    Console.WriteLine("==============================================================\n");
                    meerInformatie.ToonMeerInformatie();
                }
                if (keuzeInvoer == "4")
                {
                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine(@"
+------------------------------------------------------------------+
|                           HUISREGELS                             |
+------------------------------------------------------------------+
1. Volg altijd de aanwijzingen van de beveiliging en het festivalpersoneel op.

2. Behandel andere bezoekers met respect. Discriminatie, agressie en intimidatie worden niet getolereerd.

3. Het meenemen van wapens, drugs, vuurwerk en andere gevaarlijke voorwerpen is verboden.

4. Eigen eten en drinken meenemen is niet toegestaan.

5. Alcohol wordt uitsluitend geschonken aan bezoekers van 18 jaar en ouder. Legitimeren kan worden gevraagd.

6. Houd het festivalterrein schoon en deponeer afval in de daarvoor bestemde afvalbakken.

7. Het beklimmen van hekken, podia, lichtmasten of andere constructies is niet toegestaan.

8. Roken en vapen is alleen toegestaan in de daarvoor aangewezen zones.
                    ");
                    Console.WriteLine("==============================================================\n");
                    meerInformatie.ToonMeerInformatie();
                }
                if (keuzeInvoer == "5")
                {
                    Console.Clear();
                    Console.WriteLine(@"
+------------------------------------------------------------------+
|                             CONTACT                              |
+------------------------------------------------------------------+");
                    Console.WriteLine("Email: info@vallisnexus.nl\n");
                    Console.WriteLine("Telefoon: +31 123 456 789");
                    Console.WriteLine("==============================================================\n");
                    meerInformatie.ToonMeerInformatie();
                }
                if (keuzeInvoer == "6")
                {
                    Console.WriteLine("Je gaat nu terug naar hoofdmenu");
                    Console.Clear();
                    informatieTonen = false;
                }
            }
            HoofdMenu hoofdmenu = new HoofdMenu();
            hoofdmenu.ToonHoofdMenu(); 

        } 

    }
}
