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
            string sql = "SELECT * FROM Genre WHERE DeletedAt IS NULL";
            List<Genre> genreLijst = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                IEnumerable<Genre> query = connection.Query<Genre>(sql);
                foreach (Genre genre in query)
                {
                    genreLijst.Add(genre);
                }
            }
            return genreLijst;
        }
    }
}
