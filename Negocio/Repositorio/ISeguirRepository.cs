using Negocio.Dominio;
using System.Collections.Generic;

namespace Negocio.Repositorio
{
    public interface ISeguirRepository
    {
        void SeguirPerfil(Seguir seguir);
        void DeixarDeSeguir(Seguir seguir);
        List<Seguir> ObterSeguidos(string userId);
        void dispose();
        bool ChecaSeguido(string UserId, int IdSeguido);
    }
}
