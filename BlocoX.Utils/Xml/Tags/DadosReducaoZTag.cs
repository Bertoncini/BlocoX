using BlocoX.Modelos.ReducaoZ;
using BlocoX.Utils.Utils;
using System.Text;

namespace BlocoX.Utils.Xml.Tags
{
    public class DadosReducaoZTag
    {
        private DadosReducaoZ DadosReducaoZ { get; set; }
        private StringBuilder _tag;

        public DadosReducaoZTag(DadosReducaoZ dadosReducaoZ)
            => DadosReducaoZ = dadosReducaoZ;

        public StringBuilder ObterTag()
        {
            _tag = new StringBuilder();

            _tag.Append($"<DataReferencia>{DadosReducaoZ.DataReferencia.ToString("yyyy-MM-dd")}</DataReferencia>");
            _tag.Append($"<DataHoraEmissao>{DadosReducaoZ.DataHoraEmissao.ToString("yyyy-MM-ddTHH:mm:ss")}</DataHoraEmissao>");
            _tag.Append($"<CRZ>{DadosReducaoZ.CRZ.ToString().CortaCompleta(4, "0")}</CRZ>");
            _tag.Append($"<COO>{DadosReducaoZ.COO.ToString().CortaCompleta(9, "0")}</COO>");
            _tag.Append($"<CRO>{DadosReducaoZ.CRO.ToString().CortaCompleta(3, "0")}</CRO>");
            _tag.Append($"<VendaBrutaDiaria>{DadosReducaoZ.VendaBrutaDiaria.DecimalParaString().CortaCompleta(14, "0")}</VendaBrutaDiaria>");
            _tag.Append($"<GT>{DadosReducaoZ.GT.DecimalParaString().CortaCompleta(18, "0")}</GT>");

            return _tag;
        }

    
    }
}
