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
namespace BlocoX.Modelos.ReducaoZ
{
    using System;
    using System.Collections.Generic;

    public class DadosReducaoZ
    {
        public DadosReducaoZ(DateTime dataReferencia, DateTime dataHoraEmissao, int cRZ, int cOO, int cRO, decimal vendaBrutaDiaria, decimal gT, List<TotalizadorParcial> totalizadoresParciais)
        {
            DataReferencia = dataReferencia;
            DataHoraEmissao = dataHoraEmissao;
            CRZ = cRZ;
            COO = cOO;
            CRO = cRO;
            VendaBrutaDiaria = vendaBrutaDiaria;
            GT = gT;
            TotalizadoresParciais = totalizadoresParciais;
        }

        public DateTime DataReferencia { get; private set; }
        public DateTime DataHoraEmissao { get; private set; }
        public int CRZ { get; private set; }
        public int COO { get; private set; }
        public int CRO { get; private set; }
        public decimal VendaBrutaDiaria { get; private set; }
        public decimal GT { get; private set; }
        public List<TotalizadorParcial> TotalizadoresParciais { get; private set; }

        public void AdicionarTotalizador(TotalizadorParcial totalizador)
        {
            if (TotalizadoresParciais == null)
                TotalizadoresParciais = new List<TotalizadorParcial>();

            TotalizadoresParciais.Add(totalizador);
        }
    }
}
