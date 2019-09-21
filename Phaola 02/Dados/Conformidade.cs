using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phaola_02.Dados
{
    struct Inconf
    {
        public bool proteina;
        public bool matGorda;
        public bool densidade;
        public bool acidez;
        public bool lactose;
        public bool ph;
        public bool esd;
        public bool est;
        public bool crioscopia;
        public bool ccs;
        public bool ctb;
        public bool solidos;

        public bool teste()
        {
            return matGorda || densidade || acidez || lactose ||
                ph || esd || est || crioscopia || proteina || ccs || ctb || solidos;
        }
    }

    class Conformidade
    {
        private double materiaGorda_padrao = 3.0;
        private (double min, double max) densidade_padrao = (1.028, 1.034);
        private (double min, double max) acidez_padrao = (0.14, 0.18);
        private (double min, double max) lactose_padrao = (45, 50);
        private (double min, double max) ph_padrao = (6.6, 6.8);
        private (double min, double max) esd_padrao = (8.4, 9);
        private (double min, double max) est_padrao = (11.5, 13);
        private (double min, double max) crioscopia_padrao = (-0.550, -0.530);
        private double proteinas_padrao = 2.9;
        private double ccs_padrao = 360000;
        private double ctb_padrao = 100000;
        private (double min, double max) solidostotais_padrao = (7.9, 10);

        private Analise analise;

        public Conformidade(Analise analise)
        {
            this.analise = analise;
        }

        public (Inconf inconforme, string message) VerificaConformidade()
        {
            var inconf = new Inconf();

            inconf.proteina = false;
            inconf.matGorda = false;
            inconf.densidade = false;
            inconf.acidez = false;
            inconf.lactose = false;
            inconf.ph = false;
            inconf.esd = false;
            inconf.est = false;
            inconf.crioscopia = false;
            inconf.ccs = false;
            inconf.ctb = false;
            inconf.solidos = false;

            if (analise.Proteinas < proteinas_padrao)
                inconf.proteina = true;

            if (analise.MatGorda < materiaGorda_padrao)
                inconf.matGorda = true;

            if (analise.Densidade > densidade_padrao.max || analise.Densidade < densidade_padrao.min)
                inconf.densidade = true;

            if (analise.Acidez > acidez_padrao.max || analise.Acidez < acidez_padrao.min)
                inconf.acidez = true;

            if (analise.Lactose > lactose_padrao.max || analise.Lactose < lactose_padrao.min)
                inconf.lactose = true;

            if (analise.PH > ph_padrao.max || analise.PH < ph_padrao.min)
                inconf.ph = true;

            if (analise.ESD > esd_padrao.max || analise.ESD < esd_padrao.min)
                inconf.esd = true;

            if (analise.EST > est_padrao.max || analise.EST < est_padrao.min)
                inconf.est = true;

            if (analise.Crioscopia > crioscopia_padrao.max || analise.Crioscopia < crioscopia_padrao.min)
                inconf.crioscopia = true;

            if (analise.CCS > ccs_padrao)
                inconf.ccs = true;

            if (analise.CTB > ctb_padrao)
                inconf.ctb = true;

            if (analise.SolidosTotais > solidostotais_padrao.max || analise.SolidosTotais < solidostotais_padrao.min)
                inconf.solidos = true;

            string message = "Os seguintes campos estão dentro dos padrões incorretos:\n\n";

            if (inconf.teste())
            {
                if (inconf.matGorda)
                    message += "Matéria Gorda\n";
                if (inconf.densidade)
                    message += "Densidade\n";
                if (inconf.acidez)
                    message += "Acidez\n";
                if (inconf.lactose)
                    message += "Lactose\n";
                if (inconf.ph)
                    message += "PH\n";
                if (inconf.esd)
                    message += "ESD\n";
                if (inconf.est)
                    message += "EST\n";
                if (inconf.crioscopia)
                    message += "Crioscopia\n";
                if (inconf.proteina)
                    message += "Proteinas\n";
                if (inconf.ccs)
                    message += "CCS\n";
                if (inconf.ctb)
                    message += "CTB\n";
                if (inconf.solidos)
                    message += "Solidos totais\n";
            }

            return (inconf, message);
        }
    }
}
