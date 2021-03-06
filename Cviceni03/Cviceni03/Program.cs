using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni03
{
    class Program {
        public static void Main()
        {            
            int velikostPole = 5;
            Studenti studenti = new Studenti();
            int volba = -1;
            do
            {
                PrintMenu();
                volba = Convert.ToInt32(Console.ReadLine());

                switch (volba)
                {
                    case 1:
                        studenti.Nacti();
                        break;
                    case 2:
                        studenti.Vypis();                    
                        break;
                    case 3:
                        studenti.Sort(studenti.CompareCislo);
                        break;
                    case 4:
                        studenti.Sort(studenti.CompareJmeno);
                        break;
                    case 5:
                        studenti.Sort(studenti.CompareFakulta);
                        break;
                }
            } while (volba!=0);
        }

         static void PrintMenu() {
            Console.WriteLine("1 Načtení studentů z klávesnice");
            Console.WriteLine("2 Výpis studentů na obrazovku");
            Console.WriteLine("3 Seřazení studentů podle čísla");
            Console.WriteLine("4 Seřazení studentů podle jména");
            Console.WriteLine("5 Seřazení studentů podle fakulty");
            Console.WriteLine("0 Konec programu");
        }
 
    }
}
