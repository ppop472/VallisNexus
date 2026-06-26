using Dapper;
using DotNetEnv;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VallisNexus.Models;

namespace VallisNexus.DataAccess.CRUD_VOOR_ORG
{
    internal class DBArtiest_ORG
    {
        private string dbstring;
        public DBArtiest_ORG()
        {
            Env.Load("../../.env");
            dbstring = Env.GetString("DBSTRING");
        }


        // Moet nog andere melding krijgen als het gebruiker is al gebruikt
        public bool VoegArtiestToe(string artiestNaam)
        {
            try
            {
                string sql = "INSERT INTO Artiest (Naam,CreatedAt) SELECT @Naam, @Now WHERE NOT EXISTS (SELECT 1 FROM Artiest WHERE Naam = @Naam);";
                object parameters = new { Naam = artiestNaam , Now = DateTime.Now };
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

        // 
        public List<Artiest> GetArtiesten()
        {
            DBGenre dBGenreq = new DBGenre();
            List<Genre> genres = dBGenreq.GetGenres();

            string sql = "SELECT * FROM Artiest";
            List<Artiest> artiestenLijst = new List<Artiest>();

            using (var connection = new SqlConnection(dbstring))
            {
                IEnumerable<Artiest> query = connection.Query<Artiest>(sql);

                foreach (var artiest in query)
                {
                    IEnumerable<ArtiestGenre> artiestGenreLijst = connection.Query<ArtiestGenre>(
                        "SELECT * FROM ArtiestGenre WHERE ArtiestId = @artiestId and DeletedAt = NULL",
                        new { artiestId = artiest.id }
                    );

                    //artiest.genres = genres
                    //    .Where(g => artiestGenreLijst.Any(ag => ag.GenreId == g.id))
                    //    .ToList();

                    //artiestenLijst.Add(artiest);
                    foreach (var genre in genres)
                    {
                        foreach (var artiestGenre in artiestGenreLijst)
                        {
                            if (artiestGenre.GenreId == genre.id)
                            {
                                artiest.genres.Add(genre);
                                break;
                            }
                        }
                    }
                    artiestenLijst.Add(artiest);
                }
            }

            return artiestenLijst;
        }

        public Artiest GetArtiestMetId(int id)
        {
            string sql = "SELECT * FROM Artiest WHERE id = @id";
            object parameters = new { id = id };
            using (var connection = new SqlConnection(dbstring))
            {
                Artiest query = connection.QueryFirstOrDefault<Artiest>(sql, parameters);
                return query;
            }
        }

        
        // REGEX Optimalisaie bv bij ", 1 , 2"
        public bool GenreAanArtiestToevoegen(string artiestNaam,string genreLijst)
        {
            string regexString = @"[,\s]+";
            string[] genresNr = Regex.Split(genreLijst.Trim(), regexString);

            DBArtiest dbArtiest = new DBArtiest();
            Artiest artiest = dbArtiest.GetArtiestMetNaam(artiestNaam);

            string sql = "INSERT INTO ArtiestGenre (ArtiestId,GenreId,CreatedAt) SELECT @artiestId,@genreId, GETDATE() WHERE NOT EXISTS (SELECT 1 FROM ArtiestGenre WHERE ArtiestId = @artiestId AND GenreId = @genreId);";

            foreach (var genreNr in genresNr)
            {
                object parameters = new { artiestId = artiest.id, genreId = genreNr};
                using (var connection = new SqlConnection(dbstring))
                {
                    ArtiestGenre query = connection.QueryFirstOrDefault<ArtiestGenre>(sql, parameters);
                }
            }

            return false;
        }

        public bool ArtiestUpdaten(string nieuweArtiestNaam, string oudeArtiestNaam)
        {
            try
            {
                string sql = "UPDATE Artiest SET Naam = @NieuweNaam WHERE Naam = @OudeNaam";
                object parameters = new { NieuweNaam = nieuweArtiestNaam, OudeNaam = oudeArtiestNaam };
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

        public bool ArtiestVerwijderen(string artiestNaam)
        {
            try
            {
                DBArtiest dbArtiest = new DBArtiest();
                Artiest artiest = dbArtiest.GetArtiestMetNaam(artiestNaam);

                string sql = "UPDATE Artiest SET DeletedAt = @deletedAt WHERE Naam = @Naam";
                object parameters = new {deletedAt = DateTime.Now, Naam = artiestNaam};
                using (var connection = new SqlConnection(dbstring))
                {
                    IEnumerable<dynamic> query = connection.Query(sql, parameters);
                }
                DBOptreden_ORG dbGenre_ORG = new DBOptreden_ORG();
                dbGenre_ORG.OptredenVerwijderenBijArtiestVerwijdering(artiest.id);
                Console.WriteLine("gelukt");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);  
                
                return false;
            }
        }
    }
}
