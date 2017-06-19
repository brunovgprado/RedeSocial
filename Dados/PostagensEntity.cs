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

        public void CriarPostagem(Postagem postagem)
        {
            try
            {
                db.Postagems.Add(postagem);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                
            }
            
        }

        public void EditarPostagem(Postagem postagem)
        {
            db.Entry(postagem).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Postagem ObterPostagemUnica(int id)
        {
            return db.Postagems.Find(id);
        }

        public List<Postagem> ObterPostagens(int qtd)
        {
            return db.Postagems.Take(qtd).ToList();
        }

        public int ObterTotalPostagensGeral()
        {
            return db.Postagems.Count();
        }

        public void dispose()
        {
            db.Dispose();
        }

        // Retorna todas as postagens de um determinado usuario
        public List<Postagem> ObterPostagensUserId(string userId, int qtd)
        {
            var postagemsUserId = db.Postagems.Where(x => x.UserId == userId).Take(qtd);

            postagemsUserId = postagemsUserId.OrderByDescending(x => x.DataPostagem);

            return postagemsUserId.ToList();
        }
    }
}
