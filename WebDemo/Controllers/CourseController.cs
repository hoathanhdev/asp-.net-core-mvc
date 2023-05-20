using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebDemo.Models;

namespace WebDemo.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IStudentService studentService;
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;

        public CourseController(ICourseService courseService, IStudentService studentService, ITeacherService teacherService, IMapper mapper)
        {
            this.courseService = courseService;
            this.studentService = studentService;
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(courseService.GetCourses());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            CourseViewModel data = new CourseViewModel();
            StudentViewModel data1 = new StudentViewModel();
            TeacherViewModel data2 = new TeacherViewModel();

            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI KHÓA HỌC" : "CẬP NHẬT KHÓA HỌC";

            if (id != 0)
            {
                Course res = courseService.GetCourse(id);
                //List<Student> res11 = (List<Student>)studentService.GetStudents();
                //List<Teacher> res22 = (List<Teacher>)teacherService.GetTeachers();

                data = mapper.Map<CourseViewModel>(res);
                //data1 = mapper.Map<StudentViewModel>(res11);
                //data2 = mapper.Map<TeacherViewModel>(res22);
                if (data == null)
                {
                    return NotFound();
                }

                var viewModel1 = new MyViewModel
                {
                    Data = data,
                    Data1 = studentService.GetStudents(),
                    Data2 = teacherService.GetTeachers()
                };

                return View(viewModel1);
            }

            //List<Student> res1 = studentService.GetStudents().ToList();
            //List<Teacher> res2 = teacherService.GetTeachers().ToList();

            //data1 = mapper.Map<StudentViewModel>(res1);
            //data2 = mapper.Map<TeacherViewModel>(res2);

            var viewModel = new MyViewModel
            {
                Data = data,
                Data1 = studentService.GetStudents(),
                Data2 = teacherService.GetTeachers()
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, CourseViewModel data)
        {
            Console.WriteLine(data.MaHS);
            Console.WriteLine(data.MaGV);
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI KHÓA HỌC" : "CẬP NHẬT KHÓA HỌC";

            if (ModelState.IsValid)
            {
                try
                {
                    Course res = mapper.Map<Course>(data);
                    if (id != 0)
                    {
                        courseService.UpdateCourse(res);
                    }
                    else
                    {
                        res.CreatedDate = DateTime.Now;
                        courseService.InsertCourse(res);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "Course");
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Course res = courseService.GetCourse(id);
            courseService.DeleteCourse(res);

            return RedirectToAction("Index", "Course");
        }
    }
}