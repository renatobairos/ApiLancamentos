using System;
using System.Collections.Generic;
using ApiLancamentos.Models;

namespace ApiLancamentos.Business
{
    public interface ILancamentoBusiness
    {
        IEnumerable<Lancamento> GetAll();

        ConsultaLancamento GetConsultaLancamento(string periodoReferencia);

        long SaveLancamentos(IEnumerable<Lancamento> lancamentos); 

    }
}