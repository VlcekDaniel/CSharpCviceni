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
    public partial class FormBestClubs : Form
    {
        public FormBestClubs()
        {
            InitializeComponent();
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetClubs(Club[] clubs, int bestPoints)
        {
            labelGoals.Text = $"Points: {bestPoints} ";
            foreach (var item in clubs)
            {
                if (Club.None==item) {
                    continue;
                }
                listView1.Items.Add(item.ToString());
            }           
        }
    }
}
