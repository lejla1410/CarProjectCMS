using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCms.Models
{
    public class Engine : IBasicEntity
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public string MyModel { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateMod { get; set; }
        public bool IsActive { get; set; }

    }
}