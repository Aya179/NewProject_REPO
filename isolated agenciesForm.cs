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
    public partial class isolated_agenciesForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=Syrian_Bar_DB;Integrated Security=True");
        public isolated_agenciesForm()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void isolated_agenciesForm_Load(object sender, EventArgs e)
        {
            load();

        }

        public void load()
        {
            SqlCommand cmd = new SqlCommand("Select B.NO , B.DATE ,B.USER_NAME ,A.SERIAL_NUMBER,A.REG_NUM,A.SALES_MAN From DISMISSAL_AGENCY B , AGENCY A Where A.STAT='معزولة'   AND B.AGENCY_CODE=A.TYPE ", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "رقم العزل";
            dataGridView1.Columns[1].HeaderText = "تاريخ العزل";
            dataGridView1.Columns[2].HeaderText = "اسم المستخدم";
            dataGridView1.Columns[3].HeaderText = "الرقم المتسلسل";
            dataGridView1.Columns[4].HeaderText = " رقم السجل";
            dataGridView1.Columns[5].HeaderText = " اسم المندوب";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Select B.NO , B.DATE ,B.USER_NAME ,A.SERIAL_NUMBER,A.REG_NUM,A.SALES_MAN From DISMISSAL_AGENCY B , AGENCY A Where A.STAT='معزولة' AND  B.DATE BETWEEN @Date1 AND @Date2   AND B.AGENCY_CODE=A.TYPE", con);

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("Date1", dateTimePicker2.Value);
            sda.SelectCommand.Parameters.AddWithValue("Date2 ", dateTimePicker1.Value);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
}
