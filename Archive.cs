using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;
using Amazon.CloudWatchEvents.Model;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using PdfSharp.Pdf.Actions;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using NPOI.XWPF.UserModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace NewProject
{
    public partial class Archive : Form
    {
        public Archive()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=Syrian_Bar_DB;Integrated Security=True");
        //SqlDataAdapter adapter;
        //DataTable table= new DataTable();
        
        Syrian_Bar_DBEntities db = new Syrian_Bar_DBEntities();




        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           AddForm archive = new AddForm();
          
            //archive.MdiParent = this;
            archive.Dock = DockStyle.Fill;
            archive.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            load();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            AddForm archive = new AddForm();

            archive.Dock = DockStyle.Fill;
            if (dataGridView1.RowCount == 0) return;
            int R = 0;
            R = dataGridView1.CurrentRow.Index;
            dataGridView1.CurrentRow.Selected = true;
            dataGridView1.CurrentCell = dataGridView1[0, R];
            int CODE = (int)dataGridView1[0, R].Value;

            SqlCommand GSQLCmd = con.CreateCommand();
            SqlDataReader GDR = null;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                GSQLCmd.Parameters.Clear();
                GSQLCmd.CommandType = CommandType.Text;
                GSQLCmd.CommandText = "SELECT IMAGE ,TYPE ,SERIAL_NUMBER ,REG_NUM ,ENTRUSTED_NAME_1 ,ENTRUSTED_NAME_2 ,ENTRUSTED_NAME_3 ,ENTRUSTED_NAME_4 ,ENTRUSTED_NAME_5 ,AGENT_NAME_1 ,AGENT_NAME_2 ,SALES_MAN ,AGENCY_DATE ,EDITOR ,CODE ,TYPE_2 ,SECURITY_NO FROM AGENCY WHERE CODE = @CODE";
                GSQLCmd.Parameters.Add("@CODE", SqlDbType.Int).Value = CODE;
                GDR = GSQLCmd.ExecuteReader();

                while (GDR.Read())
                {
                    byte[] myByteArray = (byte[])GDR.GetValue(0);
                    MemoryStream myStream = new MemoryStream(myByteArray, writable: true);
                    myStream.Write(myByteArray, 0, myByteArray.Length);
                    Bitmap FinalImage = new Bitmap(myStream);
                    Bitmap AlteredImage = new Bitmap(FinalImage);
                    archive.pictureBox1.Image = Image.FromStream(myStream);
                    archive.comboBox1.Text = GDR.GetValue(1).ToString();//نوع الوكالة:
                    archive.SerialNum.Text = GDR.GetValue(2).ToString();
                    archive.recordnum.Text = GDR.GetValue(3).ToString();
                    archive.ENTRUSTED_NAME_1.Text = GDR.GetValue(4).ToString();
                    archive.ENTRUSTED_NAME_2.Text = GDR.GetValue(5).ToString();
                    archive.ENTRUSTED_NAME_3.Text = GDR.GetValue(6).ToString();
                    archive.ENTRUSTED_NAME_4.Text = GDR.GetValue(7).ToString();
                    archive.ENTRUSTED_NAME_5.Text = GDR.GetValue(8).ToString();
                    archive.AgentName.Text = GDR.GetValue(9).ToString();
                    archive.AgentName_2.Text = GDR.GetValue(10).ToString();
                    archive.SaleMan.Text = GDR.GetValue(11).ToString();
                    if (GDR.GetValue(12).ToString() == null)
                    {
                        archive.checkBox1.Checked = true;
                    }
                    else
                    {
                        archive.agencyDate.Text = GDR.GetValue(12).ToString();
                    }
                    archive.textBox11.Text = GDR.GetValue(13).ToString();//editor
                    archive.textBox100.Text = GDR.GetValue(14).ToString();//CODE
                    archive.Sec_num.Text = GDR.GetValue(16).ToString();
                    archive.comboBox2.Text = GDR.GetValue(15).ToString();//نوع الدعوى:
                }

                GDR.Close();
            }
            catch (Exception ex2)
            {
                ProjectData.SetProjectError(ex2);
                Exception ex = ex2;
                ProjectData.ClearProjectError();
            }
            con.Close();
            
            load();

        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            AddForm add = new AddForm();
            Graphics graphics = e.Graphics;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;

          
        }

        private void myPrintDocument2_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            AddForm add = new AddForm();
            Bitmap myBitmap1 = new Bitmap(add.pictureBox1.Width, add.pictureBox1.Height);
            add.pictureBox1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, add.pictureBox1.Width, add.pictureBox1.Height));
            e.Graphics.DrawImage(myBitmap1, 0, 0);
            myBitmap1.Dispose();
        }

        

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            

            if (dataGridView1.RowCount == 0)
            {
                return;
            }
            int R = 0;
            R = dataGridView1.CurrentRow.Index;
            dataGridView1.CurrentRow.Selected = true;
            dataGridView1.CurrentCell = dataGridView1[0, R];
            int CODE_2 = Convert.ToInt32(dataGridView1[0, R].Value.ToString());

            SqlCommand GSQLCmd = con.CreateCommand();
            SqlDataReader GDR = null;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                GSQLCmd.Parameters.Clear();
                GSQLCmd.CommandType = CommandType.Text;
                GSQLCmd.CommandText = "SELECT IMAGE FROM AGENCY WHERE CODE = @CODE";
                GSQLCmd.Parameters.Add("@CODE", SqlDbType.Int).Value = CODE_2;
                GDR = GSQLCmd.ExecuteReader();
                while (GDR.Read()) 

                {
                    AddForm add = new AddForm();
                    byte[] myByteArray = (byte[])GDR.GetValue(0);
                    MemoryStream myStream = new MemoryStream(myByteArray, writable: true);
                    myStream.Write(myByteArray, 0, myByteArray.Length);
                    Bitmap FinalImage = new Bitmap(myStream);
                    Bitmap AlteredImage = new Bitmap(FinalImage);
                    add.pictureBox1.Image = Image.FromStream(myStream);

                    System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
                    PrintDialog myPrinDialog1 = new PrintDialog();
                    myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);
                    myPrinDialog1.Document = myPrintDocument1;
                    if (myPrinDialog1.ShowDialog() == DialogResult.OK)
                    {
                        myPrintDocument1.Print();
                    }

                }

                GDR.Close();


            }
            catch (Exception ex2)
            {
                ProjectData.SetProjectError(ex2);
                Exception ex = ex2;
                ProjectData.ClearProjectError();
            }
            //System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
            //PrintDialog myPrinDialog1 = new PrintDialog();
            //myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);
            //myPrinDialog1.Document = myPrintDocument1;
            //if (myPrinDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    myPrintDocument1.Print();
            //}







        }
        public void ExportToPDF(DataGridView dgv,String FileName) 
        {
            iTextSharp.text.pdf.BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            iTextSharp.text.pdf.PdfPTable pdfTable = new PdfPTable(dgv.Rows.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            //pdfTable.HorizontalAlignmen
            pdfTable.DefaultCell.BorderWidth = 1;
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf,10,iTextSharp.text.Font.NORMAL);

            //Add Header
            foreach(DataGridViewColumn column in dgv.Columns) 
            {
                iTextSharp.text.pdf.PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);

            }

            //Add Data Rows
            foreach(DataGridViewRow row  in dgv.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(new iTextSharp.text.Phrase(cell.Value.ToString(),text));
                }

            }

            var save = new SaveFileDialog();
            save.FileName = FileName;
            save.DefaultExt = ".pdf";

            if (save.ShowDialog() == DialogResult.OK) 
            {
                using (FileStream file=new FileStream(save.FileName, FileMode.Create)) 
                {
                    iTextSharp.text.pdf.PdfDocument pdf = new iTextSharp.text.pdf.PdfDocument();

                    PdfWriter.GetInstance(pdf, file);
                    pdf.Open();
                    pdf.Add(pdfTable);
                    pdf.Close();
                    file.Close();
                }
            }
            

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void load()
        {
            SqlCommand cmd = new SqlCommand("Select  SERIAL_NUMBER , REG_NUM, TYPE,SALES_MAN,UESER_NAME,AGENCY_DATE ,TYPE_2,ENTRUSTED_NAME_1,ENTRUSTED_NAME_2 ,ENTRUSTED_NAME_3,ENTRUSTED_NAME_4,ENTRUSTED_NAME_5 ,AGENT_NAME_1, AGENT_NAME_1,AGENT_NAME_2,AGENT_NAME_3,AGENT_NAME_4,AGENT_NAME_5  FROM AGENCY ", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;

         
        }

        private void Archive_Load(object sender, EventArgs e)
        {
            load();
        }


        public void display() 
        {


        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;
            int R = 0;
            R = dataGridView1.CurrentRow.Index;
            string CODE = dataGridView1[0, R].Value.ToString();
            DialogResult d;
          d=  MessageBox.Show("هل انت متاكد من حذف الوكالة" + CODE, "حذف وكالة",MessageBoxButtons.OKCancel);
            if (d == DialogResult.Cancel)
            {
                return;
            }
            if (d == DialogResult.OK)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM AGENCY WHERE CODE = @CODE ", con);
                cmd.Parameters.AddWithValue("@CODE", CODE);

                con.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show("تم الحذف");
                dataGridView1.Rows.RemoveAt(R);
                con.Close();
            }
        }



        //Select from AGENCY  SERIAL_NUMBER , REG_NUM, TYPE,SALES_MAN,UESER_NAME,AGENCY_DATE ,TYPE_2,ENTRUSTED_NAME_1 ,AGENT_NAME_1
    }
    
}
