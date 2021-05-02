using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceWars
{
     class Dice
    {
        Random random = new Random();
        public  int ThrowDice(int diceNumber){
            
            int totalNumber = 0;
            for (int i = 0; i < diceNumber; i++)
            {
                totalNumber+= random.Next(1, 7); 
            }
            return totalNumber;
        }
    }
}
