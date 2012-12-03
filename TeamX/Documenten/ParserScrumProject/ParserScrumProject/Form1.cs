using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParserScrumProject
{
    public partial class Form1 : Form
    {
        ParserClass parser = new ParserClass();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] temp = null;
            try
            {

                temp = parser.uitvoer(pathFileShow.Text);
                richTextBox1.Text = " ";
                //int counter = 0;
                foreach (string s in temp)
                {
                    //if (counter % 7 == 0)
                    //{
                    //    progressBar1.Value++;
                    //}
                    if (richTextBox1.Text == null)
                    {
                        richTextBox1.Text += s + "\n";
                    }
                    else
                    {
                        richTextBox1.AppendText(s + "\n");
                    }
                    richTextBox1.ScrollToCaret();
                    progressBar1.Value++;
                    //counter ++;

                }
                System.Windows.Forms.MessageBox.Show("Data added to database");
                progressBar1.Value = 0;
            }
            catch(Exception)
            {
                System.Windows.Forms.MessageBox.Show("File in use");

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = null; 
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text|*.txt|All|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //System.IO.StreamReader sr = new
                //   System.IO.StreamReader(openFileDialog1.FileName);
                pathFileShow.Text = openFileDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 700;
        }

    }
}
