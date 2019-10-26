using BlocoX.Test.BlocoXUtils.Fakes;
using BlocoX.Utils.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocoX.Test.BlocoXUtils.Xml
{
    [TestClass]
    [TestCategory("Estabelecimento - Tag estabelecimento Redução Z e Estoque")]
    public class EstabelecimentoTagTest
    {
        [TestMethod]
        public void Deve_validar_tag_estabelecimento()
        {
            var estabelecimento = new EstabelecimentoTag(Informacoes.ObterEstabelecimento());

            Assert.AreEqual("<Estabelecimento>"+
                                "<Ie>257477110</Ie>" +
                            "</Estabelecimento>", estabelecimento.ObterTag().ToString());
        }
        
    }
}
