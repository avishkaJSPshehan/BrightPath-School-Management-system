using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementsystem.Models;

namespace SchoolManagementsystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SchoolManagementSystemDbContext _context;

    public HomeController(ILogger<HomeController> logger, SchoolManagementSystemDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var allStudent = _context.Students.ToList();
        return View(allStudent);
    }
    // public IActionResult Addnew(){
    //     return View();
    // }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Addnew(int? id){

        if(id != null){
            var studentInDb = _context.Students.SingleOrDefault(student => student.Id == id);
            return View(studentInDb);
        }
        
        return View();

    }

    public IActionResult DeleteStudent(int id){

        var studentInDb = _context.Students.SingleOrDefault(student => student.Id == id);
        _context.Students.Remove(studentInDb);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult CreateEditStudentForm(Student model)
    {
        if(model.Id == 0){
            _context.Students.Add(model);

        }else{
            _context.Students.Update(model);
        }
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
