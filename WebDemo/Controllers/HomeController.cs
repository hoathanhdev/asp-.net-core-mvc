using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebDemo.Models;
using Infrastructure.Service;
using AutoMapper;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public HomeController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(userService.GetUsers());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            UserViewModel data = new UserViewModel();
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI TÀI KHOẢN" : "CẬP NHẬT TÀI KHOẢN";

            if (id !=  0)
            {
                User res = userService.GetUser(id);
                data = mapper.Map<UserViewModel>(res);
                if(data == null)
                {
                    return NotFound();
                }
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, UserViewModel data)
        {
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI TÀI KHOẢN" : "CẬP NHẬT TÀI KHOẢN";

            if (ModelState.IsValid)
            {
                try
                {
                    User res = mapper.Map<User>(data);
                    if (id != 0)
                    {
                        userService.UpdateUser(res);
                    }
                    else
                    {
                        res.CreatedDate = DateTime.Now;
                        userService.InsertUser(res);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();
                }
                return RedirectToAction("Index", "User");
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            User res = userService.GetUser(id);
            userService.DeleteUser(res);

            return RedirectToAction("Index", "User");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
