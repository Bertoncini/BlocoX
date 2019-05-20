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
namespace BlocoX.Modelos.Estoque
{
    public class Produto
    {
        public Produto(string descricao, string codigoGTIN, string codigoCEST, string nCM, string codigoProprio, decimal quantidade, decimal quantidadeTotalAquisicao, string unidade, decimal valorUnitario, decimal valorTotalAquisicao, decimal valorTotalICMSDebitoFornecedor, decimal valorBaseCalculoICMSST, decimal valorTotalICMSST, string situacaoTributaria, decimal aliquota, bool isArredondado, string ippt, string situacaoEstoque)
        {
            Descricao = descricao;
            CodigoGTIN = codigoGTIN;
            CodigoCEST = codigoCEST;
            NCM = nCM;
            CodigoProprio = codigoProprio;
            Quantidade = quantidade;
            QuantidadeTotalAquisicao = quantidadeTotalAquisicao;
            Unidade = unidade;
            ValorUnitario = valorUnitario;
            ValorTotalAquisicao = valorTotalAquisicao;
            ValorTotalICMSDebitoFornecedor = valorTotalICMSDebitoFornecedor;
            ValorBaseCalculoICMSST = valorBaseCalculoICMSST;
            ValorTotalICMSST = valorTotalICMSST;
            SituacaoTributaria = situacaoTributaria;
            Aliquota = aliquota;
            IsArredondado = isArredondado;
            Ippt = ippt;
            SituacaoEstoque = situacaoEstoque;
        }

        public string Descricao { get; private set; }
        public string CodigoGTIN { get; private set; }
        public string CodigoCEST { get; private set; }
        public string NCM { get; private set; }
        public string CodigoProprio { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal QuantidadeTotalAquisicao { get; private set; }
        public string Unidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal ValorTotalAquisicao { get; private set; }
        public decimal ValorTotalICMSDebitoFornecedor { get; private set; }
        public decimal ValorBaseCalculoICMSST { get; private set; }
        public decimal ValorTotalICMSST { get; private set; }
        public string SituacaoTributaria { get; private set; }
        public decimal Aliquota { get; private set; }
        public bool IsArredondado { get; private set; }
        public string Ippt { get; private set; }
        public string SituacaoEstoque { get; private set; }
    }
}
