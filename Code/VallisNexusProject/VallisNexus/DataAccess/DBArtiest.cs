using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.Models;
using Dapper;
using DotNetEnv;
using System.IO;

namespace VallisNexus.DataAccess
{

    internal class DBArtiest
    {
        private string dbstring;
        public DBArtiest()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }

        public List<Artiest> GetArtiesten()
        {
            string sql = "SELECT * FROM Artiest";       
            List<Artiest> artiestenLijst = new List<Artiest>();
            using (var connection = new SqlConnection(dbstring))
            {
                IEnumerable<Artiest> query = connection.Query<Artiest>(sql);
                foreach (var artiest in query)
                {
                    artiestenLijst.Add(artiest);
                }
            }     
            return artiestenLijst;
        }

        public Artiest GetArtiestMetId(int id)
        {
            string sql = "SELECT * FROM Artiest WHERE id = @id";
            object parameters = new {id = id };           
            using (var connection = new SqlConnection(dbstring))
            {
                Artiest query = connection.QueryFirstOrDefault<Artiest>(sql, parameters);
                return query;
            }            
        }
    }
}
