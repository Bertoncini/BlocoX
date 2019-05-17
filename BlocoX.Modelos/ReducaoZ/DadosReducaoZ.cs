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
