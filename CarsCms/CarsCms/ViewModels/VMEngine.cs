using CarsCms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCms.ViewModels
{
    public class VMEngine
    {
        public Engine Eng { get; set; }
        public List<Engine> EngineList { get; set; }
        
    }
}