using BlocoX.Modelos;
using System.Text;

namespace BlocoX.Utils.Xml.Tags
{
    public class EstabelecimentoTag
    {
        private Estabelecimento Estabelecimento { get; set; }
        private StringBuilder _tag;

        public EstabelecimentoTag(Estabelecimento estabelecimento)
            => Estabelecimento = estabelecimento;

        public StringBuilder ObterTag()
        {
            _tag = new StringBuilder();

            _tag.Append("<Estabelecimento>");
            _tag.Append($"<Ie>{Estabelecimento.Ie}</Ie>");
            _tag.Append("</Estabelecimento>");

            return _tag;
        }

    }
}
