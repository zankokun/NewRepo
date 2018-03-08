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
    public partial class Form5 : Form
    {
        public TimeSlot begin=null;
        public TimeSlot end = null;
        public bool toDelete=false;
        public bool closed = false;
        public Form5()
        {
            InitializeComponent();
            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                comboBox1.Items.Add(ts.name);
                comboBox2.Items.Add(ts.name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //foreach (TimeSlot ts in Singleton.getInstance().GetState())
            //{
            //    if (comboBox1.Text == ts.name)
            //        begin = ts;
            //    if (comboBox2.Text == ts.name)
            //        end = ts;
            //}
            toDelete = checkBox1.Checked;
            closed = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void update_cmbxs()
        {
            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                if (comboBox1.Text == ts.name)
                    begin = ts;
                if (comboBox2.Text == ts.name)
                    end = ts;
            }
            if ((begin != null && end != null)&&(begin.graph != end.graph))
            {
                comboBox1.BackColor = Color.MistyRose;
                comboBox2.BackColor = Color.MistyRose;
            }
            else
            {
                comboBox1.BackColor = Color.LimeGreen;
                comboBox2.BackColor = Color.LimeGreen;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_cmbxs();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            update_cmbxs();

        }
    }
}
