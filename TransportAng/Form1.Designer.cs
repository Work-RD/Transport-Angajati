namespace TransportAng
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOk = new System.Windows.Forms.Button();
            this.cbRuta = new System.Windows.Forms.ComboBox();
            this.cbSch = new System.Windows.Forms.ComboBox();
            this.cbTran = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(479, 567);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(278, 150);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbRuta
            // 
            this.cbRuta.BackColor = System.Drawing.SystemColors.Window;
            this.cbRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbRuta.DropDownHeight = 450;
            this.cbRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRuta.ForeColor = System.Drawing.Color.Gray;
            this.cbRuta.FormattingEnabled = true;
            this.cbRuta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbRuta.IntegralHeight = false;
            this.cbRuta.Location = new System.Drawing.Point(110, 121);
            this.cbRuta.Name = "cbRuta";
            this.cbRuta.Size = new System.Drawing.Size(800, 84);
            this.cbRuta.TabIndex = 9;
            this.cbRuta.Text = "Introduceți ruta dorită:";
            this.cbRuta.DropDown += new System.EventHandler(this.colorChangeR);
            this.cbRuta.Click += new System.EventHandler(this.cbRuta_Click);
            // 
            // cbSch
            // 
            this.cbSch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbSch.DropDownHeight = 450;
            this.cbSch.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSch.ForeColor = System.Drawing.Color.Gray;
            this.cbSch.FormattingEnabled = true;
            this.cbSch.IntegralHeight = false;
            this.cbSch.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "Administrativ"});
            this.cbSch.Location = new System.Drawing.Point(110, 230);
            this.cbSch.Name = "cbSch";
            this.cbSch.Size = new System.Drawing.Size(800, 84);
            this.cbSch.TabIndex = 10;
            this.cbSch.Text = "Introduceți schimbul:";
            this.cbSch.DropDown += new System.EventHandler(this.colorChangeS);
            this.cbSch.Click += new System.EventHandler(this.cbSch_Click);
            // 
            // cbTran
            // 
            this.cbTran.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTran.DropDownHeight = 300;
            this.cbTran.DropDownWidth = 485;
            this.cbTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTran.ForeColor = System.Drawing.Color.Gray;
            this.cbTran.FormattingEnabled = true;
            this.cbTran.IntegralHeight = false;
            this.cbTran.Location = new System.Drawing.Point(110, 448);
            this.cbTran.Name = "cbTran";
            this.cbTran.Size = new System.Drawing.Size(800, 84);
            this.cbTran.TabIndex = 12;
            this.cbTran.Text = "Introduceți autobuzul:";
            this.cbTran.DropDown += new System.EventHandler(this.colorChangeT);
            this.cbTran.Click += new System.EventHandler(this.cbTran_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1250, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 36);
            this.button1.TabIndex = 13;
            this.button1.Text = "Setari";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbTran);
            this.Controls.Add(this.cbSch);
            this.Controls.Add(this.cbRuta);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTran;
        private System.Windows.Forms.ComboBox cbSch;
        private System.Windows.Forms.ComboBox cbRuta;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button button1;
    }
}

