using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni05
{
    static class ClubInfo
    {
        static readonly int count = Enum.GetValues(typeof(Club)).Length;

        public static string DejNazev(int i) {
            return Enum.GetName(typeof(Club),i);
        }

    }
}
