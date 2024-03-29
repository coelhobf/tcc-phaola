﻿using Microsoft.EntityFrameworkCore;
using Phaola_02.Dados;
using System;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Phaola_02
{
    public partial class Principal : Form
    {
        private Analise Amostra {
            get {
                var analise = new Analise();

                DateTime date;
                double num;

                if (!DateTime.TryParse(dataDateTimePicker1.Text, out date))
                {
                    analise.Data = DateTime.Now;
                }
                analise.Id = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                analise.Data = date;

                if (!Double.TryParse(matGordaTextBox.Text, out num))
                {
                    num = -1;
                }
                analise.MatGorda = num;

                if (!Double.TryParse(pROTEINASTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.Proteinas = num;

                if (!Double.TryParse(densidadeTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.Densidade = num;

                if (!Double.TryParse(acidezTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.Acidez = num;

                if (!Double.TryParse(lactoseTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.Lactose = num;

                if (!Double.TryParse(pHTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.PH = num;

                if (!Double.TryParse(eSDTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.ESD = num;

                if (!Double.TryParse(eSTTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.EST = num;

                if (!Double.TryParse(crioscopiaTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.Crioscopia = num;

                if (!Double.TryParse(cCSTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.CCS = num;

                if (!Double.TryParse(cTBTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.CTB = num;

                if (!Double.TryParse(solidosTotaisTextBox1.Text, out num))
                {
                    num = -1;
                }
                analise.SolidosTotais = num;

                return analise;
            }
            set
            {
                matGordaTextBox.Text = value.MatGorda.ToString();
                pROTEINASTextBox1.Text = value.Proteinas.ToString();
                densidadeTextBox1.Text = value.Densidade.ToString();
                acidezTextBox1.Text = value.Acidez.ToString();
                lactoseTextBox1.Text = value.Lactose.ToString();
                pHTextBox1.Text = value.PH.ToString();
                eSDTextBox1.Text = value.ESD.ToString();
                eSTTextBox1.Text = value.EST.ToString();
                crioscopiaTextBox1.Text = value.Crioscopia.ToString();
                cCSTextBox1.Text = value.CCS.ToString();
                cTBTextBox1.Text = value.CTB.ToString();
                solidosTotaisTextBox1.Text = value.SolidosTotais.ToString();
            }
        }

        

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
        private DateTime dataAnalise;

        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            DateTime date;
            if (!DateTime.TryParse(dataDateTimePicker1.Text, out date))
            {
                date = DateTime.Now;
            }
            string id = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            using (var contexto = new AnaliseContext())
            {
                Analise analise;

                var entity = contexto.Analises.AsNoTracking().FirstOrDefault(a => a.Id == id);
                if (entity == null)
                {
                    MessageBox.Show("Erro ao recuperar dados para esta data!");
                    return;
                }

                analise = entity;

                var relForm = new ReportForm(analise);
                relForm.Show();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("teste");
            Close();
        }

        private void btnAnalisar_Click(object sender, EventArgs e)
        {
            var cf = new Conformidade(Amostra);
            var conformidade = cf.VerificaConformidade();

            if(conformidade.inconforme.teste())
            {
                // exibe a mensagem de erro com cada padrão errado
                string caption = "Erros detectados nos dados";
                string message = conformidade.message;

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    // Closes the parent form.
                    this.Close();
                }

                var mncf = new MotivosNaoConformidade();
                mncf.Show();
            }

            // Salva os dados no banco
            DateTime date;
            if (!DateTime.TryParse(dataDateTimePicker1.Text, out date))
            {
                date = DateTime.Now;
            }
            string id = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            using (var contexto = new AnaliseContext())
            {
                //var analise = new Analise();

                //analise.Id = id;
                //analise.Data = DateTime.Now;
                //analise.Proteinas = proteinas_amostra;
                //analise.MatGorda = materiaGorda_amostra;
                //analise.Densidade = densidade_amostra;
                //analise.Acidez = acidez_amostra;
                //analise.Lactose = lactose_amostra;
                //analise.PH = ph_amostra;
                //analise.ESD = esd_amostra;
                //analise.EST = est_amostra;
                //analise.Crioscopia = crioscopia_amostra;
                //analise.CCS = ccs_amostra;
                //analise.CTB = ctb_amostra;
                //analise.SolidosTotais = solidostotais_amostra;

                var analise = Amostra;

                var entity = contexto.Analises.AsNoTracking().FirstOrDefault(a => a.Id == id);
                if (entity == null)
                {
                    contexto.Analises.Add(analise);
                }
                else
                {
                    contexto.Analises.Update(analise);
                }

                try
                {
                    contexto.SaveChanges();
                    MessageBox.Show("Dados Salvos com sucesso!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro ao salvar os dados.");
                }

                try
                {
                    //MessageBox.Show("Salvou ok");
                }
                catch (DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
            }

        }

        #region textChanged
        private double textChange(object sender)
        {
            var s = (TextBox)sender;
            if (s.Text.Length == 1 && s.Text[0] == '-')
                return -1;

            double num;
            if (!Double.TryParse(s.Text, out num))
            {
                num = -1;
                s.Text = "";
            }

            return num;
        }

        private void matGordaTextBox_TextChanged(object sender, EventArgs e)
        {
            materiaGorda_amostra = textChange(sender);
        }

        private void densidadeTextBox1_TextChanged(object sender, EventArgs e)
        {
            densidade_amostra = textChange(sender);
        }

        private void acidezTextBox1_TextChanged(object sender, EventArgs e)
        {
            acidez_amostra = textChange(sender);
        }

        private void lactoseTextBox1_TextChanged(object sender, EventArgs e)
        {
            lactose_amostra = textChange(sender);
        }

        private void pHTextBox1_TextChanged(object sender, EventArgs e)
        {
            ph_amostra = textChange(sender);
        }

        private void eSDTextBox1_TextChanged(object sender, EventArgs e)
        {
            esd_amostra = textChange(sender);
        }

        private void eSTTextBox1_TextChanged(object sender, EventArgs e)
        {
            est_amostra = textChange(sender);
        }

        private void crioscopiaTextBox1_TextChanged(object sender, EventArgs e)
        {
            crioscopia_amostra = textChange(sender);
        }

        private void proteinasTextBox1_TextChanged(object sender, EventArgs e)
        {
            proteinas_amostra = textChange(sender);
        }

        private void cCSTextBox1_TextChanged(object sender, EventArgs e)
        {
            ccs_amostra = textChange(sender);
        }

        private void cTBTextBox1_TextChanged(object sender, EventArgs e)
        {
            ctb_amostra = textChange(sender);
        }

        private void solidosTotaisTextBox1_TextChanged(object sender, EventArgs e)
        {
            solidostotais_amostra = textChange(sender);
        }

        private void dataDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var s = (DateTimePicker)sender;

            DateTime date;
            if (!DateTime.TryParse(s.Text, out date))
            {
                date = DateTime.Now;
            }
        
            dataAnalise = date;
        }

        #endregion

        private void btnBuscaData_Click(object sender, EventArgs e)
        {
            DateTime date;
            if (!DateTime.TryParse(dataDateTimePicker1.Text, out date))
            {
                date = DateTime.Now;
            }
            string id = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            using (var contexto = new AnaliseContext())
            {
                var analises = contexto.Analises.Where(a => a.Id == id).ToArray();

                Analise analise;
                if(analises.Length > 0)
                {
                    analise = analises[0];
                }
                else
                {
                    MessageBox.Show("Não foi possivel encontrar este registro!");
                    Amostra = new Analise();
                    return;
                }

                //matGordaTextBox.Text = analise.MatGorda.ToString();
                //pROTEINASTextBox1.Text = analise.Proteinas.ToString();
                //densidadeTextBox1.Text = analise.Densidade.ToString();
                //acidezTextBox1.Text = analise.Acidez.ToString();
                //lactoseTextBox1.Text = analise.Lactose.ToString();
                //pHTextBox1.Text = analise.PH.ToString();
                //eSDTextBox1.Text = analise.ESD.ToString();
                //eSTTextBox1.Text = analise.EST.ToString();
                //crioscopiaTextBox1.Text = analise.Crioscopia.ToString();
                //cCSTextBox1.Text = analise.CCS.ToString();
                //cTBTextBox1.Text = analise.CTB.ToString();
                //solidosTotaisTextBox1.Text = analise.SolidosTotais.ToString();
                Amostra = analise;


            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Path.GetFullPath("manual_de_metodos.pdf"));
        }
    }
}
