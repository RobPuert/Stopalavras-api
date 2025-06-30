using Dapper;
using Microsoft.Data.SqlClient;
using Stopalavras.Interfaces;
using Stopalavras.Models;
using System.Data;

namespace Stopalavras.Repositories {
    public class TemaRepository : ITemaRepository {

        private readonly IConfiguration _configuration;

        public TemaRepository(IConfiguration configuration) {
            _configuration = configuration;
        }
        private SqlConnection GetConnection() {
            return new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));
        }

        public async Task<List<Tema>> ObterTemas() {
            using var connection = GetConnection();
            var temas = await connection
                .QueryAsync<Tema>("ObterTema", commandType: CommandType.StoredProcedure);
            return temas.ToList();
        }

        public async Task<Tema> ObterTemaPorId(int? id) {
            using var connection = GetConnection();
            var tema = await connection
                .QueryFirstOrDefaultAsync<Tema>("ObterTema", new { Id = id }, commandType: CommandType.StoredProcedure);
            return tema;
        }

        public async Task InserirTema(Tema tema) {
            using var connection = GetConnection();
            var result = await connection
                .ExecuteAsync("InserirTema", new { Titulo = tema.Titulo }, commandType: CommandType.StoredProcedure);
        }

        public async Task AtualizarTema(Tema tema) {
            using var connection = GetConnection();
            var result = await connection
                .ExecuteAsync("AlterarTema", new { Id = tema.Id, Titulo = tema.Titulo }, commandType: CommandType.StoredProcedure);
        }

        public async Task DeletarTema(int? id) {
            using var connection = GetConnection();
            var result = await connection
                .ExecuteAsync("ExcluirTema", new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
