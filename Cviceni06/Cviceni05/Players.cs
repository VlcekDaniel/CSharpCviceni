using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni05
{
    public class Players
    {
        public SpojovySeznam SeznamHracu;
        private int count;

        public int Count
        {
            get { return SeznamHracu.Velikost; }
            set { count = value; }
        }



        public Players() {
            SeznamHracu = new SpojovySeznam();
        }

        public void Delete(int i) {
            SeznamHracu.RemoveAt(i);
        }

        public void Add(Player player) {
            SeznamHracu.Add(player);
        }

        public Player this[int index]
        {
            get => (Player)SeznamHracu.Return(index);
            set => SeznamHracu.Set(index, value);
        }

        public void FindBestClubs(out Club[] arrayClubs,out int count) {
            arrayClubs = new Club[Enum.GetValues(typeof(Club)).Length];
            int[] arrayInts = new int[Enum.GetValues(typeof(Club)).Length];


            int k = 0;
            for (int i = 0; i < SeznamHracu.Count; i++)
            {             
                Player player = (Player)SeznamHracu.Return(i);
                if (player == null)
                {
                    break;
                }
                if (arrayClubs.Contains(player.FootballClub))
                {
                    arrayInts[Array.IndexOf(arrayClubs, player.FootballClub)] += player.Goals;
                    arrayInts[Array.IndexOf(arrayClubs, player.FootballClub)] += player.Assists;
                }
                else
                {
                    arrayClubs[k] = player.FootballClub;
                    arrayInts[k] += player.Goals;
                    arrayInts[k] += player.Assists;
                    k++;
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
