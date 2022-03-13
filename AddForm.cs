using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }
        public String photopathe;
        byte[] binaryphoto;
        Syrian_Bar_DBEntities db = new Syrian_Bar_DBEntities();
        AGENCY agency = new AGENCY();
        BLOCK_AGENCY block = new BLOCK_AGENCY();
        DISMISSAL_AGENCY dISMISSAL = new DISMISSAL_AGENCY();//عزل
        RETIREMENT_AGENCY retirement = new RETIREMENT_AGENCY();//الاعتزال
        FORGED_AGENCY forged = new FORGED_AGENCY();//المزورة


        SqlConnection connection = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=Syrian_Bar_DB;Integrated Security=True");
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Jpegs|*.Jpegs|Png|*.Png|GIF|.*GIF|jpg|.*jpg|jpeg|.*jpeg";
            file.Title = "Select photo";
            if (file.ShowDialog() == DialogResult.OK) 
            {
                pictureBox1.Image = new Bitmap(file.OpenFile());
                photopathe = file.FileName;
                //FileStream fs = new FileStream(photopathe, FileMode.Open);
                //BinaryReader r = new BinaryReader(fs);
                //binaryphoto = r.ReadBytes((int)fs.Length);
                //fs.Close();
               


            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        public bool Is_Empty()
        {

            if (comboBox1.SelectedItem.ToString() == String.Empty)
            {
                MessageBox.Show("الرجاء إدخال نوع الوكالة");
                comboBox1.Focus();
                return false;
            }

            else if (comboBox2.SelectedItem.ToString() == String.Empty)
            {
                MessageBox.Show("الرجاء إدخال نوع الدعوى");
                comboBox2.Focus();
                return false;
            }

            else if (SerialNum.Text.ToString() == String.Empty)
            {
                MessageBox.Show("الرجاء إدخال رقم التسلسل");
                SerialNum.Focus();
                return false;
            }

            else if (recordnum.Text.ToString() == String.Empty)
            {
                MessageBox.Show("الرجاء إدخال رقم السجل");
                recordnum.Focus();
                return false;
            }

            else if (ENTRUSTED_NAME_1.Text.ToString() == String.Empty)
            {
                MessageBox.Show("الرجاء إدخال اسم الموكل");
                ENTRUSTED_NAME_1.Focus();
                return false;
            }

            else if (AgentName.Text.ToString() == String.Empty)
            {
                MessageBox.Show("الرجاء إدخال اسم الوكيل");
                AgentName.Focus();
                return false;
            }

            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("الرجاء إدخال صورة الوكالة");
                return false;
            }

            else if (SaleMan.Text.ToString() == String.Empty)
            {
                MessageBox.Show("الرجاء إدخال اسم المندوب");
                SaleMan.Focus();
                return false;
            }

            else if (Sec_num.Text.ToString() == String.Empty)
            {
                MessageBox.Show("الرجاء إدخال الرقم الأمني");
                Sec_num.Focus();
                return false;
            }

            return true;

        }


        public void reset()
        {
            SerialNum.Text = " ";
            recordnum.Text = "";
            ENTRUSTED_NAME_1.Text = " ";
            ENTRUSTED_NAME_2.Text = " ";
            ENTRUSTED_NAME_3.Text = " ";
            ENTRUSTED_NAME_4.Text = " ";
            ENTRUSTED_NAME_5.Text = " ";
            AgentName.Text = "";
            AgentName_2.Text = "";
            SaleMan.Text = "";
            textBox11.Text = "";
            Sec_num.Text = "";
            pictureBox1.Image = null;

        }


        public void EDIT()
        {
            SqlCommand GSQLCmd = connection.CreateCommand();
            SqlDataReader GDR = null;

            //Image img = pictureBox1.Image;
            //byte[] arr;
            //ImageConverter converter = new ImageConverter();
            //arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            try
            {
                GSQLCmd.Parameters.Clear();
                GSQLCmd.CommandText = "UPDATE AGENCY SET TYPE = @TYPE ,SERIAL_NUMBER = @SERIAL_NUMBER ,REG_NUM = @REG_NUM ,ENTRUSTED_NAME_1 = @ENTRUSTED_NAME_1 ,ENTRUSTED_NAME_2 = @ENTRUSTED_NAME_2 ,ENTRUSTED_NAME_3 = @ENTRUSTED_NAME_3 ,ENTRUSTED_NAME_4 = @ENTRUSTED_NAME_4 ,ENTRUSTED_NAME_5 = @ENTRUSTED_NAME_5 ,AGENT_NAME_1 = @AGENT_NAME_1 ,AGENT_NAME_2 = @AGENT_NAME_2 ,SALES_MAN = @SALES_MAN ,AGENCY_DATE = @AGENCY_DATE ,TYPE_2 = @TYPE_2 ,EDITOR = @EDITOR,SECURITY_NO = @SECURITY_NO WHERE CODE = @CODE";
                GSQLCmd.CommandType = CommandType.Text;
                //GSQLCmd.Parameters.Add("@CODE", SqlDbType.VarChar).Value = TextBox100.Text;
                GSQLCmd.Parameters.Add("@TYPE", SqlDbType.VarChar).Value = comboBox1.Text;
                GSQLCmd.Parameters.Add("@SERIAL_NUMBER", SqlDbType.VarChar).Value = SerialNum.Text;
                GSQLCmd.Parameters.Add("@REG_NUM", SqlDbType.VarChar).Value = recordnum.Text;
                GSQLCmd.Parameters.Add("@ENTRUSTED_NAME_1", SqlDbType.VarChar).Value = ENTRUSTED_NAME_1.Text.ToString();
                GSQLCmd.Parameters.Add("@ENTRUSTED_NAME_2", SqlDbType.VarChar).Value = ENTRUSTED_NAME_2.Text.ToString();
                GSQLCmd.Parameters.Add("@ENTRUSTED_NAME_3", SqlDbType.VarChar).Value = ENTRUSTED_NAME_3.Text.ToString();
                GSQLCmd.Parameters.Add("@ENTRUSTED_NAME_4", SqlDbType.VarChar).Value = ENTRUSTED_NAME_4.Text.ToString();
                GSQLCmd.Parameters.Add("@ENTRUSTED_NAME_5", SqlDbType.VarChar).Value = ENTRUSTED_NAME_5.Text.ToString();
                GSQLCmd.Parameters.Add("@AGENT_NAME_1", SqlDbType.VarChar).Value = AgentName.Text.ToString();
                GSQLCmd.Parameters.Add("@AGENT_NAME_2", SqlDbType.VarChar).Value = AgentName_2.Text.ToString();
                GSQLCmd.Parameters.Add("@SALES_MAN", SqlDbType.VarChar).Value = SaleMan.Text;
                // GSQLCmd.Parameters.Add("@IMAGE", SqlDbType.VarChar).Value = arr;
                if (checkBox1.Checked)
                {
                    GSQLCmd.Parameters.Add("@AGENCY_DATE", SqlDbType.Date).Value = "1900-01-01";
                }
                else
                {
                    GSQLCmd.Parameters.Add("@AGENCY_DATE", SqlDbType.Date).Value = agencyDate.Text;
                }
                GSQLCmd.Parameters.Add("@EDITOR", SqlDbType.VarChar).Value = textBox11.Text;
                GSQLCmd.Parameters.Add("@TYPE_2", SqlDbType.VarChar).Value = comboBox2.Text;
                GSQLCmd.Parameters.Add("@SECURITY_NO", SqlDbType.VarChar).Value = Sec_num.Text;




                if (comboBox2.Text == string.Empty)
                {
                    MessageBox.Show("يرجى اختيار نوع الدعوى");
                    return;
                }
                if (SerialNum.Text == string.Empty)
                {
                    MessageBox.Show("يرجى كتابة الرقم المتسلسل");
                    SerialNum.Focus();
                    return;
                }
                if (recordnum.Text == string.Empty)
                {
                    MessageBox.Show("يرجى كتابة رقم السجل");
                    recordnum.Focus();
                    return;
                }
                if (SaleMan.Text == string.Empty)
                {
                    MessageBox.Show("يرجى كتابة اسم المندوب");
                    SaleMan.Focus();
                    return;
                }
                if (textBox11.Text == string.Empty)
                {
                    MessageBox.Show("يرجى كتابة اسم منظم الوكالة");
                    textBox11.Focus();
                    return;
                }
                if (ENTRUSTED_NAME_1.Text == string.Empty)
                {
                    MessageBox.Show("يرجى كتابة اسم الموكل");
                    ENTRUSTED_NAME_1.Focus();
                    return;
                }
                if (AgentName.Text == string.Empty)
                {
                    MessageBox.Show("يرجى كتابة اسم الوكيل");
                    AgentName.Focus();
                    return;
                }
                GSQLCmd.ExecuteNonQuery();
                MessageBox.Show("تم التعديل");

            }
            
            catch (Exception ex) { }
            connection.Close();
            SerialNum.Focus();
            Close();
            Archive archive1 = new Archive();
            archive1.load();
        }

        public void Type()
        {
            if (comboBoxStat.SelectedItem == "مزورة")
            {
                forged.AGENCY_CODE = comboBox1.SelectedItem.ToString();
                forged.DATE = agencyDate.Value;
                forged.DATE_TODAY = System.DateTime.Now;
                db.FORGED_AGENCY.Add(forged);
                db.SaveChanges();


            }

            else if (comboBoxStat.SelectedItem == "معزولة")
            {
                block.AGENCY_CODE = comboBox1.SelectedItem.ToString();
                block.DATE = agencyDate.Value;
                block.DATE_TODAY = System.DateTime.Now;
                db.BLOCK_AGENCY.Add(block);
                db.SaveChanges();

            }

            else if (comboBoxStat.SelectedItem == "اعتزال")
            {
                retirement.AGENCY_CODE = comboBox1.SelectedItem.ToString();
                retirement.DATE = agencyDate.Value;
                retirement.DATE_TODAY = System.DateTime.Now;
                db.RETIREMENT_AGENCY.Add(retirement);
                db.SaveChanges();

            }

            else if (comboBoxStat.SelectedItem == "منع التصرف")
            {
                dISMISSAL.AGENCY_CODE = comboBox1.SelectedItem.ToString();
                dISMISSAL.DATE = agencyDate.Value;
                dISMISSAL.DATE_TODAY = System.DateTime.Now;
                db.DISMISSAL_AGENCY.Add(dISMISSAL);
                db.SaveChanges();
            }
        }


        public void save()
        {
            if (Is_Empty())
            {
                MemoryStream Stream = new MemoryStream();
                agency.TYPE_2 = comboBox2.SelectedItem.ToString();//نوع الدعوة:صلحية-شرعية...
                agency.TYPE = comboBox1.SelectedItem.ToString();//نوع الوكالة:خاص-عام ...
                agency.SERIAL_NUMBER = Convert.ToInt32(SerialNum.Text.ToString());
                agency.REG_NUM = Convert.ToInt32(recordnum.Text.ToString());//رقم السجل
                agency.ENTRUSTED_NAME_1 = ENTRUSTED_NAME_1.Text.ToString();//اسم الموكل
                agency.ENTRUSTED_NAME_2 = ENTRUSTED_NAME_2.Text.ToString();
                agency.ENTRUSTED_NAME_3 = ENTRUSTED_NAME_3.Text.ToString();
                agency.ENTRUSTED_NAME_4 = ENTRUSTED_NAME_4.Text.ToString();
                agency.ENTRUSTED_NAME_4 = ENTRUSTED_NAME_5.Text.ToString();
                agency.AGENT_NAME_1 = AgentName.Text.ToString();//اسم الوكيل
                agency.AGENT_NAME_1 = AgentName_2.Text.ToString();
                agency.SALES_MAN = SaleMan.Text.ToString();//اسم المندوب
                agency.AGENCY_DATE = agencyDate.Value;//تاريخ الوكالة
                agency.SECURITY_NO = Sec_num.Text.ToString();
                agency.STAT = comboBoxStat.SelectedItem.ToString();//حالة الوكالة: اعتزال-كعزولة-مزورة-منع تصرف
                agency.EDITOR = textBox11.Text.ToString();//منظم الوكالة


                Image img = pictureBox1.Image;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
                agency.IMAGE = arr;
                db.AGENCY.Add(agency);

                Type();
                db.SaveChanges();
                MessageBox.Show(" تم الحفظ");
                reset();

            }
        }

            private void toolStripButton1_Click(object sender, EventArgs e)

        {
            SerialNum.Focus();
            if (SerialNum.Text != null)
            {
                EDIT();
            }
            else
            {
                save();
            }

            //if (Is_Empty())
            //{
            //    MemoryStream Stream = new MemoryStream();
            //    agency.TYPE_2 = comboBox2.SelectedItem.ToString();
            //    agency.TYPE = comboBox1.SelectedItem.ToString();
            //    agency.SERIAL_NUMBER =Convert.ToInt32( SerialNum.Text.ToString());
            //    agency.REG_NUM = Convert.ToInt32(recordnum.Text.ToString());
            //    agency.ENTRUSTED_NAME_1 = ENTRUSTED_NAME_1.Text.ToString();
            //    agency.ENTRUSTED_NAME_2 = ENTRUSTED_NAME_2.Text.ToString();
            //    agency.ENTRUSTED_NAME_3 = ENTRUSTED_NAME_3.Text.ToString();
            //    agency.ENTRUSTED_NAME_4 = ENTRUSTED_NAME_4.Text.ToString();
            //    agency.ENTRUSTED_NAME_4 = ENTRUSTED_NAME_5.Text.ToString();
            //    agency.AGENT_NAME_1 = AgentName.Text.ToString();
            //    agency.AGENT_NAME_1 = AgentName_2.Text.ToString();
            //    agency.SALES_MAN = SaleMan.Text.ToString();
            //    agency.AGENCY_DATE = agencyDate.Value;
            //    agency.SECURITY_NO = Sec_num.Text.ToString();
            //    //agency.STAT = comboBoxStat.SelectedItem.ToString();


            //    Image img = pictureBox1.Image;
            //    byte[] arr;
            //    ImageConverter converter = new ImageConverter();
            //    arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            //    agency.IMAGE = arr;
            //    db.AGENCY.Add(agency);

            //    Type();
            //    db.SaveChanges();
            //    MessageBox.Show(" تم الحفظ");
            //    reset();




        }

        private void button1_Click(object sender, EventArgs e)
        {
                //SER_1 sER_1 = new SER_1();
                //sER_1.Show();
        }
    }

       

    }

