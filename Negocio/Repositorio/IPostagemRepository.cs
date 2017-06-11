using Negocio.Dominio;
using System.Collections.Generic;

namespace Negocio.Repositorio
{
    public interface IPostagemRepository
    {
        List<Postagem> ObterPostagens();
        List<Postagem> ObterPostagensUserId(string userId);
        void CriarPostagem(Postagem postagem);
        Postagem ObterPostagemUnica(int id);
        void EditarPostagem(Postagem postagem);
        void ApagarPostagem(Postagem horta);
        void dispose();
    }
}
