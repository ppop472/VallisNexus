using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace VallisNexus.DataAccess
{
    internal class DBGenre_ORG
    {
        private string dbstring;
        public DBGenre_ORG()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }
        public bool VoegGenresToe(string genreNaam)
        {
            try
            {
                string sql = "INSERT INTO Genre (Naam,CreatedAt) SELECT @Naam, @Now WHERE NOT EXISTS (SELECT 1 FROM Genre WHERE Naam = @Naam);";
                object parameters = new { Naam = genreNaam, Now = DateTime.Now };
                using (var connection = new SqlConnection(dbstring))
                {
                    Genre query = connection.QueryFirstOrDefault<Genre>(sql, parameters);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool GenresUpdaten(string nieuweGenreNaam, string oudeGenreNaam)
        {
            try
            {
                string sql = "UPDATE Genre SET Naam = @NieuweNaam WHERE Naam = @OudeNaam";
                object parameters = new { NieuweNaam = nieuweGenreNaam, OudeNaam = oudeGenreNaam };
                using (var connection = new SqlConnection(dbstring))
                {
                    Genre query = connection.QueryFirstOrDefault<Genre>(sql, parameters);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool GenresVerwijderen(string genreNaamm)
        {
            try
            {
                string sql = "UPDATE Genre SET DeletedAt = @Now WHERE Naam = @Naam";
                object parameters = new { Naam = genreNaamm, Now = DateTime.Now};
                using (var connection = new SqlConnection(dbstring))
                {
                    Genre query = connection.QueryFirstOrDefault<Genre>(sql, parameters);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
