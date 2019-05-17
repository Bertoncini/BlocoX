using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoX.Modelos.ReducaoZ
{
    public class PafEcf
    {
        public PafEcf(string numeroCredenciamento) => NumeroCredenciamento = numeroCredenciamento;

        public string NumeroCredenciamento { get; private set; }
    }
}
