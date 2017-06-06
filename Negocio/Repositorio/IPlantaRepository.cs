using Negocio.Dominio;
using System.Collections.Generic;

namespace Negocio.Repositorio
{
    public interface IPlantaRepository
    {
        List<Planta> ObterPlantas();
        bool CriarPlanta(Planta planta);
        Planta ObterPlantaUnica(int id);
        void EditarPlanta(Planta id);
        void ApagarPlanta(Planta planta);
        void dispose();
    }
}
