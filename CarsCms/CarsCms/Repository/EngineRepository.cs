using CarsCms.Models;
using CarsCms.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCms.Repository
{
    public class EngineRepository : AbstractRepository<Engine>, IEngineRepository
    {
    }
}