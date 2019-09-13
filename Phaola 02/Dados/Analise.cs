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
        public string Id { get; set; } = "";
        public DateTime Data { get; set; } = DateTime.Now;
        public double MatGorda { get; set; } = 0;
        public double Densidade { get; set; } = 0;
        public double Acidez { get; set; } = 0;
        public double Lactose { get; set; } = 0;
        public double PH { get; set; } = 0;
        public double ESD { get; set; } = 0;
        public double EST { get; set; } = 0;
        public double Crioscopia { get; set; } = 0;
        public double Proteinas { get; set; } = 0;
        public double CCS { get; set; } = 0;
        public double CTB { get; set; } = 0;
        public double SolidosTotais { get; set; } = 0;
    }
}
