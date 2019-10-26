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

using BlocoX.Modelos.ReducaoZ;
using BlocoX.Utils.Xml.ReducaoZ.Tags;
using System.Text;

namespace BlocoX.Utils.Xml.Reducaoz.Tags
{
    public class TotalizadoresTag
    {
        private TotalizadorParcial TotalizadorParcial { get; set; }
        private StringBuilder _tag;

        public TotalizadoresTag(TotalizadorParcial totalizadorParcial)
            => TotalizadorParcial = totalizadorParcial;

        public StringBuilder ObterTag()
        {
            _tag = new StringBuilder();

            ObterTagAberturaTotalizadorParcial();
            ObterTagNome();
            ObterTagValor();
            ObterTagProdutos();
            ObterTagFechamentoTotalizadorParcial();

            return _tag;
        }

        private void ObterTagAberturaTotalizadorParcial()
            => _tag.Append("<TotalizadorParcial>");

        private void ObterTagNome()
            => _tag.Append($"<Nome>{TotalizadorParcial.Nome}</Nome>");

        private void ObterTagValor()
            => _tag.Append($"<Valor>{TotalizadorParcial.Valor.Decimais()}</Valor>");

        private void ObterTagProdutos()
        {
            var tagProdutosServico = new ProdutosServicosTag(TotalizadorParcial.ProdutosServicos);
            _tag.Append(tagProdutosServico.ObterTag());
        }

        private void ObterTagFechamentoTotalizadorParcial()
           => _tag.Append("</TotalizadorParcial>");
    }
}
