using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Negocio.Dominio;

namespace Dados
{
    public class HortasEntity : IHortaRepository
    {
        SocialWebContext db = new SocialWebContext();

        public void ApagarHorta(Horta horta)
        {
            db.Hortas.Remove(horta);
            db.SaveChanges();
        }

        public void EditarHorta(Horta horta)
        {
            db.Entry(horta).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<Horta> ObterHortas()
        {           
            List<Horta> perfis = db.Hortas.ToList();

            return perfis;
        }

        public bool CriarHorta(Horta horta)
        {
            try{
                db.Hortas.Add(horta);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public Horta ObterHortaUnica(int id)
        {
            Horta horta = db.Hortas.Find(id);
            return horta;
        }

        public void dispose()
        {
            db.Dispose();
        }
    }
}
