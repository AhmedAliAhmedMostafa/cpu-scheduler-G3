using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign
{
    public partial class Gant_chart : Form
    {

        public Gant_chart()
        {
            InitializeComponent();
        }
        public Point Draw_Gant(Graphics g,Point location ,int width,string main_data,string start_data,string end_data)
        {   /////////////////graphics variable////////////////////////////////////
            Pen p_time = new Pen(Color.Black, 5);
            Brush b_time = new SolidBrush(Color.Gray);
            Brush b_process = new SolidBrush(Color.Blue);
            Font f_time = new Font("Ariall", 8, FontStyle.Regular, GraphicsUnit.Point);
            Font f_process = new Font("Ariall", 10, FontStyle.Underline, GraphicsUnit.Point);
            Font f_idle = new Font("Ariall", 8, FontStyle.Bold, GraphicsUnit.Point);
            ////////////////////////////////////////////////////////////////
            int x_coordinate=location.X;
            int y_coordinate = location.Y;
            int go_down=30;
            int partial_width;
            int height = 10;
            int height_t=7;
            int num_end_digits = (end_data.ToString()).Length;
            bool flag = false;
            do
            {
                if (x_coordinate >= 415 && x_coordinate <= 422)
                {
                    x_coordinate = 0;
                    y_coordinate += go_down;
                }
                if (x_coordinate + width > 422)
                {
                    partial_width = 422 - x_coordinate;
                    width -= partial_width;
                }
                else
                {
                    partial_width = width;
                    width = 0;

                }
            
                Rectangle r_p = new Rectangle(x_coordinate,y_coordinate,partial_width,height);
                Rectangle r_t = new Rectangle(x_coordinate,y_coordinate+height,partial_width,height_t);
                Point p_main_data = new Point((x_coordinate + partial_width / 2)-4, y_coordinate + height / 2);
                Point P_start_data=new Point(x_coordinate + 1, y_coordinate + height + 1);
                Point P_end_data = new Point(x_coordinate + partial_width - 3 * num_end_digits, y_coordinate + height + 1);
                g.DrawRectangle(Pens.Blue,r_p);
                g.DrawRectangle(Pens.Gray, r_t);
                g.DrawString(main_data, f_idle, new SolidBrush(Color.Black), p_main_data);
                if (!flag)
                {
                    g.DrawString(start_data, f_time, new SolidBrush(Color.Black), P_start_data);
                }
                if (width == 0)
                {
                    g.DrawString(end_data, f_time, new SolidBrush(Color.Black), P_end_data);
                    x_coordinate += partial_width;
                }
                else if(width!=0)
                {
                    y_coordinate += go_down;
                    x_coordinate = 0;
                    flag = true;
                }
            } 
            while (width != 0);
            Point r_pnt = new Point(x_coordinate, y_coordinate);
            return r_pnt;
          

        }

        private void Gant_chart_Paint(object sender, PaintEventArgs e)
        {


            //this.Invalidate();
            int clk = 0;
            int next, hold;
            //some graphics objects
            Pen p_time = new Pen(Color.Black, 5);
            Brush b_time = new SolidBrush(Color.Gray);
            Brush b_process = new SolidBrush(Color.Blue);
            Font f_time = new Font("Ariall", 8, FontStyle.Regular, GraphicsUnit.Point);
            Font f_process = new Font("Ariall", 10, FontStyle.Underline, GraphicsUnit.Point);
            Font f_idle=new Font("Ariall", 8, FontStyle.Bold, GraphicsUnit.Point);
            ///////////////////////////////////////////////////////
            //////////////////////////////////////////////////
            Point location =new Point(0,0);
            int x = 0;
            int y = 0;
            int hight = 10;
            int hight_2 = 7;
            int wdth;
            int window_width = this.Size.Width;
            int start;
            int end = 0;
            int num_end_digits;
            int stretch = 15;
            int first;
            string text="";
            /////////////////////////////////////////
            //////////////////////
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;
            this.Size = new Size(5000, 1000);

            ///////////////////////////
            List<int> bursts_copy = new List<int>();
            List<int> arrival_copy = new List<int>();
            List<int> Dep_time = new List<int>();

            /////////////////////////////
            if (Form1.choice == "FCFS")
            {
                //int accumulator = 0;
                // MessageBox.Show(u.ToString()); 


                try
                {
                    for (int f = 0; f < Form1.U; f++)
                    {
                        Dep_time.Add(0);
                    }


                    for (int i = 0; i < Form1.U; i++)
                    {

                        int min = Form1.arrival_copy.IndexOf(Form1.arrival_copy.Min());
                        Form1.fcfs.Add(min + 1);
                        Form1.arrival_copy.RemoveAt(min);
                        Form1.arrival_copy.Insert(min, 1000000);


                    }

                    for (int f = 0; f < Form1.U; f++)
                    {
                        Form1.arrival_copy[f] = Form1.arrival_entries[f];
                    }
                    //Label lll1 = new Label();
                    //lll1.Text = accumulator.ToString();
                    //flowLayoutPanel5.Controls.Add(lll1);
                    //g.DrawRectangle(Pens.Red, 0, 0, 1000, 1000);

                    for (int i = 0; i < Form1.U; i++)
                    {
                        if (Form1.arrival_entries[Form1.fcfs[i] - 1] > end)
                        {
                            start = end;
                            end = Form1.arrival_entries[Form1.fcfs[i] - 1];
                            wdth = (end - start) * stretch;
                            text = "IDLE";
                            location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                            i--;
                        }
                        else
                        {
                            start = end;
                            wdth=Form1.bursts_entries[Form1.fcfs[i] - 1] * stretch;
                            end = start + wdth/stretch;
                            text = "P" + Form1.fcfs[i].ToString();
                            location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                            Dep_time[Form1.fcfs[i]-1] = end;

                        }
                    }
                    double total = Dep_time.Sum() - Form1.arrival_entries.Sum() - Form1.bursts_entries.Sum();
                    double avg = total / Form1.U;
                    label1.Text = "Average Waiting time is : " + avg.ToString();


                    //Form1.arrival_entries.Clear();
                    //Form1.bursts_entries.Clear();
                    Form1.fcfs.Clear();




                }

                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("YOU LEFT SOMETHING BLANK");
                }

                ;

            }
            else if (Form1.choice == "Pirority")
            {
                if (Form1.sub_choice == "Non Preemptive")
                {
                    try
                    {
                        for (int f = 0; f < Form1.U; f++)
                        {
                            Dep_time.Add(0);
                        }

                        for (int i = 0; i < Form1.U; i++)
                        {

                            int min = Form1.arrival_copy.IndexOf(Form1.arrival_copy.Min());
                            Form1.fcfs.Add(min);
                            Form1.arrival_copy.RemoveAt(min);
                            Form1.arrival_copy.Insert(min, 1000000);
                        }
                        for (int f = 0; f < Form1.U; f++)
                        {
                            Form1.arrival_copy[f] = Form1.arrival_entries[f];
                        }
                                  
                        for (int j = 0; j < Form1.U; j++)
                        {
                            if (clk < Form1.arrival_entries[Form1.fcfs[0]])
                            {
                                wdth = (Form1.arrival_entries[Form1.fcfs[0]] - clk)*stretch;
                                start = clk;
                                end = clk + wdth / stretch;
                                text = "IDLE";
                                location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                                clk = Form1.arrival_entries[Form1.fcfs[0]];
                            }
                            next = Form1.fcfs[0];
                            hold = 0;
                            for (int k = 1; k < (Form1.U - j); k++)
                            {
                                if (Form1.arrival_entries[Form1.fcfs[k]] <= clk && (Form1.pirority_entries[Form1.fcfs[k]] < Form1.pirority_entries[next]))
                                {
                                    next = Form1.fcfs[k];
                                    hold = k;
                                }
                            }
                            start = clk;
                            wdth = Form1.bursts_entries[next] * stretch;
                            end = start + (wdth / stretch);
                            text = "P" + (next + 1).ToString();
                            Dep_time[next] = end;
                            location=Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                            clk += Form1.bursts_entries[next];
                            Form1.fcfs.RemoveAt(hold);

                        }
                        double total = Dep_time.Sum() - Form1.arrival_entries.Sum() - Form1.bursts_entries.Sum();
                        double avg = total / Form1.U;
                        label1.Text = "Average Waiting time is : " + avg.ToString();

                        Form1.fcfs.Clear();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("YOU LEFT SOMETHING BLANK");
                        this.Close();
                    }
                }
                else if (Form1.sub_choice == "Preemptive")
                {

                    try
                    {
                        for (int f = 0; f < Form1.U; f++)
                        {
                            Dep_time.Add(0);
                        }
                        int turn;
                        int no = Form1.U;
                        int unit = 10;
                        string data = "";
                        int previous = -1;
                        start = 0;
                        wdth = 0;
                        bool idle = false;
                        for (int t = 0; t < Form1.U; t++)
                        {
                            bursts_copy.Add(Form1.bursts_entries[t]);
                        }
                        for (int i = 0; i < Form1.U; i++)
                        {

                            int min = Form1.arrival_copy.IndexOf(Form1.arrival_copy.Min());
                            Form1.fcfs.Add(min);
                            Form1.arrival_copy.RemoveAt(min);
                            Form1.arrival_copy.Insert(min, 1000000);
                        }
                        for (int f = 0; f < Form1.U; f++)
                        {
                            Form1.arrival_copy[f] = Form1.arrival_entries[f];
                        }
                        for (int timer = 0; timer >= 0; timer++)
                        {

                            if (timer < Form1.arrival_entries[Form1.fcfs[0]])
                            {
                                if (previous != -1)
                                {
                                    location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                                }
                                start = timer;
                                wdth = (Form1.arrival_entries[Form1.fcfs[0]] - start) * stretch;
                                end = start + wdth / stretch;
                                text = "IDLE";
                                idle = true;
                                timer = Form1.arrival_entries[Form1.fcfs[0]];
                            }
                            turn = Form1.fcfs[0];
                            for (int i = 0; i < no; i++)
                            {
                                if (Form1.arrival_entries[Form1.fcfs[i]] <= timer && Form1.pirority_entries[Form1.fcfs[i]] < Form1.pirority_entries[turn])
                                {
                                    turn = Form1.fcfs[i];
                                }
                            }

                            if (bursts_copy[turn] != 0)
                            {
                                bursts_copy[turn]--;
                                if (previous != turn)
                                {

                                    if (previous != -1||idle)
                                    {
                                        location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                                        idle = false;
                                    }                               
                                    text = "P" + (turn + 1).ToString();
                                    previous = turn;
                                    start = timer;
                                    end = start + 1;
                                    wdth = unit;

                                    

                                }
                                else
                                {
                                    wdth += unit;
                                    end++;
                                }


                            }

                            else
                            {
                                Form1.fcfs.Remove(turn);
                                Dep_time[turn] = end; ;
                                no--;
                                timer--;
                                if (no == 0)
                                {

                                    location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                                    break;
                                }
                            }
                        }
                        Form1.fcfs.Clear();
                        bursts_copy.Clear();
                        double total = Dep_time.Sum() - Form1.arrival_entries.Sum() - Form1.bursts_entries.Sum();
                        double avg = total / Form1.U;
                        label1.Text = "Average Waiting time is : " + avg.ToString();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("YOU LEFT SOMETHING BLANK");
                        this.Close();
                    }
                }
            }
            else if (Form1.choice == "SJF")
            {

                if (Form1.sub_choice == "Non Preemptive")
                {
                    try
                    {
                        for (int f = 0; f < Form1.U; f++)
                        {
                            Dep_time.Add(0);
                        }
                        for (int i = 0; i < Form1.U; i++)
                        {

                            int min = Form1.arrival_copy.IndexOf(Form1.arrival_copy.Min());
                            Form1.fcfs.Add(min);
                            Form1.arrival_copy.RemoveAt(min);
                            Form1.arrival_copy.Insert(min, 1000000);
                        }
                        for (int f = 0; f < Form1.U; f++)
                        {
                            Form1.arrival_copy[f] = Form1.arrival_entries[f];
                        }

                        for (int j = 0; j < Form1.U; j++)
                        {
                            if (clk < Form1.arrival_entries[Form1.fcfs[0]])
                            {
                                wdth = (Form1.arrival_entries[Form1.fcfs[0]] - clk) * stretch;
                                start = clk;
                                end = clk + wdth / stretch;
                                text = "IDLE";
                                location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                                clk = Form1.arrival_entries[Form1.fcfs[0]];
                            }
                            next = Form1.fcfs[0];
                            hold = 0;
                            for (int k = 1; k < (Form1.U - j); k++)
                            {
                                if (Form1.arrival_entries[Form1.fcfs[k]] <= clk && (Form1.bursts_entries[Form1.fcfs[k]] < Form1.bursts_entries[next]))
                                {
                                    next = Form1.fcfs[k];
                                    hold = k;
                                }
                            }
                            start = clk;
                            wdth = Form1.bursts_entries[next] * stretch;
                            end = start + (wdth / stretch);
                            text = "P" + (next + 1).ToString();
                            Dep_time[next] = end;
                            location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                            clk += Form1.bursts_entries[next];
                            Form1.fcfs.RemoveAt(hold);

                        }
                        double total = Dep_time.Sum() - Form1.arrival_entries.Sum() - Form1.bursts_entries.Sum();
                        double avg = total / Form1.U;
                        label1.Text = "Average Waiting time is : " + avg.ToString();
                        Form1.fcfs.Clear();
                    }

                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("YOU LEFT SOMETHING BLANK");
                        this.Close();
                    }
                }
                else if (Form1.sub_choice == "Preemptive")
                {

                    try
                    {
                        for (int f = 0; f < Form1.U; f++)
                        {
                            Dep_time.Add(0);
                        }
                        int turn;
                        int no = Form1.U;
                        int unit = 10;
                        int previous = -1;
                        start = 0;
                        wdth = 0;
                        bool idle = false;
                        //Label test = new Label();
                        //test.Text = total_time.ToString();
                        //flowLayoutPanel4.Controls.Add(test);
                        //Button b1 = new Button();
                        //Label l1 = new Label();

                        for (int t = 0; t < Form1.U; t++)
                        {
                            bursts_copy.Add(Form1.bursts_entries[t]);
                        }
                        for (int i = 0; i < Form1.U; i++)
                        {

                            int min = Form1.arrival_copy.IndexOf(Form1.arrival_copy.Min());
                            Form1.fcfs.Add(min);
                            Form1.arrival_copy.RemoveAt(min);
                            Form1.arrival_copy.Insert(min, 1000000);
                        }
                        for (int f = 0; f < Form1.U; f++)
                        {
                            Form1.arrival_copy[f] = Form1.arrival_entries[f];
                        }
                        //for (int f = 0; f < Form1.U; f++)
                        //{
                        //    Form1.arrival_copy[f] = Form1.arrival_entries[f];
                        //}
                        for (int timer = 0; timer >= 0; timer++)
                        {


                            if (timer < Form1.arrival_entries[Form1.fcfs[0]])
                            {
                                if (previous != -1)
                                {
                                    location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                                }
                                start = timer;
                                wdth = (Form1.arrival_entries[Form1.fcfs[0]] - start) * stretch;
                                end = start + wdth / stretch;
                                text = "IDLE";
                                idle = true;
                                timer = Form1.arrival_entries[Form1.fcfs[0]];
                            }
                            turn = Form1.fcfs[0];

                            for (int i = 0; i < no; i++)
                            {
                                if (Form1.arrival_entries[Form1.fcfs[i]] <= timer && bursts_copy[Form1.fcfs[i]] < bursts_copy[turn])
                                {
                                    turn = Form1.fcfs[i];
                                }
                            }

                            if (bursts_copy[turn] != 0)
                            {
                                bursts_copy[turn]--;
                                if (previous != turn)
                                {

                                    if (previous != -1 || idle)
                                    {
                                        location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                                        idle = false;
                                    }  
                                    text= "P" + (turn + 1).ToString();
                                    previous = turn;
                                    start = timer;
                                    end = start + 1;
                                    wdth = unit;

                                }
                                else
                                {
                                    wdth += unit;
                                    end++;
                                }


                            }

                            else
                            {
                                Form1.fcfs.Remove(turn);
                                no--;
                                timer--;
                                Dep_time[turn] = end;
                                if (no == 0)
                                {

                                    location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                                    break;
                                }
                            }
                        }
                        double total = Dep_time.Sum() - Form1.arrival_entries.Sum() - Form1.bursts_entries.Sum();
                        double avg = total / Form1.U;
                        label1.Text = "Average Waiting time is : " + avg.ToString();
                        Form1.fcfs.Clear();
                        bursts_copy.Clear();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageBox.Show("YOU LEFT SOMETHING BLANK");
                        this.Close();
                    }
                }




            }
            else if (Form1.choice == "RoundRobin")
            {
                
                try
                {
                    string data;
                    for (int t = 0; t < Form1.U; t++)
                    {
                        bursts_copy.Add(Form1.bursts_entries[t]);
                    }
                    for (int t = 0; t < Form1.U; t++)
                    {
                        arrival_copy.Add(Form1.arrival_entries[t]);
                    }
                    for (int i = 0; i < Form1.U; i++)
                    {

                        int min = Form1.arrival_copy.IndexOf(Form1.arrival_copy.Min());
                        Form1.fcfs.Add(min);
                        Form1.arrival_copy.RemoveAt(min);
                        Form1.arrival_copy.Insert(min, 1000000);
                    }
                    for (int f = 0; f < Form1.U; f++)
                    {
                        Form1.arrival_copy[f] = Form1.arrival_entries[f];
                    }
                    for (int f = 0; f < Form1.U; f++)
                    {
                        Dep_time.Add(0);
                    }
                    next=Form1.fcfs[0];
                    first = Form1.arrival_entries[Form1.fcfs[0]];
                    while (true)
                    {

                        if (clk < first)
                        {
                            start = clk;
                            wdth = (first - clk) * stretch;
                            end = start + wdth / stretch;
                            text = "IDLE";
                            location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                            clk = first;
                        }
                        start=clk;
                        for (int i = 0; i < Form1.U; i++)
                        {
                            if (Form1.arrival_entries[Form1.fcfs[i]] <= clk)
                            {
                                next = Form1.fcfs[i];
                                break;
                            }
                        }
                        if (bursts_copy[next] < Form1.Q)
                        {
                            wdth = bursts_copy[next] * stretch;
                            end = start + bursts_copy[next];
                            clk += bursts_copy[next];
                            bursts_copy[next] = 0;
                           
                        }
                        else
                        {
                            wdth = Form1.Q * stretch;
                            end=start+Form1.Q;
                            clk += Form1.Q;
                            bursts_copy[next] -= Form1.Q;
                        }
                        Form1.fcfs.Remove(next);
                        if (bursts_copy[next] != 0)
                        {
                            Form1.fcfs.Add(next);
                        }
                        else
                        {
                            Dep_time[next] = end;
                            if (Form1.fcfs.Count != 0)
                            {
                                first = Form1.arrival_entries[Form1.fcfs[0]];
                                for (int i = 1; i < Form1.fcfs.Count; i++)
                                {
                                    if (Form1.arrival_entries[Form1.fcfs[i]] < first)
                                        first = Form1.arrival_entries[Form1.fcfs[i]] ;
                                }

                            }
                            
                        }

                       
                        text= "p"+(next + 1).ToString();
                        location = Draw_Gant(g, location, wdth, text, start.ToString(), end.ToString());
                        if (Form1.fcfs.Count == 0)
                        {
                            break;
                        }


                    }
                    double total = Dep_time.Sum() - Form1.arrival_entries.Sum() - Form1.bursts_entries.Sum();
                    double avg = total / Form1.U;
                    label1.Text = "Average Waiting time is : " + avg.ToString();
                    Form1.fcfs.Clear();
                    bursts_copy.Clear();
                    arrival_copy.Clear();
                   
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("YOU LEFT SOMETHING BLANK");
                    this.Close();
                }
            }






        }

        private void Gant_chart_Click(object sender, EventArgs e)
        {


        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Form1.arrival_entries.Clear();
            Form1.bursts_entries.Clear();
            Form1.fcfs.Clear();
            Form1.arrival_copy.Clear();
            Form1.pirority_entries.Clear();
            Form1.sjfnpBURST.Clear();
            this.Close();
           
        }

        private void Gant_chart_Load(object sender, EventArgs e)
        {

        }

        private void Gant_chart_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.arrival_entries.Clear();
            Form1.bursts_entries.Clear();
            Form1.fcfs.Clear();
            Form1.arrival_copy.Clear();
            Form1.pirority_entries.Clear();

            Form1.sjfnpBURST.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
