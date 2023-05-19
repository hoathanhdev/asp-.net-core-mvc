using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Repository;

namespace Infrastructure.Service
{
    public interface ITeacherService
    {
        IQueryable<Teacher> GetTeachers();
        Teacher GetTeacher(int id);
        void InsertTeacher(Teacher teac);
        void UpdateTeacher(Teacher teac);
        void DeleteTeacher(Teacher teac);
    }
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        

        public void DeleteTeacher(Teacher teac)
        {
            teacherRepository.Delete(teac);
        }


        public Teacher GetTeacher(int id)
        {
            return teacherRepository.GetById(id);
        }

        public IQueryable<Teacher> GetTeachers()
        {
            return teacherRepository.GetAll();
        }

        public void InsertTeacher(Teacher teac)
        {
            teacherRepository.Insert(teac);
        } 

        public void UpdateTeacher(Teacher teac)
        {
            teacherRepository.Update(teac);
        }
    }
}
