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

        public void DeixarDeSeguir(string UserId, int IdSeguido)
        {
            var seguir = db.Seguirs.Where(x=>x.SeguidorId == UserId && x.PerfilID == IdSeguido).First();
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
        // Metodo que retorna seguidos de um usuario
        public List<Seguir> ObterSeguidores(int perfilId)
        {
            var seguidores = db.Seguirs.Where(x => x.PerfilID == perfilId);
            return seguidores.ToList();
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

        // Metodo que removerá todos os registros de seguido e seguidor do usuário
        public void executaExclusao(string UserId, int PerfilId)
        {
            // Localiza todos os registros onde o usuario está seguindo alguem
            var listaSeguidos =  db.Seguirs.Where(x => x.SeguidorId == UserId);
            // Localiza todos os registros onde o usuário esteja sendo seguido
            var listaSeguidores = db.Seguirs.Where(x => x.PerfilID == PerfilId);

            // Percorre a lista de seguidos removendo cada registro
            foreach (var seguido in listaSeguidos)
            {
                db.Seguirs.Remove(seguido);   
            }
            db.SaveChanges();

            // Percorre a lista de seguidores removendo cada registro
            foreach (var seguidor in listaSeguidores)
            {
                db.Seguirs.Remove(seguidor);               
            }
            db.SaveChanges();
        }
    }
}
