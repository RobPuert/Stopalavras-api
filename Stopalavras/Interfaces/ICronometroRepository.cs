using Stopalavras.Models;

namespace Stopalavras.Interfaces {
    public interface ICronometroRepository {
        Task<List<Cronometro>> ObterCronometro();
        Task AtualizarCronometro(Cronometro cronometro);
    }
}
