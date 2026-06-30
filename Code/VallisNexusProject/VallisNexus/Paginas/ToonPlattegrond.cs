using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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





 