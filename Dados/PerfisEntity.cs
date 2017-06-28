using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Negocio.Dominio;

namespace Dados
{
    public class PerfisEntity : IPerfilRepository
    {
        SocialWebContext db = new SocialWebContext();

        public void ApagarPerfil(Perfil perfil)
        {
            db.Perfils.Remove(perfil);
            db.SaveChanges();
        }

        public void EditarPerfil(Perfil perfil)
        {
            db.Entry(perfil).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Perfil ObterPerfilUnico(int id)
        {
            Perfil perfil = db.Perfils.Find(id);
            return perfil;
        }

        public Perfil ObterPerfilUsuario(string UserID)
        {
            try{
                Perfil perfil = db.Perfils.Where(x => x.UserID == UserID).First();
                return perfil;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Perfil> ObterPerfis(int qtd)
        {           
            var perfis = db.Perfils.Take(qtd);
            return perfis.ToList();
        }

        public void CriarPerfil(Perfil perfil)
        {
            db.Perfils.Add(perfil);
            db.SaveChanges();        
        }

        public List<Perfil> BuscaDePerfis(string TermosBusca)
        {
            var perfis = db.Perfils.Where(x => x.NomeExibicao.Contains(TermosBusca)).OrderBy(x => x.NomeExibicao);
            return perfis.ToList();
        }

        public void dispose()
        {
            db.Dispose();
        }
        // Metodo que remove o perfil do usuário
        public void executaExclusao(string UserId, int PerfilId)
        {
            var perfil = db.Perfils.Find(PerfilId);
            db.Perfils.Remove(perfil);
            db.SaveChanges();
        }
    }
}
