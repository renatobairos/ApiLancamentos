using System;

namespace ApiLancamentos.Utils
{
    public class LancamentoUtils {

        public static DateTime convertPeriodoReferenciaToDate(string periodoReferencia)
        {
            return DateTime.Parse(periodoReferencia + "-01");
        }

    }
}