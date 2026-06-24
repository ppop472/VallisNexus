using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.DataAccess;
using VallisNexus.Models;

namespace VallisNexus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //HoofdMenu hoofdMenu = new HoofdMenu();
            //hoofdMenu.ToonHoofdMenu();

            // Voorbeelden Artiest(en)
            DBArtiest dbartiest = new DBArtiest();
            List<Artiest> artiesten = dbartiest.GetArtiesten();

            Artiest artiest = dbartiest.GetArtiestMetId(1);


            // Voorbeelden Podium(en)
            DBPodium dbPodium = new DBPodium();
            List<Podium> podiums = dbPodium.GetPodium();

            Podium podium = dbPodium.GetPodiumMetId(1);


            // Voorbeelden Optreden
            DBOptreden dbOptreden = new DBOptreden();
            List<OptredenDTO> optreden = dbOptreden.GetOptreden();
        }
    }
}
