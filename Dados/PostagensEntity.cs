using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Negocio.Dominio;

namespace Dados
{
    public class PostagensEntity : IPostagemRepository
    {
        SocialWebContext db = new SocialWebContext();

        public void ApagarPostagem(Postagem horta)
        {
            throw new NotImplementedException();
        }

        public bool CriarPostagem(Postagem horta)
        {
            throw new NotImplementedException();
        }

        public void EditarPostagem(Postagem id)
        {
            throw new NotImplementedException();
        }

        public Postagem ObterPostagemUnica(int id)
        {
            throw new NotImplementedException();
        }

        public List<Postagem> ObterPostagens()
        {
           return db.Postagems.ToList();
        }

        public void dispose()
        {
            db.Dispose();
        }

        public List<Postagem> ObterPostagensUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
