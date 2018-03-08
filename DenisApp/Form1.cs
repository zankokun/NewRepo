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

namespace DenisApp
{
    public partial class Form1 : Form
    {
        private int zoom=7;
        private int padding_lr = 100;

        public Form1()
        {
            InitializeComponent();
            Singleton.getInstance().fh = Int32.Parse(textBox1.Text);
            Color color = Color.White;
            update_picture_box();
        }

        private void update_picture_box()
        {
            int pre_width =  Singleton.getInstance().right + padding_lr;
            int width = pre_width > 600 ? pre_width: 600;  
            int height = Singleton.getInstance().mh+3*Singleton.getInstance().fh;

            Bitmap myBitmap = new Bitmap( width, height);
            pictureBox1.Width = width;
            pictureBox1.Height = height;
            Graphics fig = Graphics.FromImage(myBitmap);

            Pen def = new Pen(Color.Black);
            Brush br = new SolidBrush( Color.Black);

            fig.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            //fig.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            fig.DrawLine(def, 0, Singleton.getInstance().fh, pictureBox1.Width, Singleton.getInstance().fh);
            fig.DrawLine(def, 0, 2* Singleton.getInstance().fh, pictureBox1.Width, 2* Singleton.getInstance().fh);
            fig.DrawLine(def, 0, 3* Singleton.getInstance().fh, pictureBox1.Width, 3* Singleton.getInstance().fh);
            fig.DrawLine(def, Singleton.getInstance().ord, 0, Singleton.getInstance().ord, pictureBox1.Height);
            fig.DrawString( " Прибытие", SystemFonts.DialogFont, br, Singleton.getInstance().ord, 5);
            foreach (TimeSlot ts in Singleton.getInstance().GetState())
            {
                Brush rec = new SolidBrush(ts.color);
                fig.DrawRectangle(def, ts.GetBeginX(), ts.GetBeginY(), ts.GetWidth(), ts.GetHeight());
                fig.FillRectangle(rec, ts.GetBeginX()+1, ts.GetBeginY()+1, ts.GetWidth()-1, ts.GetHeight()-1);
                fig.DrawString(ts.name+", "+((int)(Math.Abs(ts.time)/zoom)).ToString(), SystemFonts.DialogFont, br, new RectangleF(ts.GetBeginX(), ts.GetBeginY(), ts.GetWidth(), ts.GetHeight()));
                
            }
            //summ

            
            foreach( var arr in Singleton.getInstance().GetArrows()  )
            {
                int arr_pad = 70+arr.Item3;
                int y0 = Singleton.getInstance().fh;
                fig.DrawLine(def, arr.Item1.GetBeginX(), y0*arr.Item1.graph , arr.Item1.GetBeginX() , y0 * arr.Item1.graph + arr_pad);
                fig.DrawLine(def, arr.Item2.GetWidth()+ arr.Item2.GetBeginX(), y0 * arr.Item2.graph, arr.Item2.GetWidth() + arr.Item2.GetBeginX(), y0 * arr.Item2.graph + arr_pad);
                fig.DrawLine(def, arr.Item1.GetBeginX(), y0 * arr.Item1.graph + arr_pad, arr.Item2.GetWidth() + arr.Item2.GetBeginX(), y0 * arr.Item2.graph + arr_pad);

                fig.DrawLine(def, arr.Item1.GetBeginX(), y0 * arr.Item1.graph + arr_pad, arr.Item1.GetBeginX()+5, y0 * arr.Item1.graph + arr_pad+5);
                fig.DrawLine(def, arr.Item1.GetBeginX(), y0 * arr.Item1.graph + arr_pad, arr.Item1.GetBeginX() + 5, y0 * arr.Item1.graph + arr_pad -5);

                fig.DrawLine(def, arr.Item2.GetWidth() + arr.Item2.GetBeginX(), y0 * arr.Item2.graph + arr_pad, arr.Item2.GetWidth() + arr.Item2.GetBeginX() - 5, y0 * arr.Item2.graph + arr_pad - 5);
                fig.DrawLine(def, arr.Item2.GetWidth() + arr.Item2.GetBeginX(), y0 * arr.Item2.graph + arr_pad, arr.Item2.GetWidth() + arr.Item2.GetBeginX() - 5, y0 * arr.Item2.graph + arr_pad + 5);

                fig.DrawString(((arr.Item2.GetBeginX()+ arr.Item2.GetWidth() - arr.Item1.GetBeginX())/zoom).ToString(), SystemFonts.DialogFont, br, new PointF( (arr.Item2.GetBeginX()+arr.Item2.GetWidth() + arr.Item1.GetBeginX()) /2 ,y0 * arr.Item2.graph + arr_pad ));

            }
            int label_shist = 20;
            fig.DrawString("=", SystemFonts.MessageBoxFont, br, new PointF(Singleton.getInstance().ord- label_shist, Singleton.getInstance().fh*0));
            fig.DrawString("~", SystemFonts.MessageBoxFont, br, new PointF(Singleton.getInstance().ord- label_shist, Singleton.getInstance().fh * 1));
            fig.DrawString("=~", SystemFonts.MessageBoxFont, br, new PointF(Singleton.getInstance().ord- label_shist, Singleton.getInstance().fh * 2));
            hScrollBar1.Maximum = pictureBox1.Width;
            pictureBox1.Image = myBitmap;
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            update_picture_box();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
            update_picture_box();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int delta = e.NewValue - e.OldValue;
            pictureBox1.Left -= delta*10;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() != DialogResult.OK)
                return;
            else
            {
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(open.FileName);
                    Singleton.getInstance().fh = Int32.Parse(sr.ReadLine());
                    int tss  = Int32.Parse( sr.ReadLine());
                    Singleton.getInstance().ord = Int32.Parse(sr.ReadLine());
                    Singleton.getInstance().GetState().Clear();
                    for (int i =0;i<tss;++i)
                    {
                        string str = sr.ReadLine();
                        string[] vals = str.Split('|');
                        ColorConverter colorConverter = new ColorConverter();
                        colorConverter.ConvertToString(Color.AliceBlue);
                        TimeSlot prev = null;
                        foreach (var ts in Singleton.getInstance().GetState())
                        {
                            if (ts.name == vals[6])
                            {
                                prev = ts;
                                break;
                            }
                        }
                        bool ch = false;
                        if(vals[4]=="True")
                        { ch = true; }
                        Singleton.getInstance().AddTS(new TimeSlot(vals[0], Int32.Parse(vals[1]), Int32.Parse(vals[2]), Int32.Parse(vals[3]),prev, ch, (Color)(colorConverter.ConvertFromString(vals[5])) ));
                    }
                    //Continue to read until you reach end of file
                    Singleton.getInstance().GetArrows().Clear();
                    tss = Int32.Parse(sr.ReadLine());
                    for (int i = 0; i < tss; ++i)
                    {
                        string str = sr.ReadLine();
                        string[] vals = str.Split('|');
                        TimeSlot begin =null,  end= null;
                        foreach (var ts in Singleton.getInstance().GetState())
                        {
                            if (ts.name == vals[0])
                            {
                                begin = ts;
                            }
                            if (ts.name == vals[1])
                            {
                                end = ts;
                            }
                        }
                        Singleton.getInstance().GetArrows().Add(new Tuple<TimeSlot, TimeSlot, int>(begin,end,Int32.Parse(vals[2])));
                    }

                    //close the file
                    sr.Close();
                    update_picture_box();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Exception: " + e1.Message);
                }
            }
        }
        
        private void save(bool recovery)
        {
            if (Singleton.getInstance().GetState().Count() == 0)
            {
                if (!recovery)
                    MessageBox.Show("Нет данных для сохранения");
                return;
            }
            string file;
            if (recovery)
                file = "D:\\recovery";
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() != DialogResult.OK)
                    return;
                else
                    file = save.FileName;
            }
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(file);

                //Write a line of text
                ColorConverter colorConverter = new ColorConverter();
                sw.WriteLine(Singleton.getInstance().fh);
                sw.WriteLine(Singleton.getInstance().GetState().Count());
                sw.WriteLine(Singleton.getInstance().ord);
                foreach (TimeSlot ts in Singleton.getInstance().GetState())
                {
                    string prev_name = ts.prev != null ? ts.prev.name : "null";
                    string str = ts.name + "|" + ts.time.ToString() + "|" + ts.state.ToString() + "|" + ts.graph.ToString() + "|" + ts.affect.ToString() + "|" + colorConverter.ConvertToString(ts.color) + "|" + prev_name;
                    sw.WriteLine(str);
                }
                sw.WriteLine(Singleton.getInstance().GetArrows().Count);
                foreach (var arr in Singleton.getInstance().GetArrows())
                {
                    string str = arr.Item1.name + "|" + arr.Item2.name + "|" + arr.Item3.ToString();
                    sw.WriteLine(str);
                }
                //Close the file
                sw.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Exception: " + e1.Message);
            }

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save(true);
            Application.Exit();
        }

        private void переименоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
            update_picture_box();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                int k = Int32.Parse(textBox1.Text);
                if (k >= 50)
                {
                    Singleton.getInstance().fh = k;
                    update_picture_box();
                }
                else
                    MessageBox.Show("Введите значение большее 50 !");
            }
            catch
            {
                MessageBox.Show("Введите число!");
            }
        }

        private void суммарноеВремяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.ShowDialog();
            
            if (form.closed == false) return;
            if (!form.toDelete)
                if (form.begin != null && form.end != null)
                {
                    int div = 0;
                    foreach (var arr in Singleton.getInstance().GetArrows())
                        if (arr.Item1 == form.begin|| arr.Item1==form.end|| arr.Item2 == form.begin || arr.Item2== form.end)
                        {
                            if (div < arr.Item3)
                                div = arr.Item3;
                        }
                    Singleton.getInstance().GetArrows().Add( new Tuple<TimeSlot, TimeSlot, int> (form.begin, form.end, div+15));

                }
                else { }
            else
            if (form.begin != null)

                    foreach (var arr in Singleton.getInstance().GetArrows())
                        if (arr.Item1 == form.begin)
                        {
                            Singleton.getInstance().GetArrows().Remove(arr);
                            break;
                        }
            update_picture_box();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            save(true);
        }
    }

    public class TimeSlot
    {
        public int time { get; set; }
        public int state { get; set; }
        public TimeSlot prev { get; set; }
        public TimeSlot next { get; set; }
        public int graph { get; set; }
        public string name { get; set; }
        public bool affect { get; set; }
        public Color color { get; set; }

        public TimeSlot(string name, int time, int state, int graph, TimeSlot prev, bool affect, Color color)
        {
            this.name = name;
            this.time = time;
            this.state = state;
            this.graph = graph;
            this.prev = prev;
            this.next = null;
            this.affect = affect;
            this.color = color;

        }
        public int GetHeight()
        {
            if (state > 0)
                return state;
            else
                return -state;
        }
        public int GetBeginY()
        {
            if (state > 0)
                return graph * Singleton.getInstance().fh - state;
            else
                return graph * Singleton.getInstance().fh;
        }
        public int GetWidth()
        {
            return Math.Abs(time);
        }
        public int GetBeginX()
        {
            if (prev == null)
                if (time > 0)
                    return Singleton.getInstance().ord;
                else
                    return Singleton.getInstance().ord+  time;
            
            else
                if (time>0)
                    return prev.GetBeginX() + prev.GetWidth();
                else
                    return prev.GetBeginX() + time;
        }
        public void Draw()
        {

        }
    }

    class Singleton
    {
        private static Singleton instance;
        private List<TimeSlot> time_slots;
        private List<Tuple<TimeSlot, TimeSlot, int>> arrows;
        public int right;
        public int left;
        public int mh;
        public int fh;
        public int ord;
        private Singleton()
        {
            ord = 300;
            time_slots = new List<TimeSlot>();
            arrows = new List<Tuple<TimeSlot, TimeSlot, int>>();
            right = 0;
            left = 0;
            mh = 0;
        }

        public void AddTS(TimeSlot ts)
        {
            time_slots.Add(ts);
            if (ts.prev != null)
                if (ts.prev.next != null)
                {
                    if (ts.affect == false)
                    {
                        ts.next = ts.prev.next;
                        ts.next.prev = ts;
                        ts.prev.next = ts;
                    }
                }
                else
                {
                    ts.prev.next = ts;
                }
            UpdateBounds();
            
        }
        public void UpdateBounds()
        {
            foreach (var ts in time_slots)
            {
                int temp = ts.GetBeginX() + ts.GetWidth();
                if (temp > right)
                    right = temp;
                temp = ts.GetBeginX();
                if (temp < left)
                    left = temp;
                if (Math.Abs(ts.state) > mh)
                    mh = Math.Abs(ts.state);
            }
        }
        public int GetWidth()
        {
            return right;
        }
        public List<TimeSlot> GetState()
        {
            return time_slots;
        }
        public List<Tuple<TimeSlot, TimeSlot, int>> GetArrows()
        {
            return arrows;
        }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
}
