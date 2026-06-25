using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.DataAccess;
using VallisNexus.DataAccess.CRUD_VOOR_ORG;
using VallisNexus.Models;

namespace VallisNexus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //HoofdMenu hoofdMenu = new HoofdMenu();
            //hoofdMenu.ToonHoofdMenu();

            DBArtiest_ORG test = new DBArtiest_ORG();
            //test.VoegArtiestToe("Christian M");
            //test.ArtiestVerwijderen("MR. Kitty");
            //test.ArtiestUpdaten("Mr.Kitty", "MR. Kitty");
            //test.GenreAanArtiestToevoegen("Christian", "1 2");          
            //test.ArtiestVerwijderen("Christian");
            //var idk = test.GetArtiesten();

            DBPodium_ORG test2 = new DBPodium_ORG();
            //test2.VoegPodiumToe("Side Podium2");
            //test2.PodiumUpdaten("Podium2","Side Podium2");
            //test2.PodiumVerwijderen("Podium2");

            DBArtiest test3 = new DBArtiest();
            //var test4 = test3.GetArtiesten();

            DBOptreden test4 = new DBOptreden();
            var test5 = test4.GetOptreden();
            Console.ReadLine();
        }
    }
}
