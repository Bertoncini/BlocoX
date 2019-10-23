using BlocoX.Modelos;
using BlocoX.Modelos.ReducaoZ;
using BlocoX.Utils.Xml;
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

        public static Ecf ObterECF()
            => new Ecf("UR010905000");

        public static DadosReducaoZ ObterDadosReducaoZ()
            => new DadosReducaoZ(new DateTime(2019, 01, 01), new DateTime(2019, 01, 01, 12, 59, 59), 1, 100, 1, 1000, 1850);

        public static TotalizadorParcial ObterTotalizadorParcial()
            => new TotalizadorParcial("01T1700", 2000m, ObterListaProdutos());

        public static List<ProdutoServico> ObterListaProdutos()
            => new List<ProdutoServico> { new ProdutoServico("PRODUTO ALIQUOTA 1700", "0", "1400300", "11041900", "220601", 2, "UN", 0M, 0M, 0M, 1000M, false),
                                          new ProdutoServico("PRODUTO ALIQUOTA 1700", "0", "1400300", "11041900", "220601", 2, "UN", 0M, 0M, 0M, 1000M, false)};

        public static XmlReducaoZ ObterXMlReducaoZ()
            => new XmlReducaoZ(new BlocoXRZ(ObterECF(), ObterDadosReducaoZ(), new List<TotalizadorParcial> { ObterTotalizadorParcial() }));
    }
}
