using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallisNexus.Models
{
    public class Artiest
    {
        public string naam { get; private set; }
        public int id { get; private set; }
        public List <Genre> genres { get; set; } = new List<Genre>();
        public DateTime createdAt { get; private set; }
        public DateTime updatedAt { get; private set; }
        public DateTime deletedAt { get; private set; }
    }
}
