using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebDemo.Models;

namespace WebDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(studentService.GetStudents());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            StudentViewModel data = new StudentViewModel();
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI HỌC SINH" : "CẬP NHẬT THÔNG TIN HỌC SINH";

            if (id != 0)
            {
                Student res = studentService.GetStudent(id);
                data = mapper.Map<StudentViewModel>(res);

                if (data == null)
                {
                    return NotFound();
                }
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, StudentViewModel data)
        {
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI HỌC SINH" : "CẬP NHẬT THÔNG TIN HỌC SINH";

            if (ModelState.IsValid)
            {
                try
                {
                    Student res = mapper.Map<Student>(data);
                    if (id != 0)
                    {
                        studentService.UpdateStudent(res);
                    }
                    else
                    {
                        res.CreatedDate = DateTime.Now;
                        studentService.InsertStudent(res);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "Student");
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Student res = studentService.GetStudent(id);
            studentService.DeleteStudent(res);

            return RedirectToAction("Index", "Student");
        }
    }
}