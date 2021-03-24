using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cviceni05
{
    public partial class FormChampionsLeague : Form
    {
        public Players players;
        public Player TempPlayer;
        public FormChampionsLeague()
        {
            InitializeComponent();
            players = new Players();
            players.Add(new Player("Cristiano Ronaldo", Club.RealMadrid, 10, 2));
            players.Add(new Player("Erling Haaland", Club.Dortmund, 6, 3));
            players.Add(new Player("Alvaro Morata", Club.Juventus, 6, 2));
            players.Add(new Player("Marcus Rashford", Club.Lazio, 6, 2));
            players.Add(new Player("Karim Benzema", Club.RealMadrid, 4, 3));
            players.Add(new Player("Jadon Sancho", Club.Dortmund, 5, 5));
            dataGridView1.DataSource = players.ArrayPlayers;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormPlayer formPlayer = new FormPlayer();
            formPlayer.ShowDialog();
            players.Add(formPlayer.TempPlayer);
            dataGridView1.Refresh();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            players.Delete(dataGridView1.CurrentCell.RowIndex);
            dataGridView1.Refresh();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Player player = players.ArrayPlayers[dataGridView1.CurrentCell.RowIndex];
            FormPlayer formPlayer = new FormPlayer();
            formPlayer.SetText(player);
            formPlayer.ShowDialog();
            players.ArrayPlayers[dataGridView1.CurrentCell.RowIndex] = formPlayer.TempPlayer;
            dataGridView1.Refresh();
        }

        private void buttonBest_Click(object sender, EventArgs e)
        {
            FormBestClubs formBestClubs = new FormBestClubs();
            Club[] clubs;
            int count = 0;
            players.FindBestClubs(out clubs,out count);
            formBestClubs.SetClubs(clubs,count);
            formBestClubs.Show();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
