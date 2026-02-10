
using AutoMapper;
using CSharpCollective.Services.DtoModels;
using DataBase.DataBaseProvider;
using DataBase.DataContext;
using DataBase.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Services.ConfigMap;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class RegisterService 
    {

        private CollectiveContext _context;
        private readonly IMapper _mapper;
        private LoginService loginservice;



        public RegisterService(CollectiveContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            loginservice = new LoginService(context, mapper);

        }


        public  UserDto registerUser(UserDto Datarecieved)
        {

            User userRegistered = new User(Datarecieved.Email,Datarecieved.Password,Datarecieved.UserName);
            ;
            UserDto userDtoInfo = new UserDto();
            
            var userExist = loginservice.userExists(userRegistered);
            if (userExist!=null)
            {
               
                _mapper.Map(userRegistered, userDtoInfo);
                return userDtoInfo;
            }

            _context.Users.AddAsync(userRegistered);
            _context.SaveChangesAsync();

            
            _mapper.Map(userRegistered,userDtoInfo);

            return userDtoInfo;

        }
    }
}