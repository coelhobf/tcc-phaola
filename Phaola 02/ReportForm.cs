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
            this.reportViewer1.RefreshReport();

            //Warning[] warnings;
            //string[] streamids;
            //string mimeType;
            //string encoding;
            //string filenameExtension;

            //byte[] bytes = reportViewer1.LocalReport.Render(
            //    "PDF", null, out mimeType, out encoding, out filenameExtension,
            //    out streamids, out warnings);

            //using (FileStream fs = new FileStream("Analise-" + this.analise.Id + ".pdf", FileMode.Create))
            //{
            //    fs.Write(bytes, 0, bytes.Length);
            //}

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
