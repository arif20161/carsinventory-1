using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using CarsInventory.Models;

namespace CarsInventory.DAL
{
    public class CarContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }

        

    }
}
