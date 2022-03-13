using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProject
{
    public partial class ContractCompanyForm : Form
    {
        public ContractCompanyForm()
        {
            InitializeComponent();
        }


        Syrian_Bar_DBEntities db = new Syrian_Bar_DBEntities();
        CONTRACT_COMPANY contract = new CONTRACT_COMPANY();

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            contract.DATE = dateTimePicker1.Value;
            contract.TYPE = type.SelectedItem.ToString();
            contract.ENTRUSTED_NAME = textBox1.Text.ToString();
            contract.NOTES = note.Text.ToString();
            contract.RECEIPT_NO_1 = receipt_num_1.Text.ToString();
            contract.RECEIPT_NO_2 = receipt_num_2.Text.ToString();
            contract.SALES_MAN = sale_man.Text.ToString();
            db.CONTRACT_COMPANY.Add(contract);
            db.SaveChanges();
            MessageBox.Show(" Data Saved");
            reset();
        }

     public void reset()
        {
            sale_man.Text = "";
            receipt_num_1.Text = "";
            receipt_num_2.Text = "";
            note.Text = "";
            textBox1.Text = "";

        }
    }
}
