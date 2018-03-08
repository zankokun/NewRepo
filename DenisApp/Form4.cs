using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenisApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                textBox1.Items.Add(ts.name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Неверные данные");
            else
            {
                foreach (TimeSlot ts in Singleton.getInstance().GetState())
                {
                    if (ts.name == textBox1.Text)
                    {
                        ts.name = textBox2.Text;
                        break;
                    }
                }
                this.Close();
            }

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text=="") textBox2.BackColor = Color.MistyRose;
            else textBox2.BackColor = Color.LimeGreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                if (ts.name == textBox1.Text)
                {
                    textBox1.BackColor = Color.LimeGreen;
                    return;
                }
            }
            textBox1.BackColor = Color.MistyRose;
            return;
        }
    }
}
