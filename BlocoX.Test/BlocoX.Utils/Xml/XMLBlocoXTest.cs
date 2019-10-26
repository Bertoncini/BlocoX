using BlocoX.Test.BlocoXUtils.Fakes;
using BlocoX.Utils.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocoX.Test.BlocoXUtils.Xml
{
    [TestClass]
    [TestCategory("")]
    public class XMLBlocoXTest
    {
        [TestMethod]
        public void Deve_validar_xml_reducao_z()
        {
            var reducaoZ = new XMLBlocoX(Informacoes.ObterEstabelecimento(),
                                         Informacoes.ObterPafEcf(),
                                         Informacoes.ObterXMlReducaoZ());

            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-8""?>" +
                            @"<ReducaoZ Versao=""1.0"">" +
                                "<Mensagem>" +
                                    "<Estabelecimento>" +
                                        "<Ie>257477110</Ie>" +
                                    "</Estabelecimento>" +
                                    "<PafEcf>" +
                                        "<NumeroCredenciamento>123456789012345</NumeroCredenciamento>" +
                                    "</PafEcf>" +
                                    "<Ecf>" +
                                      	"<NumeroFabricacao>UR010905000</NumeroFabricacao>" +
                                        "<DadosReducaoZ>" +
                                            "<DataReferencia>2019-01-01</DataReferencia>" +
                                            "<DataHoraEmissao>2019-01-01T12:59:59</DataHoraEmissao>" +
                                            "<CRZ>0001</CRZ>" +
                                            "<COO>000000100</COO>" +
                                            "<CRO>001</CRO>" +
                                            "<VendaBrutaDiaria>00000000100000</VendaBrutaDiaria>" +
                                            "<GT>000000000000185000</GT>" +
                                            "<TotalizadoresParciais>" +
                                                "<TotalizadorParcial>" +
                                                    "<Nome>01T1700</Nome>" +
                                                    "<Valor>2000,00</Valor>" +
                                                    "<ProdutosServicos>" +
                                                        "<Produto>" +
                                                            "<Descricao>PRODUTO ALIQUOTA 1700</Descricao>" +
                                                            "<CodigoGTIN></CodigoGTIN>" +
                                                            "<CodigoCEST>1400300</CodigoCEST>" +
                                                            "<CodigoNCMSH>11041900</CodigoNCMSH>" +
                                                            "<CodigoProprio>220601</CodigoProprio>" +
                                                            "<Quantidade>2,000</Quantidade>" +
                                                            "<Unidade>UN</Unidade>" +
                                                            "<ValorDesconto>0,00</ValorDesconto>" +
                                                            "<ValorAcrescimo>0,00</ValorAcrescimo>" +
                                                            "<ValorCancelamento>0,00</ValorCancelamento>" +
                                                            "<ValorTotalLiquido>1000,00</ValorTotalLiquido>" +
                                                        "</Produto>" +
                                                        "<Produto>" +
                                                            "<Descricao>PRODUTO ALIQUOTA 1700</Descricao>" +
                                                            "<CodigoGTIN></CodigoGTIN>" +
                                                            "<CodigoCEST>1400300</CodigoCEST>" +
                                                            "<CodigoNCMSH>11041900</CodigoNCMSH>" +
                                                            "<CodigoProprio>220601</CodigoProprio>" +
                                                            "<Quantidade>2,000</Quantidade>" +
                                                            "<Unidade>UN</Unidade>" +
                                                            "<ValorDesconto>0,00</ValorDesconto>" +
                                                            "<ValorAcrescimo>0,00</ValorAcrescimo>" +
                                                            "<ValorCancelamento>0,00</ValorCancelamento>" +
                                                            "<ValorTotalLiquido>1000,00</ValorTotalLiquido>" +
                                                        "</Produto>" +
                                                    "</ProdutosServicos>" +
                                                "</TotalizadorParcial>" +
                                            "</TotalizadoresParciais>" +
                                        "</DadosReducaoZ>" +
                                    "</Ecf>" +
                                "</Mensagem>" +
                            "</ReducaoZ>", reducaoZ.ObterXML().InnerXml);

        }

    }
}
