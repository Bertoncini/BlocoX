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
using BlocoX.Utils.Enums;

namespace BlocoX.Utils
{
    public static class Str
    {
        /// <summary>
        /// Corta e completa a string de acordo com o tamanho e orientação passadas
        /// </summary>
        /// <param name="str">String a ser modificada</param>
        /// <param name="quantidadeDeCasas">Tamanho final da string</param>
        /// <param name="valorParaPreencher">String a completa os espaços</param>
        /// <param name="alinhamento">Completa a esquerda ou direita</param>
        /// <returns>Nova string modificada</returns>
        public static string CortaCompleta(this string str, int quantidadeDeCasas = 1, string valorParaPreencher = null, Alinhamento alinhamento = Alinhamento.Esquerda)
        {
            if (PreencherComEspacoEmBranco(valorParaPreencher))
                return ObterTextoAlinhadoComEspacoEmBranco(alinhamento, str, quantidadeDeCasas);

            return ObterTextoAlinhadoComEspacoEmBranco(alinhamento, str, quantidadeDeCasas).Replace(" ", valorParaPreencher);

        }

        private static bool PreencherComEspacoEmBranco(string stringComplementar)
            => string.IsNullOrWhiteSpace(stringComplementar);

        private static string ObterTextoAlinhadoComEspacoEmBranco(Alinhamento alinhamento, string texto, int quantidadeDeCasas)
        {
            if (alinhamento == Alinhamento.Esquerda)
                return texto.PadLeft(quantidadeDeCasas);

            return texto.PadRight(quantidadeDeCasas);
        }

    }
}
