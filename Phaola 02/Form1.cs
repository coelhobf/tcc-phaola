using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phaola_02
{
    public partial class Form1 : Form
    {
        private readonly int proteinas_amostra;
        private readonly int proteinas_padrao;
        private readonly int Materiagorda_amostra;
        private readonly int Materiagorda_padrao;
        private readonly int densidade_amostra;
        private readonly int densidade_padrao;
        private readonly int acidez_amostra;
        private readonly int acidez_padrao;
        private readonly int lactose_amostra;
        private readonly int lactose_padrao;
        private readonly int ph_amostra;
        private readonly int ph_padrao;
        private readonly int esd_amostra;
        private readonly int esd_padrao;
        private readonly int crioscopia_amostra;
        private readonly int crioscopia_padrao;
        private readonly int ccs_amostra;
        private readonly int ctb_amostra;
        private readonly int ccs_padrao;
        private readonly int ctb_padrao;
        private readonly int solidostotais_amostra;
        private readonly int solidostotais_padrao;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdanalisesDataSet1.Table'. Você pode movê-la ou removê-la conforme necessário.
            this.tableTableAdapter1.Fill(this.bdanalisesDataSet1.Table);
            // TODO: esta linha de código carrega dados na tabela 'bdanalisesDataSet.Table'. Você pode movê-la ou removê-la conforme necessário.
            this.tableTableAdapter.Fill(this.bdanalisesDataSet.Table);

        }

        private void new_tableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void matGordaTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (proteinas_amostra > proteinas_padrao && proteinas_amostra < proteinas_padrao)
            {
                { MessageBox.Show("Proteínas fora do padrão"); }
                ;
            }
            
            if (Materiagorda_amostra > Materiagorda_padrao && Materiagorda_amostra < Materiagorda_padrao)
            {
                { MessageBox.Show("Materia Gorda fora do padrão"); }
                ;
            }
            
            if (densidade_amostra > densidade_padrao && densidade_amostra < densidade_padrao)
            {
                { MessageBox.Show("Densidade fora do padrão"); }
                ;
            }
            
            if (acidez_amostra > acidez_padrao && acidez_amostra < acidez_padrao)
            {
                { MessageBox.Show("Acidez fora do padrão"); }
                ;
            }
            
            if (lactose_amostra > lactose_padrao && lactose_amostra < lactose_padrao)
            {
                { MessageBox.Show("Lactose fora do padrão"); }
                ;
            }
            
            if (ph_amostra > ph_padrao && ph_amostra < ph_padrao)
            {
                { MessageBox.Show("pH fora do padrão"); }
                ;
            }
            
            if (esd_amostra > esd_padrao && esd_amostra < esd_padrao)
            {
                { MessageBox.Show("ESD fora do padrão"); }
                ;
            }
            
            if (crioscopia_amostra > crioscopia_padrao && crioscopia_amostra < crioscopia_padrao)
            {
                { MessageBox.Show("Crioscopia fora do padrão"); }
                ;
            }
            
            if (ccs_amostra > ccs_padrao && ccs_amostra < ccs_padrao)
            {
                { MessageBox.Show("CCS fora do padrão"); }
                ;
            }
            
            if (ctb_amostra > ctb_padrao && ctb_amostra < ctb_padrao)
            {
                { MessageBox.Show("CTB fora do padrão"); }
                ;
            }
            
            if (solidostotais_amostra > solidostotais_padrao && solidostotais_amostra < solidostotais_padrao)
            {
                { MessageBox.Show("Sólidos Totais fora do padrão"); }
                ;
            }
            
           
        }

        private void cCSListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cCSLabel_Click(object sender, EventArgs e)
        {

        }

        private void matGordaLabel1_Click(object sender, EventArgs e)
        {
            int matGorda = 3 / 100;
        }
    }
}
