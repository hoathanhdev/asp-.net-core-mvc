using AutoMapper;
using Infrastructure.Entities;
using WebDemo.Models;

namespace WebDemo
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Account, AccountViewModel>();
            CreateMap<AccountViewModel, Account>();

            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();

            CreateMap<Teacher, TeacherViewModel>();
            CreateMap<TeacherViewModel, Teacher>();

            CreateMap<Course, CourseViewModel>();
            CreateMap<CourseViewModel, Course>();
        }
    }
}
