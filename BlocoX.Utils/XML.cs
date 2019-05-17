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
namespace BlocoX.Utils
{
    using System.Collections.Generic;
    using System.Xml;

    public static class XML
    {
        public static string JsonToXml(this string json)
        {
            dynamic jsonObject = DynamicJsonConverter.ConvertToObject(json);

            var xml =
            $@"<?xml version='1.0' encoding='UTF‐8'?>
<ReducaoZ Versao='1.0'>
    <Mensagem>
        <Estabelecimento>
            <Ie>{jsonObject.Estabelecimento.Ie}</Ie>
        </Estabelecimento>
        <PafEcf>
            <NumeroCredenciamento>{jsonObject.PafEcf.NumeroCredenciamento}</NumeroCredenciamento>
        </PafEcf>
        <Ecf>
            <NumeroFabricacao>{jsonObject.Ecf.NumeroFabricacao}</NumeroFabricacao>
            <DadosReducaoZ>
                <DataReferencia>{jsonObject.Ecf.DadosReducaoZ.DataReferencia.ToString("yyyy-MM-dd")}</DataReferencia>
                <DataHoraEmissao>{jsonObject.Ecf.DadosReducaoZ.DataHoraEmissao.ToString("yyyy-MM-ddTHH:mm:ss-03:00")}</DataHoraEmissao>
                <CRZ>{jsonObject.Ecf.DadosReducaoZ.CRZ.ToString().CortaCompleta(4, "0", eOrietacao.Esquerda)}</CRZ>
                <COO>{jsonObject.Ecf.DadosReducaoZ.COO.ToString().CortaCompleta(9, "0", eOrietacao.Esquerda)}</COO>
                <CRO>{jsonObject.Ecf.DadosReducaoZ.CRO.ToString().CortaCompleta(3, "0", eOrietacao.Esquerda)}</CRO>
                <VendaBrutaDiaria>{jsonObject.Ecf.DadosReducaoZ.VendaBrutaDiaria.ToString("N2").Replace(",", "").Replace(".", "").CortaCompleta(14, "0", eOrietacao.Esquerda)}</VendaBrutaDiaria>
                <GT>{jsonObject.Ecf.DadosReducaoZ.GT.ToString("N2").Replace(",", "").Replace(".", "").CortaCompleta(18, "0", eOrietacao.Esquerda)}</GT>
                <TotalizadoresParciais>
                    {xmlStringBlocoXRzTotalizadorParcial(jsonObject.Ecf.DadosReducaoZ.TotalizadoresParciais)}
                </TotalizadoresParciais>
            </DadosReducaoZ>
        </Ecf>
    </Mensagem>
</ReducaoZ>
";

            return string.Empty;
        }

        public static string XmlToString(this XmlDocument document) => document.InnerXml.Replace("&gt;", "<").Replace("&lt;", ">");

        public static XmlDocument StringToXml(this string xmlString)
        {
            var xml = new XmlDocument();
            xml.LoadXml(xmlString);

            return xml;
        }

        private static string xmlStringBlocoXRzTotalizadorParcial(List<dynamic> totalizadores)
        {
            var rzTotalizadoresParciais = string.Empty;

            foreach(var totalizador in totalizadores)
            {
                rzTotalizadoresParciais = $@"
<TotalizadorParcial>
    <Nome>{totalizador.Nome}</Nome>
    <Valor>{totalizador.Valor.ToString("N2").Replace(".", "")}</Valor>
    <ProdutosServicos>
        {xmlStringBlocoXProduto(totalizador.ProdutosServicos)}
    </ProdutosServicos>
</TotalizadorParcial>
";
            }

            return rzTotalizadoresParciais;
        }

        private static string xmlStringBlocoXProduto(List<dynamic> produtos)
        {
            var strProdutos = string.Empty;

            foreach(var produto in produtos)
            {
                strProdutos = $@"
        <Produto>
            <Descricao>{produto.Descricao.Substring(produto.Descricao.LastIndexOf("#") + 1)}</Descricao>
            <CodigoGTIN>{produto.Codigo}</CodigoGTIN>
            <CodigoCEST>{produto.Descricao.Substring(2, produto.Descricao.LastIndexOf("#") - 2)}</CodigoCEST>
            <CodigoNCMSH>6666666</CodigoNCMSH>
            <CodigoProprio>{produto.Codigo}</CodigoProprio>
            <Quantidade>{produto.Quantidade},00</Quantidade>
            <Unidade>{produto.Unidade}</Unidade>
            <ValorDesconto>0,00</ValorDesconto>
            <ValorAcrescimo>0,00</ValorAcrescimo>
            <ValorCancelamento>0,00</ValorCancelamento>
            <ValorTotalLiquido>{produto.ValorUnitario.ToString("N2").Replace(".", ",")}</ValorTotalLiquido>
        </Produto>
";
            }

            return strProdutos;
        }
    }
}
