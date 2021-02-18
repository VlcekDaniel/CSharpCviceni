using System;

namespace Adresa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Josef Novák");
            Console.WriteLine("Jindrišská 16");
            Console.WriteLine("111 50, Praha 1");
          
            Console.Write("Josef Novák \n");
            Console.Write("Jindrišská 16 \r");
            Console.Write("111 50, Praha 1 \n");

            int @if = 10;
            Console.Write(@$"\\ {@if}");

            Console.ReadKey();
        }
    }
}
