using Negocio.Dominio;
using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class SeguirEntity : ISeguirRepository
    {
        private SocialWebContext db = new SocialWebContext();

        public void DeixarDeSeguir(Seguir seguir)
        {
            db.Seguirs.Remove(seguir);
            db.SaveChanges();
        }

        public void SeguirPerfil(Seguir seguir)
        {
            db.Seguirs.Add(seguir);
            db.SaveChanges();
        }
        // Metodo que retorna seguidos de um usuario
        public List<Seguir> ObterSeguidos(string userId)
        {
            var seguidos = db.Seguirs.Where(x => x.SeguidorId == userId);
            return seguidos.ToList();
        }

        public void dispose()
        {
            db.Dispose();
        }

        public bool ChecaSeguido(string UserId, int IdSeguido)
        {
            var lista = db.Seguirs.ToList();
            var seguindo = lista.Exists(x => x.SeguidorId == UserId && x.PerfilID == IdSeguido);
            return seguindo;
        }
    }
}
