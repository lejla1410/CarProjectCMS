using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarsCms.Interfaces;
using CarsCms.Models;
using CarsCms.Repository.Interfaces;
using CarsCms.ViewModels;

namespace CarsCms.Controllers
{
    public class CarsController : Controller
    {
        private ICarsRepository _carsRepository;
        private ICarBusinessLogic _businessLogic;
        public CarsController(ICarsRepository carsRepository, ICarBusinessLogic businessLogic)
        {
            _carsRepository = carsRepository;
            _businessLogic = businessLogic;
        }
        // GET: Cars
        public ActionResult Index()
        {
            var carVM = new VMCars {CarList = new List<CarEntity>()};
            carVM.ShowIfAuth = _businessLogic.CheckIfUserIsAutorize();
            if (carVM.ShowIfAuth)
                carVM.CarList = _carsRepository.GetWhere(x => x.Id > 0);
            else
                carVM.CarList = _carsRepository.GetWhere(x => x.Id > 0 && x.IsActive);

            return View(carVM);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carVM = new VMCars();
            carVM.Car = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            carVM.ShowIfAuth = _businessLogic.CheckIfUserIsAutorize();
            if (carVM.Car == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMCars carEntity)
        {
            if (ModelState.IsValid)
            {
                carEntity.Car.ModPerson = _businessLogic.CheckIfUserIsAuthAndReturnName();
                _carsRepository.Create(carEntity.Car);
                return RedirectToAction("Index");
            }

            return View(carEntity);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carVM = new VMCars();
            carVM.Car = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            carVM.ShowIfAuth = _businessLogic.CheckIfUserIsAutorize();
            if (carVM.Car == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMCars carEntity)
        {
            if (ModelState.IsValid)
            {
                carEntity.Car.ModPerson = _businessLogic.CheckIfUserIsAuthAndReturnName();
                _carsRepository.Update(carEntity.Car);
                return RedirectToAction("Index");
            }
            return View(carEntity);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carVM = new VMCars();
            carVM.Car = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            carVM.ShowIfAuth = _businessLogic.CheckIfUserIsAutorize();
            if (carVM.Car == null)
            {
                return HttpNotFound();
            }
            return View(carVM);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarEntity carEntity = _carsRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _carsRepository.Delete(carEntity);
            return RedirectToAction("Index");
        }

    }
}
