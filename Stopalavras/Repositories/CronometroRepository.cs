using Dapper;
using Microsoft.Data.SqlClient;
using Stopalavras.Interfaces;
using Stopalavras.Models;
using System.Data;

namespace Stopalavras.Repositories {
    public class CronometroRepository : ICronometroRepository {

        private readonly IConfiguration _configuration;

        public CronometroRepository(IConfiguration configuration) {
            _configuration = configuration;
        }

        private SqlConnection GetConnection() {
            return new SqlConnection(_configuration
                .GetConnectionString("DefaultConnection"));
        }

        public async Task<List<Cronometro>> ObterCronometro() {
            using var connection = GetConnection();
            var cronometro = await connection
                .QueryAsync<Cronometro>("ObterCronometro", commandType: CommandType.StoredProcedure);
            return cronometro.ToList();
        }

        public async Task AtualizarCronometro(Cronometro cronometro) {
            using var connection = GetConnection();
            var result = await connection
                .ExecuteAsync("AlterarCronometro", new { Segundos = cronometro.Segundos }, commandType: CommandType.StoredProcedure);
        }
    }
}
