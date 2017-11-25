using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarsCms.Interfaces;

namespace CarsCms.BusinessLogic
{
    public class CarBusinessLogic : ICarBusinessLogic
    {
        public string CheckIfUserIsAuthAndReturnName()
        {
            string name = "Niezalogowany";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
                name = HttpContext.Current.User.Identity.Name;
            return name;
        }
    }
}