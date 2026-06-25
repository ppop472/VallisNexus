using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallisNexus.Models
{
    internal class OptredenDTO : Optreden
    {

        public string artiestNaam { get; private set; }
        public string podiumNaam { get; private set; }
        public OptredenDTO(int Id, int ArtiestId, DateTime StartTijd, DateTime EindTijd, DateTime CreatedAt, DateTime UpdatedAt, DateTime DeletedAt, int PodiumId, string ArtiestNaam, string PodiumNaam) : base(Id, ArtiestId, StartTijd, EindTijd, CreatedAt, UpdatedAt, DeletedAt, PodiumId)
        {
            artiestNaam = ArtiestNaam;
            podiumNaam = PodiumNaam;
        }        
    }
}
