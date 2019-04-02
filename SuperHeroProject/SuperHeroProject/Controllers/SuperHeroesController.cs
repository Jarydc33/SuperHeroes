using SuperHeroProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroProject.Controllers
{
    public class SuperHeroesController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<SuperHero> allSuperHeroes = new List<SuperHero>();
            allSuperHeroes = db.SuperHeroes.Select(s => s).ToList();
            return View(allSuperHeroes);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            SuperHero detailsSuperHero = new SuperHero();
            detailsSuperHero = db.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
            return View(detailsSuperHero);
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            SuperHero superHero = new SuperHero();
            return View(superHero);
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                db.SuperHeroes.Add(superHero);
                db.SaveChanges();
                return RedirectToAction("Index"); //this should change
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            SuperHero editSuperHero = new SuperHero();
            editSuperHero = db.SuperHeroes.Where(s => s.Id == id).FirstOrDefault();
            return View(editSuperHero);
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,SuperHero heroToChange)
        {
            SuperHero updatedSuperHero = new SuperHero();
            try
            {
                updatedSuperHero = db.SuperHeroes.Where(s => s.Id == heroToChange.Id).FirstOrDefault();
                updatedSuperHero.name = heroToChange.name;
                updatedSuperHero.alterName = heroToChange.alterName;
                updatedSuperHero.ability = heroToChange.ability;
                updatedSuperHero.secondAbility = heroToChange.secondAbility;
                updatedSuperHero.catchphrase = heroToChange.catchphrase;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
