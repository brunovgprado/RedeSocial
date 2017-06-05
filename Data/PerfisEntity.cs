using SocialNetwork.core.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.negocio.Dominio;
using SocialNetwork.data;
using System.Data.Entity;

namespace Data
{
    public class PerfisEntity : IPerfilRepository
    {
        SocialNetworkContext db = new SocialNetworkContext();

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

        public List<Perfil> ObterPerfis()
        {           
            List<Perfil> perfis = db.Perfils.ToList();

            return perfis;
        }

        bool IPerfilRepository.CriarPerfil(Perfil perfil)
        {
            try{
                db.Perfils.Add(perfil);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
