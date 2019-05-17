using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocoX.Modelos.ReducaoZ
{
    public class Estabelecimento
    {
        public Estabelecimento(string ie) => Ie = ie;

        public string Ie { get; private set; }
    }
}
