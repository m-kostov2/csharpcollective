
using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataBaseProvider;
using DataBase.DataContext;
using DataBase.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Services.ConfigMap;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class RegisterService : IUserValidation
    {

        private CollectiveContext _context;
        private readonly IMapper _mapper;
        private LoginService loginservice;



        public RegisterService(IMapper mapper)
        {
            _context = new CollectiveContext();
            _mapper = mapper;
            loginservice = new LoginService(mapper);

        }


        public UserDto registerUser(UserDto Datarecieved)
        {


            if (userValidation(Datarecieved) == false)
            {
                return null;
            }



            User userRegistered = new User(Datarecieved.Email, Datarecieved.Password, Datarecieved.UserName);
            ;
            UserDto userDtoInfo = new UserDto();

            var userExist = loginservice.userExists(userRegistered);
            if (userExist != null)
            {

                //  _mapper.Map(userRegistered, userDtoInfo);
                return null;
            }

            _context.Users.AddAsync(userRegistered);
            _context.SaveChangesAsync();


            _mapper.Map(userRegistered, userDtoInfo);

            return userDtoInfo;

        }




        public bool userValidation(UserDto userData)
        {
            if (String.IsNullOrEmpty(userData.Email) || String.IsNullOrEmpty(userData.UserName) ||String.IsNullOrEmpty(userData.Password))
            {
                return false;
            }


            return true;
        }
    }
}