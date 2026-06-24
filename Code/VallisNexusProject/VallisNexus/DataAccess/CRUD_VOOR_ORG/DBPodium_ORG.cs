using Dapper;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallisNexus.DataAccess.CRUD_VOOR_ORG
{
    internal class DBPodium_ORG
    {
        private string dbstring;
        public DBPodium_ORG()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }

        // Moet nog andere melding krijgen als het gebruiker is al gebruikt
        public bool VoegPodiumToe(string podiumNaam)
        {
            try
            {
                string sql = "INSERT INTO Podium (Naam,CreatedAt) SELECT @Naam, @Now WHERE NOT EXISTS (SELECT 1 FROM Artiest WHERE Naam = @Naam);";
                object parameters = new { Naam = podiumNaam, Now = DateTime.Now };
                using (var connection = new SqlConnection(dbstring))
                {
                    IEnumerable<dynamic> query = connection.Query(sql, parameters);
                }
                Console.WriteLine("gelukt");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("nope");
                return false;
            }
        }

        public List<Podium> GetPodium()
        {
            string sql = "SELECT * FROM Podium";
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
            string sql = "SELECT * FROM Podium WHERE id = @id";
            object parameters = new { id = id };
            using (var connection = new SqlConnection(dbstring))
            {
                Podium query = connection.QueryFirstOrDefault<Podium>(sql, parameters);
                return query;
            }
        }

        public bool PodiumUpdaten(string nieuwePodiumNaam, string oudePodiumNaam)
        {
            try
            {
                string sql = "UPDATE Podium SET Naam = @NieuweNaam WHERE Naam = @OudeNaam";
                object parameters = new { NieuweNaam = nieuwePodiumNaam, OudeNaam = oudePodiumNaam };
                using (var connection = new SqlConnection(dbstring))
                {
                    IEnumerable<dynamic> query = connection.Query(sql, parameters);
                }
                Console.WriteLine("gelukt");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("nope");
                return false;
            }
        }

        public bool PodiumVerwijderen(string podiumNaam)
        {
            try
            {
                string sql = "DELETE FROM Podium WHERE Naam = @Naam";
                object parameters = new { Naam = podiumNaam };
                using (var connection = new SqlConnection(dbstring))
                {
                    IEnumerable<dynamic> query = connection.Query(sql, parameters);
                }
                Console.WriteLine("gelukt");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("nope");
                return false;
            }
        }
    }
}
