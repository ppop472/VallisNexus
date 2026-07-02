using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallisNexus.Models
{
    public class OptredenDTO : Optreden
    {
        public OptredenDTO(int id, DateTime startTijd, DateTime eindTijd, DateTime createdAt, DateTime updatedAt, DateTime deletedAt) : base(id, startTijd, eindTijd, createdAt, updatedAt, deletedAt)
        {
        }

        // Deze is toegevoegd omdat ik bij het maken heel logisch vond om artiestnaam en podiumnaam ook erbij te zetten, een DTO is dus hiervoor goed. Vind ik.
        public int teller { get; private set; }
    }
}
