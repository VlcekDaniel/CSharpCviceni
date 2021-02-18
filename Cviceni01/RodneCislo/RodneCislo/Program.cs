using System;

namespace RodneCislo
{
    class Program
    {
        static void Main(string[] args)
        {
            String RodneCislo1 = "910703";
            String RodneCislo2 = "586226";

            //vraci true(muz) nebo false(zena)
            static bool Over(String text) {
                int znak = Convert.ToInt32(text.Substring(2, 1));
                if (znak == 0|| znak == 2|| znak == 1 || znak == 3)
                    return true;
                return false;
            }
            //vraci true(muz) nebo false(zena)
            static bool OverLong(ulong cislo)
            {
                ulong znak = (cislo / 1000)%10;
                if (znak == 0 || znak == 2|| znak == 1 || znak == 3)
                    return true;
                return false;
            }

            Console.WriteLine(Over(RodneCislo1)?"muz":"zena");
            Console.WriteLine(OverLong(Convert.ToUInt64(RodneCislo2)) ? "muz" : "zena");
        }
    }
}
