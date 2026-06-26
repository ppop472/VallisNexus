using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.DataAccess;
using VallisNexus.DataAccess.CRUD_VOOR_ORG;
using VallisNexus.Models;
using System.Drawing;

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
            //test.ArtiestVerwijderen("MR. Kitty");
            //test.ArtiestUpdaten("Mr.Kitty", "MR. Kitty");
            //test.GenreAanArtiestToevoegen("Christian", "1 2");          

            DBPodium_ORG test2 = new DBPodium_ORG();
            //test2.VoegPodiumToe("Side Podium2");
            //test2.PodiumUpdaten("Podium2","Side Podium2");
            //test2.PodiumVerwijderen("Podium2");

            DBArtiest test3 = new DBArtiest();
            //var test4 = test3.GetArtiesten();

            DBOptreden_ORG dBOptreden = new DBOptreden_ORG();

            //var test5 = dBOptreden.VoegOptredenToeg(1, 1, new DateTime(2026,7,30,03,30,0,0), new DateTime(2026, 07, 30, 04, 30, 0, 0));

            Console.ReadLine();
        }
    }
}
