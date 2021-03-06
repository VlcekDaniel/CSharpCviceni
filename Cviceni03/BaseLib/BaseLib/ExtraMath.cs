using System;
using System.Collections.Generic;
using System.Text;

namespace Fei { 
namespace BaseLib
{
    /// <summary>
    /// Trida poskytuje matematicke funkce
    /// </summary>
    public class ExtraMath
    {
        /// <summary>
        /// Resi kvadratickou rovnici.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns>Vraci true jestlize je reseni v realnych cislech.</returns>
        public static bool VyresKvadratickouRovnici(double a, double b, double c, out double x1, out double x2) {            
            double d = Math.Pow(b,2) - 4 * a * c;
            if (d < 0) {
                x1 = 0;
                x2 = 0;
                return false;
                }
            if (d == 0) {
                x1 = (-b / (2 * a));
                x2 = (-b / (2 * a));
                return true;
            }
            x1 = (-b + Math.Sqrt(d)) / (2 * a);
            x2 = (-b - Math.Sqrt(d)) / (2 * a);
            return true;
        }

        /// <summary>
        /// Generuje realne cislo.
        /// </summary>
        /// <param name="rand"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Vraci double, v danem intervalu.</returns>
        public static double GenerujDouble(Random rand, int min, int max) {           
            return rand.NextDouble()*(max-min)+min;
        }
    }
    }
}