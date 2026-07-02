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

        public List<Optreden> GetAlleOptredenVoorPodium(int id)
        {
            List<Optreden> optredenLijst = new List<Optreden>();

            string query = @"SELECT Id, StartTijd, EindTijd, CreatedAt, UpdatedAt, DeletedAt, ArtiestId FROM Optreden WHERE PodiumId = @Id AND DeletedAt IS NULL";

            try
            {
                using (SqlConnection connectie = new SqlConnection(dbstring))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connectie))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        connectie.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime? updatedAt = reader.IsDBNull(4)
                                    ? (DateTime?)null
                                    : reader.GetDateTime(4);

                                DateTime? deletedAt = reader.IsDBNull(5)
                                    ? (DateTime?)null
                                    : reader.GetDateTime(5);

                                Optreden optreden = new Optreden(
                                    reader.GetInt32(0),
                                    reader.GetDateTime(1),
                                    reader.GetDateTime(2),
                                    reader.GetDateTime(3),
                                    updatedAt,
                                    deletedAt
                                );

                                int artiestNr = reader.GetInt32(6);
                                DBArtiest dbArtiest = new DBArtiest();
                                Artiest artiest = dbArtiest.GetArtiestMetId(artiestNr);
                                optreden.artiest = artiest;
                                optredenLijst.Add(optreden);
                            }
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

        public Optreden GetEenOptredenMetId(int id)
        {
            string query = @"SELECT Id, StartTijd, EindTijd, CreatedAt, UpdatedAt, DeletedAt, ArtiestId , PodiumId FROM Optreden WHERE Id = @id AND DeletedAt IS NULL";
            try
            {
                using (SqlConnection connectie = new SqlConnection(dbstring))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connectie))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        connectie.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime? updatedAt = reader.IsDBNull(4)
                                    ? (DateTime?)null
                                    : reader.GetDateTime(4);

                                DateTime? deletedAt = reader.IsDBNull(5)
                                    ? (DateTime?)null
                                    : reader.GetDateTime(5);

                                Optreden optreden = new Optreden(
                                    reader.GetInt32(0),
                                    reader.GetDateTime(1),
                                    reader.GetDateTime(2),
                                    reader.GetDateTime(3),
                                    updatedAt,
                                    deletedAt
                                );

                                int artiestNr = reader.GetInt32(6);
                                DBArtiest dbArtiest = new DBArtiest();
                                Artiest artiest = dbArtiest.GetArtiestMetId(artiestNr);
                                optreden.artiest = artiest;
                                DBPodium dbPodium = new DBPodium();
                                var test = reader.GetInt32(6);
                                optreden.podium = dbPodium.GetPodiumMetId(reader.GetInt32(7));
                                return optreden;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
            }

            return null;
        }

        public int GetAantalOptredens()
        {
            string sql = "SELECT COUNT(*) FROM Optreden WHERE DeletedAt IS NULL;";
            using (SqlConnection connection = new SqlConnection(dbstring))
            {
                int aantal = connection.QueryFirstOrDefault<int>(sql);
                return aantal;
            }
        }
    }
}
