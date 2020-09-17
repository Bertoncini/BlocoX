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
    public interface IBlocoX
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recibo">Número do recibo a cancelar</param>
        /// <param name="motivo">Motivo do cancelamento</param>
        /// <returns></returns>
        Retorno CancelarArquivo(string recibo, string motivo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recibo">Número do recibo</param>
        /// <returns></returns>
        Retorno ConsultarHistoricoArquivo(string recibo);
        /// <summary>
        /// Retorna as pendências dos arquivos do Bloco X e a situação do bloqueio do PAF-ECF para um determinado contribuinte. 
        /// </summary>
        /// <param name="ie">Inscrição Estadual do contribuinte</param>
        /// <returns></returns>
        Retorno ConsultarPendenciasContribuinte(string ie);
        /// <summary>
        /// Retorna a quantidade de pendências dos arquivos do Bloco X para todos os contribuintes associados a um determinado desenvolvedor de PAF-ECF
        /// </summary>
        /// <param name="cnpj">CNPJ do desenvolvedor do PAF-ECF</param>
        /// <returns></returns>
        Retorno ConsultarPendenciasDesenvolvedorPafEcf(string cnpj);
        /// <summary>
        /// Retorna o estado do processamento do arquivo de Redução Z ou do Estoque.
        /// </summary>
        /// <returns></returns>
        Retorno ConsultarProcessamentoArquivo(string recibo);
        /// <summary>
        /// Lista os últimos 100 arquivos transmitidos, ordenados pela data de recepção.
        /// </summary>
        /// <param name="ie">Inscrição Estadual do contribuinte</param>
        /// <returns></returns>
        Retorno ListarArquivos(string ie);
        /// <summary>
        /// Transmite o arquivo de Redução Z
        /// </summary>
        /// <param name="xmlReducaoZ"></param>
        /// <returns></returns>
        Retorno TransmitirArquivoRZ(string xmlReducaoZ);
        /// <summary>
        /// Transmite o arquivo de Estoque
        /// </summary>
        /// <param name="xmlEstoque"></param>
        /// <returns></returns>
        Retorno TransmitirArquivoEstoque(string xmlEstoque);
        /// <summary>
        /// Reprocessar arquivo do Bloco X
        /// </summary>
        /// <returns></returns>
        Retorno ReprocessarArquivo();
        /// <summary>
        /// Consultar status dos métodos do Bloco X
        /// </summary>
        /// <returns></returns>
        Retorno ConsultarStatusMetodosBlocoX();
        /// <summary>
        /// Download do arquivo de Redução Z ou de Estoque do Bloco X. 
        /// </summary>
        /// <param name="recibo">Número do recibo</param>
        /// <returns></returns>
        Retorno DownloadArquivo(string recibo);
    }
}