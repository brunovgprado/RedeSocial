using Negocio.Repositorio;
using Negocio.Dominio;
using System.Collections.Generic;

namespace Servico
{
    public class PlantaServico
    {
        private IPlantaRepository repositorio { get; set; }

        public PlantaServico(IPlantaRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        //Metodo que retorna todos os perfis
        public List<Planta> RetornaPlantas()
        {
            return repositorio.ObterPlantas();
        }

        //Metodo que cria um novo perfil
        public void CriaPlanta(Planta planta)
        {
            repositorio.CriarPlanta(planta);
        }

        //Metodo que retorna uma horta ao receber um id
        public Planta RetornaPlantaUnica(int id)
        {
            return repositorio.ObterPlantaUnica(id);
        }

        //Metodo que edita uma horta
        public void EditaPlanta(Planta planta)
        {
            repositorio.EditarPlanta(planta);
        }

        //Metodo que apaga uma horta
        public void ApagaPlanta(Planta planta)
        {
            repositorio.ApagarPlanta(planta);
        }

        public void dispose()
        {
            repositorio.dispose();
        }
    }
}
