using BlocoX.Modelos;
using System.Text;

namespace BlocoX.Utils.Xml.Tags
{
    public class PafEcfTag
    {
        private PafEcf PafEcf { get; set; }
        private StringBuilder _tag;

        public PafEcfTag(PafEcf pafEcf)
            => PafEcf = pafEcf;

        public StringBuilder ObterTag()
        {
            _tag = new StringBuilder();

            _tag.Append("<PafEcf>");
            _tag.Append($"<NumeroCredenciamento>{PafEcf.NumeroCredenciamento}</NumeroCredenciamento>");
            _tag.Append("</PafEcf>");

            return _tag;
        }
    }
}
