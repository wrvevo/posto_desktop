using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posto_desktop.Domain
{
    public class Consumo
    {
        public Guid Uuid { get; set; }
        public Guid BombaUuid { get; set; }
        public decimal Litros { get; set; }
        public DateTime DataConsumo { get; set; }
        public bool Sincronizado { get; set; }
    }
}

