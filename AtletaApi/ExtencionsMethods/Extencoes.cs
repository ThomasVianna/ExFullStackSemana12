using System;

namespace ExtencionsMethods
{
    public static class Extencoes
    {
        public static double ElevadoA(this double numero, double expoente)
        {
            return Math.Pow(numero, expoente);
        }

        public static string RemoverAcentos(this string texto)
        {
            const string comAcentos = "ÁÉÍÓÚáéíóúÀÈÌÒÙàèìòùÂÊÎÔÛâêîôûÃÕãõÄËÏÖÜäëïöüÇç";
            const string semAcentos = "AEIOUaeiouAEIOUaeiouAEIOUaeiouAOaoAEIOUaeiouCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }

            return texto;
        }
    }
}
