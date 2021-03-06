using System;

namespace Fei
{ 
    namespace BaseLib {

        /// <summary>
        /// Trida slouzi ke cteni dat z klavesnice.
        /// </summary>
        public class Reading
        {
            /// <summary>
            /// Cte z klavesnice int vstup. 
            /// </summary>
            /// <param name="msg">vyzva pro uzivatele</param>
            /// <returns>Vraci int, v pripade spatneho vstupu 0</returns>
            public static int ReadInt(String msg)
            {
                try
                {
                    Console.WriteLine(msg + ": ");
                    int cislo = Convert.ToInt32(Console.ReadLine());
                    return cislo;
                }
                catch (Exception)
                {
                    return 0;
                    throw;
                }

            }

            /// <summary>
            /// Cte z klavesnice double vstup.
            /// </summary>
            /// <param name="msg">vyzva pro uzivatele</param>
            /// <returns>Vraci double, v pripade spatneho vstupu 0</returns>
            public static double ReadDouble(String msg)
            {
                try
                {
                    Console.WriteLine(msg + ": ");
                    double cislo = Convert.ToDouble(Console.ReadLine());
                    return cislo;
                }
                catch (Exception)
                {
                    return 0;
                    throw;
                }
            }

            /// <summary>
            /// Cte z klavesnice char vstup.
            /// </summary>
            /// <param name="msg">vyzva pro uzivatele</param>
            /// <returns>Cte z klavesnice char vstup. </returns>
            public static char ReadChar(String msg)
            {
                try
                {
                    Console.WriteLine(msg + ": ");
                    char znak = Convert.ToChar(Console.ReadLine());
                    return znak;
                }
                catch (Exception)
                {
                    return '0';
                    throw;

                }
            }
        }
    }
}
