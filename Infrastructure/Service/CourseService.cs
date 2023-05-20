using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Repository;

namespace Infrastructure.Service
{
    public interface ICourseService
    {
        IQueryable<Course> GetCourses();
        Course GetCourse(int id);
        void InsertCourse(Course cour);
        void UpdateCourse(Course cour);
        void DeleteCourse(Course cour);
    }
    public class CourseService : ICourseService
    {
        private ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        

        public void DeleteCourse(Course cour)
        {
            courseRepository.Delete(cour);
        }


        public Course GetCourse(int id)
        {
            return courseRepository.GetById(id);
        }

        public IQueryable<Course> GetCourses()
        {
            return courseRepository.GetAll();
        }

      

        public void InsertCourse(Course cour)
        {
            courseRepository.Insert(cour);
        }

        

        public void UpdateCourse(Course acc)
        {
            courseRepository.Update(acc);
        }
    }
}
