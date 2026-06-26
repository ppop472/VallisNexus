using Dapper;
using DotNetEnv;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.Models;

namespace VallisNexus.DataAccess.CRUD_VOOR_ORG
{
    internal class DBTickets_ORG
    {
        private string dbstring;
        public DBTickets_ORG()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }

        public bool TicketAanmaken(string ticketNaam, double ticketPrijs)
        {
            try
            {
                string sql = "INSERT INTO Ticket (Naam,Prijs,CreatedAt) SELECT @Naam, @Prijs, GETDATE() WHERE NOT EXISTS (SELECT 1 FROM Ticket WHERE Naam = @Naam AND Prijs = @Prijs);";
                object parameters = new {Naam = ticketNaam, Prijs = ticketPrijs };
                using (var connection = new SqlConnection(dbstring))
                {
                    string query = connection.QueryFirstOrDefault(sql, parameters);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Ticket> GetTicket()
        {
            try
            {
                string sql = "SELECT * FROM Ticket";
                using (var connection = new SqlConnection(dbstring))
                {
                    IEnumerable<Ticket> query = connection.Query<Ticket>(sql);
                    return query;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
