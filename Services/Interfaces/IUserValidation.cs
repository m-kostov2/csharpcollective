using CSharpCollective.Services.DtoModels;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserValidation
    {
        public bool userValidation(UserDto userData);
    }
}
