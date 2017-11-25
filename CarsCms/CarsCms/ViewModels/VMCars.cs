using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarsCms.Models;

namespace CarsCms.ViewModels
{
    public class VMCars
    {
        public CarEntity Car { get; set; }
        public List<CarEntity> CarList { get; set; }
        public bool ShowIfAuth { get; set; }
    }
}