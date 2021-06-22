using System.Collections.Generic;
using System.Linq;
using ApiLancamentos.Models;
using ApiLancamentos.Repositories;
using ApiLancamentos.Utils;

namespace ApiLancamentos.Business
{
    public class LancamentoBusiness : ILancamentoBusiness
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        public LancamentoBusiness(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public IEnumerable<Lancamento> GetAll()
        {
           return _lancamentoRepository.GetAll();
        }

        public ConsultaLancamento GetConsultaLancamento(string periodoReferencia) 
        {
            IEnumerable<Lancamento> lancamentos = _lancamentoRepository.GetLancamentoByPeriodo(LancamentoUtils.convertPeriodoReferenciaToDate(periodoReferencia));

            if (!lancamentos.Any())
            {
                return null;
            }

            ConsultaLancamento consultaLancamento = new ConsultaLancamento();
            consultaLancamento.Lancamentos = lancamentos;
            consultaLancamento.Totalizadores = this.CalcTotalizadores(lancamentos);
            
            return consultaLancamento;

        }

        private Dictionary<string, double> CalcTotalizadores(IEnumerable<Lancamento> lancamentos) 
        {
            Dictionary<string, double> totalizadoresDictionary = new Dictionary<string, double>();

            double saldo = 0;
            foreach (Lancamento lancamento in lancamentos)
            {
                if (totalizadoresDictionary.ContainsKey(lancamento.Conta)) 
                {
                    totalizadoresDictionary[lancamento.Conta] += lancamento.Valor;
                } else 
                {
                    totalizadoresDictionary.Add(lancamento.Conta, lancamento.Valor);
                }
                saldo += lancamento.Valor;
            }

            if (!totalizadoresDictionary.ContainsKey("Saldo")) 
            {
                totalizadoresDictionary.Add("Saldo", 0);
            }

            totalizadoresDictionary["Saldo"] = saldo;

            return totalizadoresDictionary;
        }

        public long SaveLancamentos(IEnumerable<Lancamento> lancamentos)
        {
            return _lancamentoRepository.SaveLancamentos(lancamentos);
        }
    }
}