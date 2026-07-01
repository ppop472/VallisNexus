using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.DataAccess;

namespace VallisNexus.Models
{
    internal class Favoriet
    {
        public int id{ get; private set; }
        public int gebruikerId { get; private set; }
        public int optredenId { get; private set; }

        public List<Favoriet> GetAlleFavoriet()
        {
            DBFavoriet dBFavoriet = new DBFavoriet();
            List<Favoriet> favorietLijst = dBFavoriet.GetAlleFavoriet();
            return favorietLijst;
        }
        public void VoegFavorietToe(OptredenDTO optreden)
        {
            DBFavoriet dbFavoriet = new DBFavoriet();
            dbFavoriet.VoegFavorietToe(optreden);
        }

        public void FavorietVerwijderen(int id)
        {
            DBFavoriet dbFavoriet = new DBFavoriet();
            dbFavoriet.FavorietVerwijderen(id);
        }
    }
}
