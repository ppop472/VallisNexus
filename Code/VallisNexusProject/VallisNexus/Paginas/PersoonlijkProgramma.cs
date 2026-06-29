using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.Models;
using VallisNexus.DataAccess;
using System.IO;
using Newtonsoft.Json;
namespace VallisNexus.Paginas
{
    internal class PersoonlijkProgramma
    {
        private string bestand = "persoonlijkProgramma.json";

        public List<OptredenDTO> PersoonlijkeOptredens { get; set; } = new List<OptredenDTO>();

        public void OpslaanPersoonlijkProgramma()
        {
            string json = JsonConvert.SerializeObject(PersoonlijkeOptredens);
            File.WriteAllText(bestand, json);
        }

        public void LadenPersoonlijkProgramma()
        {
            if (File.Exists(bestand))
            {
                string json = File.ReadAllText(bestand);

                PersoonlijkeOptredens =
                    JsonConvert.DeserializeObject<List<OptredenDTO>>(json)
                    ?? new List<OptredenDTO>();
            }
        }

        public void ToonPersoonlijkProgramma()
        {
            if (PersoonlijkeOptredens.Count == 0)
            {
                Console.WriteLine("Er zijn nog geen optredens toegevoegd.");
            }
            else
            {
                foreach (var optreden in PersoonlijkeOptredens)
                {
                    Console.WriteLine($"Artiest: {optreden.artiestNaam}");
                    Console.WriteLine($"Starttijd: {optreden.starttijd}");
                    Console.WriteLine($"Eindtijd: {optreden.eindtijd}");
                    Console.WriteLine("---------------------------");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Druk op een toets om terug te gaan...");
            Console.ReadKey();
        }



    }
}
