using Microsoft.AspNetCore.Mvc;
using SRS.DataAccess.Repository.IRepository;
using SRS.Models;
using System.Diagnostics;

namespace StudentRecordSystemWith.NetCore.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<StudentModel> studentList = _unitOfWork.Student.GetAll(includeProperties: "Teacher");
            return View(studentList);
        }
        public IActionResult Details(int studentId)
        {
            StudentModel student = _unitOfWork.Student.Get(u=>u.StudentId== studentId, includeProperties:"Teacher");
            return View(student);
        }
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
