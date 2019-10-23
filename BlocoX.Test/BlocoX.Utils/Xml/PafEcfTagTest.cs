using BlocoX.Test.BlocoXUtils.Fakes;
using BlocoX.Utils.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocoX.Test.BlocoXUtils.Xml
{
    [TestClass]
    [TestCategory("PafEcf - Tag estabelecimento Redução Z e Estoque")]
    public class PafEcfTagTest
    {
        [TestMethod]
        public void Deve_validar_tag_pafecf()
        {
            var pafEcf = new PafEcfTag(Informacoes.ObterPafEcf());

            Assert.AreEqual("<PafEcf>" +
                                "<NumeroCredenciamento>123456789012345</NumeroCredenciamento>" +
                            "</PafEcf>", pafEcf.ObterTag().ToString());

        }

    }
}
