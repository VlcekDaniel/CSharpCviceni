using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreceSpoli
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] poleCisel;
            int volba = 0;
            int velikostPole = 5;
            poleCisel = new int[velikostPole];
            do
            {
                try
                { 
                vypisMenu();
                volba = Convert.ToInt32(Console.ReadLine());

                switch (volba)
                {
                    case 1:
                        {
                            for (int i = 0; i < velikostPole; i++)
                            {
                                poleCisel[i] = Fei.BaseLib.Reading.ReadInt("Zadejte cislo");
                            } 
                        }
                        break;
                    case 2:
                        {
                            vypisPole();
                        }
                        break;
                    case 3:
                        {
                            Array.Sort(poleCisel);
                            vypisPole();
                        }
                        break;
                    case 4:
                        {
                            int min = poleCisel.Min();
                            Console.WriteLine($"Minimalni prvek je {min}.");
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Zadejte hledane cislo: ");
                            int hledaneCislo = Convert.ToInt32(Console.ReadLine());
                            int indexCisla = -1;
                            for (int i = 0; i < velikostPole; i++)
                            {
                                if (poleCisel[i] == hledaneCislo) {
                                    indexCisla = i;
                                    break;
                                }
                            }
                            Console.WriteLine($"Hledane cislo je na {indexCisla} indexu.");
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("Zadejte hledane cislo: ");
                            int hledaneCislo = Convert.ToInt32(Console.ReadLine());
                            int indexCisla = -1;
                            for (int i = velikostPole-1; i > 0; i--)
                            {
                                if (poleCisel[i] == hledaneCislo)
                                {
                                    indexCisla = i;
                                    break;
                                }
                            }
                            Console.WriteLine($"Hledane cislo je na {indexCisla} indexu.");
                        }
                        break;
                    case 8:
                        {
                            Console.WriteLine("Konec programu.");
                        }
                        break;
                    case 7:
                        {
                            Array.Sort(poleCisel);
                            Array.Reverse(poleCisel);
                            vypisPole();
                        }
                        break;
                    default:
                        break;
                }
                }
                catch (Exception)
                {
                    Console.WriteLine("Vstup neni korektni.");
                    volba = 0;
                }
            } while (volba!=8);

            void vypisPole(){
                for (int i = 0; i < velikostPole; i++)
                {
                    Console.Write(poleCisel[i] + " ");
                }
                Console.WriteLine();
            }

            void vypisMenu()
            {                
                    Console.WriteLine("1. Zadani prvků");
                    Console.WriteLine("2. Vypis pole");
                    Console.WriteLine("3. Utrideni vzestupne");
                    Console.WriteLine("4. Najdete minimalni prvek");
                    Console.WriteLine("5. Hledani prvniho vyskytu cisla");
                    Console.WriteLine("6. Hledani posledniho vyskytu cisla");
                    Console.WriteLine("7. Utrideni vzestupne");
                    Console.WriteLine("8. Konec");                
            }
        }
    }
}
