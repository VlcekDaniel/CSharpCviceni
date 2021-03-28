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
            dataGridView1.DataSource = players.SeznamHracu;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormPlayer formPlayer = new FormPlayer();
            formPlayer.ShowDialog();
            players.Add(formPlayer.TempPlayer);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = players.SeznamHracu;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            players.Delete(dataGridView1.CurrentCell.RowIndex);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = players.SeznamHracu;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Player player = players[dataGridView1.CurrentCell.RowIndex];
            FormPlayer formPlayer = new FormPlayer();
            formPlayer.SetText(player);
            formPlayer.ShowDialog();
            players[dataGridView1.CurrentCell.RowIndex] = formPlayer.TempPlayer;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FormSave formSave = new FormSave();
            Club[] clubs = (Club[])Enum.GetValues(typeof(Club));
            formSave.LoadTeams(clubs,players);
            formSave.Show();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            var fileContent = string.Empty;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }           
            String[] playersStr = fileContent.Split('\n');
            foreach (var item in playersStr)
            {
                if (item == "") {
                    continue;
                }
                String[] playerStr = item.Split(' ');
                String playerName = playerStr[0]+ " " + playerStr[1];
                Club playerClub = (Club)Enum.Parse(typeof(Club), playerStr[2]);
                int playerGoals = Convert.ToInt32(playerStr[3]);
                int playerAssists = Convert.ToInt32(playerStr[4]);
                players.Add(new Player(playerName,playerClub,playerGoals,playerAssists));
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = players.SeznamHracu;
        }
    }
}
