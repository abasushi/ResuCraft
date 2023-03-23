using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TUPApp.Models;

namespace TUPApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TupContext _context;
        private readonly ILogger<HomeController> _logger;

        public static string Title = "";
        public static string Description = "";
        public static string Gender = "";

        public HomeController(ILogger<HomeController> logger, TupContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Resume()
        {

            //Gets the Information from the Students table of the TUP Database
            var student = _context.Students.FirstOrDefault();

            var vm = new HomeViewModel()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Address = student.Address,
                Contact = student.Contact,
                Email = student.Email,
                CareerObjective = student.CareerObjective
            };

            var skills = _context.Skills
                                 .Include(s => s.Student)
                                 .Where(x => x.StudentId == student.Id)
                                 .ToList();

            vm.Skills = new List<Skill1>();

            foreach (var x in skills)
            {
                var sk = new Skill1
                {
                    ID = x.Id,
                    Skill = x.Skill1

                };
            
                vm.Skills.Add(sk);
            }

            var educ = _context.EducationalBackgrounds
                                 .Include(e => e.Student)
                                 .Where(ed => ed.StudentId == student.Id)
                                 .ToList();

            vm.EducationalBackground = new List<EducBG>();

            /* Another syntax for calling the data from the database
            for(var x = 0; x< educ.Count; x++)
            {
                var edu = new EducBG
                {
                    ID = educ[x].Id,
                    EducationalAttainment = educ[x].EducationalAttainment,
                    School = educ[x].School,
                    YearStarted = educ[x].YearStarted,
                    YearGraduated = educ[x].YearGraduated,
                    Address = educ[x].Address
                };

                vm.EducationalBackground.Add(edu);
            } */

            foreach (var ed in educ)
            {
                var edu = new EducBG
                {
                    ID = ed.Id,
                    EducationalAttainment = ed.EducationalAttainment,
                    School = ed.School,
                    YearStarted = ed.YearStarted,
                    YearGraduated = ed.YearGraduated,
                    Address = ed.Address

                };

                vm.EducationalBackground.Add(edu);
            }

            var emer = _context.EmergencyContacts
                     .Include(e => e.Student)
                     .Where(em => em.StudentId == student.Id)
                     .ToList();

            vm.EmergencyContact = new List<EmerContact>();

            foreach (var em in emer)
            {
                var eme = new EmerContact
                {
                    ID = em.Id,
                    EmergencyName = em.EmergencyName,
                    EmergencyNumber = em.EmergencyNumber,
                    Relationship = em.Relationship
                };

                vm.EmergencyContact.Add(eme);
            }

            var exp = _context.Experiences
                     .Include(e => e.Student)
                     .Where(ex => ex.StudentId == student.Id)
                     .ToList();

            vm.Experience = new List<Expi>();

            foreach (var ex in exp)
            {
                var expi = new Expi
                {
                    ID = ex.Id,
                    Experience1 = ex.Experience1,
                    YearStarted = ex.YearStarted,
                    YearEnded = ex.YearEnded
                };

                vm.Experience.Add(expi);
            }

            var trn = _context.TrainingsAttendeds
                     .Include(e => e.Student)
                     .Where(tr => tr.StudentId == student.Id)
                     .ToList();

            vm.TrainingsAttended = new List<Train>();

            foreach (var tr in trn)
            {
                var train = new Train
                {
                    ID = tr.Id,
                    Training = tr.Training,
                    YearAttended = tr.YearAttended,
                };

                vm.TrainingsAttended.Add(train);
            }

            return View(vm);
        }

        public IActionResult CreateResume()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Insert(HomeModel model)
        {
            Title = model.Title;
            Description = model.Description;
            Gender = model.Gender;

            return RedirectToAction("Index", "Sample");
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