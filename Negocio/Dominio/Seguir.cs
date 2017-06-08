using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Negocio.Dominio
{
    public class Seguir
    {
        public int id { get; set; }
        public string SeguidorId { get; set; }
        public int PerfilID { get; set; }
        public int HortaID { get; set; }
        public int PlantaID { get; set; }
    }
}