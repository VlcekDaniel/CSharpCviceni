using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fei.BaseLib;

namespace cviceni02
{
    class Program
    {
        static void Main(string[] args)
        {
            int cislo = Fei.BaseLib.Reading.ReadInt("Zadejte int");
            double cislo2 = Fei.BaseLib.Reading.ReadDouble("Zadejte double");
            char znak = Fei.BaseLib.Reading.ReadChar("Zadejte char");

            Console.WriteLine($"Integer: {cislo}, Double: {cislo2}, Char: {znak}.");

            Console.ReadKey();
        }
    }
}


