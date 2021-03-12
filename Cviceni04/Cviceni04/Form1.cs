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

namespace Cviceni04
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
        
        private int numberOfTicks = 0;
        public Form1()
        {
            InitializeComponent();
            stats.UpdatedStats += onUpdateStats;
        }

        private void onUpdateStats(object sender, EventArgs eventArgs)
        {
            correctLabel.Text = Convert.ToString("Correct:" + stats.Correct);
            missedLabel.Text = Convert.ToString("Missed: " + stats.Missed);
            accurancyLabel.Text = Convert.ToString("Accurancy: " + stats.Accurancy + " %");
            wordsLabel.Text = Convert.ToString("Words: " + stats.NumberOfWords);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gameListBox.Items.Count == 0)
            {
                String[] text = File.ReadAllLines(@"F:\Skola\Bakalar 6. Semestr\ICSHP\CSharpCviceni\Cviceni04\Cviceni04\words_alpha.txt");
                Random rand = new Random();
                string word = text[rand.Next(text.Length)];
                foreach (var character in word)
                {
                    gameListBox.Items.Add((Keys)Char.ToUpper(character));
                }
            }           
            gameListBox.Refresh();
            numberOfTicks++;
            if (numberOfTicks == 10) {
                stats.NumberOfWords++;
                numberOfTicks = 0;
            }
            if (stats.NumberOfWords > 6) {
                timer1.Stop();
                gameListBox.Items.Clear();
                gameListBox.Items.Add("Game Over!");
            }
            stats.OnUpdatedStats();
        }

        private void gameListBox_KeyDown(object sender, KeyEventArgs e)
        {
            gameListBox.TopIndex = 0;
            bool correctKey = false;
            if (gameListBox.Items[0].Equals(e.KeyCode))
            {
                gameListBox.Items.RemoveAt(0);
                gameListBox.Refresh();
                if (gameListBox.Items.Count == 0) {
                    stats.NumberOfWords--;
                }
                correctKey = true;
            }
            else
            {
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
