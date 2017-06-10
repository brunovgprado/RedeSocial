using Negocio.Dominio;
using System.Collections.Generic;

namespace Negocio.Repositorio
{
    public interface ISeguirRepository
    {
        void SeguirPerfil(Seguir seguir);
        void DeixarDeSeguir(Seguir seguir);
        void dispose();
    }
}
