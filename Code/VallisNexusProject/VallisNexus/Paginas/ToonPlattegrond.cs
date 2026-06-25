using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            //Dit toont voorlopig de plattegrond in image viewer totdat we de ascii art opgelost hebben.
            string path = Path.Combine(
              AppDomain.CurrentDomain.BaseDirectory,
              "Images",
              "plattegrond.png"
          );

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



            //Bitmap image = new Bitmap(".\\VallisNexus\\Code\\VallisNexusProject\\VallisNexus\\Images\\PLATTE GROND VALLIS NEXUS.png");

            //for (int y = 0; y < image.Height; y += 2)
            //{
            //    for (int x = 0; x < image.Width; x++)
            //    {
            //        Color pixel = image.GetPixel(x, y);

            //        int brightness = (pixel.R + pixel.G + pixel.B) / 3;

            //        Console.Write(brightness > 128 ? " " : "#");
            //    }
            //    Console.WriteLine();
            //}


            bool plattegrondTonen = true;

            while (plattegrondTonen)
            {


                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Terug naar hoofdmenu");
                Console.WriteLine("Maak keuze: ");

                string keuze = Console.ReadLine();

                if (keuze == "1")
                {
                    Console.WriteLine("Je gaat nu terug naar het hoofdmenu");
                    Console.Clear();
                    plattegrondTonen = false;
                }


            }
        }
    }

}   


 