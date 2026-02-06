
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



        public RegisterService(CollectiveContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        public  UserDto registerUser(UserDto Datarecieved)
        {

            User userRegistered = new User(Datarecieved.Email,Datarecieved.Password,Datarecieved.UserName);
            ;

           // _mapper.Map(Datarecieved, userRegistered);
            //userRegistered = new User()
            //{
            //    UserName = Datarecieved.UserName,
            //    Email = Datarecieved.Email,
            //    Password = Datarecieved.Password,
                

            //};

            

            _context.Users.AddAsync(userRegistered);
            _context.SaveChangesAsync();

            UserDto userDtoInfo = new UserDto();
            _mapper.Map(userRegistered,userDtoInfo);

            return userDtoInfo;

        }
    }
}