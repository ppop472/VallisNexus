using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VallisNexus.Models;

namespace VallisNexus.Paginas
{
    public class ToonPlattegrond
    {
        public void PlattegrondTonen()
        {


            //Geeft console text kleur
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("PLATTEGROND");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("==================");


            ////Dit toont voorlopig de plattegrond in image viewer totdat we de ascii art opgelost hebben.
            //string path = Path.Combine(
            //  AppDomain.CurrentDomain.BaseDirectory,"Images", "FESTIVALPLATTEGRONDTEST.jpg");

            //if (File.Exists(path))
            //{
            //    Process.Start(new ProcessStartInfo
            //    {
            //        FileName = path,
            //        UseShellExecute = true
            //    });
            //}
            //else
            //{
            //    Console.WriteLine("Image niet gevonden: " + path);
            //}

            //BITMAP IMAGES, werkt niet fatsoenlijk

            int newWidth = 100;

            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Images",
                "plattegrond80-30.png"
            );

            if (!File.Exists(path))
            {
                Console.WriteLine("Image niet gevonden");
                return;
            }

            Bitmap image = new Bitmap(path);

            //Resize image
            Bitmap resized = new Bitmap(
                image,
                new Size(newWidth, (int)(image.Height / (double)image.Width * newWidth))
            );

            image.Dispose(); // originele vrijgeven

            for (int y = 0; y < resized.Height; y += 2)
            {
                for (int x = 0; x < resized.Width; x++)
                {
                    Color pixel = resized.GetPixel(x, y);

                    int brightness = (pixel.R + pixel.G + pixel.B) / 3;

                    Console.Write(brightness > 128 ? " " : "#");
                }

                Console.WriteLine();
            }

            resized.Dispose();


            bool plattegrondTonen = true;

            while (plattegrondTonen)
            {

                Console.Write("----------------------------------------------------------\n");
                Console.Write("|             FESTIVAL - DRUKTE OP HET TERREIN           |\n");
                Console.Write("----------------------------------------------------------\n");

                // Het is hardcoded omdat we geen data hebben / krijgen van camerabeelden
                // Voor podium is die van het aantal optredens

                Optreden alleOptreden = new Optreden();
                List<Podium> podiums = alleOptreden.GetAlleOptreden();

                int teller = 1;

                foreach (Podium podium in podiums)
                {
                    Console.WriteLine($"Podium: {podium.naam}\n");

                    if (podium.optredens.Count == 0)
                    {
                        Console.WriteLine($"Er zijn geen optredens.\n");
                    }
                    else
                    {
                        if(podium.optredens.Count >= 10)
                        {
                            Console.WriteLine("Status: Druk\n");
                        }
                        else if (podium.optredens.Count < 10 && podium.optredens.Count >= 5)
                        {
                            Console.WriteLine("Status: Gemiddeld\n");
                        }
                        else if (podium.optredens.Count < 5 && podium.optredens.Count > 0)
                        {
                            Console.WriteLine("Status: Rustig\n");
                        }
                        else
                        {
                            Console.WriteLine("Geen data gevonden\n");
                        }
                    }
                    Console.Write("----------------------------------------------------------\n");
                }

                // Geen data voor wc en foodtrucks
                Console.WriteLine("WC\n");
                Console.WriteLine("Status: Rustig\n");
                Console.Write("----------------------------------------------------------\n");
                Console.WriteLine("Foodtrucks\n");
                Console.WriteLine("Status: Gemiddeld\n");
                Console.Write("----------------------------------------------------------\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Interactieve plattegrond");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("2. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Terug naar hoofdmenu");
                Console.WriteLine("Maak keuze: ");

                string keuze = Console.ReadLine();
                if (keuze == "1")
                {
                    ToonPlattegrond plattegrondviewer = new ToonPlattegrond();
                    Console.Clear();
                    plattegrondviewer.PlattegrondViewer();
                }

                if (keuze == "2")
                {
                    Console.WriteLine("Je gaat nu terug naar het hoofdmenu");
                    Console.Clear();
                    plattegrondTonen = false;
                }

            }
        }

        public void PlattegrondViewer()
        {
            //Dit toont voorlopig de plattegrond in image viewer totdat we de ascii art opgelost hebben.
            string path = Path.Combine(
              AppDomain.CurrentDomain.BaseDirectory, "Images", "plattegrond80-30.png");

            if (File.Exists(path))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            else
            {
                Console.WriteLine("Image niet gevonden: " + path);
            }

        }
    }
}





 