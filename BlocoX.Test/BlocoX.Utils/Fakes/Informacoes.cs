using BlocoX.Modelos;
using BlocoX.Modelos.ReducaoZ;
using System;
using System.Collections.Generic;

namespace BlocoX.Test.BlocoXUtils.Fakes
{
    public class Informacoes
    {
        public static Estabelecimento ObterEstabelecimento()
            => new Estabelecimento("257477110");

        public static PafEcf ObterPafEcf()
            => new PafEcf("123456789012345");

        public static DadosReducaoZ ObterDadosReducaoZ()
            => new DadosReducaoZ(new DateTime(2019, 01, 01), new DateTime(2019, 01, 01, 12, 59, 59), 1, 100, 1, 1000, 1850, new List<TotalizadorParcial>());
    }
}
