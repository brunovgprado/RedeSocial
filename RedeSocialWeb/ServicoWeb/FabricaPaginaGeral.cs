using Dados;
using RedeSocialWeb.Models;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialWeb.ServicoWeb
{
    // Classe que monta todos os dados necessários para a entidade 'TodaRedeModel'
    public class FabricaPaginaGeral
    {
        private PerfilServico servicoPerfil;
        private PostagemServico servicoPostagem;

        public FabricaPaginaGeral()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
            servicoPostagem = new PostagemServico(new PostagensEntity());
        }

        public TodaRedeModel MontaPaginaTodaRede()
        {
            TodaRedeModel paginaGeral = new TodaRedeModel();
            paginaGeral.TodosOsPerfis = servicoPerfil.RetornaPerfis(16);// Obtém uma lista de perfis do banco
            var PostagensBanco = servicoPostagem.RetornaPostagens(16).ToList();// Obtém uma lista de postagens do banco
            var postagensConvertidas = PostagemViewModel.GetModel(PostagensBanco);// Converte as postagens de 'Postagem' para 'PostViewModel'
            paginaGeral.TodasAsPostagens = postagensConvertidas;// Adiciona a lista de postagens convertidas à entidade 'TodaRedeModel'

            return paginaGeral;
        }
    }
}