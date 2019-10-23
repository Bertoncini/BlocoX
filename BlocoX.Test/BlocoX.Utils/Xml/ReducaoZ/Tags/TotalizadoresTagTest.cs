using BlocoX.Test.BlocoXUtils.Fakes;
using BlocoX.Utils.Xml.Reducaoz.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocoX.Test.BlocoXUtils.Xml.ReducaoZ.Tags
{
    [TestClass]
    [TestCategory("Totalizadores - Registro totalizadores")]
    public class TotalizadoresTagTest
    {
        [TestMethod]
        public void Deve_validar_tag_totalizadores()
        {
            var produtoServicosTag = new TotalizadoresTag(Informacoes.ObterTotalizadorParcial());

            Assert.AreEqual("<TotalizadorParcial>" +
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
                            "</TotalizadorParcial>", produtoServicosTag.ObterTag().ToString());

        }
    }
}
