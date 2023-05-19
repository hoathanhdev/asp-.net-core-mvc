using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Repository;

namespace Infrastructure.Service
{
    public interface IStudentService
    {
        IQueryable<Student> GetStudents();
        Student GetStudent(int id);
        void InsertStudent(Student stu);
        void UpdateStudent(Student stu);
        void DeleteStudent(Student stu);
    }
    public class StudentService : IStudentService
    {
        private IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        

        public void DeleteStudent(Student stu)
        {
            studentRepository.Delete(stu);
        }


        public Student GetStudent(int id)
        {
            return studentRepository.GetById(id);
        }

        public IQueryable<Student> GetStudents()
        {
            return studentRepository.GetAll();
        }

        public void InsertStudent(Student stu)
        {
            studentRepository.Insert(stu);
        } 

        public void UpdateStudent(Student stu)
        {
            studentRepository.Update(stu);
        }
    }
}
