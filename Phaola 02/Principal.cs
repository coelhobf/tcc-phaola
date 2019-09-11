using System;
using System.Globalization;
using System.Windows.Forms;

namespace Phaola_02
{
    public partial class Principal : Form
    {
        private (double min, double max) materiaGorda_padrao;
        private (double min, double max) densidade_padrao = (1.028, 1.34);
        private (double min, double max) acidez_padrao = (0.14, 0.18);
        private (double min, double max) lactose_padrao = (45, 50);
        private (double min, double max) ph_padrao = (6.6, 6.8);
        private (double min, double max) esd_padrao = (8.4, 9);
        private (double min, double max) est_padrao = (11.5, 13);
        private (double min, double max) crioscopia_padrao;
        private (double min, double max) proteinas_padrao = (0, 0);
        private (double min, double max) ccs_padrao;
        private (double min, double max) ctb_padrao;
        private (double min, double max) solidostotais_padrao = (7.9, 10);

        private double proteinas_amostra;
        private double materiaGorda_amostra;
        private double densidade_amostra;
        private double acidez_amostra;
        private double lactose_amostra;
        private double ph_amostra;
        private double esd_amostra;
        private double est_amostra;
        private double crioscopia_amostra;
        private double ccs_amostra;
        private double ctb_amostra;
        private double solidostotais_amostra;

        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("teste");
            Close();
        }

        private void btnAnalisar_Click(object sender, EventArgs e)
        {
            bool proteina = false;
            bool matGorda = false;
            bool densidade = false;
            bool acidez = false;
            bool lactose = false;
            bool ph = false;
            bool esd = false;
            bool est = false;
            bool crioscopia = false;
            bool ccs = false;
            bool ctb = false;
            bool solidos = false;

            if (proteinas_amostra > proteinas_padrao.max || proteinas_amostra < proteinas_padrao.min)
                proteina = true;

            if (materiaGorda_amostra > materiaGorda_padrao.max || materiaGorda_amostra < materiaGorda_padrao.min)
                matGorda = true;

            if (densidade_amostra > densidade_padrao.max || densidade_amostra < densidade_padrao.min)
                densidade = true;

            if (acidez_amostra > acidez_padrao.max || acidez_amostra < acidez_padrao.min)
                acidez = true;

            if (lactose_amostra > lactose_padrao.max || lactose_amostra < lactose_padrao.min)
                lactose = true;

            if (ph_amostra > ph_padrao.max || ph_amostra < ph_padrao.min)
                ph = true;

            if (esd_amostra > esd_padrao.max || esd_amostra < esd_padrao.min)
                esd = true;

            if (est_amostra > est_padrao.max || est_amostra < est_padrao.min)
                est = true;

            if (crioscopia_amostra > crioscopia_padrao.max || crioscopia_amostra < crioscopia_padrao.min)
                crioscopia = true;

            if (ccs_amostra > ccs_padrao.max || ccs_amostra < ccs_padrao.min)
                ccs = true;

            if (ctb_amostra > ctb_padrao.max || ctb_amostra < ctb_padrao.min)
                ctb = true;

            if (solidostotais_amostra > solidostotais_padrao.max || solidostotais_amostra < solidostotais_padrao.min)
                solidos = true;

            if (matGorda || densidade || acidez || lactose ||
                ph || esd || est || crioscopia || proteina || ccs || ctb || solidos)
            {
                // exibe a mensagem de erro com cada padrão errado
                string caption = "Erros detectados nos dados";

                string message = "Os seguintes campos estão dentro dos padrões incorretos:\n\n";
                if (matGorda)
                    message += "Matéria Gorda\n";
                if (densidade)
                    message += "Densidade\n";
                if (acidez)
                    message += "Acidez\n";
                if (lactose)
                    message += "Lactose\n";
                if (ph)
                    message += "PH\n";
                if (esd)
                    message += "ESD\n";
                if (est)
                    message += "EST\n";
                if (crioscopia)
                    message += "Crioscopia\n";
                if (proteina)
                    message += "Proteinas\n";
                if (ccs)
                    message += "CCS\n";
                if (ctb)
                    message += "CTB\n";
                if (solidos)
                    message += "Solidos totais\n";

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }
            }

            // Salva os dados no banco
            var data = DateTime.Now;
            string id = data.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            using (var contexto = new bdanalisesEntities())
            {
                var analise = new Dados();

                analise.Id = id;
                analise.Proteinas = proteinas_amostra;
                analise.MatGorda = materiaGorda_amostra;
                analise.Densidade = densidade_amostra;
                analise.Acidez = acidez_amostra;
                analise.Lactose = lactose_amostra;
                analise.PH = ph_amostra;
                analise.ESD = esd_amostra;
                analise.EST = est_amostra;
                analise.Crioscopia = crioscopia_amostra;
                analise.CCS = ccs_amostra;
                analise.CTB = ctb_amostra;
                analise.SolidosTotais = solidostotais_amostra;

                contexto.Dados.Add(analise);
                contexto.SaveChanges();
            }

        }

        #region textChanged
        private void matGordaTextBox_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                materiaGorda_amostra= num;
            }
            else
            {
                materiaGorda_amostra = -1;
                s.Text = "";
            }
        }

        private void densidadeTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                densidade_amostra = num;
            }
            else
            {
                densidade_amostra = -1;
                s.Text = "";
            }
        }

        private void acidezTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                acidez_amostra = num;
            }
            else
            {
                acidez_amostra = -1;
                s.Text = "";
            }
        }

        private void lactoseTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                lactose_amostra = num;
            }
            else
            {
                lactose_amostra = -1;
                s.Text = "";
            }
        }

        private void pHTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                ph_amostra = num;
            }
            else
            {
                ph_amostra = -1;
                s.Text = "";
            }
        }

        private void eSDTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                esd_amostra = num;
            }
            else
            {
                esd_amostra = -1;
                s.Text = "";
            }
        }

        private void eSTTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                est_amostra = num;
            }
            else
            {
                est_amostra = -1;
                s.Text = "";
            }
        }

        private void crioscopiaTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                crioscopia_amostra = num;
            }
            else
            {
                crioscopia_amostra = -1;
                s.Text = "";
            }
        }

        private void proteinasTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                proteinas_amostra = num;
            }
            else
            {
                proteinas_amostra = -1;
                s.Text = "";
            }
        }

        private void cCSTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                ccs_amostra = num;
            }
            else
            {
                ccs_amostra = -1;
                s.Text = "";
            }
        }

        private void cTBTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                ctb_amostra = num;
            }
            else
            {
                ctb_amostra = -1;
                s.Text = "";
            }
        }

        private void solidosTotaisTextBox1_TextChanged(object sender, EventArgs e)
        {
            var s = (TextBox)sender;

            double num;
            if (Double.TryParse(s.Text, out num))
            {
                solidostotais_amostra = num;
            }
            else
            {
                solidostotais_amostra = -1;
                s.Text = "";
            }
        }



        #endregion

    }
}
