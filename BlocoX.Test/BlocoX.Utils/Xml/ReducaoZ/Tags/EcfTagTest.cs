using BlocoX.Test.BlocoXUtils.Fakes;
using BlocoX.Utils.Xml.ReducaoZ.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocoX.Test.BlocoXUtils.Xml.ReducaoZ.Tags
{
    [TestClass]
    [TestCategory("ECF - Validar informações de ECF")]
    public class EcfTagTest
    {
        [TestMethod]
        public void Deve_validar_informacoes_ecf()
        {
            var ecf = new EcfTag(Informacoes.ObterECF());
            Assert.AreEqual("<NumeroFabricacao>UR010905000</NumeroFabricacao>", ecf.ObterTag().ToString());
        }
    }
}
