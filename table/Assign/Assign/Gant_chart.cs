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

        private void Gant_chart_Paint(object sender, PaintEventArgs e)
        {
            
            
            //this.Invalidate();
            int clk = 0;
            int next, hold;
            //some graphics objects
            Pen p_time = new Pen(Color.Black, 5);
            Brush b_time = new SolidBrush(Color.Gray);
            Brush b_process = new SolidBrush(Color.Blue);
            Font f_time = new Font("Ariall", 8, FontStyle.Bold, GraphicsUnit.Point);
            Font f_process = new Font("Ariall", 10, FontStyle.Underline, GraphicsUnit.Point);
            ///////////////////////////////////////////////////////
            //////////////////////////////////////////////////
            int x = 0;
            int y = 0;
            int hight = 10;
            int hight_2 = 7;
            int wdth;
            int window_width = this.Size.Width;
            int start ;
            int end=0;
            int num_end_digits;
            
                    /////////////////////////////////////////
            //////////////////////
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;
            this.Size = new Size(5000,1000);
          ;
            ///////////////////////////
           List<int> bursts_copy = new List<int>();

            /////////////////////////////
            if (Form1.choice == "FCFS")
            {
                int accumulator = 0;
                // MessageBox.Show(u.ToString()); 
                


                try
                {

                    

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
                        if (Form1.arrival_entries[Form1.fcfs[i] - 1] >= end)
                        {
                            start = Form1.arrival_entries[Form1.fcfs[i] - 1];
                        }
                        else
                        {
                            start = end;
                        }

                        wdth = Form1.bursts_entries[Form1.fcfs[i] - 1]*10 ;
                        end = start + (wdth / 10);
                        Rectangle r_p = new Rectangle();
                        r_p.X = x;
                        r_p.Y = y;
                        r_p.Width = wdth;
                        r_p.Height = hight;
                        Rectangle r_t = new Rectangle();
                        r_t.X = x;
                        r_t.Y = y+hight;
                        r_t.Width = wdth;
                        r_t.Height = hight_2;
                        num_end_digits = (end.ToString()).Length;
                        

                        g.DrawRectangle(Pens.Blue, r_p);
                        ////g.FillRectangle(b_process, x, y, 100 * Form1.bursts_entries[Form1.fcfs[i] - 1], 100 * hight);
                        Point s_process = new Point(x + wdth / 2, hight / 2);
                        g.DrawString("P" + Form1.fcfs[i].ToString(), f_process, new SolidBrush(Color.Black), s_process);
                        //g.FillRectangle(b_time, x, y + hight, 100 * Form1.bursts_entries[Form1.fcfs[i] - 1], 100);
                        g.DrawRectangle(Pens.Gray, r_t);
                        Point s_start = new Point(x+1, hight + 1);
                        Point s_end = new Point(x+wdth-3*num_end_digits, hight+1);
                        g.DrawString(start.ToString(), f_time, new SolidBrush(Color.Black), s_start);
                        g.DrawString(end.ToString(), f_time, new SolidBrush(Color.Black), s_end);
                        x = x + wdth;


                        //Button b1 = new Button();
                        //Label ll1 = new Label();
                        ////ll1.AutoSize = true;
                        ////b1.AutoSize = true; 
                        //b1.Margin = new Padding(4, 4, 4, 4);

                        ////ll1.Margin = new Padding(b1.Width/5, 4, b1.Width/5, 4);

                        //b1.Text = "P" + Form1.fcfs[i].ToString();
                        //accumulator += Form1.bursts_entries[Form1.fcfs[i] - 1];
                        //ll1.Text = accumulator.ToString();



                    }


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
                        //for (int l = 0; l < Form1.U; l++)
                        //{
                        //    Form1.arrival_copy.RemoveAt(0);
                        //}
                       
                     
                        for (int j = 0; j < Form1.U; j++)
                        {
                            if (clk < Form1.arrival_entries[Form1.fcfs[0]])
                                clk = Form1.arrival_entries[Form1.fcfs[0]];
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
                            wdth = Form1.bursts_entries[next] * 10;
                            end = start + (wdth / 10);
                            Rectangle r_p = new Rectangle();
                            r_p.X = x;
                            r_p.Y = y;
                            r_p.Width = wdth;
                            r_p.Height = hight;
                            Rectangle r_t = new Rectangle();
                            r_t.X = x;
                            r_t.Y = y + hight;
                            r_t.Width = wdth;
                            r_t.Height = hight_2;
                            num_end_digits = (end.ToString()).Length;
                            
                            g.DrawRectangle(Pens.Blue, r_p);
                            ////g.FillRectangle(b_process, x, y, 100 * Form1.bursts_entries[Form1.fcfs[i] - 1], 100 * hight);
                            Point s_process = new Point(x + wdth / 2, hight / 2);
                            g.DrawString("P" + (next+1).ToString(), f_process, new SolidBrush(Color.Black), s_process);
                            //g.FillRectangle(b_time, x, y + hight, 100 * Form1.bursts_entries[Form1.fcfs[i] - 1], 100);
                            g.DrawRectangle(Pens.Gray, r_t);
                            Point s_start = new Point(x + 1, hight + 1);
                            Point s_end = new Point(x + wdth - 3 * num_end_digits, hight + 1);
                            g.DrawString(start.ToString(), f_time, new SolidBrush(Color.Black), s_start);
                            g.DrawString(end.ToString(), f_time, new SolidBrush(Color.Black), s_end);

                            //Button b1 = new Button();
                            //Label ll1 = new Label();
                            //ll1.AutoSize = true;
                            //b1.AutoSize = true; 
                            //b1.Margin = new Padding(4, 4, 4, 4);

                            //ll1.Margin = new Padding(b1.Width/5, 4, b1.Width/5, 4);

                            //b1.Text = "P" + (next + 1).ToString();
                            
                            //ll1.Text = clk.ToString();
                            x = x + wdth;
                            clk += Form1.bursts_entries[next];
                            Form1.fcfs.RemoveAt(hold);

                        }
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
                        //int total_time = Form1.bursts_entries.Sum();
                        int turn;
                        int no = Form1.U;
                        int unit = 10;
                        string data = "";
                        int previous=-1;
                        start = 0;
                        wdth =0;
                        //Label test = new Label();
                        //test.Text = total_time.ToString();
                        //flowLayoutPanel4.Controls.Add(test);
                        //Button b1 = new Button();
                        //Label l1 = new Label();
                      
                        for (int t = 0; t < Form1.U; t++)
                        {
                            bursts_copy.Add( Form1.bursts_entries[t]);
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
                                       if (previous!=turn)
                                    {

                                        if (previous != -1)
                                        {
                                            Rectangle r_p = new Rectangle();
                                            r_p.X = x;
                                            r_p.Y = y;
                                            r_p.Width = wdth;
                                            r_p.Height = hight;
                                            g.DrawRectangle(Pens.Blue, r_p);
                                          
                                            Point s_process = new Point(x + wdth / 2, hight / 2);
                                            g.DrawString(data, f_process, new SolidBrush(Color.Black), s_process);
                                            Rectangle r_t = new Rectangle();
                                            r_t.X = x;
                                            r_t.Y = y + hight;
                                            r_t.Width = wdth;
                                            r_t.Height = hight_2;
                                            g.DrawRectangle(Pens.Gray,r_t);
                                            num_end_digits = (end.ToString()).Length;
                                            Point s_end = new Point(x + wdth - 3 * num_end_digits, hight + 1);
                                            Point s_start = new Point(x + 1, hight + 1);
                                            g.DrawString(start.ToString(), f_time, new SolidBrush(Color.Black), s_start);
                                            g.DrawString(end.ToString(), f_time, new SolidBrush(Color.Black), s_end);
                                            x = x + wdth;

                                        }
                                        //b1.Text = "P" + (turn + 1).ToString();
                                        data = "P" + (turn + 1).ToString();
                                        previous = turn;
                                        start = timer;
                                        end = start + 1;
                                        wdth = unit;

                                        //Rectangle r_p = new Rectangle(); 
                                        //r_p.Y = y;
                                        //r_p.Width = unit;
                                        //r_p.Height = hight;
                                        //g.DrawRectangle(Pens.Blue, r_p);
                                        //data = "p" + (turn + 1).ToString();
                                        //start = timer;
                                        //end = timer;



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
                                    if (no == 0)
                                    {
                                        Rectangle r_p = new Rectangle();
                                        r_p.X = x;
                                        r_p.Y = y;
                                        r_p.Width = wdth;
                                        r_p.Height = hight;
                                        g.DrawRectangle(Pens.Blue, r_p);
                                        Point s_process = new Point(x + wdth / 2, hight / 2);
                                        g.DrawString(data, f_process, new SolidBrush(Color.Black), s_process);
                                        /*time axis*/
                                        Rectangle r_t = new Rectangle();
                                        r_t.X = x;
                                        r_t.Y = y + hight;
                                        r_t.Width = wdth;
                                        r_t.Height = hight_2;
                                        g.DrawRectangle(Pens.Gray, r_t);
                                        num_end_digits = (end.ToString()).Length;
                                        Point s_start = new Point(x + 1, hight + 1);
                                        Point s_end = new Point(x + wdth - 3 * num_end_digits, hight + 1);
                                        g.DrawString(start.ToString(), f_time, new SolidBrush(Color.Black), s_start);
                                        g.DrawString(end.ToString(), f_time, new SolidBrush(Color.Black), s_end);
                                        x = x + wdth;
                                       
                                        
                                        break;
                                    }
                                }
                            }
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
            else if (Form1.choice == "SJF")
            {

                if (Form1.sub_choice == "Non Preemptive")
                {
                    try   {
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
                        //for (int l = 0; l < Form1.U; l++)
                        //{
                        //    Form1.arrival_copy.RemoveAt(0);
                        //}
                       
                     
                        for (int j = 0; j < Form1.U; j++)
                        {
                            if (clk < Form1.arrival_entries[Form1.fcfs[0]])
                                clk = Form1.arrival_entries[Form1.fcfs[0]];
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
                            wdth = Form1.bursts_entries[next] * 10;
                            end = start + (wdth / 10);
                            Rectangle r_p = new Rectangle();
                            r_p.X = x;
                            r_p.Y = y;
                            r_p.Width = wdth;
                            r_p.Height = hight;
                            Rectangle r_t = new Rectangle();
                            r_t.X = x;
                            r_t.Y = y + hight;
                            r_t.Width = wdth;
                            r_t.Height = hight_2;
                            num_end_digits = (end.ToString()).Length;
                            
                            g.DrawRectangle(Pens.Blue, r_p);
                            ////g.FillRectangle(b_process, x, y, 100 * Form1.bursts_entries[Form1.fcfs[i] - 1], 100 * hight);
                            Point s_process = new Point(x + wdth / 2, hight / 2);
                            g.DrawString("P" + (next+1).ToString(), f_process, new SolidBrush(Color.Black), s_process);
                            //g.FillRectangle(b_time, x, y + hight, 100 * Form1.bursts_entries[Form1.fcfs[i] - 1], 100);
                            g.DrawRectangle(Pens.Gray, r_t);
                            Point s_start = new Point(x + 1, hight + 1);
                            Point s_end = new Point(x + wdth - 3 * num_end_digits, hight + 1);
                            g.DrawString(start.ToString(), f_time, new SolidBrush(Color.Black), s_start);
                            g.DrawString(end.ToString(), f_time, new SolidBrush(Color.Black), s_end);

                            //Button b1 = new Button();
                            //Label ll1 = new Label();
                            //ll1.AutoSize = true;
                            //b1.AutoSize = true; 
                            //b1.Margin = new Padding(4, 4, 4, 4);

                            //ll1.Margin = new Padding(b1.Width/5, 4, b1.Width/5, 4);

                            //b1.Text = "P" + (next + 1).ToString();
                            
                            //ll1.Text = clk.ToString();
                            x = x + wdth;
                            clk += Form1.bursts_entries[next];
                            Form1.fcfs.RemoveAt(hold);

                        }
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
                        //int total_time = Form1.bursts_entries.Sum();
                        int turn;
                        int no = Form1.U;
                        int unit = 10;
                        string data = "";
                        int previous = -1;
                        start = 0;
                        wdth = 0;
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

                                    if (previous != -1)
                                    {
                                        Rectangle r_p = new Rectangle();
                                        r_p.X = x;
                                        r_p.Y = y;
                                        r_p.Width = wdth;
                                        r_p.Height = hight;
                                        g.DrawRectangle(Pens.Blue, r_p);

                                        Point s_process = new Point(x + wdth / 2, hight / 2);
                                        g.DrawString(data, f_process, new SolidBrush(Color.Black), s_process);
                                        Rectangle r_t = new Rectangle();
                                        r_t.X = x;
                                        r_t.Y = y + hight;
                                        r_t.Width = wdth;
                                        r_t.Height = hight_2;
                                        g.DrawRectangle(Pens.Gray, r_t);
                                        num_end_digits = (end.ToString()).Length;
                                        Point s_end = new Point(x + wdth - 3 * num_end_digits, hight + 1);
                                        Point s_start = new Point(x + 1, hight + 1);
                                        g.DrawString(start.ToString(), f_time, new SolidBrush(Color.Black), s_start);
                                        g.DrawString(end.ToString(), f_time, new SolidBrush(Color.Black), s_end);
                                        x = x + wdth;

                                    }
                                    //b1.Text = "P" + (turn + 1).ToString();
                                    data = "P" + (turn + 1).ToString();
                                    previous = turn;
                                    start = timer;
                                    end = start + 1;
                                    wdth = unit;

                                    //Rectangle r_p = new Rectangle(); 
                                    //r_p.Y = y;
                                    //r_p.Width = unit;
                                    //r_p.Height = hight;
                                    //g.DrawRectangle(Pens.Blue, r_p);
                                    //data = "p" + (turn + 1).ToString();
                                    //start = timer;
                                    //end = timer;



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
                                if (no == 0)
                                {
                                    Rectangle r_p = new Rectangle();
                                    r_p.X = x;
                                    r_p.Y = y;
                                    r_p.Width = wdth;
                                    r_p.Height = hight;
                                    g.DrawRectangle(Pens.Blue, r_p);
                                    Point s_process = new Point(x + wdth / 2, hight / 2);
                                    g.DrawString(data, f_process, new SolidBrush(Color.Black), s_process);
                                    /*time axis*/
                                    Rectangle r_t = new Rectangle();
                                    r_t.X = x;
                                    r_t.Y = y + hight;
                                    r_t.Width = wdth;
                                    r_t.Height = hight_2;
                                    g.DrawRectangle(Pens.Gray, r_t);
                                    num_end_digits = (end.ToString()).Length;
                                    Point s_start = new Point(x + 1, hight + 1);
                                    Point s_end = new Point(x + wdth - 3 * num_end_digits, hight + 1);
                                    g.DrawString(start.ToString(), f_time, new SolidBrush(Color.Black), s_start);
                                    g.DrawString(end.ToString(), f_time, new SolidBrush(Color.Black), s_end);
                                    x = x + wdth;


                                    break;
                                }
                            }
                        }
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
    }
}
