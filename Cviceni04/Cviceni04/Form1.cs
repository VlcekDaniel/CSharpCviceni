using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cviceni04
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();

        public Form1()
        {
            InitializeComponent();
            stats.UpdatedStats += onUpdateStats;  
        }

        private void onUpdateStats(object sender, EventArgs eventArgs)
        {
            correctLabel.Text = Convert.ToString("Correct:" + stats.Correct);
            missedLabel.Text = Convert.ToString("Missed: " + stats.Missed);
            accurancyLabel.Text = Convert.ToString("Accurancy: " + stats.Accurancy);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameListBox.Items.Add((Keys)random.Next(65,90));
            gameListBox.Refresh();
            if (gameListBox.Items.Count > 6) {
                timer1.Stop();
                gameListBox.Items.Clear();
                gameListBox.Items.Add("Game Over!");
            }
        }

        private void gameListBox_KeyDown(object sender, KeyEventArgs e)
        {
            bool correctKey = false;
            if (gameListBox.Items.Contains(e.KeyCode))
            {
                gameListBox.Items.Remove(e.KeyCode);
                gameListBox.Refresh();
                correctKey = true;
            }
            else {
                correctKey = false;
            }

            if (timer1.Interval > 100)
            {
                if (timer1.Interval > 400)
                {
                    timer1.Interval -= 60;
                }
                else
                if (timer1.Interval > 250)
                {
                    timer1.Interval -= 15;
                }
                else
                if (timer1.Interval > 150)
                {
                    timer1.Interval -= 8;
                }
                if (timer1.Interval > 800 || timer1.Interval < 90) {
                    throw new Exception();
                }
            }
            difficultyProgressBar.Value = timer1.Interval;
            stats.Update((correctKey));
        }
    }
}
