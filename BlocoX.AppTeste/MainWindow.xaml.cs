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
namespace BlocoX.AppTeste
{
    using BlocoX.Servicos;
    using Microsoft.Win32;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Xml;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServicosBlocoX servicos = new ServicosBlocoX();
        public MainWindow()
        {
            InitializeComponent();

            txtLocalCertificado.Text = readSetting("localCertificado");
            txtSenhaCertificado.Text = readSetting("senhaCertificado");
            rdbXsdSim.IsChecked = Convert.ToBoolean(string.IsNullOrWhiteSpace(readSetting("seValidaXsd")) ? "false" : readSetting("seValidaXsd"));
            txtDiretorioXsd.Text = readSetting("diretorioXsd");
            rdbArquivosSim.IsChecked = Convert.ToBoolean(string.IsNullOrWhiteSpace(readSetting("seSalvaArquivo")) ? "false" : readSetting("seSalvaArquivo"));
            txtDiretorioSalvaArquivo.Text = readSetting("diretorioSalvaArquivo");

            txtEstabelecimentoRazaoSocial.Text = readSetting("estabelecimentoRazaoSocial");
            txtEstabelecimentoCnpj.Text = readSetting("estabelecimentoCnpj");
            txtEstabelecimentoIe.Text = readSetting("estabelecimentoIe");

            txtNumeroCredenciamentoSW.Text = readSetting("swNumeroEstabelecimento");
        }

        private void mensagemAviso(string mensagem) => MessageBox.Show(mensagem, "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var input = showInput("Consultar recibo", "Informe o número do Recibo a ser consultado:");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("O número do recibo é obrigatório!");
                return;
            }

            trataRetorno(servicos.Consultar(input));
        }

        private void BtnSituacaoPafEcf_Click(object sender, RoutedEventArgs e)
        {
            var input = selecionarArquivo("Selecionar arquivo XML", ".xml", "Arquivo XML (.xml)|*.xml");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("O arquivo XML é obrigatório!");
                return;
            }
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(input);

            trataRetorno(servicos.ConsultarSituacaoPafEcf(xmlDoc.InnerXml));
        }

        private void BtnValidar_Click(object sender, RoutedEventArgs e)
        {
            var input = selecionarArquivo("Selecionar arquivo XML", ".xml", "Arquivo XML (.xml)|*.xml");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("O arquivo XML é obrigatório!");
                return;
            }
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(input);

            trataRetorno(servicos.Validar(xmlDoc.InnerXml));
        }

        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            var input = selecionarArquivo("Selecionar arquivo XML", ".xml", "Arquivo XML (.xml)|*.xml");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("O arquivo XML é obrigatório!");
                return;
            }
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(input);

            trataRetorno(servicos.Enviar(xmlDoc.InnerXml));
        }

        private void trataRetorno(Retorno retorno)
        {
            RtbEnvio.Document.Blocks.Clear();
            RtbRetornoStr.Document.Blocks.Clear();
            EnvioStr(RtbEnvio, retorno.SoapSent);
            RetornoStr(RtbRetornoStr, retorno.ResultString);
            if (retorno.ResultXML != null)
                RetornoXml(WebXmlRetorno, retorno.ResultXML);
        }

        private readonly string _path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private void RetornoXml(WebBrowser webBrowser, XmlDocument resultXML)
        {
            var stw = new StreamWriter(_path + @"\tmp.xml");
            stw.WriteLine(resultXML.InnerXml);
            stw.Close();
            webBrowser.Navigate(_path + @"\tmp.xml");
        }

        private void RetornoStr(RichTextBox richTextBox, string resultString)
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.AppendText(resultString);
        }
        private void EnvioStr(RichTextBox richTextBox, string soapSent)
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.AppendText(soapSent);
        }

        private string showInput(string titulo, string descricao, string valorPadrao = "")
        {
            var inputBox = new InputBoxWindow
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Title = titulo,
                txtDescricao = { Text = descricao },
                txtValor = { Text = valorPadrao },
                ResizeMode = ResizeMode.NoResize,
                Topmost = true,
                Owner = this
            };
            inputBox.ShowDialog();
            return inputBox.txtValor.Text;
        }

        public static string selecionarArquivo(string titulo, string extensaoPadrao, string filtro, string arquivoPadrao = null)
        {
            var dlg = new OpenFileDialog
            {
                Title = titulo,
                FileName = arquivoPadrao,
                DefaultExt = extensaoPadrao,
                Filter = filtro
            };
            dlg.ShowDialog();
            return dlg.FileName;
        }

        private void btnSalvarConfig_Click(object sender, RoutedEventArgs e)
        {
            addUpdateAppSettings("localCertificado", txtLocalCertificado.Text);
            addUpdateAppSettings("senhaCertificado", txtSenhaCertificado.Text);
            addUpdateAppSettings("seValidaXsd", rdbXsdSim.IsChecked ?? false ? "true" : "false");
            addUpdateAppSettings("diretorioXsd", txtDiretorioXsd.Text);
            addUpdateAppSettings("seSalvaArquivo", rdbArquivosSim.IsChecked ?? false ? "true" : "false");
            addUpdateAppSettings("diretorioSalvaArquivo", txtDiretorioSalvaArquivo.Text);

            addUpdateAppSettings("estabelecimentoRazaoSocial", txtEstabelecimentoRazaoSocial.Text);
            addUpdateAppSettings("estabelecimentoCnpj", txtEstabelecimentoCnpj.Text);
            addUpdateAppSettings("estabelecimentoIe", txtEstabelecimentoIe.Text);

            addUpdateAppSettings("swNumeroEstabelecimento", txtNumeroCredenciamentoSW.Text);
        }

        private static string readSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                return appSettings[key] ?? string.Empty;
            }
            catch (ConfigurationErrorsException)
            {
                return string.Empty;
            }
        }

        private static void addUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
