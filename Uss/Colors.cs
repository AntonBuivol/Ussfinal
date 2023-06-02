using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uss
{
    internal class Colors
    {
        List<string> color = new List<string>()
        {
            "White",
            "Blue",
            "Green",
            "Yellow"
        };

        public string ValiColor()
        {
            try
            {
                int i = 0;
                Console.WriteLine("Kirjutage mao värv");

                foreach (string item in color)
                {
                    i++;
                    Console.WriteLine("{0} --> {1}", i, item);
                }
                int Vali = Convert.ToInt32(Console.ReadLine());
                int colornumber = color.Count;

                if (Vali > colornumber + 1)
                {
                    Console.WriteLine("VIGA NUMBER!!!!");
                    return "";
                }

                else
                {
                    string ussColor = color[Vali - 1];
                    Console.WriteLine(ussColor);
                    return ussColor;
                }
            }

            catch
            {
                Console.WriteLine("Vale värv, sa mängid rohelisega.");
                string ussColor;
                ussColor = "Green";
                return ussColor;
            }
        }
    }
}
