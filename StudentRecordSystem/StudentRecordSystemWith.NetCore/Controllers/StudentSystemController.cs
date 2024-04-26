using Microsoft.AspNetCore.Mvc;
using StudentRecordSystemWith.NetCore.Data;
using StudentRecordSystemWith.NetCore.Models;

namespace StudentRecordSystemWith.NetCore.Controllers
{
    public class StudentSystemController : Controller
    {
        private ApplicationDataContext _applicationDataContext;
        public IActionResult Create()
        {
            return View();
        }
        public StudentSystemController(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }
        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            
            if( null != _applicationDataContext.StudentModel.Find(student.SchoolNumber))
            {
                ModelState.AddModelError("SchoolNumber","Same school number can't use more than 1");
            }
            
            if (ModelState.IsValid ) {
                _applicationDataContext.StudentModel.Add(student);
                _applicationDataContext.SaveChanges();
                TempData["success"] = "You created succesffuly.";
                return RedirectToAction("List");
            }

            return View();
        }

        public IActionResult List()
        {
            return View(_applicationDataContext.StudentModel);
        }

        public IActionResult Update(int? id) { 
        
        return View(_applicationDataContext.StudentModel.Find(id));
        }

        [HttpPost]
        public IActionResult Update(StudentModel student)
        {
            if (null != _applicationDataContext.StudentModel.Find(student.SchoolNumber))
            {
                ModelState.AddModelError("SchoolNumber", "You can't use same school number more than 1");
            }
            if (ModelState.IsValid)
            {
                _applicationDataContext.StudentModel.Update(student);
                _applicationDataContext.SaveChanges();
                TempData["success"] = "You edited succesffuly.";
                return RedirectToAction("List");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var student = _applicationDataContext.StudentModel.Find(id);
            _applicationDataContext.StudentModel.Remove(student);
            _applicationDataContext.SaveChanges();
            TempData["success"] = "You deleted succesffuly.";
            return RedirectToAction("List");

        }
    }
}
