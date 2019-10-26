/********************************************************************************/
/* Projeto: Biblioteca BlocoX                                                   */
/* Biblioteca C# para emissão do BlocoX (ReduçãoZ e Estoque)                    */
/*https://www.confaz.fazenda.gov.br/legislacao/despacho/2017/dp045_17           */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2019 Alexsandro Bertoncini                  */
/*                                       alex.bertoncini@terra.com.br           */
/*                                                                              */
/*  Você pode obter a última versão desse arquivo no GitHub                     */
/* localizado em https://github.com/Bertoncini/BlocoX                           */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la */
/* sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) */
/* qualquer versão posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      */
/* ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto*/
/* com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  */
/* no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Você também pode obter uma copia da licença em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/********************************************************************************/

using BlocoX.Modelos.ReducaoZ;
using BlocoX.Utils.Xml.Interfaces;
using BlocoX.Utils.Xml.Reducaoz.Tags;
using BlocoX.Utils.Xml.ReducaoZ.Tags;
using System.Text;

namespace BlocoX.Utils.Xml
{
    public class XmlReducaoZ : IBlocoX
    {
        private BlocoXRZ ReducaoZ { get; set; }
        private StringBuilder _tag;

        public XmlReducaoZ(BlocoXRZ reducaoZ)
            => ReducaoZ = reducaoZ;

        public StringBuilder ObterTag()
        {
            _tag = new StringBuilder();

            ObterTagAberturaECF();

            ObterTagECF();

            ObterTagAberturaDadosReducaoZ();

            ObterTagDadosReducaoZ();
            ObterTagTotalizadores();

            ObterTagFechamentoDadosReducaoZ();

            ObterTagFechamentoECF();

            return _tag;
        }

        private void ObterTagAberturaECF()
            => _tag.Append("<Ecf>");

        private void ObterTagAberturaDadosReducaoZ()
            => _tag.Append("<DadosReducaoZ>");

        private void ObterTagECF()
        {
            var ecf = new EcfTag(ReducaoZ.Ecf);
            _tag.Append(ecf.ObterTag());

        }

        private void ObterTagDadosReducaoZ()
        {
            var dadosReducaoZ = new DadosReducaoZTag(ReducaoZ.DadosReducaoZ);
            _tag.Append(dadosReducaoZ.ObterTag());

        }

        private void ObterTagTotalizadores()
        {
            _tag.Append("<TotalizadoresParciais>");

            foreach (var totalizador in ReducaoZ.TotalizadoresParciais)
            {
                var totalizadorTag = new TotalizadoresTag(totalizador);
                _tag.Append(totalizadorTag.ObterTag());

            }

            _tag.Append("</TotalizadoresParciais>");

        }

        private void ObterTagFechamentoDadosReducaoZ()
            => _tag.Append("</DadosReducaoZ>");

        private void ObterTagFechamentoECF()
          => _tag.Append("</Ecf>");
    }
}
