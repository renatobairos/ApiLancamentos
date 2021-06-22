using System;
using System.Collections.Generic;
using ApiLancamentos.Models;
using Dapper;
using MySqlConnector;

namespace ApiLancamentos.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private const string Sql = "SELECT * FROM lancamento";
        private readonly string _connectionString;
        public LancamentoRepository(string connectionString)
        {
            _connectionString = connectionString;   // Injetando a string de conexão no construtor da classe
        }

        public IEnumerable<Lancamento> GetAll()
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Lancamento>(Sql);
            }
        }

        public IEnumerable<Lancamento> GetLancamentoByPeriodo(DateTime periodoReferencia)
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Lancamento WHERE data BETWEEN @periodoReferencia AND LAST_DAY(@periodoReferencia)";

                return connection.Query<Lancamento>(sql, new {periodoReferencia});
            }
        }

        public long SaveLancamentos(IEnumerable<Lancamento> lancamentos)
        {
            using(MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string sql = @"INSERT INTO Lancamento 
                                        (Data, Valor, Descricao, Conta, Tipo)
                                 VALUES (@Data, @Valor, @Descricao, @Conta, @Tipo)";

                return connection.Execute(sql, lancamentos);
            }
        }
    }
}