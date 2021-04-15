using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using TransportAngajati.TransportAng;

namespace TransportAng
{
    public partial class Form1 : Form
    {
        public static string ruta = "";
        public static string sch = "";
        public static string tran = "";
        public static string restart = "";
        public static string cmd = "";
        public static string pc = "";

        SQLiteConnection sqlLiteCon = new SQLiteConnection("Data Source=Rute.sqlite;Version=3;");

        Timer timer1 = new Timer
        {
            Interval = 10000
        };

        public Form1()
        {
            InitializeComponent();

            timer1.Tick += new System.EventHandler(OnTimerEvent);
        }

        private void OnTimerEvent(object source, EventArgs e)
        {
            this.timer1.Enabled = false;
            Form1_Load(null, EventArgs.Empty);
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Maximized;

            int diferenta = this.Width - this.cbRuta.Size.Width;

            this.cbRuta.Location = new System.Drawing.Point(diferenta / 2, 1 * this.Height / 6);
            this.cbSch.Location = new System.Drawing.Point(diferenta / 2, 2 * this.Height / 6);
            this.cbTran.Location = new System.Drawing.Point(diferenta / 2, 3 * this.Height / 6);
            this.btnOk.Location = new System.Drawing.Point(this.Width / 2 - 139, 4 * this.Height / 6);
            this.btnOk.Size = new System.Drawing.Size(250, this.Height / 6);
            this.button1.Location = new System.Drawing.Point(this.Width - 108, 20);

            try
            {
                DataTable dataTableRuta = new DataTable();

                string query = "SELECT DISTINCT ruta FROM rute WHERE ruta != 'N/A' AND ruta != '' ORDER BY ruta";
                SQLiteCommand cmd = new SQLiteCommand(query, sqlLiteCon);
                sqlLiteCon.Open();
                SQLiteDataAdapter dadapter = new SQLiteDataAdapter(cmd);
                dadapter.Fill(dataTableRuta);
                sqlLiteCon.Close();
                dadapter.Dispose();

                foreach (DataRow row in dataTableRuta.Rows)
                {
                    this.cbRuta.Items.AddRange(new object[] { row["ruta"] });
                }
            }
            catch (Exception)
            {
                if (MessageBox.Show("Aplicația nu are acces la internet! \nAplicația nu găsește baza de date locală! \nPentru a funcționa vă rugăm restartați aplicația. \n \nDoriți să o restartați acum?", "Atenție !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    restart = "DA";
                    Application.Restart();
                }
                else
                {
                    timer1.Enabled = true;
                }
            }

            try
            {
                DataTable dataTableTran = new DataTable();

                string query1 = "SELECT DISTINCT autobuz FROM autobuz";
                SQLiteCommand cmd1 = new SQLiteCommand(query1, sqlLiteCon);
                sqlLiteCon.Open();
                SQLiteDataAdapter dadapter1 = new SQLiteDataAdapter(cmd1);
                dadapter1.Fill(dataTableTran);
                sqlLiteCon.Close();
                dadapter1.Dispose();

                foreach (DataRow row in dataTableTran.Rows)
                {
                    this.cbTran.Items.AddRange(new object[] { row["autobuz"] });
                }
            }
            catch (Exception)
            {
            }

            try
            {
                sqlLiteCon.Open();
                pc = Environment.MachineName;
                SQLiteDataReader sqlDataReader = new SQLiteCommand("SELECT autobuz, ruta FROM autobuz WHERE pc='" + pc + "'", sqlLiteCon).ExecuteReader();
                bool flag = sqlDataReader.Read();
                if (flag)
                {
                    this.cbRuta.SelectedItem = sqlDataReader.GetValue(1).ToString();
                    this.cbRuta.ForeColor = System.Drawing.Color.Black;
                    this.cbTran.SelectedItem = sqlDataReader.GetValue(0).ToString();
                    this.cbTran.ForeColor = System.Drawing.Color.Black;

                }
                sqlLiteCon.Close();
            }
            catch (Exception)
            {
            }

            TimeSpan start1a = new TimeSpan(24, 0, 0);
            TimeSpan end1a = new TimeSpan(06, 0, 0);
            TimeSpan start1b = new TimeSpan(14, 30, 0);
            TimeSpan end1b = new TimeSpan(16, 0, 0);

            TimeSpan start2a = new TimeSpan(08, 0, 0);
            TimeSpan end2a = new TimeSpan(14, 30, 0);
            TimeSpan start2b = new TimeSpan(23, 0, 0);
            TimeSpan end2b = new TimeSpan(24, 0, 0);

            TimeSpan start3a = new TimeSpan(06, 0, 0);
            TimeSpan end3a = new TimeSpan(06, 30, 0);
            TimeSpan start3b = new TimeSpan(17, 0, 0);
            TimeSpan end3b = new TimeSpan(23, 0, 0);

            TimeSpan startAdmina = new TimeSpan(06, 30, 0);
            TimeSpan endAdmina = new TimeSpan(08, 0, 0);
            TimeSpan startAdminb = new TimeSpan(16, 0, 0);
            TimeSpan endAdminb = new TimeSpan(17, 0, 0);

            bool TimeBetween(DateTime datetime, TimeSpan start, TimeSpan end)
            {
                TimeSpan now = datetime.TimeOfDay;
                if (start < end)
                    return start <= now && now <= end;
                return !(end < now && now < start);
            }

            bool sch1a = TimeBetween(DateTime.Now, start1a, end1a);
            bool sch1b = TimeBetween(DateTime.Now, start1b, end1b);

            bool sch2a = TimeBetween(DateTime.Now, start2a, end2a);
            bool sch2b = TimeBetween(DateTime.Now, start2b, end2b);

            bool sch3a = TimeBetween(DateTime.Now, start3a, end3a);
            bool sch3b = TimeBetween(DateTime.Now, start3b, end3b);

            bool schAdmina = TimeBetween(DateTime.Now, startAdmina, endAdmina);
            bool schAdminb = TimeBetween(DateTime.Now, startAdminb, endAdminb);

            if (sch1a || sch1b)
            {
                this.cbSch.SelectedItem = "1";
                this.cbSch.ForeColor = System.Drawing.Color.Black;
            }

            if (sch2a || sch2b)
            {
                this.cbSch.SelectedItem = "2";
                this.cbSch.ForeColor = System.Drawing.Color.Black;
            }

            if (sch3a || sch3b)
            {
                this.cbSch.SelectedItem = "3";
                this.cbSch.ForeColor = System.Drawing.Color.Black;
            }

            if (schAdmina || schAdminb)
            {
                this.cbSch.SelectedItem = "Administrativ";
                this.cbSch.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                e.Cancel = false;
            }
            else if (cmd == "DA")
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                if (restart == "DA")
                {
                    var openProcesses = Process.GetProcesses().Where(pr => (pr.ProcessName == "Upload Angajati") || (pr.ProcessName == "Interflex")); 

                    foreach (var process in openProcesses)
                    {
                        try
                        {
                            process.Kill();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Mai incearcă...");
                }
            }
        }

        private void cbRuta_Click(object sender, EventArgs e)
        {
            cbRuta.DroppedDown = true;

        }
        private void cbSch_Click(object sender, EventArgs e)
        {
            cbSch.DroppedDown = true;

        }
        private void cbTran_Click(object sender, EventArgs e)
        {
            cbTran.DroppedDown = true;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbRuta.Text) && cbRuta.Text != "Introduceți ruta dorită:")
            {
                ruta = cbRuta.SelectedItem.ToString();
            }
            if (!String.IsNullOrEmpty(cbSch.Text) && cbSch.Text != "Introduceți schimbul:")
            {
                sch = cbSch.SelectedItem.ToString();
            }
            if (!String.IsNullOrEmpty(cbTran.Text) && cbTran.Text != "Introduceți autobuzul:")
            {
                tran = cbTran.SelectedItem.ToString();
            }
            if (String.IsNullOrEmpty(ruta) || String.IsNullOrEmpty(sch) || String.IsNullOrEmpty(tran))
            {
                MessageBox.Show("Vă rugăm alegeți ruta, schimbul și transportul.", "Atenție");
            }
            else
            {
                if (Program.Interflex == true)
                {
                    Form3 frm3 = new Form3();
                    this.Hide();
                    frm3.Show();
                }
                else
                {
                    Form2 frm2 = new Form2();
                    this.Hide();
                    frm2.Show();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.R))
            {
                cmd = "DA";
                this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
                Environment.Exit(0);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void colorChangeR(object sender, EventArgs e)
        {
            this.cbRuta.ForeColor = System.Drawing.Color.Black;
        }
        private void colorChangeS(object sender, EventArgs e)
        {
            this.cbSch.ForeColor = System.Drawing.Color.Black;
        }
        private void colorChangeT(object sender, EventArgs e)
        {
            this.cbTran.ForeColor = System.Drawing.Color.Black;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int num = (int)new Parola().ShowDialog();
        }
    }
}
