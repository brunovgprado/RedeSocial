using Negocio.Dominio;
using System.Collections.Generic;

namespace Negocio.Repositorio
{
    public interface IPostagemRepository
    {
        List<Postagem> ObterPostagens();
        List<Postagem> ObterPostagensUserId(string userId);
        bool CriarPostagem(Postagem horta);
        Postagem ObterPostagemUnica(int id);
        void EditarPostagem(Postagem id);
        void ApagarPostagem(Postagem horta);
        void dispose();
    }
}
