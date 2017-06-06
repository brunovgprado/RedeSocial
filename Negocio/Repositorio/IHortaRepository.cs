using Negocio.Dominio;
using System.Collections.Generic;

namespace Negocio.Repositorio
{
    public interface IHortaRepository
    {
        List<Horta> ObterHortas();
        bool CriarHorta(Horta horta);
        Horta ObterHortaUnica(int id);
        void EditarHorta(Horta id);
        void ApagarHorta(Horta horta);
        void dispose();
    }
}
