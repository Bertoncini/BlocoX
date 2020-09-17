/********************************************************************************/
/* Projeto: Biblioteca BlocoX                                                   */
/* Biblioteca C# para emissão do BlocoX (ReduçãoZ e Estoque)                    */
/*https://www.confaz.fazenda.gov.br/legislacao/despacho/2017/dp045_17           */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2019 Alexsandro Bertoncini                  */
/*                                       alex.bertoncini@terra.com.br           */
/*                                                                              */
/*  Você pode obter a última versão desse arquivo no GitHub                     */
/* localizado em https://github.com/Bertoncini/BlocoX                           */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la */
/* sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) */
/* qualquer versão posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      */
/* ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto*/
/* com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  */
/* no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Você também pode obter uma copia da licença em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/********************************************************************************/
namespace BlocoX.Utils.Arquivos
{
    using BlocoX.Modelos.ReducaoZ;
    using BlocoX.Utils.Xml;
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using System.Xml;

    public class Exemplo
    {
        public XmlDocument BlocoXRz()
        {
            //TOOD Implementar servico

            var dadosRz = new DadosReducaoZ(DateTime.Now, DateTime.Now, 1, 10, 1, 10, 20);

            var listaTotalizadores = new List<TotalizadorParcial>() { ObterTotalizadorAliquota17(), ObterTotalizadorAliquota12() };

            var blocoxRz = new BlocoXRZ(new Modelos.ReducaoZ.Ecf("UR010905000"),
                                                                dadosRz,
                                                                listaTotalizadores);

            var reducaoz = new XmlReducaoZ(blocoxRz);

            var xml = new XMLBlocoX(new Modelos.Estabelecimento("257477110"),
                                    new Modelos.PafEcf("123456789012345"),
                                    reducaoz);

            return xml.ObterXML();
        }

        private TotalizadorParcial ObterTotalizadorAliquota17()
            => new TotalizadorParcial("01T1700", 2100.0M, new List<ProdutoServico>() { ObterProdutoAliquota17() });

        private TotalizadorParcial ObterTotalizadorAliquota12()
            => new TotalizadorParcial("01T1200", 1000.0M, new List<Modelos.ReducaoZ.ProdutoServico>() { ObterProdutoAliquota12() });

        private ProdutoServico ObterProdutoAliquota17()
            => new ProdutoServico("PRODUTO ALIQUOTA 1700", "0", "1400300", "11041900", "220601", 2, "UN", 0M, 0M, 0M, 1000M, false);

        private ProdutoServico ObterProdutoAliquota12()
            => new ProdutoServico("PRODUTO ALIQUOTA 1200", "0", "1400300", "11041900", "220602", 2, "UN", 0M, 0M, 0M, 1000M, false);


        public string RzJson() => new JavaScriptSerializer().Serialize(BlocoXRz());

        public Modelos.Estoque.BlocoXEstoque BlocoXEstoque()
        {
            var produtoAliquota17 = new BlocoX.Modelos.Estoque.Produto("PRODUTO ALIQUOTA 1700", "0", "1400300", "11041900", "220601", 100, 200, "UN", 1000M, 100000, 0, 0, 0, "Tributado pelo ICMS", 17M, false, "Terceiros", "Positivo");
            var produtoAliquota12 = new BlocoX.Modelos.Estoque.Produto("PRODUTO ALIQUOTA 1200", "0", "1400300", "11041900", "220602", 100, 200, "UN", 1000M, 100000, 0, 0, 0, "Tributado pelo ICMS", 12M, false, "Terceiros", "Positivo");

            var blocoxEstoque = new BlocoX.Modelos.Estoque.BlocoXEstoque(
                new Modelos.Estabelecimento("257477110"),
                new Modelos.PafEcf("123456789012345"),
                new Modelos.Estoque.DadosEstoque(new DateTime(2019, 04, 01), new List<Modelos.Estoque.Produto> { produtoAliquota17, produtoAliquota12 })
                );

            return blocoxEstoque;
        }

        public string EstoqueJson() => new JavaScriptSerializer().Serialize(BlocoXEstoque());

        public XmlDocument EstoqueXml() => BlocoXEstoque().BlocoXEstoqueToXml();

        public XmlDocument ListarArquivoXml() => XML.BlocoXListaArquivosToXml("257477110");
    }
}
