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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                textBox1.Items.Add(ts.name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Tuple<TimeSlot, TimeSlot, int>> todel = new List<Tuple<TimeSlot, TimeSlot, int>>();
            foreach (var arr in Singleton.getInstance().GetArrows())
                if (arr.Item1.name == textBox1.Text|| arr.Item2.name == textBox1.Text)
                {
                    todel.Add(arr);
                }
            foreach (var arr in todel)
                Singleton.getInstance().GetArrows().Remove(arr);

            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                if (ts.name == textBox1.Text)
                {
                    Singleton.getInstance().GetState().Remove(ts);
                    if (ts.prev != null)
                    {
                        ts.prev.next = ts.next;
                        if (ts.next != null)
                        {
                            ts.next.prev = ts.prev;
                        }
                    }

                    if (ts.next != null)
                    {
                        ts.next.prev = ts.prev;
                        if (ts.prev != null)
                            ts.prev.next = ts.next;
                    }

                    break;
                }
            }
            this.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
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
