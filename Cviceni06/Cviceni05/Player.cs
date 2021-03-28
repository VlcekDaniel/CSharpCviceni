using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni05
{
    public class Player
    {
        public string Name { get; set; }
        public Club FootballClub { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }

        public Player(string name, Club footballClub, int goals, int assists)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            FootballClub = footballClub;
            Goals = goals;
            Assists = assists;
        }

        public override string ToString()
        {
            return ($"{Name} {FootballClub} {Goals} {Assists}");
        }
    }
}
