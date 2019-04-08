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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            panel2.Visible = false;
            panel3.Visible = false;

        }

    
        //global variables 
        Label l1;
        List<int> bursts_entries = new List<int>();
        List<int> arrival_entries = new List<int>();
        List<int> arrival_copy = new List<int>();
        List<int> pirority_entries = new List<int>();
        List<int> fcfs = new List<int>();
        List<int> sjfnpBURST = new List<int>();
        List<int> sjfnpINDEX = new List<int>();
        List<int> bursts_copy = new List<int>();
        //int u = Int32.Parse(textBox1.Text);
        // for SJF non peemptive algo ::
        List<int> available = new List<int>();
        List<int> sorted_arrival_entries = new List<int>();
        List<int> availableIndex = new List<int>();

        //int u = Int32.Parse(textBox1.Text);



        //generates processes label column 
        private void processesTemplateGenerator(int u)
        {
            flowLayoutPanel1.Controls.Clear();

            l1 = new Label();
            l1.Text = "Process";
            flowLayoutPanel1.Controls.Add(l1);
            for (int i = 1; i <= u; i++)
            {
                l1 = new Label(); 
                l1.Name = i.ToString(); ;
                l1.Text = "P" + i.ToString();
                l1.AutoSize = true;
                l1.Margin = new Padding(6, 6, 6, 6);
         
                flowLayoutPanel1.Controls.Add(l1); 

            }

        }
        //**************/// 


        //generates arrival_time text input column 
        TextBox t2;
        private void textboxgenerateArrival(int u)
        {
            flowLayoutPanel3.Controls.Clear();

            Label l1 = new Label();
            l1.Text = "Arrival_time";
            flowLayoutPanel3.Controls.Add(l1);
            for (int i = 1; i <= u; i++)
            {
                t2 = new TextBox();
                t2.AutoSize = true;

                Arrival_Storing_Handlers(); 
                //this.t2.Leave += new System.EventHandler(this.t2_Leave);



                flowLayoutPanel3.Controls.Add(t2);

            }

        }

        //**************/// 
        //generates burst_time text input column 
        TextBox t1;
        

        private void Burst_Storing_Handlers() {

            this.t1.Leave += new System.EventHandler(this.t1_Leave);


        }
        private void Arrival_Storing_Handlers()
        {

            this.t2.Leave += new System.EventHandler(this.t2_Leave);

        }



        private bool textboxgenerateBurst(int u)
        {
            flowLayoutPanel2.Controls.Clear();

            Label l1 = new Label();
            l1.Text = "Burst_time";
            flowLayoutPanel2.Controls.Add(l1);
            for (int i = 1; i <= u; i++)
            {
                t1 = new TextBox();
                t1.AutoSize = true;


                Burst_Storing_Handlers(); 
               //**** this.t1.Leave += new System.EventHandler(this.t1_Leave);
                flowLayoutPanel2.Controls.Add(t1);

            }
            return true ; 
        }
        /*generate pirority input-field column */
        //field in pirority column
        TextBox t3;
        private void pirority_Storing_Handlers()
        {

            this.t3.Leave += new System.EventHandler(this.t3_Leave);

        }

        private void textboxgeneratePirority(int u)
        {
            flowLayoutPanel6.Controls.Clear();
           Label l1 = new Label();
            l1.Text = "Pirority";
            flowLayoutPanel2.Controls.Add(l1);
            for (int i = 1; i <= u; i++)
            {
                t3 = new TextBox();
                t3.AutoSize = true;


                pirority_Storing_Handlers();
                //**** this.t1.Leave += new System.EventHandler(this.t1_Leave);
                flowLayoutPanel2.Controls.Add(t3);

            }

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    buttontest(); 
        //}



            //home button
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill; 
            panel2.Visible = false;
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel6.Controls.Clear();
            bursts_entries.Clear();
            arrival_entries.Clear();
            arrival_copy.Clear();
            fcfs.Clear();
            sjfnpBURST.Clear();
            bursts_copy.Clear();
            pirority_entries.Clear();

            flowLayoutPanel7.Controls.Clear();

            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            panel2.Visible = false;
        }

   

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
            MessageBox.Show(l1.Text);
        }



        // panel1 columns activator according to #processes entered by user 
        private void button1_Click(object sender, EventArgs e)
        {

            errorProvider1.SetError(textBox1, "");


            ErrorProvider err = new ErrorProvider();
            if (textBox1.Text == "") err.SetError(textBox1, "you have to enter a number!");

            else
            {
                err.SetError(textBox1, "");//this line is refusing to execute xD

                int u = Int32.Parse(textBox1.Text);

                processesTemplateGenerator(u);
                textboxgenerateBurst(u);
                textboxgenerateArrival(u);
                if(checkBox1.Checked==true)
                    textboxgeneratePirority(u);
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }




        // confirm&proceed
        //the action taken after catching bursts&arrival times 

        ErrorProvider errorProvider1 = new ErrorProvider();
        private void button5_Click(object sender, EventArgs e)
        {

           
            //if (flagForConfirmProceedButton>1) errorProvider1.SetError(butto, "You left something empty");
            if (textBox1.Text == "") errorProvider1.SetError(textBox1, "You didn't insert #processes");

            else
            {

                errorProvider1.SetError(textBox1, "");
                int u = Int32.Parse(textBox1.Text);


                panel2.Visible = true;
                panel2.Dock = DockStyle.Fill;
                panel1.Visible = false;


                if (textboxgenerateBurst(u))
                {

                    textboxgenerateBurst(u);
                    textboxgenerateArrival(u);
                    textboxgeneratePirority(u);

                }


            

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int flagForConfirmProceedButton = 0; 
        //stores bursts_entries into list : bursts_entries
        private void t1_Leave(object sender, EventArgs e)
        {

            ErrorProvider errorprovider1= new ErrorProvider(); 
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


        // generate button
        private void button6_Click(object sender, EventArgs e)
        {

            flowLayoutPanel4.Controls.Clear();
            flowLayoutPanel5.Controls.Clear();

            int u = Int32.Parse(textBox1.Text);
            panel3.Visible = true;
            panel3.Dock = DockStyle.Fill;
            panel2.Visible = false;
            int clk = 0;
            int next,hold;
          



            if (comboBox1.Text == "FCFS")
            {
                int accumulator = 0; 
                // MessageBox.Show(u.ToString()); 
                flowLayoutPanel4.Controls.Clear();
                flowLayoutPanel5.Controls.Clear();


                try
                {
                


                  for (int i = 0; i < u; i++)
                    {

                       int min = arrival_entries.IndexOf(arrival_entries.Min()); 
                       fcfs.Add(min + 1);

                       arrival_entries.RemoveAt(min);
                       arrival_entries.Insert(min, 10000);

                    }

                    //Label lll1 = new Label();
                    //lll1.Text = accumulator.ToString();
                    //flowLayoutPanel5.Controls.Add(lll1);

                    for (int i = 0; i < u; i++)
                    {

                        Button b1 = new Button();
                        Label ll1 = new Label();
                        //ll1.AutoSize = true;
                        //b1.AutoSize = true; 
                        b1.Margin = new Padding(4, 4, 4, 4);

                        //ll1.Margin = new Padding(b1.Width/5, 4, b1.Width/5, 4);

                        b1.Text = "P" + fcfs[i].ToString();
                        accumulator += bursts_entries[fcfs[i] - 1];
                        ll1.Text = accumulator.ToString();   
                        flowLayoutPanel4.Controls.Add(b1);
                        flowLayoutPanel5.Controls.Add(ll1);
                        

                    }

                    arrival_entries.Clear();
                    bursts_entries.Clear();
                    fcfs.Clear();
                


     
                    }

                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("YOU LEFT SOMETHING BLANK");
                }

                ;

            }
            else if (comboBox1.Text == "Pirority")
            {
                try
                {
                    for (int i = 0; i < u; i++)
                    {

                        int min = arrival_copy.IndexOf(arrival_copy.Min());
                        fcfs.Add(min);
                        arrival_copy.RemoveAt(min);
                        arrival_copy.Insert(min, 10000);
                    }
                    for (int l = 0; l < u; l++)
                    {
                        arrival_copy.RemoveAt(0);
                    }
                        for (int j = 0; j < u; j++)
                        {
                            if (clk < arrival_entries[fcfs[0]])
                                clk = arrival_entries[fcfs[0]];
                            next = fcfs[0];
                            hold = 0;
                            for (int k = 1; k < (u - j); k++)
                            {
                                if (arrival_entries[fcfs[k]] <= clk && (pirority_entries[fcfs[k]] < pirority_entries[next]))
                                {
                                    next = fcfs[k];
                                    hold = k;
                                }
                            }
                            Button b1 = new Button();
                            Label ll1 = new Label();
                            //ll1.AutoSize = true;
                            //b1.AutoSize = true; 
                            b1.Margin = new Padding(4, 4, 4, 4);

                            //ll1.Margin = new Padding(b1.Width/5, 4, b1.Width/5, 4);

                            b1.Text = "P" + (next + 1).ToString();
                            clk += bursts_entries[next];
                            ll1.Text = clk.ToString();
                            flowLayoutPanel4.Controls.Add(b1);
                            flowLayoutPanel5.Controls.Add(ll1);
                            fcfs.RemoveAt(hold);

                        }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("YOU LEFT SOMETHING BLANK");
                }
            }
            else if (comboBox1.Text == "SJF")
            {


                // the algorithm to implement SJF ::
                // unsorted arrival_time list == arrival_entries >> i have it 
                // sorted arrival_time list == sorted_arrival_time >> i will have it
                // unsorted burst_time list == burst_entires >> i have it 
                // available list >> i will have it 
                // availableIndex list >> i will have it 


                for (int i = 0; i < u; i++)
                {
                    bursts_copy.Add(bursts_entries[i]);
                    sorted_arrival_entries.Add(arrival_entries[i]);

                }

                //here comes the sorting 
                sorted_arrival_entries.Sort();


                if (cb.Text == "Non Preemptive")
                {


                    int accumulatorsjfnp = 0;

                    ////this algorithm infects bursts_entries list , hence the need to have a copy of it
                    //for (int i = 0; i < u; i++)
                    //{

                    //    int min = bursts_entries.IndexOf(bursts_entries.Min());
                    //    sjfnp.Add(min + 1);

                    //    bursts_entries.RemoveAt(min);
                    //    bursts_entries.Insert(min, 10000);

                    //}

                    ////sjfnp list = 

                    ////safety line

                    //bursts_entries.Clear();

                    //for (int i = 0; i < u; i++)
                    //{

                    //    Button b2 = new Button();
                    //    Label ll2 = new Label();
                    //    //ll1.AutoSize = true;
                    //    //b1.AutoSize = true; 
                    //    b2.Margin = new Padding(4, 4, 4, 4);

                    //    //ll1.Margin = new Padding(b1.Width/5, 4, b1.Width/5, 4);

                    //    b2.Text = "P" + sjfnp[i].ToString();
                    //    accumulatorsjfnp += bursts_copy[sjfnp[i] - 1];
                    //    ll2.Text = accumulatorsjfnp.ToString();
                    //    flowLayoutPanel4.Controls.Add(b2);
                    //    flowLayoutPanel5.Controls.Add(ll2);


                    //}

                    //////////////////////////////////////HERE MAN



                    int currentTime = 0;

                    for (int i = 0; i < arrival_entries.Count(); i++)
                    {

                        //process with early arival comes 
                        currentTime += sorted_arrival_entries[i];


                        //loop over all arival times to check who is available within the current time
                        for (int k = 0; k < arrival_entries.Count(); k++)
                        {

                            if (arrival_entries[k] <= currentTime)
                            { // so it's available !  

                                available.Add(bursts_entries[k]); //arrival_entries index map to the actual process ID but : +1 don't forget 
                                availableIndex.Add(k); //adding the actual process ID -1 as i will need it later on


                            }




                        }

                        for (int k = 0; k < available.Count(); k++)
                        {

                            arrival_entries.RemoveAt(availableIndex[k]);
                            arrival_entries.Insert(availableIndex[k], 10000);
                        }



                        //applying SJF on available list where shortest in burst is rendered first 


                        //getting shortest burst along with it's index
                        for (int l = 0; l < available.Count(); l++)
                        {

                            sjfnpBURST.Add(available.Min());  // push min burst
                            sjfnpINDEX.Add(availableIndex[available.IndexOf(available.Min())] + 1); // push index of min burst

                            //available.Insert(available.IndexOf(available.Min()), 10000);
                            available.Insert(available.IndexOf(available.Min()), 10000);
                            available.RemoveAt(available.IndexOf(available.Min())); // remove first min burst to evaluate next min


                            //note :: availalbe list is cleared at the end of this loop but availableIndex it NOT so clear it
                        }
                        available.Clear();
                        availableIndex.Clear();

                        //rendering shortest bursts
                        for (int m = 0; m < sjfnpINDEX.Count(); m++)
                        {

                            Button b2 = new Button();
                            Label ll2 = new Label();
                            //ll1.AutoSize = true;
                            //b1.AutoSize = true; 
                            b2.Margin = new Padding(4, 4, 4, 4);

                            //ll1.Margin = new Padding(b1.Width/5, 4, b1.Width/5, 4);

                            b2.Text = "P" + sjfnpINDEX[m].ToString();
                            accumulatorsjfnp += sjfnpBURST[m];
                            ll2.Text = accumulatorsjfnp.ToString();
                            flowLayoutPanel4.Controls.Add(b2);
                            flowLayoutPanel5.Controls.Add(ll2);



                        }
                        sjfnpINDEX.Clear();
                        sjfnpBURST.Clear();





                        //as i have done with it !
                        //arrival_entries.RemoveAt(i); 




                    }

                    //algorithm ends here
                    availableIndex.Clear();

                }



            }



        }
        ComboBox cb = new ComboBox(); //used inside this method and another one, hence it's placed in here
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {


            if (comboBox1.Text == "SJF")
            {
               
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                cb.Items.Add("Preemptive");
                cb.Items.Add("Non Preemptive");
                flowLayoutPanel7.Controls.Clear();
                flowLayoutPanel7.Controls.Add(cb);


            }
        }

  
        private void button2_Click(object sender, EventArgs e)
        {



            bursts_entries.Clear();
            arrival_entries.Clear();
            arrival_copy.Clear();
            pirority_entries.Clear();
            fcfs.Clear();
            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            panel3.Visible = false;
            fcfs.Clear();
            sjfnpBURST.Clear();
            sorted_arrival_entries.Clear();
            bursts_copy.Clear();

            flowLayoutPanel4.Controls.Clear();
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel7.Controls.Clear();

            comboBox1.Text = null;
            cb.Items.Clear();

            panel1.Visible = true;
            panel1.Dock = DockStyle.Fill;
            panel3.Visible = false;
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    buttontest(); 
        //}


    }
}
