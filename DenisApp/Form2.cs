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
    public partial class Form2 : Form
    {
        private int zoom = 7;
        public Form2()
        {
            InitializeComponent();
            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                ts_prev.Items.Add(ts.name);
                ts_name.Items.Add(ts.name);
            }
            colorDialog1.Color = Color.White;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label5.BackColor = Color.White;
        }

        private TimeSlot get_prev()
        {
            foreach ( TimeSlot ts in Singleton.getInstance().GetState())
            {
                if (ts.name == ts_prev.Text)
                    return ts;
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                if (ts.name == ts_name.Text)
                {
                    ts.state = Int32.Parse(ts_state.Text);
                    ts.time = Int32.Parse(ts_length.Text)*zoom;
                    ts.graph = Int32.Parse(ts_graph.Text);
                    ts.color = colorDialog1.Color;
                    Singleton.getInstance().UpdateBounds();
                    this.Close();
                    return;
                }

            }
            Singleton.getInstance().AddTS(new TimeSlot(ts_name.Text, Int32.Parse(ts_length.Text)*zoom,Int32.Parse(ts_state.Text), Int32.Parse(ts_graph.Text), get_prev(), checkBox1.Checked , colorDialog1.Color ));
            this.Close();
        }

        private void ts_prev_TextChanged(object sender, EventArgs e)
        {
            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                if (ts.name == ts_prev.Text)
                {
                    ts_prev.BackColor = Color.LimeGreen;
                    return;
                }
            }
            ts_prev.BackColor = Color.MistyRose;
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            label5.BackColor = colorDialog1.Color;
        }

        private void ts_name_TextChanged_1(object sender, EventArgs e)
        {
            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                if (ts.name == ts_name.Text)
                {
                    ts_graph.Text = ts.graph.ToString();
                    ts_length.Text = ((int)(ts.time / zoom)).ToString();
                    if (ts.prev != null)
                        ts_prev.Text = ts.prev.name;
                    label5.BackColor = ts.color;
                    colorDialog1.Color = ts.color;
                    ts_state.Text = ts.state.ToString();
                    ts_name.BackColor = Color.LimeGreen;
                    return;
                }
            }
            ts_name.BackColor = Color.White;
        }
        
    }
}
