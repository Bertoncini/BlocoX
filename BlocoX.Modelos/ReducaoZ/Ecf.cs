namespace BlocoX.Modelos.ReducaoZ
{
    public class Ecf
    {
        public Ecf(string numeroFabricacao, DadosReducaoZ dadosReducaoZ)
        {
            NumeroFabricacao = numeroFabricacao;
            DadosReducaoZ = dadosReducaoZ;
        }

        public string NumeroFabricacao { get; private set; }
        public DadosReducaoZ DadosReducaoZ { get; private set; }
    }
}
