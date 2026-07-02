using Dapper;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.DataAccess.CRUD_VOOR_ORG;
using VallisNexus.Models;

namespace VallisNexus.DataAccess
{
    internal class DBOptreden
    {
        private string dbstring;
        public DBOptreden()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }

        public List<Optreden> GetOptreden()
        {     
            List<Optreden> optredenLijst = new List<Optreden>();
            string query = "SELECT * FROM Optreden where DeletedAt IS NULL";
            try
            {
                using (SqlConnection conn = new SqlConnection(dbstring))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@minPrice", 5);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Optreden optreden = new Optreden(reader.GetInt32(0),
                                                             reader.GetDateTime(1),
                                                             reader.GetDateTime(2),
                                                             reader.GetDateTime(3),
                                                             reader.GetDateTime(4),
                                                             reader.GetDateTime(5));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
            }
            return optredenLijst;
        }
        //public OptredenDTO GetOptredenVoorFavoriete(int id)
        //{
        //    DBPodium dbPodium = new DBPodium();
        //    List<Podium> podiumLijst = dbPodium.GetPodium();
        //    using (SqlConnection connection = new SqlConnection(dbstring))
        //    {
        //        string sql = "  SELECT * FROM Optreden WHERE Id = @id AND DeletedAt IS NULL ORDER BY StartTijd";
        //        object parameters = new { id = id };
        //        OptredenDTO query = connection.QueryFirstOrDefault<OptredenDTO>(sql, parameters);

        //        DBArtiest dbArtiest = new DBArtiest();
        //        Artiest artiest = dbArtiest.GetArtiestMetId(query.artiestId);
        //        if (artiest != null)
        //        {
        //            query.SetOptredenDTOArtiestNaam(artiest.naam);
        //        }
        //        Podium podium = podiumLijst.FirstOrDefault(p => p.id == query.podiumId);
        //        if (podium != null)
        //        {
        //            query.SetOptredenDTOPodiumNaam(podium.naam);
        //        }
        //        return query;
        //    }           
        //}
    }
}
