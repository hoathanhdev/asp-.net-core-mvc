using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebDemo.Models;

namespace WebDemo.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;
        private readonly IMapper mapper;
        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(teacherService.GetTeachers());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            TeacherViewModel data = new TeacherViewModel();
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI GIÁO VIÊN" : "CẬP NHẬT THÔNG TIN GIÁO VIÊN";

            if (id != 0)
            {
                Teacher res = teacherService.GetTeacher(id);
                data = mapper.Map<TeacherViewModel>(res);
                if (data == null)
                {
                    return NotFound();
                }
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, TeacherViewModel data)
        {
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI GIÁO VIÊN" : "CẬP NHẬT THÔNG TIN GIÁO VIÊN";

            if (ModelState.IsValid)
            {
                try
                {
                    Teacher res = mapper.Map<Teacher>(data);
                    if (id != 0)
                    {
                        teacherService.UpdateTeacher(res);
                    }
                    else
                    {
                        res.CreatedDate = DateTime.Now;
                        teacherService.InsertTeacher(res);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "Teacher");
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Teacher res = teacherService.GetTeacher(id);
            teacherService.DeleteTeacher(res);

            return RedirectToAction("Index", "Teacher");
        }
    }
}