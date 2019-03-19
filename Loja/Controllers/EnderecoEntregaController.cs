﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Loja.Models;

namespace Loja.Controllers
{
    public class EnderecoEntregaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnderecoEntrega
        public ActionResult Index()
        {
            return View(db.EnderecoEntregas.ToList());
        }

        // GET: EnderecoEntrega/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEntrega enderecoEntrega = db.EnderecoEntregas.Find(id);
            if (enderecoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(enderecoEntrega);
        }

        // GET: EnderecoEntrega/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnderecoEntrega/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CEP,Estado,Cidade,Bairro,Logradouro,Numero,Observacao,DataCadastro")] EnderecoEntrega enderecoEntrega)
        {
            if (ModelState.IsValid)
            {
                db.EnderecoEntregas.Add(enderecoEntrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enderecoEntrega);
        }

        // GET: EnderecoEntrega/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEntrega enderecoEntrega = db.EnderecoEntregas.Find(id);
            if (enderecoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(enderecoEntrega);
        }

        // POST: EnderecoEntrega/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CEP,Estado,Cidade,Bairro,Logradouro,Numero,Observacao,DataCadastro")] EnderecoEntrega enderecoEntrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enderecoEntrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enderecoEntrega);
        }

        // GET: EnderecoEntrega/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoEntrega enderecoEntrega = db.EnderecoEntregas.Find(id);
            if (enderecoEntrega == null)
            {
                return HttpNotFound();
            }
            return View(enderecoEntrega);
        }

        // POST: EnderecoEntrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnderecoEntrega enderecoEntrega = db.EnderecoEntregas.Find(id);
            db.EnderecoEntregas.Remove(enderecoEntrega);
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