using Negocio.Repositorio;
using Negocio.Dominio;
using System.Collections.Generic;

namespace Servico
{
    public class PostagemServico
    {
        private IPostagemRepository repositorio { get; set; }

        public PostagemServico(IPostagemRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        //Metodo que retorna todas as Postagens
        public List<Postagem> RetornaPostagens()
        {
            return repositorio.ObterPostagens();
        }

        //Metodo que cria uma nova Postagem
        public void CriaPostagem(Postagem postagem)
        {
            repositorio.CriarPostagem(postagem);
        }

        //Metodo que retorna uma Postagem ao receber um id
        public Postagem RetornaPostagemUnica(int id)
        {
            return repositorio.ObterPostagemUnica(id);
        }

        //Metodo que retorna um perfil ao receber um id
        public List<Postagem> RetornaPostagemUsuario(string UserId)
        {
            return repositorio.ObterPostagensUserId(UserId);
        }

        //Metodo que edita um perfil
        public void EditaPostagem(Postagem postagem)
        {
            repositorio.EditarPostagem(postagem);
        }

        //Metodo que apaga um perfil
        public void ApagaPostagem(Postagem postagem)
        {
            repositorio.ApagarPostagem(postagem);
        }

        public void dispose()
        {
            repositorio.dispose();
        }
    }
}
