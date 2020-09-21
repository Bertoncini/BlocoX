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
namespace BlocoX.Servicos.wsdl
{
    using BlocoX.Utils;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Web;
    using System.Xml;

    internal class WebService
    {
        public string Url { get; private set; }
        public string MethodName { get; private set; }
        public Dictionary<string, string> Params = new Dictionary<string, string>();
        public XmlDocument ResultXML { get; private set; }
        public string ResultString { get; private set; }
        public string SoapStr { get; private set; }
        public string SoapAction { get; private set; }

        public WebService(string urlBase, string methodName, string soapActionBase)
        {
            Url = urlBase.Trim();
            MethodName = methodName.Trim();
            SoapAction = soapActionBase.Trim();
        }

        /// <summary>
        /// Invokes service
        /// </summary>
        public void Invoke() => Invoke(false);

        /// <summary>
        /// Invokes service
        /// </summary>
        /// <param name="encode">Added parameters will encode? (default: true)</param>
        public void Invoke(bool encode)
        {
            SoapStr =
               @"<?xml version=""1.0"" encoding=""utf-8""?>
              <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                 xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                 xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                 <soap:Body>
                     <{0} xmlns=""{1}"">
                      {2}
                    </{0}>
                 </soap:Body>
              </soap:Envelope>";

            var req = (HttpWebRequest)WebRequest.Create(Url);
            req.Headers.Add("SOAPAction", $"{SoapAction}{MethodName}");
            req.ContentType = "text/xml;charset=\"utf-8\"";
            req.Accept = "text/xml";
            req.Method = "POST";

            using (var stm = req.GetRequestStream())
            {
                var postValues = "";
                foreach (var param in Params)
                {
                    if (encode)
                        postValues += string.Format("<{0}>{1}</{0}>", System.Net.WebUtility.UrlEncode(param.Key.Trim()), System.Net.WebUtility.UrlEncode(param.Value.Trim()));
                    else
                        postValues += string.Format("<{0}>{1}</{0}>", param.Key.Trim(), param.Value.Trim());
                }

                SoapStr = string.Format(SoapStr, MethodName, SoapAction, postValues);
                using (var stmw = new StreamWriter(stm))
                {
                    stmw.Write(SoapStr);
                }
            }

            using (var responseReader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                var result = responseReader.ReadToEnd();
                ResultXML = result.StringToXml();
                ResultString = result.Replace("&gt;", "<").Replace("&lt;", ">");
            }
        }

    }
}