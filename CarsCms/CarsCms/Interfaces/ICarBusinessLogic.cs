using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsCms.Interfaces
{
    public interface ICarBusinessLogic
    {
        string CheckIfUserIsAuthAndReturnName();
        bool CheckIfUserIsAutorize();
    }
}
