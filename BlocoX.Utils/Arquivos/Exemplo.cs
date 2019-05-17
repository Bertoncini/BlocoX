using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;

namespace BlocoX.Utils.Arquivos
{
    public class Exemplo
    {
        public Modelos.ReducaoZ.BlocoXRZ BlocoXRz()
        {
            var produtoAliquota17 = new BlocoX.Modelos.ReducaoZ.ProdutoServico("PRODUTO ALIQUOTA 1700", "0", "1400300", "11041900", "220601", 2, "UN", 0M, 0M, 0M, 1000M, false);
            var produtoAliquota12 = new BlocoX.Modelos.ReducaoZ.ProdutoServico("PRODUTO ALIQUOTA 1200", "0", "1400300", "11041900", "220601", 2, "UN", 0M, 0M, 0M, 1000M, false);
            var servico = new BlocoX.Modelos.ReducaoZ.ProdutoServico("SERVICO ALIQUOTA 1700", "0", "1400300", "11041900", "220601", 2, "UN", 100M, 200M, 0M, 1000M, true);

            var totalizadorAliquota17 = new BlocoX.Modelos.ReducaoZ.TotalizadorParcial("01T1700", 2100.0M,
                new List<Modelos.ReducaoZ.ProdutoServico>() { produtoAliquota17, servico });

            var totalizadorAliquota12 = new BlocoX.Modelos.ReducaoZ.TotalizadorParcial("01T1200", 1000.0M,
               new List<Modelos.ReducaoZ.ProdutoServico>() { produtoAliquota12 });

            var dadosRz = new BlocoX.Modelos.ReducaoZ.DadosReducaoZ(DateTime.Now, DateTime.Now, 1, 10, 1, 10, 20, new List<Modelos.ReducaoZ.TotalizadorParcial>());
            dadosRz.AdicionarTotalizador(totalizadorAliquota17);
            dadosRz.AdicionarTotalizador(totalizadorAliquota12);

            var blocoxRz = new BlocoX.Modelos.ReducaoZ.BlocoXRZ(
                new Modelos.ReducaoZ.Estabelecimento("253525000"),
                new Modelos.ReducaoZ.PafEcf("123456789012345"),
                new Modelos.ReducaoZ.Ecf("UR010905000", dadosRz)
                );

            return blocoxRz;
        }

        public string Json() => new JavaScriptSerializer().Serialize(BlocoXRz());

        public XmlDocument Xml() => BlocoXRz().BlocoXRZToXml();
    }
}
