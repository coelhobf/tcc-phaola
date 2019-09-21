using Microsoft.Reporting.WinForms;
using Phaola_02.Dados;
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

namespace Phaola_02
{
    public partial class ReportForm : Form
    {
        private Analise analise;

        public ReportForm(Analise analise)
        {
            this.analise = analise;
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            var list = new List<Analise>();
            list.Add(this.analise);
            this.Analises_BindingSource.DataSource = list;

            var inconf = (new Conformidade(this.analise)).VerificaConformidade().inconforme;
            var rParems = new ReportParameter[]
            {
                new ReportParameter("cf_mat", (!inconf.matGorda).ToString()),
                new ReportParameter("cf_densi", (!inconf.densidade).ToString()),
                new ReportParameter("cf_acidez", (!inconf.acidez).ToString()),
                new ReportParameter("cf_lactose", (!inconf.lactose).ToString()),
                new ReportParameter("cf_ph", (!inconf.ph).ToString()),
                new ReportParameter("cf_esd", (!inconf.esd).ToString()),
                new ReportParameter("cf_est", (!inconf.est).ToString()),
                new ReportParameter("cf_crios", (!inconf.crioscopia).ToString()),
                new ReportParameter("cf_prot", (!inconf.proteina).ToString()),
                new ReportParameter("cf_ccs", (!inconf.ccs).ToString()),
                new ReportParameter("cf_ctb", (!inconf.ctb).ToString()),
                new ReportParameter("cf_solid", (!inconf.solidos).ToString())
            };
            reportViewer1.LocalReport.SetParameters(rParems);

            this.reportViewer1.RefreshReport();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
