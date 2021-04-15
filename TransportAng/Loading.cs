using System;
using System.Data;
using System.Windows.Forms;
using TransportAng;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace TransportAngajati.TransportAng
{
    public partial class Loading : Form
    {
        public static string res = "";
        //private SqlConnection myConnection = new SqlConnection(Program.myConnectionString);
        private MySqlConnection myConn = new MySqlConnection(Program.myConnectionString);

        Timer timer1 = new Timer
        {
            Interval = 5000
            //Interval = 1000
        };
        public Loading()
        {
            InitializeComponent();
            timer1.Tick += new System.EventHandler(OnTimerEvent);
        }

        private void OnTimerEvent(object source, EventArgs e)
        {
            Process.Start("Upload Angajati.exe");
            if (Program.Interflex == true)
            {
                Process.Start(@"IFReader\Interflex.exe");
            }
            this.timer1.Enabled = false;
            try
            {
                this.myConn.Open();
                this.myConn.Close();
                ExportDataFromSQLServerToSQLLite();
                this.Hide();
                new Form1().Show();
            }
            catch (Exception)
            {
                //MessageBox.Show("Setari baza de date incorecte!\r\n", "Atenție!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Hide();
                new Form1().Show();
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;

            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Maximized;
        }

        private void Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                e.Cancel = false;
            }
            else if (Form1.cmd == "DA")
            {
                Application.Exit();
            }
            else
            {
                if (Form1.restart == "DA")
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Mai incearcă...");
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.R))
            {
                this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.Loading_FormClosing);
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // save data to local database from database
        public void ExportDataFromSQLServerToSQLLite()
        {
            SQLiteConnection.CreateFile("Rute.sqlite");
            SQLiteConnection sqlLiteCon = new SQLiteConnection("Data Source=Rute.sqlite;Version=3;");

            sqlLiteCon.Open();
            new SQLiteCommand("CREATE TABLE IF NOT EXISTS autobuz (autobuz varchar(50), locuri varchar(50), locuri_rezerva varchar(50), pc varchar(50), ruta varchar(50))", sqlLiteCon).ExecuteNonQuery();
            new SQLiteCommand("CREATE TABLE IF NOT EXISTS personal (numar varchar(128), numar_cartela varchar(10))", sqlLiteCon).ExecuteNonQuery();
            new SQLiteCommand("CREATE TABLE IF NOT EXISTS rute (numar_angajat varchar(128), nevoie_transport varchar(10), ruta varchar(128), schimb varchar(8), data datetime, data_final datetime, loc varchar(50))", sqlLiteCon).ExecuteNonQuery();
            new SQLiteCommand("CREATE TABLE IF NOT EXISTS transport (numar_angajat varchar(128), numar_cartela varchar(128), data_transport datetime, ruta varchar(50), schimb varchar(50), loc varchar(50), transport varchar(50))", sqlLiteCon).ExecuteNonQuery();
            sqlLiteCon.Close();

            DataTable dataTable = new DataTable();

            string query = "SELECT autobuz, locuri, locuri_rezerva, pc, ruta FROM autobuz WHERE retired != 'da' OR retired IS NULL";
            MySqlCommand cmd = new MySqlCommand(query, this.myConn);
            this.myConn.Open();
            MySqlDataAdapter dadapter = new MySqlDataAdapter(cmd);
            dadapter.Fill(dataTable);
            this.myConn.Close();
            dadapter.Dispose();

            foreach (DataRow row in dataTable.Rows)
            {
                sqlLiteCon.Open();
                new SQLiteCommand(string.Concat(new string[]
                                {
                                "INSERT INTO autobuz (autobuz, locuri, locuri_rezerva, pc, ruta) VALUES ('",
                                row["autobuz"].ToString(),
                                "', '",
                                row["locuri"].ToString(),
                                "', '",
                                row["locuri_rezerva"].ToString(),
                                "', '",
                                row["pc"].ToString(),
                                "', '",
                                row["ruta"].ToString(),
                                "')"
                                }), sqlLiteCon).ExecuteNonQuery();
                sqlLiteCon.Close();
            }

            DataTable dataTable1 = new DataTable();

            string query1 = "SELECT numar, numar_cartela FROM personal WHERE numar_cartela != '' AND plecat = 'nu'";
            MySqlCommand cmd1 = new MySqlCommand(query1, this.myConn);
            this.myConn.Open();
            MySqlDataAdapter dadapter1 = new MySqlDataAdapter(cmd1);
            dadapter1.Fill(dataTable1);
            this.myConn.Close();
            dadapter1.Dispose();

            foreach (DataRow row1 in dataTable1.Rows)
            {
                sqlLiteCon.Open();
                new SQLiteCommand(string.Concat(new string[]
                                {
                                "INSERT INTO personal (numar, numar_cartela) VALUES ('",
                                row1["numar"].ToString(),
                                "', '",
                                row1["numar_cartela"].ToString(),
                                "')"
                                }), sqlLiteCon).ExecuteNonQuery();
                sqlLiteCon.Close();
            }

            DateTime lastSunday = DateTime.Now.AddDays(-1);
            while (lastSunday.DayOfWeek != DayOfWeek.Sunday)
            {
                lastSunday = lastSunday.AddDays(-1);
            }
            string lastSunday2 = lastSunday.ToString("yyyy-MM-dd 23:59:59");

            DataTable dataTable2 = new DataTable();

            string query2 = "SELECT numar_angajat, nevoie_transport, ruta, schimb, DATE_FORMAT(data, '%Y-%m-%d %H:%i:%s') as data, DATE_FORMAT(data_final, '%Y-%m-%d %H:%i:%s') as data_final, loc FROM rute WHERE data >'" + lastSunday2 + "'";
            MySqlCommand cmd2 = new MySqlCommand(query2, this.myConn);
            this.myConn.Open();
            MySqlDataAdapter dadapter2 = new MySqlDataAdapter(cmd2);
            dadapter2.Fill(dataTable2);
            this.myConn.Close();
            dadapter2.Dispose();

            foreach (DataRow row2 in dataTable2.Rows)
            {
                sqlLiteCon.Open();
                new SQLiteCommand(string.Concat(new string[]
                                {
                                "INSERT INTO rute (numar_angajat, nevoie_transport, ruta, schimb, data, data_final, loc) VALUES ('",
                                row2["numar_angajat"].ToString(),
                                "', '",
                                row2["nevoie_transport"].ToString(),
                                "', '",
                                row2["ruta"].ToString(),
                                "', '",
                                row2["schimb"].ToString(),
                                "', '",
                                row2["data"].ToString(),
                                "', '",
                                row2["data_final"].ToString(),
                                 "', '",
                                row2["loc"].ToString(),
                                "')"
                                }), sqlLiteCon).ExecuteNonQuery();
                sqlLiteCon.Close();
            }

            DataTable dataTable3 = new DataTable();

            string query3 = "SELECT numar_angajat, numar_cartela, DATE_FORMAT(data_transport, '%Y-%m-%d') as data_transport, ruta, schimb, loc, transport FROM transport WHERE DATE_FORMAT(data_transport, '%Y-%m-%d') = CURDATE()";
            MySqlCommand cmd3 = new MySqlCommand(query3, this.myConn);
            this.myConn.Open();
            MySqlDataAdapter dadapter3 = new MySqlDataAdapter(cmd3);
            dadapter3.Fill(dataTable3);
            this.myConn.Close();
            dadapter3.Dispose();

            foreach (DataRow row3 in dataTable3.Rows)
            {
                sqlLiteCon.Open();
                new SQLiteCommand(string.Concat(new string[]
                                {
                                "INSERT INTO transport (numar_angajat, numar_cartela, data_transport, ruta, schimb, loc, transport) VALUES ('",
                                row3["numar_angajat"].ToString(),
                                "', '",
                                row3["numar_cartela"].ToString(),
                                "', '",
                                row3["data_transport"].ToString(),
                                "', '",
                                row3["ruta"].ToString(),
                                "', '",
                                row3["schimb"].ToString(),
                                "', '",
                                row3["loc"].ToString(),
                                "', '",
                                row3["transport"].ToString(),
                                "')"
                                }), sqlLiteCon).ExecuteNonQuery();
                sqlLiteCon.Close();
            }
        }
    }
}
