namespace TransportAng
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.upload_label = new System.Windows.Forms.Label();
            this.schimba_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nu_btn = new System.Windows.Forms.Button();
            this.da_btn = new System.Windows.Forms.Button();
            this.transport_label = new System.Windows.Forms.Label();
            this.schimb_label = new System.Windows.Forms.Label();
            this.ruta_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(323, 259);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(640, 360);
            this.pictureBox.TabIndex = 34;
            this.pictureBox.TabStop = false;
            // 
            // upload_label
            // 
            this.upload_label.AutoSize = true;
            this.upload_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload_label.Location = new System.Drawing.Point(12, 121);
            this.upload_label.Name = "upload_label";
            this.upload_label.Size = new System.Drawing.Size(482, 37);
            this.upload_label.TabIndex = 33;
            this.upload_label.Text = "Versiune date: 05/07/2020 10:22";
            // 
            // schimba_btn
            // 
            this.schimba_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.schimba_btn.Location = new System.Drawing.Point(1230, 13);
            this.schimba_btn.Name = "schimba_btn";
            this.schimba_btn.Size = new System.Drawing.Size(108, 43);
            this.schimba_btn.TabIndex = 32;
            this.schimba_btn.Text = "Schimbă Ruta";
            this.schimba_btn.UseVisualStyleBackColor = true;
            this.schimba_btn.Click += new System.EventHandler(this.schimba_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(402, 259);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(523, 20);
            this.textBox1.TabIndex = 24;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // nu_btn
            // 
            this.nu_btn.BackColor = System.Drawing.Color.Yellow;
            this.nu_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.nu_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.nu_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nu_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nu_btn.Location = new System.Drawing.Point(702, 332);
            this.nu_btn.Name = "nu_btn";
            this.nu_btn.Size = new System.Drawing.Size(615, 386);
            this.nu_btn.TabIndex = 30;
            this.nu_btn.Text = "Nu";
            this.nu_btn.UseVisualStyleBackColor = false;
            this.nu_btn.Click += new System.EventHandler(this.nu_btn_Click);
            // 
            // da_btn
            // 
            this.da_btn.BackColor = System.Drawing.Color.Yellow;
            this.da_btn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.da_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.da_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.da_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.da_btn.Location = new System.Drawing.Point(40, 332);
            this.da_btn.Name = "da_btn";
            this.da_btn.Size = new System.Drawing.Size(615, 386);
            this.da_btn.TabIndex = 26;
            this.da_btn.Text = "Da";
            this.da_btn.UseVisualStyleBackColor = false;
            this.da_btn.Click += new System.EventHandler(this.da_btn_Click);
            // 
            // transport_label
            // 
            this.transport_label.AutoSize = true;
            this.transport_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transport_label.Location = new System.Drawing.Point(12, 84);
            this.transport_label.Name = "transport_label";
            this.transport_label.Size = new System.Drawing.Size(319, 37);
            this.transport_label.TabIndex = 29;
            this.transport_label.Text = "Transport: AR20BUS";
            // 
            // schimb_label
            // 
            this.schimb_label.AutoSize = true;
            this.schimb_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schimb_label.Location = new System.Drawing.Point(12, 47);
            this.schimb_label.Name = "schimb_label";
            this.schimb_label.Size = new System.Drawing.Size(185, 37);
            this.schimb_label.TabIndex = 28;
            this.schimb_label.Text = "Schimbul: 3";
            // 
            // ruta_label
            // 
            this.ruta_label.AutoSize = true;
            this.ruta_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruta_label.Location = new System.Drawing.Point(12, 10);
            this.ruta_label.Name = "ruta_label";
            this.ruta_label.Size = new System.Drawing.Size(171, 37);
            this.ruta_label.TabIndex = 27;
            this.ruta_label.Text = "Ruta: Arad";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 244F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(327, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(636, 293);
            this.label2.TabIndex = 31;
            this.label2.Text = "B8";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(752, 258);
            this.label1.TabIndex = 25;
            this.label1.Text = "Scanare cartelă";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.upload_label);
            this.Controls.Add(this.schimba_btn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.nu_btn);
            this.Controls.Add(this.da_btn);
            this.Controls.Add(this.transport_label);
            this.Controls.Add(this.schimb_label);
            this.Controls.Add(this.ruta_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Transport Bus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label upload_label;
        private System.Windows.Forms.Button schimba_btn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button nu_btn;
        private System.Windows.Forms.Button da_btn;
        private System.Windows.Forms.Label transport_label;
        private System.Windows.Forms.Label schimb_label;
        private System.Windows.Forms.Label ruta_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}