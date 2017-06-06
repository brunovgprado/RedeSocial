using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Negocio.Dominio;

namespace Dados
{
    public class PlantasEntity : IPlantaRepository
    {
        SocialWebContext db = new SocialWebContext();

        public void ApagarPlanta(Planta planta)
        {
            db.Plantas.Remove(planta);
            db.SaveChanges();
        }

        public void EditarPlanta(Planta planta)
        {
            db.Entry(planta).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Planta ObterPlantaUnica(int id)
        {
            Planta planta = db.Plantas.Find(id);

            return planta;
        }

        public List<Planta> ObterPlantas()
        {           
            List<Planta> planta = db.Plantas.ToList();

            return planta;
        }

        public bool CriarPlanta(Planta planta)
        {
            try{
                db.Plantas.Add(planta);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public void dispose()
        {
            db.Dispose();
        }
    }
}
