namespace BlocoX.Utils.Utils
{
    public static class Utils
    {
        public static string DecimalParaString(this decimal valor)
        {
            var stringValor = valor.ToString("n2");
            stringValor = stringValor.Replace(",", "");
            stringValor = stringValor.Replace(".", "");
            return stringValor;
        }

    }
}
