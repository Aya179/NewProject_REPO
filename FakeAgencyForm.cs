using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject
{
    public partial class FakeAgencyForm : Form
    {
        public FakeAgencyForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6H2DVCG;Initial Catalog=Syrian_Bar_DB;Integrated Security=True");

        private void FakeAgencyForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select DISTINCt f.DATE,f.USER_NAME,A.REG_NUM ,A.SERIAL_NUMBER , A.SALES_MAN From FORGED_AGENCY f,AGENCY A  Where A.STAT='مزورة' AND f.AGENCY_CODE=A.TYPE AND f.DATE=a.AGENCY_DATE AND f.DATE BETWEEN @Date1 AND @Date2 ", con);
            cmd.Parameters.AddWithValue("Date1", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("Date2", dateTimePicker1.Value);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }
    }
}
