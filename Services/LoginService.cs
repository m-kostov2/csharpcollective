

using AutoMapper;


using CSharpCollective.Services.DtoModels;
using DataBase.DataContext;
using DataBase.Models;
using Services.ConfigMap;


namespace Services
{
    public class LoginService 
    {

        private CollectiveContext _context;
        private readonly IMapper _mapper;


        public LoginService(CollectiveContext context, IMapper mapper)
        {
            _context =context;
            _mapper = mapper;

        }



        public UserDto userExists(UserDto Datarecieved)
        {
         

            User userInfo = new User();
             
            _mapper.Map(Datarecieved, userInfo);


            var userExists = _context.Users.SingleOrDefault(u => u.UserName == userInfo.UserName);
            ;
            UserDto userDtoInfo = new UserDto();
            if (userExists != null)
            {
                var role = _context.Users.Where(u => u.UserName == userInfo.UserName).Select(u => u.Role).ToString();

                if (role == "Admin")
                {
                    userInfo = _context.Users.Where(u => u.UserName == userInfo.UserName).Select(u => new User
                    {
                        UserName = u.UserName,
                        Email = u.Email,
                        Role = u.Role,
                        Posts = u.Posts.ToArray()

                    }).Single();

                  

                }
                else if (role == "User")
                {
                    userInfo = _context.Users.Where(u => u.UserName == userInfo.UserName).Select(u => new User
                    {
                        UserName = u.UserName,
                        Email = u.Email,
                        Role = u.Role
                        
                    }).Single();

                }
                _mapper.Map(userInfo, userDtoInfo);
            }
            else if (userExists == null)
            {
                userDtoInfo = null;
                return userDtoInfo;
            }

            return  userDtoInfo;

        }


    }
}
