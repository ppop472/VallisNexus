using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallisNexus.Models
{
    internal class Favoriet
    {
        public int id{ get; set; }
        public int gebruikerId { get; set; }
        public int optredenId { get; set; }
    }
}
