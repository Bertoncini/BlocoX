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
    using BlocoX.Utils.Enums;
    using System.Collections.Generic;
    using System.Xml;

    public static class XML
    {
        public static XmlDocument RzJsonToXml(this string json)
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
                <CRZ>{jsonObject.Ecf.DadosReducaoZ.CRZ.ToString().CortaCompleta(4, "0", Alinhamento.Esquerda)}</CRZ>
                <COO>{jsonObject.Ecf.DadosReducaoZ.COO.ToString().CortaCompleta(9, "0", Alinhamento.Esquerda)}</COO>
                <CRO>{jsonObject.Ecf.DadosReducaoZ.CRO.ToString().CortaCompleta(3, "0", Alinhamento.Esquerda)}</CRO>
                <VendaBrutaDiaria>{jsonObject.Ecf.DadosReducaoZ.VendaBrutaDiaria.ToString("N2").Replace(",", "").Replace(".", "").CortaCompleta(14, "0", Alinhamento.Esquerda)}</VendaBrutaDiaria>
                <GT>{jsonObject.Ecf.DadosReducaoZ.GT.ToString("N2").Replace(",", "").Replace(".", "").CortaCompleta(18, "0", Alinhamento.Esquerda)}</GT>
                <TotalizadoresParciais>
                    {xmlStringBlocoXRzTotalizadorParcial(jsonObject.Ecf.DadosReducaoZ.TotalizadoresParciais)}
                </TotalizadoresParciais>
            </DadosReducaoZ>
        </Ecf>
    </Mensagem>
</ReducaoZ>
";

            return xml.StringToXml();
        }

        public static XmlDocument EstoqueJsonToXml(this string json)
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
        <DadosEstoque>
            <DataReferencia>{jsonObject.DadosEstoque.DataReferencia.ToString("yyyy-MM-dd")}</DataReferencia>
            <Produtos>
                {xmlStringBlocoXEstoqueProduto(jsonObject.DadosEstoque.Produtos)}
            </Produtos>
        </DadosEstoque>
    </Mensagem>
</ReducaoZ>
";

            return xml.StringToXml();
        }

        public static XmlDocument BlocoXEstoqueToXml(this Modelos.Estoque.BlocoXEstoque blocoXEstoque)
        {
            if (blocoXEstoque == null)
                throw new System.ArgumentNullException(nameof(blocoXEstoque));

            var xml =
          $@"<?xml version='1.0' encoding='UTF‐8'?>
<Estoque Versao='1.0'>
    <Mensagem>
        <Estabelecimento>
            <Ie>{blocoXEstoque.Estabelecimento.Ie}</Ie>
        </Estabelecimento>
        <PafEcf>
            <NumeroCredenciamento>{blocoXEstoque.PafEcf.NumeroCredenciamento}</NumeroCredenciamento>
        </PafEcf>
        <DadosEstoque>
            <DataReferencia>{blocoXEstoque.DadosEstoque.DataReferencia.ToString("yyyy-MM-dd")}</DataReferencia>
            <Produtos>
                {xmlStringBlocoXEstoqueProduto(blocoXEstoque.DadosEstoque.Produtos)}
            </Produtos>
        </DadosEstoque>
    </Mensagem>
</Estoque>
";

            return xml.StringToXml();
        }

        public static XmlDocument BlocoXListaArquivosToXml(string ie)
        {
            if (ie == null)
                throw new System.ArgumentNullException(nameof(ie));

            var xml =
          $@"
<ListarArquivos Versao='1.0'>
    <Mensagem>
        <IE>{ie}</IE>
    </Mensagem>
</ListarArquivos>
";

            return xml.StringToXml();
        }
        public static XmlDocument BlocoXDownloadArquivoToXml(string recibo)
        {
            if (recibo == null)
                throw new System.ArgumentNullException(nameof(recibo));

            var xml =
          $@"
<DownloadArquivo Versao='1.0'>
    <Mensagem>
        <Recibo>{recibo}</Recibo>
    </Mensagem>
</DownloadArquivo>
";

            return xml.StringToXml();
        }

        public static XmlDocument BlocoXConsultarPendenciasContribuinteToXml(string ie)
        {
            if (ie == null)
                throw new System.ArgumentNullException(nameof(ie));

            var xml =
          $@"
<ConsultarPendenciasContribuinte Versao='1.0'>
    <Mensagem>
        <IE>{ie}</IE>
    </Mensagem>
</ConsultarPendenciasContribuinte>
";

            return xml.StringToXml();
        }

        public static XmlDocument BlocoXConsultarHistoricoArquivoToXml(string recibo)
        {
            if (recibo == null)
                throw new System.ArgumentNullException(nameof(recibo));

            var xml =
          $@"
<ConsultarHistoricoArquivo Versao='1.0'>
    <Mensagem>
        <Recibo>{recibo}</Recibo>
    </Mensagem>
</ConsultarHistoricoArquivo>
";

            return xml.StringToXml();
        }

        public static XmlDocument BlocoXConsultarProcessamentoArquivoToXml(string recibo)
        {
            if (recibo == null)
                throw new System.ArgumentNullException(nameof(recibo));

            var xml =
          $@"
<Manutencao Versao='1.0'>
    <Mensagem>
        <Recibo>{recibo}</Recibo>
    </Mensagem>
</Manutencao>
";

            return xml.StringToXml();
        }

        public static XmlDocument BlocoXCancelarArquivoToXml(string recibo, string motivo)
        {
            if (recibo == null)
                throw new System.ArgumentNullException(nameof(recibo));

            if (motivo == null)
                throw new System.ArgumentNullException(nameof(motivo));

            var xml =
          $@"
<Manutencao Versao='1.0'>
    <Mensagem>
        <Recibo>{recibo}</Recibo>
        <Motivo>{motivo}</Motivo>
    </Mensagem>
</Manutencao>
";

            return xml.StringToXml();
        }

        public static XmlDocument BlocoXConsultarPendenciasDesenvolvedorPafEcfToXml(string cnpj)
        {
            if (cnpj == null)
                throw new System.ArgumentNullException(nameof(cnpj));

            var xml =
          $@"
<ConsultarPendenciasDesenvolvedorPafEcf Versao='1.0'>
    <Mensagem>
        <CNPJ>{cnpj}</CNPJ>
    </Mensagem>
</ConsultarPendenciasDesenvolvedorPafEcf>
";

            return xml.StringToXml();
        }

        public static XmlDocument StringToXml(this string xmlString)
        {
            var xml = new XmlDocument();
            xml.LoadXml(xmlString);

            return xml;
        }

        private static string xmlStringBlocoXRzTotalizadorParcial(List<dynamic> totalizadores)
        {
            var rzTotalizadoresParciais = string.Empty;

            foreach (var totalizador in totalizadores)
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

        private static string xmlStringBlocoXRzTotalizadorParcial(List<Modelos.ReducaoZ.TotalizadorParcial> totalizadores)
        {
            var rzTotalizadoresParciais = string.Empty;

            foreach (var totalizador in totalizadores)
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

            foreach (var produto in produtos)
            {
                strProdutos = $@"
        <Produto>
            <Descricao>{produto.Descricao.Substring(produto.Descricao.LastIndexOf("#") + 1)}</Descricao>
            <CodigoGTIN>{produto.CodigoGTIN}</CodigoGTIN>
            <CodigoCEST>{produto.CodigoCEST}</CodigoCEST>
            <CodigoNCMSH>{produto.NCM}</CodigoNCMSH>
            <CodigoProprio>{produto.CodigoProprio}</CodigoProprio>
            <Quantidade>{produto.Quantidade.ToString("N2").Replace(".", "")}</Quantidade>
            <Unidade>{produto.Unidade}</Unidade>
            <ValorDesconto>{produto.ValorDesconto.ToString("N2").Replace(".", "")}</ValorDesconto>
            <ValorAcrescimo>{produto.ValorAcrescimo.ToString("N2").Replace(".", "")}</ValorAcrescimo>
            <ValorCancelamento>{produto.ValorCancelamento.ToString("N2").Replace(".", "")}</ValorCancelamento>
            <ValorTotalLiquido>{produto.ValorTotalLiquido.ToString("N2").Replace(".", "")}</ValorTotalLiquido>
        </Produto>
";
            }

            return strProdutos;
        }

        private static string xmlStringBlocoXProduto(List<Modelos.ReducaoZ.ProdutoServico> produtos)
        {
            var strProdutos = string.Empty;

            foreach (var produto in produtos)
            {
                strProdutos = $@"
        <Produto>
            <Descricao>{produto.Descricao.Substring(produto.Descricao.LastIndexOf("#") + 1)}</Descricao>
            <CodigoGTIN>{produto.CodigoGTIN}</CodigoGTIN>
            <CodigoCEST>{produto.CodigoCEST}</CodigoCEST>
            <CodigoNCMSH>{produto.CodigoNCMSH}</CodigoNCMSH>
            <CodigoProprio>{produto.CodigoProprio}</CodigoProprio>
            <Quantidade>{produto.Quantidade.ToString("N2").Replace(".", "")}</Quantidade>
            <Unidade>{produto.Unidade}</Unidade>
            <ValorDesconto>{produto.ValorDesconto.ToString("N2").Replace(".", "")}</ValorDesconto>
            <ValorAcrescimo>{produto.ValorAcrescimo.ToString("N2").Replace(".", "")}</ValorAcrescimo>
            <ValorCancelamento>{produto.ValorCancelamento.ToString("N2").Replace(".", "")}</ValorCancelamento>
            <ValorTotalLiquido>{produto.ValorTotalLiquido.ToString("N2").Replace(".", "")}</ValorTotalLiquido>
        </Produto>
";
            }

            return strProdutos;
        }

        private static string xmlStringBlocoXEstoqueProduto(List<dynamic> produtos)
        {
            var strProdutos = string.Empty;

            foreach (var produto in produtos)
            {
                strProdutos = $@"
        <Produto>
            <Descricao>{produto.Descricao.Substring(produto.Descricao.LastIndexOf("#") + 1)}</Descricao>
            <CodigoGTIN>{produto.CodigoGTIN}</CodigoGTIN>
            <CodigoCEST>{produto.CodigoCEST}</CodigoCEST>
            <CodigoNCMSH>{produto.NCM}</CodigoNCMSH>
            <CodigoProprio>{produto.CodigoProprio}</CodigoProprio>
            <Quantidade>{produto.Quantidade.ToString("N3").Replace(".", "")}</Quantidade>
            <QuantidadeTotalAquisicao>{produto.QuantidadeTotalAquisicao.ToString("N3").Replace(".", "")}</Quantidade>
            <Unidade>{produto.Unidade}</Unidade>
            <ValorUnitario>{produto.ValorUnitario.ToString("N3").Replace(".", "")}</ValorUnitario>
            <ValorTotalAquisicao>{produto.ValorTotalAquisicao.ToString("N2").Replace(".", "")}</ValorTotalAquisicao>
            <ValorTotalICMSDebitoFornecedor>{produto.ValorTotalICMSDebitoFornecedor.ToString("N2").Replace(".", "")}</ValorTotalICMSDebitoFornecedor>
            <ValorBaseCalculoICMSST>{produto.ValorBaseCalculoICMSST.ToString("N2").Replace(".", "")}</ValorBaseCalculoICMSST>
            <ValorTotalICMSST>{produto.ValorTotalICMSST.ToString("N2").Replace(".", "")}</ValorTotalICMSST>
            <SituacaoTributaria>{produto.SituacaoTributaria}</SituacaoTributaria>
            <Aliquota>{produto.Aliquota.ToString("N2").Replace(".", "")}</Aliquota>
            <IsArredondado>{produto.IsArredondado}</IsArredondado>
            <Ippt>{produto.Ippt}</Ippt>
            <SituacaoEstoque>{produto.SituacaoEstoque}</SituacaoEstoque>
        </Produto>
";
            }

            return strProdutos;
        }

        private static string xmlStringBlocoXEstoqueProduto(List<Modelos.Estoque.Produto> produtos)
        {
            var strProdutos = string.Empty;

            foreach (var produto in produtos)
            {
                strProdutos = $@"
        <Produto>
            <Descricao>{produto.Descricao.Substring(produto.Descricao.LastIndexOf("#") + 1)}</Descricao>
            <CodigoGTIN>{produto.CodigoGTIN}</CodigoGTIN>
            <CodigoCEST>{produto.CodigoCEST}</CodigoCEST>
            <CodigoNCMSH>{produto.NCM}</CodigoNCMSH>
            <CodigoProprio>{produto.CodigoProprio}</CodigoProprio>
            <Quantidade>{produto.Quantidade.ToString("N3").Replace(".", "")}</Quantidade>
            <QuantidadeTotalAquisicao>{produto.QuantidadeTotalAquisicao.ToString("N3").Replace(".", "")}</QuantidadeTotalAquisicao>
            <Unidade>{produto.Unidade}</Unidade>
            <ValorUnitario>{produto.ValorUnitario.ToString("N3").Replace(".", "")}</ValorUnitario>
            <ValorTotalAquisicao>{produto.ValorTotalAquisicao.ToString("N2").Replace(".", "")}</ValorTotalAquisicao>
            <ValorTotalICMSDebitoFornecedor>{produto.ValorTotalICMSDebitoFornecedor.ToString("N2").Replace(".", "")}</ValorTotalICMSDebitoFornecedor>
            <ValorBaseCalculoICMSST>{produto.ValorBaseCalculoICMSST.ToString("N2").Replace(".", "")}</ValorBaseCalculoICMSST>
            <ValorTotalICMSST>{produto.ValorTotalICMSST.ToString("N2").Replace(".", "")}</ValorTotalICMSST>
            <SituacaoTributaria>{produto.SituacaoTributaria}</SituacaoTributaria>
            <Aliquota>{produto.Aliquota.ToString("N2").Replace(".", "")}</Aliquota>
            <IsArredondado>{(produto.IsArredondado ? "true" : "false")}</IsArredondado>
            <Ippt>{produto.Ippt}</Ippt>
            <SituacaoEstoque>{produto.SituacaoEstoque}</SituacaoEstoque>
        </Produto>
";
            }

            return strProdutos;
        }

        public static string AssinarXML(this string strXml, string tagAssinatura)
        {
            var certificado = Config.Certificado;
            var xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.LoadXml(strXml);

            xmlDocument = xmlDocument.AssinarXML(tagAssinatura);

            return xmlDocument.InnerXml;
        }

        public static XmlDocument AssinarXML(this XmlDocument xmlDocument, string tagAssinatura)
        {
            var certificado = Config.Certificado;

            var reference = new System.Security.Cryptography.Xml.Reference
            {
                Uri = ""
            };

            var signedXml = new System.Security.Cryptography.Xml.SignedXml(xmlDocument)
            {
                SigningKey = certificado.PrivateKey
            };

            reference.AddTransform(new System.Security.Cryptography.Xml.XmlDsigEnvelopedSignatureTransform());

            reference.AddTransform(new System.Security.Cryptography.Xml.XmlDsigC14NTransform());

            signedXml.AddReference(reference);

            var keyInfo = new System.Security.Cryptography.Xml.KeyInfo();

            keyInfo.AddClause(new System.Security.Cryptography.Xml.KeyInfoX509Data(certificado));

            signedXml.KeyInfo = keyInfo;

            signedXml.ComputeSignature();

            var xmlDigitalSignature = signedXml.GetXml();

            xmlDocument.GetElementsByTagName(tagAssinatura)[0].AppendChild(xmlDocument.ImportNode(xmlDigitalSignature, true));

            return xmlDocument;
        }
    }
}
