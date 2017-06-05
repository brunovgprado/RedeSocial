﻿using SocialNetwork.core.Repositorio;
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

        //Metodo que retorna um perfil ao receber um id
        public Perfil RetornaPerfilUnico(int id)
        {
            return repositorio.ObterPerfilUnico(id);
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
    }
}
