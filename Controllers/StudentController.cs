using Microsoft.AspNetCore.Mvc;
using myweb.Data;
using myweb.Models;

namespace myweb.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _dataContext;

        public StudentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var student = _dataContext.Students.ToList();
            return View(student);
        }
        [HttpGet]
        public IActionResult Create() {
           
            return View();
        
        }
        public IActionResult Edit(int id)
        {
               var student = _dataContext.Students.Where(x => x.Id == id).FirstOrDefault();
                return View(student);

            }
        public IActionResult Delete(int id)
        {
            var student=_dataContext.Students.Where(x=>x.Id == id).FirstOrDefault();
            _dataContext.Students.Remove(student);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
   
       
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _dataContext.Students.Add(student);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _dataContext.Students.Update(student);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");

        }
      //  [HttpPost]
       // public IActionResult Delete(Student student)
        //{
         //   _dataContext.Students.Remove(student);
          //  _dataContext.SaveChanges();
          //  return RedirectToAction("Index");
        //}
    }
}
