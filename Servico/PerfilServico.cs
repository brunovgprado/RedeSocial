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
        public List<Perfil> RetornaPerfis()
        {
            return repositorio.ObterPerfis();
        }

        //Metodo que cria um novo perfil
        public void CriaPerfil(Perfil perfil)
        {
            repositorio.CriarPerfil(perfil);
        }

        //Metodo que retorna uma horta ao receber um id
        public Perfil RetornaPerfilUnico(int id)
        {
            return repositorio.ObterPerfilUnico(id);
        }

        //Metodo que edita uma horta
        public void EditaPerfil(Perfil perfil)
        {
            repositorio.EditarPerfil(perfil);
        }

        //Metodo que apaga uma horta
        public void ApagaPerfil(Perfil perfil)
        {
            repositorio.ApagarPerfil(perfil);
        }
    }
}
