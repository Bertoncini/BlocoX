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
    using BlocoX.Utils;
    using BlocoX.Utils.Xml;
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;

    public class ServicosBlocoX : IBlocoX
    {
        string urlWebServicesBase = "http://webservices.sathomologa.sef.sc.gov.br/wsDfeSiv/BlocoX.asmx";
        const string SoapActionBase = "http://webservices.sef.sc.gov.br/wsDfeSiv/";
        private Config _config;

        public ServicosBlocoX(Config config)
        {
            _config = config;
            if (_config.Ambiente)
                urlWebServicesBase = "http://webservices.sef.sc.gov.br/wsDfeSiv/BlocoX.asmx";
            else
                urlWebServicesBase = "http://webservices.sathomologa.sef.sc.gov.br/wsDfeSiv/BlocoX.asmx";
        }

        public Retorno CancelarArquivo(string recibo, string motivo)
        {
            var ws = new WebService(urlWebServicesBase, "CancelarArquivo", SoapActionBase);
            var xml = BlocoX.Utils.XML.BlocoXCancelarArquivoToXml(recibo, motivo).InnerXml;
            var pXml = BlocoX.Utils.XML.AssinarXML(xml, "Manutencao", _config.Certificado);

            salvarArquivo(pXml, "CancelarArquivo", $"Env_{recibo}.xml");

            ws.Params.Add("pXml", pXml.Replace("<", "&lt;").Replace(">", "&gt;"));

            ws.Invoke();

            salvarArquivo(ws.ResultXML.InnerXml, "CancelarArquivo", $"Ret_{recibo}.xml");

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno ConsultarHistoricoArquivo(string recibo)
        {
            var ws = new WebService(urlWebServicesBase, "ConsultarHistoricoArquivo", SoapActionBase);
            var xml = BlocoX.Utils.XML.BlocoXConsultarHistoricoArquivoToXml(recibo).InnerXml;
            var pXml = BlocoX.Utils.XML.AssinarXML(xml, "ConsultarHistoricoArquivo", _config.Certificado);

            salvarArquivo(pXml, "ConsultarHistoricoArquivo", $"Env_{recibo}.xml");

            ws.Params.Add("pXml", pXml.Replace("<", "&lt;").Replace(">", "&gt;"));

            ws.Invoke();

            salvarArquivo(ws.ResultXML.InnerXml, "ConsultarHistoricoArquivo", $"Ret_{recibo}.xml");

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno ConsultarPendenciasContribuinte(string ie)
        {
            var ws = new WebService(urlWebServicesBase, "ConsultarPendenciasContribuinte", SoapActionBase);
            var xml = BlocoX.Utils.XML.BlocoXConsultarPendenciasContribuinteToXml(ie).InnerXml;
            var pXml = BlocoX.Utils.XML.AssinarXML(xml, "ConsultarPendenciasContribuinte", _config.Certificado);

            salvarArquivo(pXml, "ConsultarPendenciasContribuinte", $"Env_{ie}.xml");
            ws.Params.Add("pXml", pXml.Replace("<", "&lt;").Replace(">", "&gt;"));

            ws.Invoke();
            salvarArquivo(ws.ResultXML.InnerXml, "ConsultarPendenciasContribuinte", $"Ret_{ie}.xml");

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno ConsultarPendenciasDesenvolvedorPafEcf(string cnpj)
        {
            var ws = new WebService(urlWebServicesBase, "ConsultarPendenciasDesenvolvedorPafEcf", SoapActionBase);
            var xml = BlocoX.Utils.XML.BlocoXConsultarPendenciasDesenvolvedorPafEcfToXml(cnpj).InnerXml;
            var pXml = BlocoX.Utils.XML.AssinarXML(xml, "ConsultarPendenciasDesenvolvedorPafEcf", _config.Certificado);

            salvarArquivo(pXml, "ConsultarPendenciasDesenvolvedorPafEcf", $"Env_{cnpj}.xml");
            ws.Params.Add("pXml", pXml.Replace("<", "&lt;").Replace(">", "&gt;"));

            ws.Invoke();
            salvarArquivo(ws.ResultXML.InnerXml, "ConsultarPendenciasDesenvolvedorPafEcf", $"Ret_{cnpj}.xml");

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno ConsultarProcessamentoArquivo(string recibo)
        {
            var ws = new WebService(urlWebServicesBase, "ConsultarProcessamentoArquivo", SoapActionBase);
            var xml = BlocoX.Utils.XML.BlocoXConsultarProcessamentoArquivoToXml(recibo).InnerXml;
            var pXml = BlocoX.Utils.XML.AssinarXML(xml, "Manutencao", _config.Certificado);

            salvarArquivo(pXml, "ConsultarProcessamentoArquivo", $"Env_{recibo}.xml");
            ws.Params.Add("pXml", pXml.Replace("<", "&lt;").Replace(">", "&gt;"));

            ws.Invoke();
            salvarArquivo(ws.ResultXML.InnerXml, "ConsultarProcessamentoArquivo", $"Ret_{recibo}.xml");

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno ListarArquivos(string ie)
        {
            var ws = new WebService(urlWebServicesBase, "ListarArquivos", SoapActionBase);
            var xml = BlocoX.Utils.XML.BlocoXListaArquivosToXml(ie).InnerXml;
            var pXml = BlocoX.Utils.XML.AssinarXML(xml, "ListarArquivos", _config.Certificado);

            salvarArquivo(pXml, "ListarArquivos", $"Env_{ie}.xml");
            ws.Params.Add("pXml", pXml.Replace("<", "&lt;").Replace(">", "&gt;"));

            ws.Invoke();
            salvarArquivo(ws.ResultXML.InnerXml, "ListarArquivos", $"Ret_{ie}.xml");

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno TransmitirArquivoRZ(string xmlReducaoZ)
        {
            var ws = new WebService(urlWebServicesBase, "TransmitirArquivo", SoapActionBase);

            var xmlCompactado = Compacta(xmlReducaoZ);
            var data = DateTime.Now;
            salvarArquivo(xmlReducaoZ, "ReducaoZ", $"Env_XML_{data.ToString("yyyyMMddHHmmss")}.xml");
            salvarArquivo(xmlCompactado, "ReducaoZ", $"Env_Compactado_{data.ToString("yyyyMMddHHmmss")}.xml");

            ws.Params.Add("pXmlCompactado", xmlCompactado);

            ws.Invoke();
            salvarArquivo(ws.ResultXML.InnerXml, "ReducaoZ", $"Ret_{data.ToString("yyyyMMddHHmmss")}.xml");

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno TransmitirArquivoEstoque(string xmlEstoque)
        {
            var ws = new WebService(urlWebServicesBase, "TransmitirArquivo", SoapActionBase);

            var xmlCompactado = Compacta(xmlEstoque);
            var data = DateTime.Now;
            salvarArquivo(xmlEstoque, "Estoque", $"Env_XML_{data.ToString("yyyyMMddHHmmss")}.xml");
            salvarArquivo(xmlCompactado, "Estoque", $"Env_Compactado_{data.ToString("yyyyMMddHHmmss")}.xml");

            ws.Params.Add("pXmlCompactado", xmlCompactado);

            ws.Invoke();
            salvarArquivo(ws.ResultXML.InnerXml, "Estoque", $"Ret_{data.ToString("yyyyMMddHHmmss")}.xml");

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno DownloadArquivo(string recibo)
        {
            var ws = new WebService(urlWebServicesBase, "DownloadArquivo", SoapActionBase);
            var xml = BlocoX.Utils.XML.BlocoXDownloadArquivoToXml(recibo).InnerXml;
            var pXml = BlocoX.Utils.XML.AssinarXML(xml, "DownloadArquivo", _config.Certificado);

            salvarArquivo(pXml, "DownloadArquivo", $"Env_{recibo}.xml");
            ws.Params.Add("pXml", pXml.Replace("<", "&lt;").Replace(">", "&gt;"));

            ws.Invoke();
            salvarArquivo(ws.ResultXML.InnerXml, "DownloadArquivo", $"Ret_{recibo}.xml");

            return new Retorno(ws.ResultXML, ws.ResultString, ws.SoapStr);
        }

        public Retorno ReprocessarArquivo() => throw new NotImplementedException();
        public Retorno ConsultarStatusMetodosBlocoX() => throw new NotImplementedException();

        private void salvarArquivo(string conteudo, string diretorio, string arquivoExtensao)
        {
            if (string.IsNullOrWhiteSpace(_config.DiretorioSalvarArquivos))
                return;

            diretorio = $"{_config.DiretorioSalvarArquivos}\\{diretorio}";
            var caminhoArquivo = $"{diretorio}\\{arquivoExtensao}";

            if (!Directory.Exists(diretorio))
                Directory.CreateDirectory(diretorio);

            var qtdMesmoArquivoNoDiretorio = Directory.GetFiles(diretorio, $"*{arquivoExtensao.Substring(0, arquivoExtensao.Length - 4)}*").Length.ToString();

            caminhoArquivo = caminhoArquivo.Insert(caminhoArquivo.Length - 4, $"_{qtdMesmoArquivoNoDiretorio}");

            File.WriteAllText(caminhoArquivo, conteudo);
        }

        private static string Compacta(string text)
        {
            var fileName = "export_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";

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
                    using (var originalFileMemoryStream = new MemoryStream(Encoding.ASCII.GetBytes(text)))
                    using (var entryStream = zipItem.Open())
                        originalFileMemoryStream.CopyTo(entryStream);
                }

                fileBytes = memoryStream.ToArray();
            }

            return Convert.ToBase64String(fileBytes);
        }

    }

}