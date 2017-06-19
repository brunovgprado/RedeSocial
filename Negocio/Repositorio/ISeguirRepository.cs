﻿using Negocio.Dominio;
using System.Collections.Generic;

namespace Negocio.Repositorio
{
    public interface ISeguirRepository
    {
        void SeguirPerfil(Seguir seguir);
        void DeixarDeSeguir(string UserId, int IdSeguido);
        List<Seguir> ObterSeguidos(string userId);
        void dispose();
        bool ChecaSeguido(string UserId, int IdSeguido);
    }
}
