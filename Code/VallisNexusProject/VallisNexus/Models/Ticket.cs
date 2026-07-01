using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.DataAccess;

namespace VallisNexus.Models
{
    internal class Ticket
    {
        public int id { get; set; }
        public string naam { get; set; }
        public int prijs { get; set; }

        public List<Ticket> GetTicket()
        {
            DBTicket dbTicket = new DBTicket();
            List<Ticket> tickets = dbTicket.GetTicket();
            return tickets;
        }
    }
}
