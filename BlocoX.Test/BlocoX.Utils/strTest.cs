using BlocoX.Utils;
using BlocoX.Utils.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocoX.Test.BlocoX.Utils
{
    [TestClass]
    [TestCategory("STR - Classe corta e completa")]
    public class strTest
    {
        [TestMethod]
        public void Deve_validar_alinhamento_a_esquerda()
        {
            var texto = 10;
            Assert.AreEqual("0010", texto.ToString().CortaCompleta(4, "0", Alinhamento.Esquerda));
        }

        [TestMethod]
        public void Deve_validar_alinhamento_a_direita()
        {
            var texto = 10;
            Assert.AreEqual("1000", texto.ToString().CortaCompleta(4, "0", Alinhamento.Direita));
        }


        [TestMethod]
        public void Deve_validar_PreencherComEspacoEmBranco_alinhado_a_esquerda()
        {
            var texto = 10;
            Assert.AreEqual("  10", texto.ToString().CortaCompleta(4, null, Alinhamento.Esquerda));
        }

        [TestMethod]
        public void Deve_validar_PreencherComEspacoEmBranco_alinhado_a_direita()
        {
            var texto = 10;
            Assert.AreEqual("10  ", texto.ToString().CortaCompleta(4, null, Alinhamento.Direita));
        }

        [TestMethod]
        public void Deve_validar_Venda_bruta_diaria()
        {
            var numero = 10.00m;
            Assert.AreEqual("00000000001000", numero.ToString("n2").Replace(",", "").Replace(".", "").CortaCompleta(14, "0", Alinhamento.Esquerda));
        }


        [TestMethod]
        public void Deve_validar_GT()
        {
            var numero = 10.00m;
            Assert.AreEqual("000000000000001000", numero.ToString("n2").Replace(",", "").Replace(".", "").CortaCompleta(18, "0", Alinhamento.Esquerda));
        }
    }
}
