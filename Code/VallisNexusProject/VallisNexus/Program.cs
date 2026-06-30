using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.DataAccess;
using VallisNexus.DataAccess.CRUD_VOOR_ORG;
using VallisNexus.Models;
using VallisNexus.Paginas;

namespace VallisNexus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HoofdMenu hoofdMenu = new HoofdMenu();
            hoofdMenu.ToonHoofdMenu();  

            DBArtiest_ORG test = new DBArtiest_ORG();
            //test.VoegArtiestToe("MR. Kitty");
            //test.ArtiestVerwijderen("Christian");
            //test.ArtiestUpdaten("Mr.Kitty", "MR. Kitty");
            //test.GenreAanArtiestToevoegen("Christian", "1 2");          

            DBPodium_ORG test2 = new DBPodium_ORG();
            //test2.VoegPodiumToe("Side Podium2");
            //test2.PodiumUpdaten("Podium2","Side Podium2");
            //test2.PodiumVerwijderen("Podium2");

            DBArtiest test3 = new DBArtiest();
            //var test4 = test3.GetArtiesten();

            DBOptreden_ORG dBOptreden = new DBOptreden_ORG();

            //var test5 = dBOptreden.VoegOptredenToeg(5, 1, new DateTime(2026,2,2,05,30,0,0), new DateTime(2026, 2, 2, 06, 30, 0, 0));

            DBTickets_ORG dBTickets = new DBTickets_ORG();
            //var test6 = dBTickets.TicketAanmaken("VIP Ticket", 129.50);
            //var test7 = dBTickets.TicketAanmaken("Regular Ticket", 79.50);
            //var test8 = dBTickets.TicketAanmaken("Combo Ticket (2 per.)", 149.00);
            //var test9 = dBTickets.GetTicket();

            DBGenre_ORG dbGenre_ORG = new DBGenre_ORG();
            //var test10 = dbGenre_ORG.VoegGenresToe("Rap");
            //var test11 = dbGenre_ORG.GenresUpdaten("Techno", "Rap");
            //var test12 = dbGenre_ORG.GenresVerwijderen("Techno");

            var test13 = new PersoonlijkProgramma();
            //test13.OpslaanPersoonlijkProgramma();

            Console.ReadLine();
        }
    }
}
