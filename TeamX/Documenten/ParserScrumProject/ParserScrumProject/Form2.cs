using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ParserScrumProject
{
    public partial class Form2 : Form
    {
        Form1 form = new Form1();
        PutInDatabase test = new PutInDatabase();

        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxServerName.Text.Length > 0 && textBoxUsername.Text.Length > 0 && textBoxPassword.Text.Length > 0)
            {
                test.setConnectionString(textBoxServerName.Text, textBoxUsername.Text, textBoxPassword.Text);
                if (test.testConnection())
                {
                    MessageBox.Show("Connection Established");
                    Form1 p = (Form1)this.Owner;
                    p.button2.Enabled = true;
                    p.username = textBoxUsername.Text;
                    p.pcname = textBoxServerName.Text;
                    p.password = textBoxPassword.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Connection string not valid");
                }

            }
            else
            {
                MessageBox.Show("One of the required fields has no data");
            }

        }


    }
}
