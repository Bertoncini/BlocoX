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
namespace BlocoX.Modelos.ReducaoZ
{
    public class ProdutoServico
    {
        public ProdutoServico(string descricao, string codigoGTIN, string codigoCEST, string nCM, string codigoProprio, int quantidade, string unidade, decimal valorDesconto, decimal valorAcrescimo, decimal valorCancelamento, decimal valorTotalLiquido, bool seServico)
        {
            Descricao = descricao;
            CodigoGTIN = codigoGTIN;
            CodigoCEST = codigoCEST;
            CodigoNCMSH = nCM;
            CodigoProprio = codigoProprio;
            Quantidade = quantidade;
            Unidade = unidade;
            ValorDesconto = valorDesconto;
            ValorAcrescimo = valorAcrescimo;
            ValorCancelamento = valorCancelamento;
            ValorTotalLiquido = valorTotalLiquido;
            SeServico = seServico;
        }

        public string Descricao { get; private set; }
        public string CodigoGTIN { get; private set; }
        public string CodigoCEST { get; private set; }
        public string CodigoNCMSH { get; private set; }
        public string CodigoProprio { get; private set; }
        public decimal Quantidade { get; private set; }
        public string Unidade { get; private set; }
        public decimal ValorDesconto { get; private set; }
        public decimal ValorAcrescimo { get; private set; }
        public decimal ValorCancelamento { get; private set; }
        public decimal ValorTotalLiquido { get; private set; }
        public bool SeServico { get; private set; }
    }
}
