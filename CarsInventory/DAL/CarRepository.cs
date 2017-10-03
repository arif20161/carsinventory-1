using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarsInventory.Models;
using System.Data.Entity;

namespace CarsInventory.DAL
{
    public class CarRepository : iRepository<Car>
    {

        private CarContext _context;
        public Guid UserId { get; set; }

        public CarRepository(CarContext carContext)
        {
            this._context = carContext;
        }

        public void Delete(int id)
        {
            Car obj = _context.Cars.Find(id);
            _context.Cars.Remove(obj);
        }

        public IEnumerable<Car> Get()
        {
            //return _context.Cars.ToList();
            return _context.Cars.Where(c => c.UserId == UserId).ToList();
        }

        public Car GetById(int id)
        {
            return _context.Cars.Find( id);
        }

        public void Insert(Car obj)
        {
            obj.UserId = UserId;
            _context.Cars.Add(obj);
        }

        public void Update(Car obj)
        {
            obj.UserId = UserId;
            _context.Entry(obj).State = EntityState.Modified;
        }

       
    }
}