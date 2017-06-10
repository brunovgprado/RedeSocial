using Negocio.Repositorio;
using Negocio.Dominio;
using System.Collections.Generic;

namespace Servico
{
    public class SeguirServico
    {
        private ISeguirRepository repositorio { get; set; }

        public SeguirServico(ISeguirRepository repositorio)
        {
            this.repositorio = repositorio;
        }
        
        public void SeguirPerfil(Seguir seguir)
        {
            repositorio.SeguirPerfil(seguir);
        }

        public void DeixarDeSeguir(Seguir seguir)
        {
            repositorio.DeixarDeSeguir(seguir);
        }

        public void dispose()
        {
            repositorio.dispose();
        }
    }
}
