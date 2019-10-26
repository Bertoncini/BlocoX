using BlocoX.Test.BlocoXUtils.Fakes;
using BlocoX.Utils.Xml.ReducaoZ.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocoX.Test.BlocoXUtils.Xml.ReducaoZ.Tags
{
    [TestClass]
    [TestCategory("Dados Reducao Z - Tag dados redução Z com formatação")]
    public class DadosReducaoZTagTest
    {
        [TestMethod]
        public void Deve_validar_tag_reducao_z()
        {
            var dadosReducaoZ = new DadosReducaoZTag(Informacoes.ObterDadosReducaoZ());

            Assert.AreEqual("<DataReferencia>2019-01-01</DataReferencia>" +
                            "<DataHoraEmissao>2019-01-01T12:59:59</DataHoraEmissao>" +
                            "<CRZ>0001</CRZ>" +
                            "<COO>000000100</COO>" +
                            "<CRO>001</CRO>" +
                            "<VendaBrutaDiaria>00000000100000</VendaBrutaDiaria>" +
                            "<GT>000000000000185000</GT>", dadosReducaoZ.ObterTag().ToString());

        }
    }   
}
