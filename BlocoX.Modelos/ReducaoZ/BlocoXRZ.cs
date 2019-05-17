namespace BlocoX.Modelos.ReducaoZ
{
    public class BlocoXRZ
    {
        public BlocoXRZ(Estabelecimento estabelecimento, PafEcf pafEcf, Ecf ecf)
        {
            Estabelecimento = estabelecimento;
            PafEcf = pafEcf;
            Ecf = ecf;
        }

        public Estabelecimento Estabelecimento { get; private set; }
        public PafEcf PafEcf { get; private set; }
        public Ecf Ecf { get; private set; }
    }
}
