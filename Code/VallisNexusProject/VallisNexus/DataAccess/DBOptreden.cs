using Dapper;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<OptredenDTO> GetOptreden()
        {
            string sql = "SELECT * FROM Optreden";
            List<OptredenDTO> optredenDTOLijst = new List<OptredenDTO>();

            using (var connection = new SqlConnection(dbstring))
            {
                IEnumerable<Optreden> query = connection.Query<Optreden>(sql);
                foreach (var optreden in query)
                {
                    DBArtiest dbArtiest = new DBArtiest();
                    DBPodium dbPodium = new DBPodium();

                    Artiest artiest = dbArtiest.GetArtiestMetId(optreden.artiestId);
                    Podium podium = dbPodium.GetPodiumMetId(optreden.podiumId);

                    OptredenDTO optredenDTO = new OptredenDTO(optreden.id,artiest.id,optreden.starttijd,optreden.eindtijd,optreden.createdAt,optreden.updatedAt,optreden.deletedAt,podium.id,artiest.naam,podium.naam);
                    optredenDTOLijst.Add (optredenDTO);
                }
            } 
            return optredenDTOLijst;
        }
    }
}
