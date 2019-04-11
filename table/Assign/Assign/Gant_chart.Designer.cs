namespace Assign
{
    partial class Gant_chart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.SystemColors.Highlight;
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Exit.Location = new System.Drawing.Point(708, 109);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 0;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Gant_chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(795, 144);
            this.Controls.Add(this.Exit);
            this.Name = "Gant_chart";
            this.Text = "Gant_chart";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Gant_chart_FormClosed);
            this.Load += new System.EventHandler(this.Gant_chart_Load);
            this.Click += new System.EventHandler(this.Gant_chart_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Gant_chart_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Exit;
    }
}