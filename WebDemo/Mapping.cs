using AutoMapper;
using Infrastructure.Entities;
using WebDemo.Models;

namespace LearnX
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}
