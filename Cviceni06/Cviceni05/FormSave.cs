using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cviceni05
{
    public partial class FormSave : Form
    {
        Players players;
        public FormSave()
        {
            InitializeComponent();
        }

        public void LoadTeams(Club[] clubs,Players players)
        {
            foreach (var item in clubs)
            {
                listView1.Items.Add(item.ToString());
            }
            this.players = players;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }

        private void save()
        {
            String[] playersStr = null;
            String[] clubs = new String[listView1.SelectedItems.Count];
            int index = 0;
            //stringy klubů
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                clubs[index] = item.Text;
                index++;
            }

            //vybraní hráči
            playersStr = new String[players.Count];
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i] == null)
                {
                    continue;
                }
                if (clubs.Contains(players[i].FootballClub.ToString()))
                {
                    playersStr[i] += players[i].ToString();
                }
            }

            //počet hráču s nenulovým týmem
            int citac = 0;
            foreach (var item in playersStr)
            {
                if (item == null)
                {
                    citac++;
                }
            }

            //pole hráču s týmy
            String[] playersStrClean = new String[players.Count-citac];
            index = 0;
            foreach (var item in playersStr)
            {
                if (item != null) {
                    playersStrClean[index] = item;
                    index++;
                }              
            }

            File.WriteAllLines("Clubs.txt", playersStrClean);
        }
    }
}
