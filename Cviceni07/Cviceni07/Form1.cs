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

namespace Cviceni07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Bitmap LoadPCX(string filename) {
            
            Stream fs = File.OpenRead(filename);
            BinaryReader binaryReader = new BinaryReader(fs);

            Byte[] header = readHeader(binaryReader);
            string a = "";
            foreach (var item in header)
            {
                a += item;
            }
            MessageBox.Show(a);
            //pictureBox1.Image = bitmap;
            return null;          
        }

        private Byte[] readHeader(BinaryReader binaryReader) {
            return binaryReader.ReadBytes(128);
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "pcx files(*.pcx)| *.pcx";
            openFileDialog1.ShowDialog();

            pictureBox1.Image = LoadPCX(openFileDialog1.FileName);
            
        }
    }
}
