namespace BlocoX.Modelos.ReducaoZ
{
    public class ProdutoServico
    {
        public ProdutoServico(string descricao, string codigoGTIN, string codigoCEST, string nCM, string codigoProprio, int quantidade, string unidade, decimal valorDesconto, decimal valorAcrescimo, decimal valorCancelamento, decimal valorTotalLiquido, bool seServico)
        {
            Descricao = descricao;
            CodigoGTIN = codigoGTIN;
            CodigoCEST = codigoCEST;
            NCM = nCM;
            CodigoProprio = codigoProprio;
            Quantidade = quantidade;
            Unidade = unidade;
            ValorDesconto = valorDesconto;
            ValorAcrescimo = valorAcrescimo;
            ValorCancelamento = valorCancelamento;
            ValorTotalLiquido = valorTotalLiquido;
            SeServico = seServico;
        }

        public string Descricao { get; private set; }
        public string CodigoGTIN { get; private set; }
        public string CodigoCEST { get; private set; }
        public string NCM { get; private set; }
        public string CodigoProprio { get; private set; }
        public int Quantidade { get; private set; }
        public string Unidade { get; private set; }
        public decimal ValorDesconto { get; private set; }
        public decimal ValorAcrescimo { get; private set; }
        public decimal ValorCancelamento { get; private set; }
        public decimal ValorTotalLiquido { get; private set; }
        public bool SeServico { get; private set; }
    }
}
