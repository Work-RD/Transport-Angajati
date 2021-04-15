using System;
using System.Windows.Forms;
using TransportAng.TransportAng;
using TransportAngajati.TransportAng;

namespace TransportAng
{
    static class Program
    {
		/*public static string myConnectionString = string.Concat(new string[]
		{
			"Data Source=",
			SetariInitiale.Default.serverIP,
			",",
			SetariInitiale.Default.portNo,
			";Network Library=DBMSSOCN;Initial Catalog=",
			SetariInitiale.Default.databaseName,
			";User ID=",
			SetariInitiale.Default.dUsername,
			";Password=",
			SetariInitiale.Default.dPassword,
			";"
		});
		[STAThread]*/

		public static string myConnectionString = string.Concat(new string[]
		{
			"server=",
			SetariInitiale.Default.serverIP,
			";uid=bonaofic_",
			SetariInitiale.Default.dUsername,
			";password=",
			SetariInitiale.Default.dPassword,
			";database=bonaofic_",
			SetariInitiale.Default.databaseName,
			";port=",
			SetariInitiale.Default.portNo,
			";"
		});
		public static bool Interflex = SetariInitiale.Default.Interflex;
		[STAThread]
		static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Loading());
        }
    }
}
