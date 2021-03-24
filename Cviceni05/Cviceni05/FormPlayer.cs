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
    public partial class FormPlayer : Form
    {
        public Player TempPlayer { get; set; }
        public FormPlayer()
        {
            InitializeComponent();
            comboBoxClub.DataSource = Enum.GetValues(typeof(Club));
            
        }

        public void SetText(Player player)
        {
            textBoxName.Text = player.Name;
            comboBoxClub.SelectedItem = player.FootballClub;
            numericUpDownGoals.Value = player.Goals;
            numericUpDownAssists.Value = player.Assists;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Player player = new Player(textBoxName.Text,(Club)comboBoxClub.SelectedItem,(int)numericUpDownGoals.Value,(int)numericUpDownAssists.Value);
            TempPlayer = player;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
