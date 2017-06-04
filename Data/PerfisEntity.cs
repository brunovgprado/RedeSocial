using SocialNetwork.core.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.negocio.Dominio;
using SocialNetwork.data;

namespace Data
{
    public class PerfisEntity : IPerfilRepository
    {
        SocialNetworkContext db = new SocialNetworkContext();

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
