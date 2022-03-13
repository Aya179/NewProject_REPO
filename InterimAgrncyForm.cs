using Microsoft.VisualBasic;
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
    public partial class InterimAgrncyForm : Form
    {
        public InterimAgrncyForm()
        {
            InitializeComponent();
        }
        Syrian_Bar_DBEntities db = new Syrian_Bar_DBEntities();
        AGENCY agency = new AGENCY();
        SqlConnection con = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=Syrian_Bar_DB;Integrated Security=True");
        public static InterimAgrncyForm instace;


        public InterimAgrncyForm(String name)
        {
            AGENCY[] arr = new AGENCY[10];

            agency = db.AGENCY.Where(b=>b.AGENT_NAME_1==name).FirstOrDefault();
             String agent= agency.AGENT_NAME_1;
            arr[0] = agency;
            dataGridView1.DataSource = arr;
            //MessageBox.Show("name is" + agency);
            //SqlCommand cmd = new SqlCommand("Select SERIAL_NUMBER,REG_NUM,TYPE,SALES_MAN,UESER_NAME, ENTRUSTED_NAME_1, ENTRUSTED_NAME_2, ENTRUSTED_NAME_3, ENTRUSTED_NAME_4, ENTRUSTED_NAME_5,AGENCY_DATE From  AGENCY Where AGENT_NAME_1=@name2 ", con);

            //cmd.Parameters.AddWithValue("name2", agent);
            //con.Open();
            //SqlDataAdapter sad = new SqlDataAdapter(cmd);
            //DataTable data = new DataTable();
            //sad.Fill(data);
            
            //cmd.ExecuteNonQuery();
            //Close();

        }

       

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SearchForm search=  new SearchForm();
            //search.MdiParent = this;
            search.Dock = DockStyle.Fill;
            search.Show();
        }

        private void InterimAgrncyForm_Load(object sender, EventArgs e)
        {
               load();
        }

        public void load()
        {
            SqlCommand cmd = new SqlCommand("Select SERIAL_NUMBER,REG_NUM,TYPE,SALES_MAN,UESER_NAME, ENTRUSTED_NAME_1, ENTRUSTED_NAME_2, ENTRUSTED_NAME_3, ENTRUSTED_NAME_4, ENTRUSTED_NAME_5,AGENCY_DATE From  AGENCY", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "الرقم المتسلسل ";
            dataGridView1.Columns[1].HeaderText = "رقم السجل";
            dataGridView1.Columns[2].HeaderText = "نوع الوكالة";
            dataGridView1.Columns[3].HeaderText = "اسم المندوب";
            dataGridView1.Columns[4].HeaderText = " اسم المستخدم";
            dataGridView1.Columns[5].HeaderText = " اسم الموكل";
            dataGridView1.Columns[6].HeaderText = " اسم الموكل";
            dataGridView1.Columns[7].HeaderText = " اسم الموكل";
            dataGridView1.Columns[8].HeaderText = " اسم الموكل";
            dataGridView1.Columns[9].HeaderText = " اسم الموكل";
            dataGridView1.Columns[10].HeaderText = "تاريخ الوكالة";

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Select SERIAL_NUMBER,REG_NUM,TYPE,SALES_MAN,UESER_NAME, ENTRUSTED_NAME_2, ENTRUSTED_NAME_3, ENTRUSTED_NAME_4, ENTRUSTED_NAME_5,AGENCY_DATE From  AGENCY Where AGENCY_DATE BETWEEN @Date1 AND @Date2 ", con);

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("Date1", dateTimePicker1.Value);
            sda.SelectCommand.Parameters.AddWithValue("Date2 ", dateTimePicker2.Value);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
           
            label3.Visible = true;
            var coun = dataGridView1.Rows.Count;
            coun = coun - 1;
            label3.Text = "عدد الوكالات المؤرشفة : " + coun.ToString();
        }

        private void بحثحسباسمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string CLIENT = Interaction.InputBox("الرجاء ادخال اسم الموكل", "بحث عن وكالة ");
            if (CLIENT == null) { return; }
            SqlCommand cmd = new SqlCommand("SELECT CODE ,SERIAL_NUMBER ,REG_NUM ,TYPE ,SALES_MAN ,UESER_NAME ,ENTRUSTED_NAME_1 ,ENTRUSTED_NAME_2,ENTRUSTED_NAME_3,ENTRUSTED_NAME_4,ENTRUSTED_NAME_5,EDITOR ,AGENCY_DATE FROM AGENCY WHERE CONVERT(datetime, AGENCY_DATE, 104) BETWEEN @DATE1 AND @DATE2  AND ENTRUSTED_NAME_1 LIKE @ENTRUSTED_NAME_1 or ENTRUSTED_NAME_2 LIKE @ENTRUSTED_NAME_2 or ENTRUSTED_NAME_3 LIKE @ENTRUSTED_NAME_3 or ENTRUSTED_NAME_4 LIKE @ENTRUSTED_NAME_4 or ENTRUSTED_NAME_5 LIKE @ENTRUSTED_NAME_5 ORDER BY AGENCY_DATE", con);

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("@DATE1", dateTimePicker1.Value);
            sda.SelectCommand.Parameters.AddWithValue("@DATE2 ", dateTimePicker2.Value);
            sda.SelectCommand.Parameters.AddWithValue("@ENTRUSTED_NAME_1 ", "%" + CLIENT + "%");
            sda.SelectCommand.Parameters.AddWithValue("@ENTRUSTED_NAME_2 ", "%" + CLIENT + "%");
            sda.SelectCommand.Parameters.AddWithValue("@ENTRUSTED_NAME_3 ", "%" + CLIENT + "%");
            sda.SelectCommand.Parameters.AddWithValue("@ENTRUSTED_NAME_4 ", "%" + CLIENT + "%");
            sda.SelectCommand.Parameters.AddWithValue("@ENTRUSTED_NAME_5", "%" + CLIENT + "%");


            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            label3.Visible = true;
            var coun = dataGridView1.Rows.Count;
            coun = coun - 1;
            label3.Text = "عدد الوكالات المؤرشفة : " + coun.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AgencySearchForm ag= new AgencySearchForm();
            //ag.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }

        private void بحثحسباسمالموكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string CLIENT = Interaction.InputBox("الرجاء ادخال اسم منظم الوكالة", "بحث عن وكالة ");
            if (CLIENT == null) { return; }
            SqlCommand cmd = new SqlCommand("SELECT CODE ,SERIAL_NUMBER ,REG_NUM ,TYPE ,SALES_MAN ,UESER_NAME ,ENTRUSTED_NAME_1 ,EDITOR ,AGENCY_DATE FROM AGENCY WHERE CONVERT(datetime, AGENCY_DATE, 104) BETWEEN @DATE1 AND @DATE2  AND EDITOR LIKE @EDITOR ORDER BY AGENCY_DATE", con);

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("@DATE1", dateTimePicker1.Value);
            sda.SelectCommand.Parameters.AddWithValue("@DATE2 ", dateTimePicker2.Value);
            sda.SelectCommand.Parameters.AddWithValue("@EDITOR ", "%" + CLIENT + "%");



            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            label3.Visible = true;
            var coun = dataGridView1.Rows.Count;
            coun = coun - 1;
            label3.Text = "عدد الوكالات المؤرشفة : " + coun.ToString();
        }

        private void بحثحسباسمالموكلToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string CLIENT = Interaction.InputBox("الرجاء ادخال رقم السجل", "بحث عن وكالة ");
            if (CLIENT == null) { return; }
            SqlCommand cmd = new SqlCommand("SELECT CODE ,SERIAL_NUMBER ,REG_NUM ,TYPE ,SALES_MAN ,UESER_NAME ,ENTRUSTED_NAME_1 ,EDITOR ,AGENCY_DATE FROM AGENCY WHERE CONVERT(datetime, AGENCY_DATE, 104) BETWEEN @DATE1 AND @DATE2 AND REG_NUM = @REG_NUM ORDER BY AGENCY_DATE", con);

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("@DATE1", dateTimePicker1.Value);
            sda.SelectCommand.Parameters.AddWithValue("@DATE2 ", dateTimePicker2.Value);
            sda.SelectCommand.Parameters.AddWithValue("@REG_NUM", CLIENT);



            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            label3.Visible = true;
            var coun = dataGridView1.Rows.Count;
            coun = coun - 1;
            label3.Text = "عدد الوكالات المؤرشفة : " + coun.ToString();
        }

        private void بحثحسباسمالموكلToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string CLIENT = Interaction.InputBox("الرجاء ادخال اسم المندوب", "بحث عن وكالة ");

            if (CLIENT == null) { return; }
            SqlCommand cmd = new SqlCommand("SELECT CODE ,SERIAL_NUMBER ,REG_NUM ,TYPE ,SALES_MAN ,UESER_NAME ,ENTRUSTED_NAME_1 ,EDITOR ,AGENCY_DATE FROM AGENCY WHERE CONVERT(datetime, AGENCY_DATE, 104) BETWEEN @DATE1 AND @DATE2 AND SALES_MAN Like @SALES_MAN ORDER BY AGENCY_DATE", con);

            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.Parameters.AddWithValue("@DATE1", dateTimePicker1.Value);
            sda.SelectCommand.Parameters.AddWithValue("@DATE2 ", dateTimePicker2.Value);
            sda.SelectCommand.Parameters.AddWithValue("@SALES_MAN ", "%" + CLIENT + "%");



            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            label3.Visible = true;
            var coun = dataGridView1.Rows.Count;
            coun = coun - 1;
            label3.Text = "عدد الوكالات المؤرشفة : " + coun.ToString();

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
