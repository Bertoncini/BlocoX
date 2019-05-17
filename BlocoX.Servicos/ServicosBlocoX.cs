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
namespace BlocoX.Servicos
{
    using BlocoX.Servicos.wsdl;
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;

    public class ServicosBlocoX
    {
        public Retorno Consultar(string pRecibo)
        {
            var ws = new WebService("http://webservices.sathomologa.sef.sc.gov.br/wsDfeSiv/Recepcao.asmx", "Consultar");

            ws.Params.Add("pRecibo", pRecibo);
            ws.Invoke();

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno ConsultarSituacaoPafEcf(string pXml)
        {
            var ws = new WebService("http://webservices.sathomologa.sef.sc.gov.br/wsDfeSiv/Recepcao.asmx", "ConsultarSituacaoPafEcf");


            var fileName = "export_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xml";

            byte[] fileBytes = null;

            // create a working memory stream
            using (var memoryStream = new MemoryStream())
            {
                // create a zip
                using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    // add the item name to the zip
                    var zipItem = zip.CreateEntry(fileName);

                    // add the item bytes to the zip entry by opening the original file and copying the bytes 
                    using (var originalFileMemoryStream = new MemoryStream(Encoding.ASCII.GetBytes(pXml)))
                    using (var entryStream = zipItem.Open())
                        originalFileMemoryStream.CopyTo(entryStream);
                }

                fileBytes = memoryStream.ToArray();
            }

            ws.Params.Add("pXml", Convert.ToBase64String(fileBytes));
            ws.Invoke();
            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno Enviar(string pXml)
        {
            var ws = new WebService("http://webservices.sathomologa.sef.sc.gov.br/wsDfeSiv/Recepcao.asmx", "Enviar");

            var fileName = "export_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xml";

            byte[] fileBytes = null;

            // create a working memory stream
            using (var memoryStream = new MemoryStream())
            {
                // create a zip
                using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    // add the item name to the zip
                    var zipItem = zip.CreateEntry(fileName);

                    // add the item bytes to the zip entry by opening the original file and copying the bytes 
                    using (var originalFileMemoryStream = new MemoryStream(Encoding.ASCII.GetBytes(pXml)))
                    using (var entryStream = zipItem.Open())
                        originalFileMemoryStream.CopyTo(entryStream);
                }

                fileBytes = memoryStream.ToArray();
            }

            ws.Params.Add("pXmlZipado", Convert.ToBase64String(fileBytes));

            ws.Invoke();

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno Validar(string pXml)
        {
            var ws = new WebService("http://webservices.sathomologa.sef.sc.gov.br/wsDfeSiv/Recepcao.asmx", "Validar");
            try
            {
                var fileName = "export_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xml";

                byte[] fileBytes = null;

                // create a working memory stream
                using (var memoryStream = new MemoryStream())
                {
                    // create a zip
                    using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        // add the item name to the zip
                        var zipItem = zip.CreateEntry(fileName);

                        // add the item bytes to the zip entry by opening the original file and copying the bytes 
                        using (var originalFileMemoryStream = new MemoryStream(Encoding.ASCII.GetBytes(pXml)))
                        using (var entryStream = zipItem.Open())
                            originalFileMemoryStream.CopyTo(entryStream);
                    }

                    fileBytes = memoryStream.ToArray();
                }

                ws.Params.Add("pXml", Convert.ToBase64String(fileBytes));

                ws.Params.Add("pValidarPafEcfEEcf", "true");
                ws.Params.Add("pValidarAssinaturaDigital", "true");
                ws.Invoke();
                return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
            }
            catch (Exception)
            {
                return new Retorno(ws.ResultXML, "Problema ao validar arquivo", ws.SoapStr);
            }

        }
    }

}