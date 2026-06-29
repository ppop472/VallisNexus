using Dapper;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.Models;

namespace VallisNexus.DataAccess
{
    internal class DBTicket
    {
        private string dbstring;
        public DBTicket()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }
        public List<Ticket> GetTicket()
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                string sql = "SELECT * FROM Ticket WHERE DeletedAt IS NULL";
                using (var connection = new SqlConnection(dbstring))
                {
                    IEnumerable<Ticket> query = connection.Query<Ticket>(sql);
                    foreach (Ticket ticket in query)
                    {
                        tickets.Add(ticket);
                    }
                    return tickets;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
