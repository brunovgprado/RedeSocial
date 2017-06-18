using Negocio.Repositorio;
using Negocio.Dominio;
using System.Collections.Generic;

namespace Servico
{
    public class PerfilServico
    {
        private IPerfilRepository repositorio { get; set; }

        public PerfilServico(IPerfilRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        //Metodo que retorna todos os perfis
        public List<Perfil> RetornaPerfis(int qtd)
        {
            return repositorio.ObterPerfis(qtd);
        }

        //Metodo que cria um novo perfil
        public void CriaPerfil(Perfil perfil)
        {
            repositorio.CriarPerfil(perfil);
        }

        //Metodo que retorna um perfil ao receber um id
        public Perfil RetornaPerfilUnico(int id)
        {
            return repositorio.ObterPerfilUnico(id);
        }

        //Metodo que retorna um perfil ao receber um id
        public Perfil RetornaPerfilUsuario(string UserId)
        {
            return repositorio.ObterPerfilUsuario(UserId);
        }

        //Metodo que edita um perfil
        public void EditaPerfil(Perfil perfil)
        {
            repositorio.EditarPerfil(perfil);
        }

        //Metodo que apaga um perfil
        public void ApagaPerfil(Perfil perfil)
        {
            repositorio.ApagarPerfil(perfil);
        }

        public void dispose()
        {
            repositorio.dispose();
        }
    }
}
