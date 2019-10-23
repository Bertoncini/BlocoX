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

using BlocoX.Modelos;
using BlocoX.Utils.Xml.Interfaces;
using System.Text;
using System.Xml;

namespace BlocoX.Utils.Xml
{
    public class XMLBlocoX
    {
        private Estabelecimento Estabelecimento { get; set; }
        private PafEcf PafEcf { get; set; }
        private IBlocoX BlocoX { get; set; }
        private StringBuilder _tag;

        public XMLBlocoX(Estabelecimento estabelecimento, PafEcf pafEcf, IBlocoX blocoX)
        {
            Estabelecimento = estabelecimento;
            PafEcf = pafEcf;
            BlocoX = blocoX;
        }

        public XmlDocument ObterXML()
        {
            var xml = new XmlDocument();
            xml.LoadXml(ObterTag().ToString());

            return xml;
        }

        public StringBuilder ObterTag()
        {
            _tag = new StringBuilder();

            _tag.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            _tag.Append(@"<ReducaoZ Versao=""1.0"">");
            ObterTagAberturaMensagem();
            ObterTagHeader();
            ObterTagBody();
            ObterTagFechamentoMensagem();
            _tag.Append("</ReducaoZ>");

            return _tag;
        }

        private void ObterTagAberturaMensagem()
            => _tag.Append("<Mensagem>");

        private void ObterTagHeader()
        {
            var header = new HeaderXML(Estabelecimento, PafEcf);
            _tag.Append(header.ObterTag());

        }

        private void ObterTagBody()
            => _tag.Append(BlocoX.ObterTag());

        private void ObterTagFechamentoMensagem()
            => _tag.Append("</Mensagem>");
    }
}
