using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using VallisNexus.DataAccess;
using VallisNexus.DataAccess.CRUD_VOOR_ORG;
using VallisNexus.Models;
using VallisNexus.Paginas;

namespace VallisNexus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HoofdMenu hoofdMenu = new HoofdMenu();
            hoofdMenu.ToonHoofdMenu();
        }
    }
}
