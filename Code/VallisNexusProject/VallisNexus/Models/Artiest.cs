using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallisNexus.Models
{
    internal class Artiest
    {
        public string naam { get; private set; }
        public int id { get; private set; }
        public List <Genre> genres { get; private set; }
        public DateTime createdAt { get; private set; }
        public DateTime updatedAt { get; private set; }
        public DateTime deletedAt { get; private set; }



        internal Artiest(string naam, int id)
        {
            this.naam = naam;
            //this.Id = artiestId;

            this.genres = new List<Genre>();
        }


    }
}
