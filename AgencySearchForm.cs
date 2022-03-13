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
    public partial class AgencySearchForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6H2DVCG;Initial Catalog=Syrian_Bar_DB;Integrated Security=True");
        Syrian_Bar_DBEntities db = new Syrian_Bar_DBEntities();
        AGENCY agency = new AGENCY();
        public AgencySearchForm()
        {
            InitializeComponent();
        }

        private void AgencySearchForm_Load(object sender, EventArgs e)
        {
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AGENCY[] arr = new AGENCY[1];
            //String name = textBox1.Text;

            //agency = db.AGENCY.Where(b => b.ENTRUSTED_NAME_1 == name).FirstOrDefault();
            //String agent = agency.ENTRUSTED_NAME_1;
            //arr[0] = agency;
            //dataGridView1.DataSource = arr.ToList();


        }
    }
}
