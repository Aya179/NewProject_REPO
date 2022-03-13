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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6H2DVCG;Initial Catalog=Syrian_Bar_DB;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == null && textBox4.Text == null)
            {
                return;
            }
            InterimAgrncyForm interim = new InterimAgrncyForm();
            interim.dataGridView1.Rows.Clear();




            SqlCommand cmd = new SqlCommand("SELECT CODE ,SERIAL_NUMBER ,REG_NUM ,TYPE ,SALES_MAN ,UESER_NAME ,ENTRUSTED_NAME_1 ,EDITOR ,AGENCY_DATE FROM AGENCY WHERE CONVERT(datetime, AGENCY_DATE, 104) BETWEEN @DATE1 AND @DATE2  AND ENTRUSTED_NAME_1 LIKE @ENTRUSTED_NAME_1 or ENTRUSTED_NAME_2 LIKE @ENTRUSTED_NAME_2  AND REG_NUM LIKE @REG_NUM ORDER BY AGENCY_DATE", con);

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("@DATE1", dateTimePicker1.Value);
            sda.SelectCommand.Parameters.AddWithValue("@DATE2 ", dateTimePicker2.Value);
            sda.SelectCommand.Parameters.AddWithValue("@ENTRUSTED_NAME_1 ", "%" + textBox4.Text + "%");
            sda.SelectCommand.Parameters.AddWithValue("@ENTRUSTED_NAME_2 ", "%" + textBox4.Text + "%");
            //sda.SelectCommand.Parameters.AddWithValue("@ENTRUSTED_NAME_3 ", "%" + textBox4.Text + "%");
            //sda.SelectCommand.Parameters.AddWithValue("@ENTRUSTED_NAME_4 ", "%" +textBox4.Text  + "%");
            //sda.SelectCommand.Parameters.AddWithValue("@ENTRUSTED_NAME_5", "%" + textBox4.Text + "%");
            //or ENTRUSTED_NAME_3 LIKE @ENTRUSTED_NAME_3 or ENTRUSTED_NAME_4 LIKE @ENTRUSTED_NAME_4 or ENTRUSTED_NAME_5 LIKE @ENTRUSTED_NAME_5
            sda.SelectCommand.Parameters.AddWithValue("@REG_NUM", "%" + textBox3.Text + "%");



            sda.Fill(dt);
            // interim.dataGridView1.DataSource = dt;
            interim.dataGridView1.DataSource = dt;
            con.Close();
            interim.label3.Visible = true;
            var coun = interim.dataGridView1.Rows.Count;
            coun = coun - 1;
            interim.label3.Text = "عدد الوكالات المؤرشفة : " + coun.ToString();
            interim.dateTimePicker1.Value = dateTimePicker1.Value;
            interim.dateTimePicker2.Value = dateTimePicker2.Value;

            interim.Show();

        }
    }
}
