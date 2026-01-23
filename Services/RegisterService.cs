
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


     
        public RegisterService()
        {
            _context = new CollectiveContext();
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CollectiveProfile>();
            }));
        }
        

        public UserDto CommunicationService(UserDto Datarecieved)
        {

            User userRegistered = new User();
            

            _mapper.Map(Datarecieved, userRegistered);
            userRegistered = new User()
            {
                UserName = Datarecieved.UserName,
                Email = Datarecieved.Email,
                Password = Datarecieved.Password,
                

            };

            

            _context.Users.Add(userRegistered);
             _context.SaveChangesAsync();

            UserDto userDtoInfo = new UserDto();
            _mapper.Map(userRegistered,userDtoInfo);

            return userDtoInfo;

        }
    }
}