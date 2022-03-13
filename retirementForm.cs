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
    public partial class retirementForm : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=Syrian_Bar_DB;Integrated Security=True");
        public retirementForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


            SqlCommand cmd = new SqlCommand("Select DISTINCT  R.DATE,R.USER_NAME,A.REG_NUM ,A.SERIAL_NUMBER , A.SALES_MAN From RETIREMENT_AGENCY R,AGENCY A  Where A.STAT='اعتزال' AND R.DATE BETWEEN @Date1 AND @Date2   AND R.AGENCY_CODE=A.TYPE", con);
           
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda= new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("Date1", dateTimePicker1.Value);
            sda.SelectCommand.Parameters.AddWithValue("@Date2 ", dateTimePicker2.Value);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
           
             

        }

        private void retirementForm_Load(object sender, EventArgs e)
        {
            load();
        }

        public void load() 
        {
            SqlCommand cmd = new SqlCommand("Select DISTINCT  R.DATE,R.USER_NAME,A.REG_NUM ,A.SERIAL_NUMBER , A.SALES_MAN From RETIREMENT_AGENCY R,AGENCY A  Where A.STAT='اعتزال'  AND R.AGENCY_CODE=A.TYPE ", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "تاريخ";
            dataGridView1.Columns[1].HeaderText = "اسم المستخدم";
            dataGridView1.Columns[2].HeaderText = "رقم السجل";
            dataGridView1.Columns[3].HeaderText = "الرقم التسلسلي";
            dataGridView1.Columns[4].HeaderText = "المندوب";
        }
    }
}
