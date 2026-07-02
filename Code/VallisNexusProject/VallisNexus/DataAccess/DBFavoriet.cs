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
            string sql = @"INSERT INTO Favoriet (GebruikerId, OptredenId, CreatedAt) SELECT @gebruikerId, @optredenId, GETDATE() WHERE NOT EXISTS (SELECT 1 FROM Favoriet WHERE GebruikerId = @gebruikerId AND OptredenId = @optredenId AND DeletedAt IS NULL);";
            object parameters = new { gebruikerId = 2, optredenId = optreden.id, Now = DateTime.Now };
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                IEnumerable<dynamic> query = connection.Query(sql, parameters);
            }
            return true;
        }

        public List<int> GetAlleFavorieten()
        {
            List<int> favorieteOptredenNrLijst = new List<int>();
            string sql = "SELECT OptredenId FROM Favoriet WHERE GebruikerId = 2 AND DeletedAt IS NULL";
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                IEnumerable<int> query = connection.Query<int>(sql);
                foreach (int optredenId in query)
                {
                    favorieteOptredenNrLijst.Add(optredenId);
                }
            }
            return favorieteOptredenNrLijst;
        }
        public void FavorietVerwijderen(int id)
        {

            string sql = "Update Favoriet SET DeletedAt = GETDATE() WHERE OptredenId = @Id AND DeletedAt IS NULL";
            object parameters = new { Id = id };
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                IEnumerable<dynamic> query = connection.QueryFirstOrDefault<dynamic>(sql, parameters);
            }
        }
     }
}