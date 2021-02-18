using System;

namespace Abeceda
{
    class Program
    {
        static void Main(string[] args)
        {
            int cislo = 97;
            for (int i = 0; i < 26; i++)
            {
                char a = (char)cislo;
                Console.Write(a);
                cislo++;
            }
            cislo = 97;
            Console.WriteLine();
            while (cislo<=122)
            {
                char a = (char)cislo;
                Console.Write(a);
                cislo++;
            }
            cislo = 97;
            Console.WriteLine();
            do
            {
                char a = (char)cislo;
                Console.Write(a);
                cislo++;
                if (cislo > 122) {
                    break;
                }
            } while (true);
        }
    }
}
