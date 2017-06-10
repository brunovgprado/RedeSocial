using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Negocio.Dominio;
using RedeSocialWeb.Models;
using Dados;

namespace RedeSocialWeb.Controllers
{
    public class PostagemsController : Controller
    {
        private SocialWebContext db = new SocialWebContext();

        // GET: Postagems
        public ActionResult Index()
        {
            return View(db.Postagems.ToList());
        }

        // GET: Postagems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postagem postagem = db.Postagems.Find(id);
            if (postagem == null)
            {
                return HttpNotFound();
            }
            return View(postagem);
        }

        // GET: Postagems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Postagems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,PerfilId,DataPostagem,FotoPostagem,TextoPostagem")] Postagem postagem)
        {
            if (ModelState.IsValid)
            {
                db.Postagems.Add(postagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postagem);
        }

        // GET: Postagems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postagem postagem = db.Postagems.Find(id);
            if (postagem == null)
            {
                return HttpNotFound();
            }
            return View(postagem);
        }

        // POST: Postagems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,PerfilId,DataPostagem,FotoPostagem,TextoPostagem")] Postagem postagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postagem);
        }

        // GET: Postagems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postagem postagem = db.Postagems.Find(id);
            if (postagem == null)
            {
                return HttpNotFound();
            }
            return View(postagem);
        }

        // POST: Postagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Postagem postagem = db.Postagems.Find(id);
            db.Postagems.Remove(postagem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
