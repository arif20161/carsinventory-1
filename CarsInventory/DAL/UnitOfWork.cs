using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsInventory.DAL
{
    public class UnitOfWork : IDisposable
    {
        CarRepository _carRepository;
        private readonly CarContext db;

        public UnitOfWork()
        {
            db = new CarContext();
        }

        public CarRepository CarRepository
        {
            get
            {

                if (_carRepository == null)
                    _carRepository = new CarRepository(db);
                return _carRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region IDisposable Support

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}