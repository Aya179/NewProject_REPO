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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void أرشفةالوكالاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Archive archive = new Archive();
            archive.MdiParent = this;
            archive.Dock = DockStyle.Fill;
            archive.Show();
        }

        private void عقودالشركاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ContractCompanyForm contract = new ContractCompanyForm();
            contract.MdiParent = this;
            contract.Dock = DockStyle.Fill;
            contract.Show();

        }

        private void عقودالشركاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ContractCompanyForm contract = new ContractCompanyForm();
            contract.MdiParent = this;
            contract.Dock = DockStyle.Fill;
            contract.Show();
        }

        private void الوكالاتالمرحليةToolStripMenuItem_Click(object sender, EventArgs e)
        {
           InterimAgrncyForm interim = new InterimAgrncyForm();
            interim.MdiParent = this;
            interim.Dock = DockStyle.Fill;
            interim.Show();
        }

        private void الوكالاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isolated_agenciesForm isolated= new isolated_agenciesForm();
            isolated.MdiParent = this;
            isolated.Dock = DockStyle.Fill;
            isolated.Show();

        }

        private void الوكالاتمنعToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            PreventAgencyForm prevent= new PreventAgencyForm();
            prevent.MdiParent = this;
            prevent.Dock = DockStyle.Fill;
            prevent.Show();


        }

        private void الوكالاتالمزورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FakeAgencyForm fake = new FakeAgencyForm();
            fake.MdiParent = this;
            fake.Dock = DockStyle.Fill;
            fake.Show();


        }

        private void الوكالاتالاعتزالToolStripMenuItem_Click(object sender, EventArgs e)
        {
           retirementForm form= new retirementForm();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();

        }

        private void تقريرعددالوكالاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountAgencrReportForm count = new CountAgencrReportForm();
            count.MdiParent = this;
            count.Dock = DockStyle.Fill;
            count.Show();

        }

        private void تقريرالوكالاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
          AllReportForm all = new AllReportForm();
            all = new AllReportForm();
            all.MdiParent = this;
            all.Dock = DockStyle.Fill;
            all.Show();
        }

        private void تقريرماليللوكالاتالمصدقةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Certified_AgenciesForm certified = new Certified_AgenciesForm();
            certified.MdiParent = this;
            certified.Dock = DockStyle.Fill;
            certified.Show();

        }

        private void تقريرماليللوكالاتالمؤرشفةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArchiveReportForm report = new ArchiveReportForm();
            report.MdiParent = this;
            report.Dock = DockStyle.Fill;
            report.Show();


        }

        private void تقريماليلإجماليالوكالاتمصدقةمؤرشفةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllReportForm report = new AllReportForm();
            report.MdiParent = this;
            report.Dock = DockStyle.Fill;
            report.Show();

        }

        private void تقريرماليلإجماليالوكالاتتجميعيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            representativeReportForm report = new representativeReportForm();
            report.MdiParent = this;
            report.Dock = DockStyle.Fill;
            report.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InterimAgrncyForm interim = new InterimAgrncyForm();
            interim.MdiParent = this;
            interim.Dock = DockStyle.Fill;
            interim.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Archive archive = new Archive();
            archive.MdiParent = this;
            archive.Dock = DockStyle.Fill;
            archive.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
