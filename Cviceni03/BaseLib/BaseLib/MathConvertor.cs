using System;
using System.Collections.Generic;
using System.Text;

namespace Fei
{
    namespace BaseLib
    {
        /// <summary>
        /// Trida slouzi k prevodu mezi ciselnymi soustavami
        /// </summary>
        public class MathConvertor
        {
            /// <summary>
            /// Prevod z desitkove do dvojkove soustavy.
            /// </summary>
            /// <returns>Vraci cislo ve dvojkove soustave.</returns>
            public static string ConvertDesitkovaToDvojkova(int cislo)
            {
                string cisloDvojkova = "";
                while ((int)cislo != 0)
                {
                    cisloDvojkova = ((int)cislo % 2).ToString() + cisloDvojkova;
                    cislo = cislo / 2;
                }
                return cisloDvojkova;
            }

            /// <summary>
            /// Prevod z dvojkove do desitkove soustavy.
            /// </summary>
            /// <returns>Vraci cislo v desitkove soustave.</returns>
            public static int ConvertDvojkovaToDesitkova(string cisloDvojkova)
            {
                int cislo = 0;
                for (int i = 0; i < cisloDvojkova.Length-1; i++)
                {
                    cislo += (int)Math.Pow((cisloDvojkova[i]-'0')*2,cisloDvojkova.Length-i-1);
                }
                return cislo;
            }

            /// <summary>
            /// Prevod z desitkove do rimske soustavy.
            /// </summary>
            /// <returns>Vraci cislo v rimske soustave.</returns>
            public static string ConvertDesitkovaToRimska(int arabske)              
            {
                string rimske = "";
                while (true)
                {
                    if (arabske / 1000 > 0)
                    {
                        rimske += 'M';
                        arabske -= 1000;
                    }
                    if (arabske / 500 > 0)
                    {
                        if ((arabske + 100) / 900 > 0)
                        {
                            rimske += "CM";
                            arabske -= 900;
                            continue;
                        }
                        else
                        {
                            rimske += 'D';
                            arabske -= 500;
                            continue;
                        }
                    }
                    if (arabske / 100 > 0)
                    {
                        if ((arabske + 100) / 500 > 0)
                        {
                            rimske += "CD";
                            arabske -= 400;
                            continue;
                        }
                        else
                        {
                            rimske += 'C';
                            arabske -= 100;
                            continue;
                        }
                    }
                    if (arabske / 50 > 0)
                    {
                        if ((arabske + 10) / 100 > 0)
                        {
                            rimske += "XC";
                            arabske -= 90;
                            continue;
                        }
                        else
                        {
                            rimske += 'L';
                            arabske -= 100;
                            continue;
                        }
                    }
                    if (arabske / 10 > 0)
                    {
                        if ((arabske + 10) / 50 > 0)
                        {
                            rimske += "XL";
                            arabske -= 40;
                            continue;
                        }
                        else
                        {
                            rimske += 'X';
                            arabske -= 10;
                            continue;
                        }
                    }
                    if (arabske / 5 > 0)
                    {
                        if ((arabske + 1) / 10 > 0)
                        {
                            rimske += "IX";
                            arabske -= 9;
                            continue;
                        }
                        else
                        {
                            rimske += 'V';
                            arabske -= 5;
                            continue;
                        }
                    }
                    if (arabske / 1 > 0)
                    {
                        if ((arabske + 1) / 5 > 0)
                        {
                            rimske += "IV";
                            arabske -= 4;
                            continue;
                        }
                        else
                        {
                            rimske += 'I';
                            arabske -= 1;
                            continue;
                        }
                    }
                    if (arabske == 0) {
                        break;
                    }
                }
                return rimske;
            }

            /// <summary>
            /// Prevod z rimske do desitkove soustavy.
            /// </summary>
            /// <returnsVraci cislo v desitkove soustave.></returns>
            public static int ConvertRimskaToDesitkova(string rimske)
            {
                int aktualni = 0;
                int minulaCislice = 0;
                int arabske = 0;
                for (int i = rimske.Length; i > 0; i--)
                {
                    switch (rimske[i-1])
                    {
                        case 'I': aktualni = 1; break;
                        case 'V': aktualni = 5; break;
                        case 'X': aktualni = 10; break;
                        case 'L': aktualni = 50; break;
                        case 'C': aktualni = 100; break;
                        case 'D': aktualni = 500; break;
                        case 'M': aktualni = 1000; break;
                    }
                    if (minulaCislice > aktualni)
                    {
                        arabske -= aktualni;
                    }
                    else
                    {
                        arabske += aktualni;
                    }
                    minulaCislice = aktualni;
                }
                return arabske;
            }
        }
    }
}
