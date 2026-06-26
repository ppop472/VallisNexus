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

        public List<Podium> GetOptreden()
        {
            DBPodium dbPodium = new DBPodium();
            List<Podium> podiumLijst = dbPodium.GetPodium();

            foreach (var podium in podiumLijst)
            {
                using (var connection = new SqlConnection(dbstring))
                {
                    string sql = "  SELECT * FROM Optreden WHERE PodiumId = @podiumId AND DeletedAt IS NULL ORDER BY StartTijd";
                    object parameters = new { podiumId = podium.id };
                    IEnumerable<OptredenDTO> query = connection.Query<OptredenDTO>(sql,parameters);
                    foreach (var optreden in query)
                    {
                        podium.optreden.Add(optreden);
                        DBArtiest dbArtiest = new DBArtiest();
                        Artiest artiest = dbArtiest.GetArtiestMetId(optreden.artiestId);
                        if(artiest != null)
                        {
                            optreden.artiestNaam = artiest.naam;
                        }
                    }
                }
            }
            return podiumLijst;
        }
    }
}
