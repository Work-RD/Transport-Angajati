using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace TransportAng
{
    public partial class Form3 : Form
    {
        public string nr_cartela = "";
        public int loc = 1;
        public string numar_angajat = "";
        public string numar_angajat_rezerva = "";
        public string numar_cartela = "";
        public int nr_locuri = 0;
        public int nr_locuri_rezerva = 0;
        public int loc_liber = 0;
        public string accept = "";
        public string ruta = "";
        public string transport = "";
        public int locAfisat = 1;
        public int[] locuri_bus = new int[100];
        public int[] locuri_rezerva = new int[100];
        public string schimb = "";
        public int loc_gasit_deja = 0;
        public string negasit = "";
        public string alocare_locuri = "";
        public string ruta_transport = "";
        public string schimb_transport = "";
        //public string webcam = "";
        //List<string> scanati = new List<string>();

        //private SqlConnection myConnection = new SqlConnection(Program.myConnectionString);

        SQLiteConnection sqlLiteCon = new SQLiteConnection("Data Source=Rute.sqlite;Version=3;");

        //FilterInfoCollection filterInfoCollection;
        //VideoCaptureDevice captureDevice;
        //Bitmap image;

        Timer timer1 = new Timer
        {
            Interval = 3000
        };
        /*Timer timer2 = new Timer
        {
            Interval = 7200000
        };*/
        Timer timer3 = new Timer
        {
            Interval = 1
        };

        /*Timer timer4 = new Timer
        {
            Interval = 1
        };*/

        public Form3()
        {
            InitializeComponent();

            timer1.Tick += new System.EventHandler(OnTimerEvent);
            //timer2.Tick += new System.EventHandler(OnTimerEventUpdateSQL);
            timer3.Tick += new System.EventHandler(OnTimerEventRefresh);
            //timer4.Tick += new System.EventHandler(timer4_Tick);
        }
        private void OnTimerEventRefresh(object source, EventArgs e)
        {
            Form3_Load(source, e);

            TimeSpan start1 = new TimeSpan(06, 0, 0);
            TimeSpan end1 = new TimeSpan(06, 0, 3);
            TimeSpan start2 = new TimeSpan(06, 30, 0);
            TimeSpan end2 = new TimeSpan(06, 30, 3);
            TimeSpan start3 = new TimeSpan(08, 0, 0);
            TimeSpan end3 = new TimeSpan(08, 0, 3);
            TimeSpan start4 = new TimeSpan(14, 30, 0);
            TimeSpan end4 = new TimeSpan(14, 30, 3);
            TimeSpan start5 = new TimeSpan(16, 0, 0);
            TimeSpan end5 = new TimeSpan(16, 0, 3);
            TimeSpan start6 = new TimeSpan(17, 0, 0);
            TimeSpan end6 = new TimeSpan(17, 0, 3);
            TimeSpan start7 = new TimeSpan(23, 0, 0);
            TimeSpan end7 = new TimeSpan(23, 0, 3);
            TimeSpan start8 = new TimeSpan(24, 0, 0);
            TimeSpan end8 = new TimeSpan(00, 0, 3);

            bool TimeBetween(DateTime datetime, TimeSpan start, TimeSpan end)
            {
                TimeSpan now = datetime.TimeOfDay;
                if (start < end)
                    return start <= now && now <= end;
                return !(end < now && now < start);
            }

            bool sch1 = TimeBetween(DateTime.Now, start1, end1);
            bool sch2 = TimeBetween(DateTime.Now, start2, end2);
            bool sch3 = TimeBetween(DateTime.Now, start3, end3);
            bool sch4 = TimeBetween(DateTime.Now, start4, end4);
            bool sch5 = TimeBetween(DateTime.Now, start5, end5);
            bool sch6 = TimeBetween(DateTime.Now, start6, end6);
            bool sch7 = TimeBetween(DateTime.Now, start7, end7);
            bool sch8 = TimeBetween(DateTime.Now, start8, end8);

            if (sch1 || sch2 || sch3 || sch4 || sch5 || sch6 || sch7 || sch8)
            {
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.Show();
                timer3.Enabled = false;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            this.FormBorderStyle = FormBorderStyle.None;

            this.WindowState = FormWindowState.Maximized;

            //
            /*if (webcam != "ON")
            {
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                captureDevice = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
                captureDevice.VideoResolution = captureDevice.VideoCapabilities[2];
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                timer4.Start();
            }
            webcam = "ON";*/

            //timer2.Enabled = true;
            timer3.Enabled = true;

            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Visible = false;
            this.da_btn.Visible = false;
            this.nu_btn.Visible = false;

            //this.textBox1.Enabled = false;
            //this.textBox1.Visible = false;

            this.pictureBox.Enabled = false;
            this.pictureBox.Visible = false;

            this.ruta_label.Text = "Ruta: " + Form1.ruta;
            this.schimb_label.Text = "Schimbul: " + Form1.sch;
            this.transport_label.Text = "Transport: " + Form1.tran;
            string modification = File.GetLastWriteTime("Rute.sqlite").ToString("dd-MM-yyyy HH:mm:ss");
            this.upload_label.Text = "Versiune date: " + modification;

            this.textBox1.Location = new System.Drawing.Point(this.Width / 2 - label1.Size.Width / 4, this.Height / 2 + 50);

            this.textBox1.Size = new System.Drawing.Size(label1.Size.Width / 2, 20);

            //this.pictureBox.Location = new System.Drawing.Point(this.Width / 2 - pictureBox.Size.Width / 2, this.Height / 2 - pictureBox.Size.Width / 4 + 50);

            /*sqlLiteCon.Open();
            SQLiteDataReader sqlDataReader = new SQLiteCommand("SELECT locuri, locuri_rezerva FROM autobuz WHERE autobuz='" + Form1.tran + "'", sqlLiteCon).ExecuteReader();
            bool flag1 = sqlDataReader.Read();
            if (flag1)
            {
                nr_locuri = Convert.ToInt32(sqlDataReader.GetValue(0).ToString());
                nr_locuri_rezerva = Convert.ToInt32(sqlDataReader.GetValue(1).ToString());

            }
            sqlLiteCon.Close();

            locuri_bus = new int[nr_locuri];

            for (int i = 0, nr = 1; i < nr_locuri; i++, nr += 1)
            {
                locuri_bus[i] = nr;
            }

            locuri_rezerva = new int[nr_locuri_rezerva];

            for (int i = 0, nr = locuri_bus[locuri_bus.Length - 1] + 1; i < nr_locuri_rezerva; i++, nr += 1)
            {
                locuri_rezerva[i] = nr;
            }*/
        }

        /*private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();
            image = img;
        }*/

        /*private void timer4_Tick(object sender, EventArgs e)
        {
            pictureBox.Image = image;
            if (pictureBox.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox.Image);
                if (result != null)
                {
                    nr_cartela = result.ToString();
                    timer4.Stop();
                    captureDevice.Stop();
                    scanare_cartela(nr_cartela);
                }
            }
        }*/

        // prevent closing app
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }*/
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

        // timer pentru schimbare pagini
        private void OnTimerEvent(object source, EventArgs e)
        {
            //webcam = "OFF";
            //image = null;
            main_page();
            Form3_Load(source, e);
        }

        /*private void OnTimerEventUpdateSQL(object source, EventArgs e)
        {
            Loading load = new Loading();
            load.ExportDataFromSQLServerToSQLLite();

            /// primul import
            try
            {
                string path = @"C:\Transport\Transport Angajati RESPINS.txt";
                StreamReader streamReader = new StreamReader(path);
                string line = "";
                string filedelimiter = ",";
                this.myConnection.Open();
                while ((line = streamReader.ReadLine()) != null)
                {
                    string query = "INSERT INTO transport (numar_angajat, numar_cartela, data_transport, ruta, schimb, accept, transport) VALUES ('" + line.Replace(filedelimiter, "','") + "')";
                    SqlCommand myCommand = new SqlCommand(query, this.myConnection);
                    myCommand.ExecuteNonQuery();
                }
                streamReader.Close();
                File.Delete(path);
                this.myConnection.Close();
            }
            catch (Exception)
            {
            }
            /// al doilea import
            try
            {
                string path = @"C:\Transport\Transport Angajati NEGASIT.txt";
                StreamReader streamReader = new StreamReader(path);
                string line = "";
                string filedelimiter = ",";

                this.myConnection.Open();
                while ((line = streamReader.ReadLine()) != null)
                {
                    string query = "INSERT INTO transport (numar_angajat, numar_cartela, data_transport, ruta, schimb, loc,accept, transport) VALUES ('" + line.Replace(filedelimiter, "','") + "')";
                    SqlCommand myCommand = new SqlCommand(query, this.myConnection);
                    myCommand.ExecuteNonQuery();
                }
                streamReader.Close();
                File.Delete(path);
                this.myConnection.Close();
            }
            catch (Exception)
            {
            }
            /// al treilea import
            try
            {
                string path = @"C:\Transport\Transport Angajati ACCEPTAT.txt";
                StreamReader streamReader = new StreamReader(path);
                string line = "";
                string filedelimiter = ",";

                this.myConnection.Open();
                while ((line = streamReader.ReadLine()) != null)
                {
                    string query = "INSERT INTO transport (numar_angajat, numar_cartela, data_transport, ruta, schimb, loc,accept, transport) VALUES ('" + line.Replace(filedelimiter, "','") + "')";
                    SqlCommand myCommand = new SqlCommand(query, this.myConnection);
                    myCommand.ExecuteNonQuery();
                }
                streamReader.Close();
                File.Delete(path);
                this.myConnection.Close();
            }
            catch (Exception)
            {
            }
            /// al patrulea import
            try
            {
                string path = @"C:\Transport\Transport Angajati GASIT.txt";
                StreamReader streamReader = new StreamReader(path);
                string line = "";
                string filedelimiter = ",";

                this.myConnection.Open();
                while ((line = streamReader.ReadLine()) != null)
                {
                    string query = "INSERT INTO transport (numar_angajat, numar_cartela, data_transport, ruta, schimb, loc, transport) VALUES ('" + line.Replace(filedelimiter, "','") + "')";
                    SqlCommand myCommand = new SqlCommand(query, this.myConnection);
                    myCommand.ExecuteNonQuery();
                }
                streamReader.Close();
                File.Delete(path);
                this.myConnection.Close();
            }
            catch (Exception)
            {
            }
            /// al cincilea import
            try
            {
                string path = @"C:\Transport\Transport Angajati LIPSA NEGASIT.txt";
                StreamReader streamReader = new StreamReader(path);
                string line = "";
                string filedelimiter = ",";

                this.myConnection.Open();
                while ((line = streamReader.ReadLine()) != null)
                {
                    string query = "INSERT INTO transport (numar_angajat, numar_cartela, data_transport, ruta, schimb, accept, transport) VALUES ('" + line.Replace(filedelimiter, "','") + "')";
                    SqlCommand myCommand = new SqlCommand(query, this.myConnection);
                    myCommand.ExecuteNonQuery();
                }
                streamReader.Close();
                File.Delete(path);
                this.myConnection.Close();
            }
            catch (Exception)
            {
            }
            /// al saselea import
            try
            {
                string path = @"C:\Transport\Transport Angajati LIPSA GASIT.txt";
                StreamReader streamReader = new StreamReader(path);
                string line = "";
                string filedelimiter = ",";

                this.myConnection.Open();
                while ((line = streamReader.ReadLine()) != null)
                {
                    string query = "INSERT INTO transport (numar_angajat, numar_cartela, data_transport, ruta, schimb, accept, transport) VALUES ('" + line.Replace(filedelimiter, "','") + "')";
                    SqlCommand myCommand = new SqlCommand(query, this.myConnection);
                    myCommand.ExecuteNonQuery();
                }
                streamReader.Close();
                File.Delete(path);
                this.myConnection.Close();
            }
            catch (Exception)
            {
            }
        }*/

        // doresti sa aloci loc nou
        private void da_btn_Click(object sender, EventArgs e)
        {
            alocare_locuri = "DA";
            accept = "Acceptat";
            loc_liber = loc_liber + 1;
            timer1.Enabled = true;

            if (locuri_rezerva.Length != 0)
            {
                if (loc_liber <= nr_locuri_rezerva)
                {
                    loc = locuri_rezerva[0];
                    locuri_rezerva = locuri_rezerva.Skip(1).ToArray();
                    loc_gasit();
                }
            }
            else
            {
                loc_lipsa();
            }
        }

        // first page
        private void main_page()
        {
            timer1.Enabled = false;
            this.textBox1.Visible = true;
            this.textBox1.ReadOnly = false;
            this.textBox1.Enabled = true;
            this.ActiveControl = textBox1;
            //this.pictureBox.Visible = true;
            this.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Visible = false;
            this.da_btn.Visible = false;
            this.nu_btn.Visible = false;
            this.ruta_label.Visible = true;
            this.schimb_label.Visible = true;
            this.transport_label.Visible = true;
            this.upload_label.Visible = true;
            this.label1.Text = "Scanare cartelă";
            this.schimba_btn.Visible = true;

            this.textBox1.Location = new System.Drawing.Point(this.Width / 2 - label1.Size.Width / 4, this.Height / 2 + 50);

            this.textBox1.Size = new System.Drawing.Size(label1.Size.Width / 2, 20);
        }

        // nu doresti alocare loc
        private void nu_btn_Click(object sender, EventArgs e)
        {
            if (ruta_transport == "")
            {
                accept = "Respins/Lipsa comanda transport";
            }
            else if (ruta_transport != Form1.ruta)
            {
                accept = "Respins/Transport alta ruta";
            }
            else if (schimb_transport != Form1.sch)
            {
                accept = "Respins/Transport alt schimb";
            }
            else
            {
                accept = "Respins";
            }

            string path = @"C:\Transport\Transport Angajati RESPINS.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(numar_angajat_rezerva + ",");
                writer.Write(numar_cartela + ",");
                writer.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                writer.Write(Form1.ruta + ",");
                writer.Write(Form1.sch + ",");
                writer.Write(accept + ",");
                writer.WriteLine(Form1.tran);
            }

            loc_respins();
        }

        private void scanare_cartela()
        {
            if (alocare_locuri != "DA")
            {
                sqlLiteCon.Open();
                SQLiteDataReader sqlDataReader3 = new SQLiteCommand("SELECT locuri_rezerva FROM autobuz WHERE autobuz='" + Form1.tran + "'", sqlLiteCon).ExecuteReader();
                bool flag3 = sqlDataReader3.Read();
                if (flag3)
                {
                    nr_locuri_rezerva = Convert.ToInt32(sqlDataReader3.GetValue(0).ToString());

                }
                sqlLiteCon.Close();

                locuri_rezerva = new int[nr_locuri_rezerva];

                for (int i = 0, nr = 1; i < nr_locuri_rezerva; i++, nr += 1)
                {
                    locuri_rezerva[i] = nr;
                }
            }

            //
            DataTable dataTable = new DataTable();

            string query = "SELECT loc FROM transport WHERE loc!='' AND ruta='" + Form1.ruta + "' AND schimb='" + Form1.sch + "' AND transport='" + Form1.tran + "' AND SUBSTR(data_transport,0,11)  = DATE('NOW')";
            SQLiteCommand cmd = new SQLiteCommand(query, sqlLiteCon);
            sqlLiteCon.Open();
            SQLiteDataAdapter dadapter = new SQLiteDataAdapter(cmd);
            dadapter.Fill(dataTable);
            sqlLiteCon.Close();
            dadapter.Dispose();

            foreach (DataRow row in dataTable.Rows)
            {
                locAfisat = Convert.ToInt32(row["loc"].ToString());
                locuri_rezerva = locuri_rezerva.Where(val => val != locAfisat).ToArray();
            }
            ///

            timer3.Enabled = false;
            numar_cartela = nr_cartela;
            // selecteaza angajatul
            numar_angajat = "";
            sqlLiteCon.Open();
            SQLiteDataReader sqlDataReader = new SQLiteCommand("SELECT numar FROM personal WHERE numar_cartela='" + nr_cartela + "'", sqlLiteCon).ExecuteReader();
            bool flag1 = sqlDataReader.Read();
            if (flag1)
            {
                numar_angajat = sqlDataReader.GetValue(0).ToString();
                numar_angajat_rezerva = numar_angajat;

            }
            sqlLiteCon.Close();

            // daca are cartela
            if (numar_angajat != "")
            {
                loc = 0;
                sqlLiteCon.Open();
                SQLiteDataReader sqlDataReader2 = new SQLiteCommand("SELECT loc FROM rute WHERE nevoie_transport LIKE 'da' AND loc!='' AND ruta='" + Form1.ruta + "' AND schimb='" + Form1.sch + "' AND DATE('NOW') BETWEEN SUBSTR(data,0,11) AND SUBSTR(data_final,0,11) AND numar_angajat='" + numar_angajat + "'", sqlLiteCon).ExecuteReader();
                bool flag2 = sqlDataReader2.Read();
                if (flag2)
                {
                    loc = Convert.ToInt32(sqlDataReader2.GetValue(0).ToString());
                }
                sqlLiteCon.Close();
                if (loc != 0)
                {
                    timer1.Enabled = true;
                    sqlLiteCon.Open();
                    SQLiteDataReader sqlDataReader3 = new SQLiteCommand("SELECT loc FROM transport WHERE loc!='' AND numar_angajat='" + numar_angajat + "' AND numar_angajat!='' AND ruta='" + Form1.ruta + "' AND schimb='" + Form1.sch + "' AND transport='" + Form1.tran + "'AND SUBSTR(data_transport,0,11)  = DATE('NOW')", sqlLiteCon).ExecuteReader();
                    bool flag3 = sqlDataReader3.Read();
                    if (flag3)
                    {
                        locAfisat = Convert.ToInt32(sqlDataReader3.GetValue(0).ToString());
                    }
                    else
                    {
                        locAfisat = 0;
                    }
                    sqlLiteCon.Close();

                    if (locAfisat != 0) //if (scanati.Contains(numar_angajat))
                    {
                        locAfisat = loc;
                        loc_afisat();
                    }
                    else
                    {
                        loc_gasit();
                    }
                }
                else // daca se scaneaza a doua oara dupa ce l-ai acceptat
                {
                    sqlLiteCon.Open();
                    SQLiteDataReader sqlDataReader3 = new SQLiteCommand("SELECT loc FROM transport WHERE loc!='' AND numar_angajat='" + numar_angajat + "' AND numar_angajat!='' AND ruta='" + Form1.ruta + "' AND schimb='" + Form1.sch + "' AND transport='" + Form1.tran + "'AND SUBSTR(data_transport,0,11)  = DATE('NOW')", sqlLiteCon).ExecuteReader();
                    bool flag3 = sqlDataReader3.Read();
                    if (flag3)
                    {
                        locAfisat = Convert.ToInt32(sqlDataReader3.GetValue(0).ToString());
                    }
                    else
                    {
                        locAfisat = 0;
                    }
                    sqlLiteCon.Close();
                    if (locAfisat != 0)
                    {
                        timer1.Enabled = true;
                        loc_afisat();
                    }
                    else
                    {
                        loc_negasit();
                    }
                }
            }
            else // daca nu are cartela alocata
            {
                cartela_nealocata();
            }
        }

        private void alocare_loc()
        {
            timer3.Enabled = false;
            numar_cartela = this.textBox1.Text;

            // verifica locuri autobuz (sterge locurile ocupare din array)

            DataTable dataTable = new DataTable();

            string query = "SELECT loc FROM transport WHERE loc!='' AND ruta='" + Form1.ruta + "' AND schimb='" + Form1.sch + "' AND transport='" + Form1.tran + "' AND SUBSTR(data_transport,0,11)  = DATE('NOW')";
            SQLiteCommand cmd = new SQLiteCommand(query, sqlLiteCon);
            sqlLiteCon.Open();
            SQLiteDataAdapter dadapter = new SQLiteDataAdapter(cmd);
            dadapter.Fill(dataTable);
            sqlLiteCon.Close();
            dadapter.Dispose();

            foreach (DataRow row in dataTable.Rows)
            {
                locAfisat = Convert.ToInt32(row["loc"].ToString());
                locuri_bus = locuri_bus.Where(val => val != locAfisat).ToArray();
                locuri_rezerva = locuri_rezerva.Where(val => val != locAfisat).ToArray();
            }

            numar_angajat = "";
            negasit = "";
            loc_gasit_deja = 0;

            sqlLiteCon.Open();
            SQLiteDataReader sqlDataReader = new SQLiteCommand("SELECT numar FROM personal WHERE numar_cartela='" + this.textBox1.Text + "'", sqlLiteCon).ExecuteReader();
            bool flag1 = sqlDataReader.Read();
            if (flag1)
            {
                numar_angajat = sqlDataReader.GetValue(0).ToString();
                numar_angajat_rezerva = numar_angajat;

            }
            sqlLiteCon.Close();

            sqlLiteCon.Open();
            SQLiteDataReader sqlDataReader1 = new SQLiteCommand("SELECT transport.ruta, transport.transport, transport.schimb FROM personal LEFT JOIN transport ON transport.numar_angajat=personal.numar WHERE personal.numar_cartela='" + this.textBox1.Text + "' AND transport.ruta='" + Form1.ruta + "' AND transport.schimb='" + Form1.sch + "' AND transport.transport='" + Form1.tran + "'", sqlLiteCon).ExecuteReader();
            bool flag2 = sqlDataReader1.Read();
            if (flag2)
            {
                ruta = sqlDataReader1.GetValue(0).ToString();
                transport = sqlDataReader1.GetValue(1).ToString();
                schimb = sqlDataReader1.GetValue(2).ToString();
            }
            sqlLiteCon.Close();

            sqlLiteCon.Open();
            SQLiteDataReader sqlDataReader2 = new SQLiteCommand("SELECT loc FROM transport WHERE loc!='' AND numar_angajat='" + numar_angajat + "' AND numar_angajat!='' AND ruta='" + Form1.ruta + "' AND schimb='" + Form1.sch + "' AND transport='" + Form1.tran + "'AND SUBSTR(data_transport,0,11)  = DATE('NOW')", sqlLiteCon).ExecuteReader();
            bool flag3 = sqlDataReader2.Read();
            if (flag3)
            {
                locAfisat = Convert.ToInt32(sqlDataReader2.GetValue(0).ToString());
                locuri_bus = locuri_bus.Where(val => val != locAfisat).ToArray();
            }
            else
            {
                locAfisat = 0;
            }
            sqlLiteCon.Close();

            // verifica daca cartela este alocata unui angajat si daca acesta nu are loc ocupat deja pe ziua curenta
            if (numar_angajat != "")
            {
                if (ruta == Form1.ruta && transport == Form1.tran && schimb == Form1.sch && locAfisat != 0)
                {
                    timer1.Enabled = true;
                    loc_afisat();
                    loc_gasit_deja = 1;
                }

                numar_angajat = "";

                sqlLiteCon.Open();
                SQLiteDataReader sqlDataReader3 = new SQLiteCommand("SELECT personal.numar FROM personal LEFT JOIN rute ON rute.numar_angajat=personal.numar WHERE rute.nevoie_transport LIKE 'da' AND rute.ruta='" + Form1.ruta + "' AND rute.schimb='" + Form1.sch + "' AND CURRENT_TIMESTAMP BETWEEN rute.data AND rute.data_final AND personal.numar_cartela='" + this.textBox1.Text + "'", sqlLiteCon).ExecuteReader();
                bool flag4 = sqlDataReader3.Read();
                if (flag4)
                {
                    numar_angajat = sqlDataReader3.GetValue(0).ToString();
                }
                sqlLiteCon.Close();

                sqlLiteCon.Open();
                SQLiteDataReader sqlDataReader4 = new SQLiteCommand("SELECT transport.ruta, transport.transport, transport.schimb FROM personal LEFT JOIN transport ON transport.numar_angajat=personal.numar LEFT JOIN rute ON rute.numar_angajat=personal.numar WHERE rute.nevoie_transport LIKE 'da' AND rute.ruta='" + Form1.ruta + "' AND transport.schimb='" + Form1.sch + "' AND transport.transport='" + Form1.tran + "' AND CURRENT_TIMESTAMP BETWEEN rute.data AND rute.data_final AND personal.numar_cartela='" + this.textBox1.Text + "'", sqlLiteCon).ExecuteReader();
                bool flag5 = sqlDataReader4.Read();
                if (flag5)
                {
                    ruta = sqlDataReader4.GetValue(0).ToString();
                    transport = sqlDataReader4.GetValue(1).ToString();
                    schimb = sqlDataReader4.GetValue(2).ToString();
                }
                sqlLiteCon.Close();

                sqlLiteCon.Open();
                SQLiteDataReader sqlDataReader5 = new SQLiteCommand("SELECT loc FROM transport WHERE numar_angajat='" + numar_angajat + "' AND ruta='" + Form1.ruta + "' AND schimb='" + Form1.sch + "' AND transport='" + Form1.tran + "' AND SUBSTR(data_transport,0,11)  = DATE('NOW')", sqlLiteCon).ExecuteReader();
                bool flag6 = sqlDataReader5.Read();
                if (flag6)
                {
                    locAfisat = Convert.ToInt32(sqlDataReader5.GetValue(0).ToString());
                    locuri_bus = locuri_bus.Where(val => val != locAfisat).ToArray();
                }
                else
                {
                    locAfisat = 0;
                }
                sqlLiteCon.Close();

                // alocare loc autobuz daca persoana nu are loc alocat deja pe ziua curenta
                if (numar_angajat != "")
                {
                    if (ruta == Form1.ruta && transport == Form1.tran && schimb == Form1.sch && locAfisat != 0)
                    {
                        timer1.Enabled = true;
                        loc_afisat();
                    }
                    else
                    {
                        if (locuri_bus.Length != 0)
                        {
                            loc = locuri_bus[0];
                            locuri_bus = locuri_bus.Skip(1).ToArray();
                            timer1.Enabled = true;
                            loc_gasit();
                        }
                        else
                        {
                            loc_negasit();
                        }
                    }
                }
                else
                {
                    if (loc_gasit_deja != 1)
                    {
                        loc_negasit();
                    }
                }
            }
            else // daca cartela nu este alocata
            {
                if (Form1.ruta.Contains("Collect"))
                {
                    sqlLiteCon.Open();
                    SQLiteDataReader sqlDataReader3 = new SQLiteCommand("SELECT loc, ruta, transport, schimb FROM transport WHERE numar_cartela='" + this.textBox1.Text + "' AND ruta='" + Form1.ruta + "' AND schimb='" + Form1.sch + "' AND transport='" + Form1.tran + "' AND SUBSTR(data_transport,0,11)  = DATE('NOW')", sqlLiteCon).ExecuteReader();
                    bool flag4 = sqlDataReader3.Read();
                    if (flag4)
                    {
                        ruta = sqlDataReader3.GetValue(1).ToString();
                        transport = sqlDataReader3.GetValue(2).ToString();
                        schimb = sqlDataReader3.GetValue(3).ToString();
                        locAfisat = Convert.ToInt32(sqlDataReader3.GetValue(0).ToString());
                        locuri_bus = locuri_bus.Where(val => val != locAfisat).ToArray();
                    }
                    else
                    {
                        locAfisat = 0; ;
                    }
                    sqlLiteCon.Close();

                    if (ruta == Form1.ruta && transport == Form1.tran && schimb == Form1.sch && locAfisat != 0)
                    {
                        timer1.Enabled = true;
                        loc_afisat();
                        loc_gasit_deja = 1;
                    }
                    else
                    {
                        negasit = "DA";
                        timer1.Enabled = true;

                        if (locuri_bus.Length != 0)
                        {
                            loc = locuri_bus[0];
                            locuri_bus = locuri_bus.Skip(1).ToArray();
                            timer1.Enabled = true;
                            loc_gasit();
                        }
                        else
                        {
                            loc_liber = loc_liber + 1;
                            if (locuri_rezerva.Length != 0)
                            {
                                if (loc_liber <= nr_locuri_rezerva)
                                {
                                    loc = locuri_rezerva[0];
                                    locuri_rezerva = locuri_rezerva.Skip(1).ToArray();
                                    loc_gasit();
                                }
                            }
                            else
                            {
                                loc_lipsa();
                            }
                        }
                    }
                }
                else
                {
                    cartela_nealocata();
                }
            }
        }

        // loc existent in bd si se afiseaza
        private void loc_afisat()
        {
            this.BackColor = System.Drawing.Color.Green;
            this.ActiveControl = label1;

            this.label2.Visible = false;
            this.textBox1.Enabled = false;

            this.label1.Text = "\r\n" + "Vă rugăm ocupați locul:";
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Visible = true;
            this.label2.Text = locAfisat.ToString();
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.da_btn.Visible = false;
            this.nu_btn.Visible = false;
            this.textBox1.Visible = false;
            //this.pictureBox.Visible = false;
            this.ruta_label.Visible = false;
            this.schimb_label.Visible = false;
            this.transport_label.Visible = false;
            this.upload_label.Visible = false;
            this.schimba_btn.Visible = false;
        }

        // loc nou alocat angajatului
        private void loc_gasit()
        {
            this.BackColor = System.Drawing.Color.Green;
            this.ActiveControl = label1;

            this.label2.Visible = false;
            this.textBox1.Enabled = false;

            this.label1.Text = "\r\n" + "Vă rugăm ocupați locul:";
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Visible = true;
            this.label2.Text = loc.ToString();
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.da_btn.Visible = false;
            this.nu_btn.Visible = false;
            this.textBox1.Visible = false;
            //this.pictureBox.Visible = false;
            this.ruta_label.Visible = false;
            this.schimb_label.Visible = false;
            this.transport_label.Visible = false;
            this.upload_label.Visible = false;
            this.schimba_btn.Visible = false;

            if (negasit == "DA")
            {
                string path = @"C:\Transport\Transport Angajati NEGASIT.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.Write(",");
                    writer.Write(numar_cartela + ",");
                    writer.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                    writer.Write(Form1.ruta + ",");
                    writer.Write(Form1.sch + ",");
                    writer.Write(loc.ToString() + ",");
                    writer.Write("Cartela nealocata,");
                    writer.WriteLine(Form1.tran);
                }

                sqlLiteCon.Open();
                new SQLiteCommand(string.Concat(new string[]
                                {
                               "INSERT INTO transport (numar_angajat, numar_cartela, data_transport, ruta, schimb, loc, transport) VALUES ('",
                                "",
                                "', '",
                                numar_cartela,
                                "', '",
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                "', '",
                                Form1.ruta,
                                "', '",
                                Form1.sch,
                                "', '",
                                loc.ToString(),
                                "', '",
                                Form1.tran,
                                "')"
                                }), sqlLiteCon).ExecuteNonQuery();
                sqlLiteCon.Close();
            }
            else
            {
                if (accept == "Acceptat")
                {
                    if (ruta_transport == "")
                    {
                        accept = "Acceptat/Lipsa comanda transport";
                    }
                    else if (ruta_transport != Form1.ruta)
                    {
                        accept = "Acceptat/Transport alta ruta";
                    }
                    else if (schimb_transport != Form1.sch)
                    {
                        accept = "Acceptat/Transport alt schimb";
                    }
                    else
                    {
                        accept = "Acceptat";
                    }

                    string path = @"C:\Transport\Transport Angajati ACCEPTAT.txt";
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.Write(numar_angajat_rezerva + ",");
                        writer.Write(numar_cartela + ",");
                        writer.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                        writer.Write(Form1.ruta + ",");
                        writer.Write(Form1.sch + ",");
                        writer.Write(loc.ToString() + ",");
                        writer.Write(accept + ",");
                        writer.WriteLine(Form1.tran);
                    }

                    sqlLiteCon.Open();
                    new SQLiteCommand(string.Concat(new string[]
                                    {
                               "INSERT INTO transport (numar_angajat, numar_cartela, data_transport, ruta, schimb, loc, transport) VALUES ('",
                                numar_angajat_rezerva,
                                "', '",
                                numar_cartela,
                                "', '",
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                "', '",
                                Form1.ruta,
                                "', '",
                                Form1.sch,
                                "', '",
                                loc.ToString(),
                                "', '",
                                Form1.tran,
                                "')"
                                }), sqlLiteCon).ExecuteNonQuery();
                    sqlLiteCon.Close();
                }
                else
                {
                    /*if (!(scanati.Contains(numar_angajat)))
                    {
                        scanati.Add(numar_angajat);
                    }*/

                    string path = @"C:\Transport\Transport Angajati GASIT.txt";
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.Write(numar_angajat + ",");
                        writer.Write(numar_cartela + ",");
                        writer.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                        writer.Write(Form1.ruta + ",");
                        writer.Write(Form1.sch + ",");
                        writer.Write(loc.ToString() + ",");
                        writer.WriteLine(Form1.tran);
                    }

                    sqlLiteCon.Open();
                    new SQLiteCommand(string.Concat(new string[]
                                    {
                               "INSERT INTO transport (numar_angajat, numar_cartela, data_transport, ruta, schimb, loc, transport) VALUES ('",
                                numar_angajat,
                                "', '",
                                numar_cartela,
                                "', '",
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                "', '",
                                Form1.ruta,
                                "', '",
                                Form1.sch,
                                "', '",
                                loc.ToString(),
                                "', '",
                                Form1.tran,
                                "')"
                                }), sqlLiteCon).ExecuteNonQuery();
                    sqlLiteCon.Close();
                }
            }

            accept = "";
        }

        // doresti sa aloci loc nou, dar nu mai sunt libere
        private void loc_lipsa()
        {
            this.textBox1.Enabled = false;

            this.BackColor = System.Drawing.Color.Red;
            this.label1.Text = "Ne pare rău dar nu mai sunt locuri libere în autobuz.";
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Visible = false;
            this.da_btn.Visible = false;
            this.nu_btn.Visible = false;
            this.textBox1.Visible = false;
            //this.pictureBox.Visible = false;
            this.ruta_label.Visible = false;
            this.schimb_label.Visible = false;
            this.transport_label.Visible = false;
            this.upload_label.Visible = false;
            this.schimba_btn.Visible = false;

            if (negasit == "DA")
            {
                if (ruta_transport == "")
                {
                    accept = "Lipsa comanda transport";
                }
                else if (ruta_transport != Form1.ruta)
                {
                    accept = "Transport alta ruta";
                }
                else if (schimb_transport != Form1.sch)
                {
                    accept = "Transport alt schimb";
                }
                else
                {
                    accept = "Locuri indisponibile";
                }
                string path = @"C:\Transport\Transport Angajati LIPSA NEGASIT.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.Write(",");
                    writer.Write(numar_cartela + ",");
                    writer.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                    writer.Write(Form1.ruta + ",");
                    writer.Write(Form1.sch + ",");
                    writer.Write(accept + "/cartela nealocata,");
                    writer.WriteLine(Form1.tran);
                }
            }
            else
            {
                if (ruta_transport == "")
                {
                    accept = "Lipsa comanda transport";
                }
                else if (ruta_transport != Form1.ruta)
                {
                    accept = "Transport alta ruta";
                }
                else if (schimb_transport != Form1.sch)
                {
                    accept = "Transport alt schimb";
                }
                else
                {
                    accept = "Locuri indisponibile";
                }
                string path = @"C:\Transport\Transport Angajati LIPSA GASIT.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.Write(numar_angajat_rezerva + ",");
                    writer.Write(numar_cartela + ",");
                    writer.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ",");
                    writer.Write(Form1.ruta + ",");
                    writer.Write(Form1.sch + ",");
                    writer.Write(accept + ",");
                    writer.WriteLine(Form1.tran);
                }
            }
        }

        // soferul nu doreste sa aloce loc calatorului
        private void loc_respins()
        {
            timer1.Enabled = true;
            this.textBox1.Enabled = false;

            this.BackColor = System.Drawing.Color.Red;
            this.label1.Text = "Ne pare rău dar șoferul nu v-a aprobat loc în autobuz." + "\n" + "Vă rugăm părăsiți autobuzul.";
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Visible = false;
            this.da_btn.Visible = false;
            this.nu_btn.Visible = false;
            this.textBox1.Visible = false;
            //this.pictureBox.Visible = false;
            this.ruta_label.Visible = false;
            this.schimb_label.Visible = false;
            this.transport_label.Visible = false;
            this.upload_label.Visible = false;
            this.schimba_btn.Visible = false;

        }

        // cartela nu este alocata
        private void cartela_nealocata()
        {
            this.ActiveControl = label1;
            timer1.Enabled = true;
            this.textBox1.Enabled = false;

            this.BackColor = System.Drawing.Color.OrangeRed;
            this.label1.Text = "Cartelă nealocată!" + "\r\n" + "Vă rugăm luați legătura cu HR.";
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Visible = false;
            this.da_btn.Visible = false;
            this.nu_btn.Visible = false;
            this.textBox1.Visible = false;
            //this.pictureBox.Visible = false;
            this.ruta_label.Visible = false;
            this.schimb_label.Visible = false;
            this.transport_label.Visible = false;
            this.upload_label.Visible = false;
            this.schimba_btn.Visible = false;
        }

        // nu mai sunt locuri libere, se poate adauga un loc din cele de rezerva daca este disponibil
        private void loc_negasit()
        {
            DateTime lastSunday = DateTime.Now.AddDays(-1);
            while (lastSunday.DayOfWeek != DayOfWeek.Sunday)
            {
                lastSunday = lastSunday.AddDays(-1);
            }
            string lastSunday2 = lastSunday.ToString("yyyy-MM-dd 23:59:59");

            sqlLiteCon.Open();
            SQLiteDataReader sqlDataReader = new SQLiteCommand("SELECT ruta, schimb FROM rute WHERE numar_angajat ='" + numar_angajat + "' AND data >'" + lastSunday2 + "'", sqlLiteCon).ExecuteReader();
            bool flag = sqlDataReader.Read();
            if (flag)
            {
                ruta_transport = sqlDataReader.GetValue(0).ToString();
                schimb_transport = sqlDataReader.GetValue(1).ToString();
            }
            sqlLiteCon.Close();

            if (ruta_transport == "")
            {
                this.label1.Text = "Nu există comandă de transport!" + "\r\n" + "Doriți să alocați un loc de rezervă?";
            }
            else if (ruta_transport == Form1.ruta + " 2")
            {
                this.label1.Text = "Transport alocat în autobuzul secundar!" + "\r\n" + "Doriți să alocați un loc de rezervă?";
            }
            else if (ruta_transport + " 2" == Form1.ruta)
            {
                this.label1.Text = "Transport alocat în autobuzul principal!" + "\r\n" + "Doriți să alocați un loc de rezervă?";
            }
            else if (ruta_transport != Form1.ruta)
            {
                this.label1.Text = "Transport alocat pe alta rută! (" + ruta_transport + ")" + "\r\n" + "Doriți să alocați un loc de rezervă?";
            }
            else if (schimb_transport != Form1.sch)
            {
                this.label1.Text = "Transport alocat pe alt schimb! (" + schimb_transport + ")" + "\r\n" + "Doriți să alocați un loc de rezervă?";
            }
            else
            {
                this.label1.Text = "Loc nealocat!" + "\r\n" + "Doriți să alocați un loc nou?";
            }

            this.ActiveControl = label1;
            this.BackColor = System.Drawing.Color.Yellow;
            //this.label1.Text = "Loc nealocat!" + "\r\n" + "Doriți să alocați un loc nou?";
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.da_btn.Visible = true;
            this.nu_btn.Visible = true;
            this.da_btn.Size = new System.Drawing.Size(label1.Size.Width / 2, label1.Size.Width / 4);
            this.nu_btn.Size = new System.Drawing.Size(label1.Size.Width / 2, label1.Size.Width / 4);
            this.da_btn.Location = new System.Drawing.Point(this.Width / 2 - da_btn.Size.Width, this.Height / 2);
            this.nu_btn.Location = new System.Drawing.Point(this.Width / 2, this.Height / 2);
            this.textBox1.Visible = false;
            //this.pictureBox.Visible = false;

            this.textBox1.Enabled = false;

            this.label2.Visible = false;
            this.ruta_label.Visible = false;
            this.schimb_label.Visible = false;
            this.transport_label.Visible = false;
            this.upload_label.Visible = false;
            this.schimba_btn.Visible = false;
        }

        // scanare cartela
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            nr_cartela = textBox1.Text;
            if (e.KeyCode == Keys.Enter)
            {
                //alocare_loc();
                scanare_cartela();
                textBox1.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.R))
            {
                Form1.cmd = "DA";
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // schimbare setari autobuz
        private void schimba_btn_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }
    }
}
