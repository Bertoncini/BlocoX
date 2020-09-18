﻿/********************************************************************************/
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
    using BlocoX.Utils;
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
        private readonly string _path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        ServicosBlocoX servicos;
        Config config;

        private void ValidarConfiguracaoServico()
        {
            config = new Config
            (
                rdbProducao.IsChecked.Value,
                txtLocalCertificado.Text,
                txtSenhaCertificado.Text,
                txtDiretorioSalvaArquivo.Text
            );

            servicos = new ServicosBlocoX(config);
        }

        public MainWindow()
        {
            InitializeComponent();

            txtLocalCertificado.Text = readSetting("localCertificado");
            txtSenhaCertificado.Text = readSetting("senhaCertificado");
            //rdbXsdSim.IsChecked = Convert.ToBoolean(string.IsNullOrWhiteSpace(readSetting("seValidaXsd")) ? "0" : readSetting("seValidaXsd"));
            //txtDiretorioXsd.Text = readSetting("diretorioXsd");
            rdbArquivosSim.IsChecked = Convert.ToBoolean(string.IsNullOrWhiteSpace(readSetting("seSalvaArquivo")) ? "0" : readSetting("seSalvaArquivo"));
            txtDiretorioSalvaArquivo.Text = readSetting("diretorioSalvaArquivo");

            txtEstabelecimentoRazaoSocial.Text = readSetting("estabelecimentoRazaoSocial");
            txtEstabelecimentoCnpj.Text = readSetting("estabelecimentoCnpj");
            txtEstabelecimentoIe.Text = readSetting("estabelecimentoIe");

            txtNumeroCredenciamentoSW.Text = readSetting("swNumeroEstabelecimento");
        }

        private void mensagemAviso(string mensagem) => MessageBox.Show(mensagem, "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

        private MessageBoxResult mensagemConfrimacao(string mensagem) => MessageBox.Show(mensagem, "Atenção", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No, MessageBoxOptions.DefaultDesktopOnly);

        private void btnConsultarHistoricoArquivo_Click(object sender, RoutedEventArgs e)
        {
            var input = showInput("Consultar Historico Arquivo", "Informe o número do Recibo a ser consultado:");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("O número do recibo é obrigatório!");
                return;
            }

            ValidarConfiguracaoServico();
            trataRetorno(servicos.ConsultarHistoricoArquivo(input));
        }

        private void btnConsultarProcessamentoArquivo_Click(object sender, RoutedEventArgs e)
        {
            var input = showInput("Consultar Processamento Arquivo", "Informe o número do Recibo a ser consultado:");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("O número do recibo é obrigatório!");
                return;
            }

            ValidarConfiguracaoServico();
            trataRetorno(servicos.ConsultarProcessamentoArquivo(input));
        }

        private void btnDownloadArquivo_Click(object sender, RoutedEventArgs e)
        {
            var input = showInput("Download Arquivo", "Informe o número do Recibo para realizar o download do arquivo:");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("O número do recibo é obrigatório!");
                return;
            }

            ValidarConfiguracaoServico();
            trataRetorno(servicos.DownloadArquivo(input));
        }

        private void btnCancelarArquivo_Click(object sender, RoutedEventArgs e)
        {
            var recibo = showInput("Cancelar Arquivo", "Informe o número do Recibo a ser cancelado:");
            if (string.IsNullOrWhiteSpace(recibo))
            {
                mensagemAviso("O número do recibo é obrigatório!");
                return;
            }

            var motivo = showInput("Cancelar Arquivo", "Informe o motivo do cancelamento:");
            if (string.IsNullOrWhiteSpace(motivo))
            {
                mensagemAviso("O número do motivo é obrigatório!");
                return;
            }

            ValidarConfiguracaoServico();
            trataRetorno(servicos.CancelarArquivo(recibo, motivo));
        }

        private void btnConsultarPendenciaContribuinte_Click(object sender, RoutedEventArgs e)
        {
            var input = showInput("Consultar Pendencia Contribuinte", "Informe o número da Inscrição Estadual:");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("O número da Inscrição estadual é obrigatório!");
                return;
            }

            ValidarConfiguracaoServico();
            trataRetorno(servicos.ConsultarPendenciasContribuinte(input));
        }

        private void btnConsultarPendenciDesenvolvedorPafEcf_Click(object sender, RoutedEventArgs e)
        {
            var input = showInput("Consultar Pendencia Desenvolvedor PAF ECF", "Informe o número o CNPJ:");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("O número do CNPJ é obrigatório!");
                return;
            }

            ValidarConfiguracaoServico();
            trataRetorno(servicos.ConsultarPendenciasDesenvolvedorPafEcf(input));
        }

        private void btnListarArquivos_Click(object sender, RoutedEventArgs e)
        {
            var input = showInput("Listar Arquivos", "Informe o número da Inscrição Estadual:");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("O número da Inscrição estadual é obrigatório!");
                return;
            }

            ValidarConfiguracaoServico();
            trataRetorno(servicos.ListarArquivos(input));
        }

        private void btnTransmitirReducaoZ_Click(object sender, RoutedEventArgs e)
        {
            var input = selecionarArquivo("Selecionar arquivo XML", ".xml", "Arquivo XML (.xml)|*.xml");
            var xmlDoc = new System.Xml.XmlDocument();
            if (string.IsNullOrWhiteSpace(input))
            {
                if (mensagemConfrimacao("Não foi informado um XML, deseja enviar um default?") == MessageBoxResult.No)
                    return;

                if (string.IsNullOrWhiteSpace(txtLocalCertificado.Text) || string.IsNullOrWhiteSpace(txtSenhaCertificado.Text))
                {
                    mensagemAviso("Para enviar o arquivo default deve se informar o certificado para realizar a assinatura!");
                    return;
                }

                xmlDoc = new Utils.Arquivos.Exemplo().BlocoXRz();
                xmlDoc.AssinarXML("ReducaoZ", config.Certificado);
            }
            else
                xmlDoc.Load(input);

            ValidarConfiguracaoServico();
            trataRetorno(servicos.TransmitirArquivoRZ(xmlDoc.InnerXml));
        }

        private void btnTransmitirEstoque_Click(object sender, RoutedEventArgs e)
        {
            ValidarConfiguracaoServico();

            var input = selecionarArquivo("Selecionar arquivo XML", ".xml", "Arquivo XML (.xml)|*.xml");
            var xmlDoc = new System.Xml.XmlDocument();
            if (string.IsNullOrWhiteSpace(input))
            {
                if (mensagemConfrimacao("Não foi informado um XML, deseja enviar um default?") == MessageBoxResult.No)
                    return;

                if (string.IsNullOrWhiteSpace(txtLocalCertificado.Text) || string.IsNullOrWhiteSpace(txtSenhaCertificado.Text))
                {
                    mensagemAviso("Para enviar o arquivo default deve se informar o certificado para realizar a assinatura!");
                    return;
                }

                xmlDoc = new Utils.Arquivos.Exemplo().EstoqueXml();
                xmlDoc.AssinarXML("Estoque", config.Certificado);
            }
            else
                xmlDoc.Load(input);

            trataRetorno(servicos.TransmitirArquivoEstoque(xmlDoc.InnerXml));
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

            //addUpdateAppSettings("seValidaXsd", rdbXsdSim.IsChecked ?? false ? "1" : "0");
            //addUpdateAppSettings("diretorioXsd", txtDiretorioXsd.Text);

            addUpdateAppSettings("seSalvaArquivo", rdbArquivosSim.IsChecked ?? false ? "1" : "0");
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

        private static void addUpdateAppSettings(string key, object value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value.ToString());
                }
                else
                {
                    settings[key].Value = value.ToString();
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private void btnArqCertificado_Click(object sender, RoutedEventArgs e)
        {
            var input = selecionarArquivo("Selecionar Certificado", ".pdf", "Certificado (.pfx)|*.pfx");
            if (string.IsNullOrWhiteSpace(input))
            {
                mensagemAviso("Não foi selecionado um certificado.");
                return;
            }

            txtLocalCertificado.Text = input;
        }

        private string selecionarDiretorio()
        {
            var diretorio = string.Empty;
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    diretorio = dialog.SelectedPath;
            }

            return diretorio;
        }

        private void btnDiretorioSalvarArquivos_Click(object sender, RoutedEventArgs e)
        {
            var caminho = selecionarDiretorio();
            txtDiretorioSalvaArquivo.Text = caminho;
        }

        private void btnDiretorioXSD_Click(object sender, RoutedEventArgs e)
        {
            //var caminho = selecionarDiretorio();
            //txtDiretorioXsd.Text = caminho;
        }
    }




























}
