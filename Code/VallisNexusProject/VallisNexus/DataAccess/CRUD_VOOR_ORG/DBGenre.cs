using Dapper;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.Models;

namespace VallisNexus.DataAccess.CRUD_VOOR_ORG
{
    internal class DBGenre
    {
        private string dbstring;
        public DBGenre()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }

        public List<Genre> GetGenres()
        {
            string sql = "SELECT * FROM Genre";
            List<Genre> genreLijst = new List<Genre>();
            using (var connection = new SqlConnection(dbstring))
            {
                IEnumerable<Genre> query = connection.Query<Genre>(sql);
                foreach (var podium in query)
                {
                    genreLijst.Add(podium);
                }
            }
            return genreLijst;
        }
    }
}
