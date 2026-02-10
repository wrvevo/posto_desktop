using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace posto_desktop.Domain
{
    public class Bomba
    {
        public Guid Uuid { get; set; }
        public int Numero { get; set; }
        public decimal EstoqueLitros { get; set; }
    }
}
