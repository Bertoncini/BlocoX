namespace BlocoX.Modelos.ReducaoZ
{
    using System.Collections.Generic;

    public class TotalizadorParcial
    {
        public TotalizadorParcial(string nome, decimal valor, List<ProdutoServico> produtosServicos)
        {
            Nome = nome;
            Valor = valor;
            ProdutosServicos = produtosServicos;
        }

        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public List<ProdutoServico> ProdutosServicos { get; private set; }

        public void AdicionarTotalizador(ProdutoServico produtoServico)
        {
            if (ProdutosServicos == null)
                ProdutosServicos = new List<ProdutoServico>();

            ProdutosServicos.Add(produtoServico);
        }
    }
}
