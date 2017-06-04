using SocialNetwork.core.Repositorio;
using SocialNetwork.negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.data
{
    public class PerfilServico
    {
        private IPerfilRepository repositorio { get; set; }

        public PerfilServico(IPerfilRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Perfil> RetornaPerfis()
        {
            return repositorio.ObterPerfis();
        }

        public void CriaPerfil(Perfil perfil)
        {
            repositorio.CriarPerfil(perfil);
        }
    }
}
