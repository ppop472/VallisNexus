using Dapper;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.Models;

namespace VallisNexus.DataAccess.CRUD_VOOR_ORG
{
    internal class DBOptreden_ORG
    {
        private string dbstring;
        public DBOptreden_ORG()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }

        public bool VoegOptredenToeg(int artiesId, int podiumId, DateTime startTijd, DateTime eindTijd)
        {

            try
            {
                string sql = "INSERT INTO Optreden (ArtiestId,PodiumId,StartTijd,EindTijd,CreatedAt) SELECT @artiestId, @podiumId,@startTijd, @eindTijd, GETDATE() WHERE EXISTS ( SELECT 1 FROM Artiest WHERE Id = 1) AND NOT EXISTS (SELECT 1 FROM Optreden o WHERE o.PodiumId = @podiumid AND @startTijd < o.EindTijd AND @eindTijd > o.StartTijd);";
                object parameters = new {artiestId = artiesId, podiumId = podiumId, startTijd = startTijd, eindTijd = eindTijd };
                using (var connection = new SqlConnection(dbstring))
                {
                     string query = connection.QueryFirstOrDefault(sql, parameters);
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void OptredenVerwijderenBijArtiestVerwijdering(int artiestId)
        {
            try
            {
                string sql = "UPDATE Optreden SET DeletedAt = @Now WHERE ArtiestId = @artiestId";
                object parameters = new { artiestId = artiestId, Now = DateTime.Now };
                using (var connection = new SqlConnection(dbstring))
                {
                    Genre query = connection.QueryFirstOrDefault<Genre>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
