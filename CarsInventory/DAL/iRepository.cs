using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.DAL
{
    interface iRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(int Id);
        void Insert(T obj);
        void Delete(int Id);
        void Update(T obj);
        void Save();
    }
}
