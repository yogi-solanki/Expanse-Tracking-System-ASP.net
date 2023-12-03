using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myweb.Data;
using myweb.Models;
using myweb.Viewmodel;
using System.Diagnostics;

namespace myweb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly RoleManager<IdentityRole> _roleManager;
        public readonly DataContext x;

        public HomeController(ILogger<HomeController> logger,DataContext y)
        {
            x = y;
            _logger = logger;
       //     _roleManager = x;
        }

        public IActionResult Index(int id)
        {
            return View();
        }

       // public IActionResult Create()
        //{
         //   return View();
        //}
                            //    [HttpPost]
                               // public async Task<IActionResult> Create(RoleStore role)
                                //{
                                 //   var roleExist = await _roleManager.RoleExistsAsync(role.Name);
                                  //  if (!roleExist)
                                   // {
                                    //    await _roleManager.CreateAsync(new IdentityRole(role.Name));
                                    //}
                                    //return RedirectToAction("Index");
                               // }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}