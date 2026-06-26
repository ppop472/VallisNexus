using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.Models;
using Dapper;
using System.Collections;

namespace VallisNexus.DataAccess
{
    internal class DBPodium
    {
        private string dbstring;
        public DBPodium()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }

        public List<Podium> GetPodium()
        {
            string sql = "SELECT * FROM Podium WHERE DeletedAt IS NULL";
            List<Podium> podiumLijst = new List<Podium>();
            using (var connection = new SqlConnection(dbstring))
            {
                IEnumerable<Podium> query = connection.Query<Podium>(sql);
                foreach (var podium in query)
                {
                    podiumLijst.Add(podium);
                }
            }
            return podiumLijst;
        }

        public Podium GetPodiumMetId(int id)
        {
            string sql = "SELECT * FROM Podium WHERE id = @id WHERE DeletedAt IS NULL";
            object parameters = new { id = id };
            using (var connection = new SqlConnection(dbstring))
            {
                Podium query = connection.QueryFirstOrDefault<Podium>(sql, parameters);
                return query;
            }            
        }
    }
}
