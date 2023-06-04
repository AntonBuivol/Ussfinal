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
        public static void SetColor(string color)
        {
            switch (color) //swictch выражение которое позволяет выбирать различные пути выполнения кода в зависимости от значения выражения
            {
                case "White": // case - варианты каждый из которых содержит значение с которым будет сравниваться выражение
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Green; // По умолчанию, если выбран неверный цвет
                    break;
            }
        }
    }
}
