using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarsInventory.DAL;
using CarsInventory.Models;
using Microsoft.AspNet.Identity;


namespace CarsInventory.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        //private CarContext db = new CarContext();
        private CarRepository _carRepository;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CarController));

        public CarController()
        {
            this._carRepository = new CarRepository(new CarContext());
        }



        // GET: Car
        public ActionResult Index()
        {
            _carRepository.UserId = Guid.Parse(User.Identity.GetUserId());
            return View(_carRepository.Get().ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _carRepository.UserId = Guid.Parse(User.Identity.GetUserId());
            Car car = _carRepository.GetById((int)id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return PartialView(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Brand,Model,Year,Price,New")] Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.UserId = Guid.Parse(User.Identity.GetUserId());
                _carRepository.Insert(car);
                _carRepository.Save();
                return RedirectToAction("Index");
            }

            return PartialView(car);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _carRepository.UserId = Guid.Parse(User.Identity.GetUserId());
            Car car = _carRepository.GetById((int)id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return PartialView(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Brand,Model,Year,Price,New")] Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.UserId = Guid.Parse(User.Identity.GetUserId());
                _carRepository.Update(car);
                _carRepository.Save();
                return RedirectToAction("Index");
            }
            return PartialView(car);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _carRepository.UserId = Guid.Parse(User.Identity.GetUserId());
            Car car = _carRepository.GetById((int)id);

            log.Error($"Car {id} : {car.Model} deleted by {_carRepository.UserId}."); //this is for testing

            if (car == null)
            {
                return HttpNotFound();
            }
            return PartialView(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _carRepository.UserId = Guid.Parse(User.Identity.GetUserId());
            _carRepository.Delete(id);
            _carRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _carRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
