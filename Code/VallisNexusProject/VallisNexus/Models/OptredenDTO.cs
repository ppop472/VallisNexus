using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallisNexus.Models
{
    public class OptredenDTO : Optreden
    {
        public int teller { get; private set; }

        public OptredenDTO(int teller, int id, DateTime startTijd, DateTime eindTijd, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, Artiest artiest) : base(id, startTijd, eindTijd, createdAt, updatedAt, deletedAt, artiest)
        {
            this.teller = teller;
        }

        // Deze is voor het verwijderen van favoriete Optreden. Bij het tonen van favorieten is de Locatie daarnaast toegeveogd.
        // het is niet per podium.
        public OptredenDTO(int teller, Podium podium, int id, DateTime startTijd, DateTime eindTijd, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, Artiest artiest) : base(id, startTijd, eindTijd, createdAt, updatedAt, deletedAt, artiest)
        {
            this.teller = teller;
            this.podium = podium;
        }
    }
}
