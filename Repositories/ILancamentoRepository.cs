using System;
using System.Collections.Generic;
using ApiLancamentos.Models;

namespace ApiLancamentos.Repositories
{
    public interface ILancamentoRepository
    {
        IEnumerable<Lancamento> GetAll();

        IEnumerable<Lancamento> GetLancamentoByPeriodo(DateTime periodoReferencia);

        long SaveLancamentos(IEnumerable<Lancamento> lancamentos); 

    }
}