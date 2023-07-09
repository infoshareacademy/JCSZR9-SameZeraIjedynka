using SameZeraIJedynka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SameZeraIjedynka.BusinnessLogic.Services
{
    public interface IUserService
    {
       Task Add(UserModel addUserRequest);
    }
}

