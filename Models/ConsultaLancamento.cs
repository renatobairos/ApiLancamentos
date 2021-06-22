using System.Collections.Generic;


namespace ApiLancamentos.Models
{
    public class ConsultaLancamento
    {

        public Dictionary<string, double> Totalizadores { get; set; }

        public IEnumerable<Lancamento> Lancamentos { get; set; }

    }
}