using Negocio.Dominio;
using System.Collections.Generic;

namespace Negocio.Repositorio
{
    public interface IPostagemRepository
    {
        List<Postagem> ObterPostagens(int qtd);
        List<Postagem> ObterPostagensUserId(string userId, int qtd);
        void CriarPostagem(Postagem postagem);
        Postagem ObterPostagemUnica(int id);
        void EditarPostagem(Postagem postagem);
        void ApagarPostagem(Postagem horta);
        int ObterTotalPostagens();
        void dispose();
    }
}
