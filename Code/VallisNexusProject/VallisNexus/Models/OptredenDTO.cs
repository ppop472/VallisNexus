using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallisNexus.Models
{
    public class OptredenDTO : Optreden
    {

        // Deze is toegevoegd omdat ik bij het maken heel logisch vond om artiestnaam en podiumnaam ook erbij te zetten, een DTO is dus hiervoor goed. Vind ik.
        public string artiestNaam { get; private set; }
        public int teller { get; private set; }
        public string podiumNaam { get; private set; }

        public void SetOptredenDTOTeller(int teller)
        {
             this.teller = teller;
        }

        public void SetOptredenDTOPodiumNaam(string podiumNaam)
        {
             this.podiumNaam = podiumNaam;
        }

        public void SetOptredenDTOArtiestNaam(string artiestNaam)
        {
            this.artiestNaam = artiestNaam;
        }
    }
}
