using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_IoT
{
    internal class FeatureSelector
    {
        public static void PrintMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(@" ------ MENU ------
            1 - C2D - Cloud to Device 
            2 - Device Twin
            3 - Direct Method - Send Message
            4 - Direct Method - Emergency STOP
            5 - Direct Method - Reset Errors
            6 - Increase Production Rate by 10
            7 - Decrease Production Rate by 10
            8 - Set Production Rate
            0 - Exit"
            );
        }
    }
}
