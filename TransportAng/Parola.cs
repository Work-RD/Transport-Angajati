using System;
using System.Windows.Forms;
using TransportAng.TransportAng;

namespace TransportAngajati.TransportAng
{
    public partial class Parola : Form
    {
        public Parola()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ("Webasto123"))
            {
                int num = (int)new Setari().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please try again.");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (textBox1.Text == ("Webasto123"))
                {
                    int num = (int)new Setari().ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please try again.");
                }
            }
        }
    }
}
