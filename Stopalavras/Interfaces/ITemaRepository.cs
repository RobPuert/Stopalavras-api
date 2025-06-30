using Stopalavras.Models;

namespace Stopalavras.Interfaces {
    public interface ITemaRepository {
        Task<List<Tema>>ObterTemas();
        Task<Tema>ObterTemaPorId(int? id);
        Task InserirTema(Tema tema);
        Task AtualizarTema(Tema tema);
        Task DeletarTema(int? id);
    }
}
