using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarsCms.Models;
using CarsCms.Repository.Interfaces;

namespace CarsCms.Repository
{
    public class CarsRepository : AbstractRepository<CarEntity>, ICarsRepository
    {
    }
}