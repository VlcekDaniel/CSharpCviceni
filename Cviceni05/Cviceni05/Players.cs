using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni05
{
    public class Players
    {
        private int index;
        public int Count { get; set; }
        public Player[] ArrayPlayers { get; set; }

        public Players() {
            Count = 20;
            ArrayPlayers = new Player[Count];
        }

        public void Delete(int i) {
            ArrayPlayers[i] = ArrayPlayers[index - 1];
            ArrayPlayers[index - 1] = null;
            index--;
        }

        public void Add(Player player) {
            ArrayPlayers[index] = player;
            index++;
        }

        public Player this[int index]
        {
            get { return ArrayPlayers[index]; }
            set { ArrayPlayers[index] = value; }
        }

        public void FindBestClubs(out Club[] arrayClubs,out int count) {
            arrayClubs = new Club[Enum.GetValues(typeof(Club)).Length];
            int[] arrayInts = new int[Enum.GetValues(typeof(Club)).Length];
            int i = 0;
            foreach (var item in ArrayPlayers)
            {
                if (item == null) {
                    break;
                }
                if (arrayClubs.Contains(item.FootballClub))
                {
                    arrayInts[Array.IndexOf(arrayClubs, item.FootballClub)] += item.Goals;
                    arrayInts[Array.IndexOf(arrayClubs, item.FootballClub)] += item.Assists;
                }
                else {
                    arrayClubs[i] = item.FootballClub;
                    arrayInts[i] += item.Goals;
                    arrayInts[i] += item.Assists;
                    i++;
                }                
            }
            count = arrayInts.Max();
            for (int j = 0; j < arrayInts.Length; j++)
            {            
                if (arrayInts[j] != count) {
                    arrayClubs[j] = Club.None;
                }
            }

        }

        private void CountChanged(object sender, EventArgs e,int count)
        {

        }
    }
}
