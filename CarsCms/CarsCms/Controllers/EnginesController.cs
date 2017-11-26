using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarsCms.Models;
using CarsCms.Repository.Interfaces;
using CarsCms.ViewModels;
using CarsCms.Interfaces;
using CarsCms.Validations;

namespace CarsCms.Controllers
{
    public class EnginesController : Controller
    {
        private IEngineRepository _engineRepository;
        private ICarBusinessLogic _businessLogic;

        public EnginesController(IEngineRepository engineRepository, ICarBusinessLogic businessLogic)
        {
            _engineRepository = engineRepository;
            _businessLogic = businessLogic;

        }
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Engines
        public ActionResult Index()
        {
            var engineVM = new VMEngine { EngineList = new List<Engine>() };
            engineVM.ShowIfAuth = _businessLogic.CheckIfUserIsAutorize();
            if (engineVM.ShowIfAuth)
                engineVM.EngineList = _engineRepository.GetWhere(x => x.Id > 0);
            else
                engineVM.EngineList = _engineRepository.GetWhere(x => x.Id > 0 && x.IsActive);

            return View(engineVM);
        }

        // GET: Engines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var engineVM = new VMEngine();
            engineVM.Eng = _engineRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            engineVM.ShowIfAuth = _businessLogic.CheckIfUserIsAutorize();

            if (engineVM.Eng == null)
            {
                return HttpNotFound();
            }
            return View(engineVM.Eng);
        }

        // GET: Engines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Engines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMEngine model)
        {
            var validator = new EngineValidator();
            var result= validator.Validate(model.Eng);
            if(result.Errors.Any())
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            else
            {
                _engineRepository.Create(model.Eng);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Engines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var engineVM = new VMEngine();
            engineVM.Eng = _engineRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            engineVM.ShowIfAuth = _businessLogic.CheckIfUserIsAutorize();
            if (engineVM.Eng == null)
            {
                return HttpNotFound();
            }
            return View(engineVM);
        }

        // POST: Engines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMEngine model)
        {
            var validator = new EngineValidator();
            var result = validator.Validate(model.Eng);
            if (result.Errors.Any())
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.ErrorMessage);
                }
            else
            {
                _engineRepository.Create(model.Eng);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Engines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engine engine = _engineRepository.Engines.Find(id);
            if (engine == null)
            {
                return HttpNotFound();
            }
            return View(engine);
        }

        // POST: Engines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Engine engine = _engineRepository.Engines.Find(id);
            _engineRepository.Engines.Remove(engine);
            _engineRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _engineRepository.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
