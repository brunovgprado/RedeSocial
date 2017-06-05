using SocialNetwork.core.Dominio;
using SocialNetwork.negocio.Dominio;
using System.Collections.Generic;

namespace SocialNetwork.core.Repositorio
{
    public interface IHortaRepository
    {
        List<Horta> ObterHortas();
        bool CriarHorta(Horta horta);
        Horta ObterHortaUnica(int id);
        void EditarHorta(Horta id);
        void ApagarHorta(Horta horta);
    }
}
