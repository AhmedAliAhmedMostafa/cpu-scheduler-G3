using System;
using System.Collections;
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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 30F));
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30f));
            tableLayoutPanel1.Visible = false;
            add_process.Visible = false;
            flowLayoutPanel2.Visible = false;
            //panel2.Visible = false;
            //panel3.Visible = false;

        }


        //global variables 
        Label l1;
        public static List<int> bursts_entries = new List<int>();
        public static List<int> arrival_entries = new List<int>();
        public static List<int> arrival_copy = new List<int>();
        public static List<int> pirority_entries = new List<int>();
        public static List<int> fcfs = new List<int>();
        public static List<int> sjfnpBURST = new List<int>();
        public static List<int> sjfnpINDEX = new List<int>();
        public static List<int> bursts_copy = new List<int>();
        public static int U;
        public static string choice;
        public static string sub_choice;
        public static bool open = false;
        //int u = Int32.Parse(textBox1.Text);
        // for SJF non peemptive algo ::
        public static List<int> available = new List<int>();
        public static List<int> sorted_arrival_entries = new List<int>();
        public static List<int> availableIndex = new List<int>();
        public static int Q;


        //int u = Int32.Parse(textBox1.Text);
        //add instance of gant chart




        //generates processes label column 
        private void processesTemplateGenerator(int u)
        {

            l1 = new Label();
            l1.Text = "Processes";
            //l1.AutoSize = false;
            //l1.Margin = new Padding(6, 6, 6, 6);
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.Controls.Add(l1, 0, 0);

            //flowLayoutPanel1.Controls.Add(l1);
            for (int i = 1; i <= u; i++)
            {
                l1 = new Label();
                l1.Name = i.ToString(); ;
                l1.Text = "P" + i.ToString();
                l1.AutoSize = true;
                l1.Margin = new Padding(6, 6, 6, 6);
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.Controls.Add(l1, 0, i);





            }

        }
        //**************/// 


        //generates arrival_time text input column 
        TextBox t2;
        private void textboxgenerateArrival(int u)
        {


            Label l1 = new Label();
            l1.Text = "Arrival_time";
            tableLayoutPanel1.ColumnCount++;
            tableLayoutPanel1.Controls.Add(l1, 2, 0);
            for (int i = 1; i <= u; i++)
            {
                t2 = new TextBox();
                
                t2.AutoSize = true;

                //Arrival_Storing_Handlers(); 
                //this.t2.Leave += new System.EventHandler(this.t2_Leave);


                tableLayoutPanel1.Controls.Add(t2, 2, i);
                tableLayoutPanel1.Controls.SetChildIndex(t2, u + i);

            }

        }

        //**************/// 
        //generates burst_time text input column 
        TextBox t1;


        //private void Burst_Storing_Handlers() {

        //    this.t1.Leave += new System.EventHandler(this.t1_Leave);


        //}
        //private void Arrival_Storing_Handlers()
        //{

        //    this.t2.Leave += new System.EventHandler(this.t2_Leave);

        //}



        private void textboxgenerateBurst(int u)
        {
            Label l1 = new Label();
            l1.Text = "Burst_time";
            tableLayoutPanel1.ColumnCount++;
            tableLayoutPanel1.Controls.Add(l1, 1, 0);


            for (int i = 1; i <= u; i++)
            {
                t1 = new TextBox();
                t1.AutoSize = true;
                tableLayoutPanel1.Controls.Add(t1, 1, i);
                tableLayoutPanel1.Controls.SetChildIndex(t1,i);

                //Burst_Storing_Handlers(); 
                //**** this.t1.Leave += new System.EventHandler(this.t1_Leave);


            }

        }
        /*generate pirority input-field column */
        //field in pirority column
        //TextBox t3;
        //private void pirority_Storing_Handlers()
        //{

        //    this.t3.Leave += new System.EventHandler(this.t3_Leave);

        //}

        private void textboxgeneratePirority(int u)
        {
            Label l1 = new Label();
            l1.Text = "Pirority";
            tableLayoutPanel1.ColumnCount++;
            tableLayoutPanel1.Controls.Add(l1, 3, 0);
            
       
            for (int i = 1; i <= u; i++)
            {
               TextBox t3 = new TextBox();
                t3.AutoSize = true;
                tableLayoutPanel1.Controls.Add(t3, 3, i);
                tableLayoutPanel1.Controls.SetChildIndex(t3, 2 * u + i);


  
            }

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    buttontest(); 
        //}



        //home button
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    panel1.Visible = true;
        //    panel1.Dock = DockStyle.Fill; 
        //    panel2.Visible = false;
        //    flowLayoutPanel2.Controls.Clear();
        //    flowLayoutPanel3.Controls.Clear();
        //    flowLayoutPanel6.Controls.Clear();
        //    bursts_entries.Clear();
        //    arrival_entries.Clear();
        //    arrival_copy.Clear();
        //    fcfs.Clear();
        //    sjfnpBURST.Clear();
        //    bursts_copy.Clear();
        //    pirority_entries.Clear();

        //    flowLayoutPanel7.Controls.Clear();

        //    panel1.Visible = true;
        //    panel1.Dock = DockStyle.Fill;
        //    panel2.Visible = false;
        //}



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }





        // panel1 columns activator according to #processes entered by user 
        private void button1_Click(object sender, EventArgs e)
        {


            
            //ErrorProvider errorProvider1 = new ErrorProvider();
            //ErrorProvider errorProvider2 = new ErrorProvider();
            //if (flagForConfirmProceedButton>1) errorProvider1.SetError(butto, "You left something empty");
            if (textBox1.Text == "") errorProvider1.SetError(textBox1, "You didn't insert #processes");
            if (comboBox1.Text == "") errorProvider2.SetError(comboBox1, "please select schduling Algorithm First");
            

            else
            {
                errorProvider1.SetError(textBox1, "");
                errorProvider2.SetError(comboBox1, "");
                tableLayoutPanel1.Visible = false;
                add_process.Visible = true;
                //errorProvider1.Clear();
                
                //errorProvider2.Clear();
               int u = Int32.Parse(textBox1.Text);
               U = Int32.Parse(textBox1.Text);
               
               tableLayoutPanel1.ColumnCount = 1;
               tableLayoutPanel1.RowCount = 1;
               tableLayoutPanel1.Controls.Clear();
               processesTemplateGenerator(u);
               textboxgenerateBurst(u);
               textboxgenerateArrival(u);
               if (comboBox1.Text == "Pirority")
               {
                   textboxgeneratePirority(u);
               }
               if (comboBox1.Text == "RoundRobin")
               {
                   flowLayoutPanel2.Visible = true;
               }
               else
               {
                   flowLayoutPanel2.Visible = false;
               }
               tableLayoutPanel1.Visible = true;
            }
        }






        // Generate
        //the action taken after catching bursts&arrival times 

        
        private void button5_Click(object sender, EventArgs e)
        {


            
                
                fcfs.Clear();
                bursts_entries.Clear();
                bursts_copy.Clear();
                arrival_entries.Clear();
                arrival_copy.Clear();
                pirority_entries.Clear();
                //int u = Int32.Parse(textBox1.Text);
              
                choice = comboBox1.Text;
                sub_choice = cb.Text;
                for (int i = 1; i <= U; i++)
                {
                    bursts_entries.Add(int.Parse(tableLayoutPanel1.Controls[i].Text));
                }
                for (int i = 1; i <= U; i++)
                {
                    arrival_entries.Add(int.Parse(tableLayoutPanel1.Controls[U + i].Text));

                }
                for (int i = 1; i <= U; i++)
                {
                    arrival_copy.Add(int.Parse(tableLayoutPanel1.Controls[U + i].Text));

                }
                if (choice == "Pirority")
                {
                    for (int i = 1; i <= U; i++)
                    {
                        pirority_entries.Add(int.Parse(tableLayoutPanel1.Controls[2 * U + i].Text));

                    }
                }
            else if(choice=="RoundRobin")
            {
                Q = int.Parse(textBox2.Text);
            }


                ////gant.Invalidate();
                Gant_chart gant = new Gant_chart();
                gant.Show();









            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int flagForConfirmProceedButton = 0;
        //stores bursts_entries into list : bursts_entries
        private void t1_Leave(object sender, EventArgs e)
        {

            ErrorProvider errorprovider1 = new ErrorProvider();
            TextBox l1 = sender as TextBox;
            //MessageBox.Show(l1.Text); 

            if (l1.Text == "")
            {


                errorprovider1.SetError(l1, "You didn't insert a value");
                flagForConfirmProceedButton++;

            }
            else
            {

                errorprovider1.SetError(l1, "");
                bursts_entries.Add(Int32.Parse(l1.Text));


            }

        }

        //stores arrival_entries into list : arrival_entries
        private void t2_Leave(object sender, EventArgs e)
        {
            ErrorProvider errorprovider1 = new ErrorProvider();
            TextBox l1 = sender as TextBox;
            //MessageBox.Show(l1.Text); 


            if (l1.Text == "") errorprovider1.SetError(l1, "You didn't insert a value");
            else
            {

                errorprovider1.SetError(l1, "");
                arrival_entries.Add(Int32.Parse(l1.Text));
                arrival_copy.Add(Int32.Parse(l1.Text));



            }

        }
        //stores arrival_entries into list : pirority_entries
        private void t3_Leave(object sender, EventArgs e)
        {
            ErrorProvider errorprovider1 = new ErrorProvider();
            TextBox l1 = sender as TextBox;
            //MessageBox.Show(l1.Text); 


            if (l1.Text == "") errorprovider1.SetError(l1, "You didn't insert a value");
            else
            {

                errorprovider1.SetError(l1, "");
                pirority_entries.Add(Int32.Parse(l1.Text));



            }

        }





        ComboBox cb = new ComboBox(); //used inside this method and another one, hence it's placed in here
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {


            if (comboBox1.Text == "SJF" || comboBox1.Text == "Pirority")
            {

                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                cb.Items.Add("Preemptive");
                cb.Items.Add("Non Preemptive");
                flowLayoutPanel8.Controls.Add(cb);
                cb.Visible = true;


            }
            else
            {
                cb.Visible = false;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void add_process_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowCount++;
            int u=int.Parse(textBox1.Text);
            U++;
            Label l1 = new Label();

            l1.Text = "P"+U;
            tableLayoutPanel1.Controls.Add(l1, 0, tableLayoutPanel1.RowCount - 1);
            TextBox t1 = new TextBox();
            tableLayoutPanel1.Controls.Add(t1, 1, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.SetChildIndex(t1, U);
            TextBox t2 = new TextBox();
            tableLayoutPanel1.Controls.Add(t2, 2, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.SetChildIndex(t2, 2*U);
            if (textBox1.Text == "Pirority")
            {
                TextBox t3 = new TextBox();
                tableLayoutPanel1.Controls.Add(t3, 3, tableLayoutPanel1.RowCount - 1);
                tableLayoutPanel1.Controls.SetChildIndex(t3, 3*U);
            }



        }






    }
}

