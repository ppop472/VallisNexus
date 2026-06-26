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
using VallisNexus.DataAccess.CRUD_VOOR_ORG;
using System.Net.Http.Headers;
using System.Collections;

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
            DBGenre dBGenreq = new DBGenre();
            List<Genre> genres = dBGenreq.GetGenres();

            string sql = "SELECT * FROM Artiest WHERE DeletedAt IS NULL";
            List<Artiest> artiestenLijst = new List<Artiest>();

            using (var connection = new SqlConnection(dbstring))
            {
                IEnumerable<Artiest> query = connection.Query<Artiest>(sql);

                foreach (var artiest in query)
                {
                    IEnumerable<ArtiestGenre> artiestGenreLijst = connection.Query<ArtiestGenre>(
                        "SELECT * FROM ArtiestGenre WHERE ArtiestId = @artiestId WHERE DeletedAt IS NULL",
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
            string sql = "SELECT * FROM Artiest WHERE id = @id AND DeletedAt IS NULL";
            object parameters = new {id = id };           
            using (var connection = new SqlConnection(dbstring))
            {
                Artiest query = connection.QueryFirstOrDefault<Artiest>(sql, parameters);
                return query;
            }            
        }

        public Artiest GetArtiestMetNaam(string artiestNaam)
        {
            string sql = "SELECT * FROM Artiest WHERE Naam = @naam AND DeletedAt IS NULL";
            object parameters = new { naam = artiestNaam };
            using (var connection = new SqlConnection(dbstring))
            {
                Artiest query = connection.QueryFirstOrDefault<Artiest>(sql, parameters);
                return query;
            }
        }
    }
}
