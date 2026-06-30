using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using VallisNexus.Models;

namespace VallisNexus.DataAccess
{
    internal class DBFavoriet
    {
        private string dbstring;
        public DBFavoriet()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }

        public bool VoegFavorietToe(OptredenDTO optreden)
        {
            try
            {
                string sql = @"
INSERT INTO Favoriet (GebruikerId, OptredenId, CreatedAt)
SELECT @gebruikerId, @optredenId, GETDATE()
WHERE NOT EXISTS (
    SELECT 1 
    FROM Favoriet 
    WHERE GebruikerId = @gebruikerId 
      AND OptredenId = @optredenId 
      AND DeletedAt IS NULL
);";
                object parameters = new {gebruikerId = 2, optredenId = optreden.id, Now = DateTime.Now };
                using (var connection = new SqlConnection(dbstring))
                {
                    IEnumerable<dynamic> query = connection.Query(sql, parameters);
                }                
                return true;
            }
            catch (Exception ex)
            {                
                return false;
            }
        }

        public List<Favoriet> GetAlleFavoriet()
        {
            List<Favoriet> favorietLijst = new List<Favoriet>();
            string sql = "SELECT * FROM Favoriet WHERE GebruikerId = 2 AND DeletedAt IS NULL";
            using (var connection = new SqlConnection(dbstring))
            {
                IEnumerable<Favoriet> query = connection.Query<Favoriet>(sql);
                foreach (var item in query)
                {
                    favorietLijst.Add(item);                    
                }                
            }
            return favorietLijst;
        }

        public bool FavorietVerwijderen(int id)
        {
            try
            {
                string sql = "Update Favoriet SET DeletedAt = GETDATE() WHERE OptredenId = @Id AND DeletedAt IS NULL";
                object parameters = new { Id = id };
                using (var connection = new SqlConnection(dbstring))
                {
                    Favoriet query = connection.QueryFirstOrDefault<Favoriet>(sql, parameters);                   
                }
                return true;
            }
            catch(Exception ex) { return false; }
        }
    }
}
