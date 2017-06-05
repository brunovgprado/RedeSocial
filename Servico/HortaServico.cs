using Negocio.Repositorio;
using Negocio.Dominio;
using System.Collections.Generic;

namespace Servico
{
    public class HortaServico
    {
        private IHortaRepository repositorio { get; set; }

        public HortaServico(IHortaRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        //Metodo que retorna todos os perfis
        public List<Horta> RetornaHortas()
        {
            return repositorio.ObterHortas();
        }

        //Metodo que cria um novo perfil
        public void CriaHorta(Horta horta)
        {
            repositorio.CriarHorta(horta);
        }

        //Metodo que retorna uma horta ao receber um id
        public Horta RetornaHortaUnica(int id)
        {
            return repositorio.ObterHortaUnica(id);
        }

        //Metodo que edita uma horta
        public void EditaHorta(Horta horta)
        {
            repositorio.EditarHorta(horta);
        }

        //Metodo que apaga uma horta
        public void ApagaHorta(Horta horta)
        {
            repositorio.ApagarHorta(horta);
        }
    }
}
