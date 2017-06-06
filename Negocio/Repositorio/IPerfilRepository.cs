using Negocio.Dominio;
using System.Collections.Generic;

namespace Negocio.Repositorio
{
    public interface IPerfilRepository
    {
        List<Perfil> ObterPerfis();
        bool CriarPerfil(Perfil perfil);
        Perfil ObterPerfilUnico(int id);
        void EditarPerfil(Perfil id);
        void ApagarPerfil(Perfil perfil);
        void dispose();
    }
}
