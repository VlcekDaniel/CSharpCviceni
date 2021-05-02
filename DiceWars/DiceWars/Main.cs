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
using static DiceWars.Field;

namespace DiceWars
{
    public partial class Main : Form
    {
        Game game;
        Renderer renderer;
        int seed = 6;
        public Main()
        {
            InitializeComponent();
            game = new Game(10, 10, seed);
            renderer = new Renderer(game);
            renderer.SetRendererTarget(panel1);
            game.UpdatedStats += RefreshLabels;
            game.UpdatedWin += RefreshWin;
            panelPlayer1.BackColor = Color.Blue;
            panelPlayer2.BackColor = Color.Red;
            game.OnUpdatedStats();
        }

        private void RefreshLabels(object sender, EventArgs eventArgs) {
            labelPlayer1.Text = Convert.ToString("Player1: " + game.NumberOfDicesPlayer1);
            labelPlayer2.Text = Convert.ToString("Player2: " + game.NumberOfDicesPlayer2);
            panel1.Refresh();
        }

        private void RefreshWin(object sender, EventArgs eventArgs)
        {
            labelWin.Text = "You win";       
        }
        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            game.EndTurn();

            game.OnUpdatedStats();
            game.selectedField = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.OnUpdatedStats();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("save.txt");
            for (int i = 0; i < game.NumberOfRows; i++)
            {
                for (int j = 0; j < game.NumberOfColumns; j++)
                {
                    writer.Write(game.mapa[i, j].diceNumber);
                    writer.Write(game.mapa[i, j].FieldType);
                    writer.Write(" ");
                }
                writer.WriteLine("");
            }
            writer.Close();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("save.txt");
            for (int i = 0; i < game.NumberOfRows; i++)
            {
                string line = reader.ReadLine();
                string[] words = line.Split(' ');
                for (int j = 0; j < game.NumberOfColumns; j++)
                {
                    string word =words[j];
                    int dicesNumber =(int) char.GetNumericValue(word[0]);
                    game.mapa[i, j].diceNumber = dicesNumber;
                    string fieldString = words[j].Substring(1);
                    game.mapa[i, j].FieldType = (FieldEnum)Enum.Parse(typeof(FieldEnum), fieldString);
                }
            }
            game.CountDices();
            game.OnUpdatedStats();
            panel1.Refresh();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            game.GenerateGrid(random.Next());
            game.CountDices();
            game.OnUpdatedStats();
            panel1.Refresh();
        }


    }
}
