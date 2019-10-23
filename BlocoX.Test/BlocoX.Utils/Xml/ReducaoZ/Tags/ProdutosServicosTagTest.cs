using BlocoX.Modelos.ReducaoZ;
using BlocoX.Test.BlocoXUtils.Fakes;
using BlocoX.Utils.Xml.ReducaoZ.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlocoX.Test.BlocoXUtils.Xml.ReducaoZ.Tags
{
    [TestClass]
    [TestCategory("Produtos - Validar Tags Produtos e Serviços")]
    public class ProdutosServicosTagTest
    {
        [TestMethod]
        public void Deve_validar_tag_produtos_servicos()
        {
            var produtoServicosTag = new ProdutosServicosTag(Informacoes.ObterListaProdutos());

            Assert.AreEqual("<ProdutosServicos>" +
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
                            "</ProdutosServicos>", produtoServicosTag.ObterTag().ToString());

        }

    }
}
