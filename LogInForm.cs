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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {

                SqlConnection con = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=Syrian_Bar_DB;Integrated Security=True");
                String Query = "SELECT * From USERS Where USER_NAME ='"+UserName.Text.Trim()+ "' AND  PASSWORD ='"+ Password.Text.Trim() + "'";
                SqlDataAdapter sql = new SqlDataAdapter(Query,con);
                DataTable data = new DataTable();
                sql.Fill(data);
                if(data.Rows.Count==1)
                {
                    Main main = new Main();
                    this.Hide();
                    main.Show();
                }
                    

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool IsValid() 
        {
            if(UserName.Text.TrimStart()==String.Empty)
            {
                MessageBox.Show("الرجاء إدخال اسم المستخدم");
                return false;
            }

            else if (Password.Text.TrimStart() == String.Empty)
            {
                MessageBox.Show("الرجاء إدخال كلمة المرور");
                return false;
            }


            return true;
        }
    }
}
