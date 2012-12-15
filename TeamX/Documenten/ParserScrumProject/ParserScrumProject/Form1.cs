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
        public string pcname;
        public string username;
        public string password;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            ParserClass parser = new ParserClass();
            PutInDatabase pidb = new PutInDatabase();
            try
            {
                //pidb.setConnectionString("db2-pc","sa","sa");
                Records[] temp = parser.uitvoer(pathFileShow.Text);
                try
                {
                    progressBar1.Maximum = temp.Length;
                    richTextBox1.Text = " ";
                    int counter = 0;
                    foreach (Records s in temp)
                    {
                        pidb.addListToDatabase(s,pcname,username,password);
                        if (richTextBox1.Text == null)
                        {
                            richTextBox1.Text += s + "\n";
                        }
                        else
                        {
                            richTextBox1.AppendText(s + "\n");
                        }
                        richTextBox1.ScrollToCaret();
                        counter++;
                        progressBar1.Value++;
                    }
                    System.Windows.Forms.MessageBox.Show("Data added to database");
                    this.Close();
                    this.Dispose();
                }
                catch
                {
                    MessageBox.Show("Text file not in the correct format");
                }
            }
            catch(Exception E)
            {
                System.Windows.Forms.MessageBox.Show("File in use"+ E );

            }
            
        }

        public void enableButton()
        {
            button2.Enabled = true;
            this.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = null; 
            progressBar1.Value = 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text|*.txt|All|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //System.IO.StreamReader sr = new
                //   System.IO.StreamReader(openFileDialog1.FileName);
                pathFileShow.Text = openFileDialog1.FileName;
            }
            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Owner = this;
            form.ShowDialog();
        }

    }
}
