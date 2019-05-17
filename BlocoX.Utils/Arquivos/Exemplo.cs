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
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using System.Xml;

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
