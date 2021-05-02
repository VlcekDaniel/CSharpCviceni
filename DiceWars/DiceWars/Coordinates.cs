using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceWars
{
    class Coordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Coordinates(int row, int column) 
        {
            Row = row;
            Column = column;
        }

        public Coordinates()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinates coordinates &&
                   Row == coordinates.Row &&
                   Column == coordinates.Column;
        }

        public override string ToString()
        {
            return $"Row: {Row}, Column: {Column}";
        }

        public override int GetHashCode()
        {
            int hashCode = 240067226;
            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();
            return hashCode;
        }

    }  
}
