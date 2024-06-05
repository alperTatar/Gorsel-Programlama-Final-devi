using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

```csharp
namespace Uçuş_Rezervasyon_Sistemi
{
    public partial class Uçuş_Arama : Form
    {
        OracleConnection conn;
        OracleDataAdapter da;
        OracleCommandBuilder cb;
        DataSet ds;

        string ordb = Program.ConnStr;

        public Uçuş_Arama()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        private void Uçuş_Arama_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PRO_sehirleri_al";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("sehirler", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader orc = cmd.ExecuteReader();
            List<string> stringtxt = new List<string>();
            while (orc.Read())
            {
                //Console.WriteLine(orc[0]);
                stringtxt.Add((string)orc[0]);
            }
            List<string> distinct = stringtxt.Distinct().ToList();
            foreach (string value in distinct)
            {
                cmb_1.Items.Add(value);
                cmb_2.Items.Add(value);
            }
            orc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmb_1.Text.Equals("") || cmb_2.Text.Equals(""))
                {
                    MessageBox.Show(Program.MessageAlert);
                }
                else
                {
                    dataGridView1.Visible = true;
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "PRO_UÇUŞ_ARA";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("kaynak", cmb_1.SelectedItem.ToString());
                    cmd.Parameters.Add("varış", cmb_2.SelectedItem.ToString());
                    cmd.Parameters.Add("sehirler", OracleDbType.RefCursor, ParameterDirection.Output);
                    da = new OracleDataAdapter(cmd);
                    cb = new OracleCommandBuilder(da);
                    ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    //conn.Close();
                }
            }
            catch
            {
                dataGridView1.Visible = false;
                MessageBox.Show("Yanlış Yerler\nLütfen Doğru Yeri Seçiniz");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Visible = false;
            cmb_1.Text = "";
            cmb_2.Text = "";
        }
    }
}
```