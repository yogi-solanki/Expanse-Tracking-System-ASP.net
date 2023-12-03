using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myweb.Data;
using myweb.Models;
using System.Data;
using System.Runtime.CompilerServices;

namespace myweb.Controllers
{
    public class CategoryController : Controller

    {
        public readonly DataContext _DataContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public readonly string email;


        public CategoryController(DataContext dataContext, UserManager<ApplicationUser> userManager)
        {
            _DataContext = dataContext;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var userEmail = await _userManager.GetUserIdAsync(currentUser);
                // Use the userEmail as needed
                // For example, you can pass it to the view or perform some logic
                ViewData["UserEmail"] = userEmail;

            }
            return View();
        }
         public IActionResult Add(String id)
        {
            var item = _DataContext.Item.FirstOrDefault(x => x.UserId == id && x.currentMonth == DateTime.Now.Month);
            if (item != null)
        {
                ViewData["id"] = item.Id;
                ViewData["Userid"] = item.UserId;
                ViewData["cost"] = item.Cost;
                ViewData["Food"] = item.Food;
                ViewData["Transport"] = item.Transport;
                ViewData["Clothes"] = item.Clothes;
                ViewData["CurrentMonth"] = item.currentMonth;
                ViewData["Other"] = item.Other;
                ViewData["Total"] = item.Total;
                ViewData["date"] = item.CurrentDate;
                if(item.Total> 0)
                {
                    ViewData["Profile"] = "PROFIT";
                }
                else if(item.Total<0)
                {
                    ViewData["Profile"] = "LOSS";
                }
                else
                {
                    ViewData["profile"] = "No Loss No Profit";
                }
                return View();
             
        }
        else
        {
                return RedirectToAction("New");
            }
    }
        public async  Task<IActionResult> New()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                //string userEmail = await _userManager.GetUserIdAsync(currentUser);
                // Use the userEmail as needed
                // For example, you can pass it to the view or perform some logic
                //Item x=new Item();
                //x.UserId= currentUser.Id;
                ViewData["Userid"] = currentUser.Id;
                //x.Cost= 0;
                //x.Food = 0;
               // x.Transport = 0;
             //   x.Other= 0;
           //     x.Clothes = 0;
         //       x.currentMonth = DateTime.Now.Month;         
       // x.Total = x.Cost - (x.Clothes + x.Food + x.Transport + x.Other);
               // _DataContext.Item.Add(x);
                //_DataContext.SaveChanges();
                //var All = _DataContext.Item.FirstOrDefault(x => x.UserId == currentUser.Id && x.currentMonth == DateTime.Now.Month);
                //ViewData["newid"]=All.Id;
                return View();
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }
        [HttpPost]
        public IActionResult New(Item item)
        {
            var y = item;
            var All = _DataContext.Item.FirstOrDefault(x => x.UserId == item.UserId && x.currentMonth == DateTime.Now.Month);
            if (All != null)
            {
                All.UserId = y.UserId;
                All.Cost = y.Cost;
                _DataContext.Item.Update(All);
                _DataContext.SaveChanges();
                return RedirectToAction("Add");
            }
            else
            {
                y.currentMonth = DateTime.Now.Month;
                _DataContext.Item.Add(y);
                _DataContext.SaveChanges();
                return RedirectToAction("Add");
            }

        }
        public async Task<IActionResult> Update()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            string m="";
            if (currentUser != null)
            {
                var userEmail = await _userManager.GetUserIdAsync(currentUser);
                // Use the userEmail as needed
                // For example, you can pass it to the view or perform some logic
                ViewData["UserEmail"] = userEmail;
                m = userEmail;

            }
            var All = _DataContext.Item.FirstOrDefault(x => x.UserId == m && x.currentMonth == DateTime.Now.Month);
            if (All != null)
            {
                ViewData["Id"] = All.Id;
            }
            else
            {
                return RedirectToAction("New");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(Item item) {
            var y = item;
            var All = _DataContext.Item.FirstOrDefault(x => x.UserId == item.UserId && x.currentMonth == DateTime.Now.Month);
            if (All != null)
            {
                if (y.Food != 0)
                {
                    All.Food += y.Food;
                }
                if (y.Transport != 0)
                {
                    All.Transport += y.Transport;
                }
                if (y.Other != 0)
                {
                    All.Other += y.Other;
                }
                if (y.Clothes != 0)
                {
                    All.Clothes += y.Clothes;
                }
               
                All.CurrentDate = All.CurrentDate;
                All.Total = All.Cost - (All.Clothes + All.Food + All.Transport + All.Other);
                _DataContext.Item.Update(All);
                _DataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else { return RedirectToAction("New"); }


        }
        /*[HttpGet]
       public ActionResult Today(String id)
       {
           var item = _DataContext.Item.Where(x => x.UserId == id).FirstOrDefault();
           if (item != null)
           {
               ViewData["id"] = item.Id;
               ViewData["Userid"] = item.UserId;
               ViewData["cost"] = item.Cost;
               ViewData["Food"] = item.Food;
               ViewData["Transport"] = item.Transport;
               ViewData["Clothes"] = item.Clothes;
               ViewData["Other"] = item.Other;
               return View();

           }
           else
           {
               return RedirectToAction("New");
           }

       }
       [HttpPost]
       public ActionResult Today(Item item)
       {
           var Data = _DataContext.Item.Where(x => x.UserId == item.UserId).FirstOrDefault();
           _DataContext.Item.Update(item);
           _DataContext.SaveChanges();
           return RedirectToAction("Add");
       }*/
        public async Task<IActionResult> History()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var userId = await _userManager.GetUserIdAsync(currentUser);
                var item = _DataContext.Item.Where(x=>x.UserId==userId).ToList();
                return View(item);
            }
            else
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
        }
    }
}
