using System;

namespace HadaniCisla
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int cislo = rand.Next(0, 101);
            int pocetPokusu = 0;
            do
            {
                do
            {
                Console.WriteLine("Hadejte cislo: \n");
                int hadaneCislo =Convert.ToInt32(Console.ReadLine());
                if (hadaneCislo < cislo) {
                    Console.WriteLine("vetsi");
                }
                if (hadaneCislo > cislo)
                {
                    Console.WriteLine("mensi");
                }
                if (hadaneCislo == cislo)
                {
                    Console.WriteLine("spravne");
                    break;
                }
                pocetPokusu++;
                if (pocetPokusu == 10) {
                    Console.WriteLine("prohra");
                    break;
                }
            } while (true);
                Console.WriteLine("Chcete hrat znovu?(0/1)");
                int volba = Convert.ToInt32(Console.ReadLine());
                if (volba == 0) {
                    break;
                }
                cislo = rand.Next(0, 101);
                pocetPokusu = 0;
            } while (true);
        }
    }
}
