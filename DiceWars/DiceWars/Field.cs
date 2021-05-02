using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceWars
{
    class Field
    {
        public enum FieldEnum { player1, player2, wall }
        public FieldEnum FieldType;
        public int diceNumber;
        public Coordinates Position { get; }

        public Field(FieldEnum fieldType, Coordinates position, int diceNumber)
        {
            this.diceNumber = diceNumber;
            this.FieldType = fieldType;
            Position = position;
        }

        public Field(FieldEnum fieldType, Coordinates position)
        {           
            this.FieldType = fieldType;
            Position = position;            
        }

    }
}
