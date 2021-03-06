using System;
using System.Collections.Generic;
using System.Text;

namespace BaseLib
{
    /// <summary>
    /// Trida poskytuje matematicke funkce
    /// </summary>
    class ExtraMath
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
        public bool vyresKvadratickouRovnici(double a, double b, double c, out double x1, out double x2) {
            
            
            x1 = 0;
            x2 = 0;
            return true;
        }

        /// <summary>
        /// Generuje realne cislo.
        /// </summary>
        /// <param name="rand"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Vraci double, v danem intervalu.</returns>
        public double generateDouble(Random rand, int min, int max) {


            return 0;
        }
    }
}
