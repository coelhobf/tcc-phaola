using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phaola_02.Dados
{
    [Table("Analise")]
    public partial class Analise
    {
        public string Id { get; set; }
        public System.DateTime Data { get; set; }
        public double MatGorda { get; set; }
        public double Densidade { get; set; }
        public double Acidez { get; set; }
        public double Lactose { get; set; }
        public double PH { get; set; }
        public double ESD { get; set; }
        public double EST { get; set; }
        public double Crioscopia { get; set; }
        public double Proteinas { get; set; }
        public double CCS { get; set; }
        public double CTB { get; set; }
        public double SolidosTotais { get; set; }
    }
}
