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
using System.Collections.Generic;
using System.Text;

namespace BlocoX.Utils.Xml.ReducaoZ.Tags
{
    public class ProdutosServicosTag
    {
        private List<ProdutoServico> ListaDeProdutos { get; set; }
        private StringBuilder _tag;

        public ProdutosServicosTag(List<ProdutoServico> listaDeProdutos)
            => ListaDeProdutos = listaDeProdutos;

        public StringBuilder ObterTag()
        {
            _tag = new StringBuilder();

            _tag.Append("<ProdutosServicos>");
            ObterTagProdutos();
            _tag.Append("</ProdutosServicos>");

            return _tag;
        }

        private void ObterTagProdutos()
        {
            foreach (var Produto in ListaDeProdutos)
            {

                _tag.Append("<Produto>");

                _tag.Append($"<Descricao>{Produto.Descricao.Substring(Produto.Descricao.LastIndexOf("#") + 1)}</Descricao>");

                _tag.Append($"<CodigoGTIN></CodigoGTIN>");

                _tag.Append($"<CodigoCEST>{Produto.CodigoCEST}</CodigoCEST>");

                _tag.Append($"<CodigoNCMSH>{Produto.CodigoNCMSH}</CodigoNCMSH>");

                _tag.Append($"<CodigoProprio>{Produto.CodigoProprio}</CodigoProprio>");

                _tag.Append($"<Quantidade>{Produto.Quantidade.Decimais(3)}</Quantidade>");

                _tag.Append($"<Unidade>{Produto.Unidade}</Unidade>");

                _tag.Append($"<ValorDesconto>{Produto.ValorDesconto.Decimais()}</ValorDesconto>");

                _tag.Append($"<ValorAcrescimo>{Produto.ValorAcrescimo.Decimais()}</ValorAcrescimo>");

                _tag.Append($"<ValorCancelamento>{Produto.ValorCancelamento.Decimais()}</ValorCancelamento>");

                _tag.Append($"<ValorTotalLiquido>{Produto.ValorTotalLiquido.Decimais()}</ValorTotalLiquido>");

                _tag.Append("</Produto>");

            }
        }
    }
}
