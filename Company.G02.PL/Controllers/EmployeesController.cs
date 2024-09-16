using Company.G02.BLL.Interfaces;
using Company.G02.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.G02.PL.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository) // ASK the CLR to Create Object From employeeRepository
        {
            _employeeRepository = employeeRepository;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAll();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //--------- Create ---------//


        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent any Request Outside My Application from Any Tool Or Any Outside Application
        public IActionResult Create(Employee model)  /// Returning the view if has no Data = Stay in the same page
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                var count = _employeeRepository.Add(model);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        //--------- Details ---------//


        public IActionResult Details(int? id, string viewName = "Details") // 100
        {
            if (id is null) return BadRequest(); // 400

            var employee = _employeeRepository.Get(id.Value);

            if (employee == null) return NotFound(); // 404

            return View(viewName, employee);

        }


        //------------------Update ------------------//

        [HttpGet]
        public IActionResult Edit(int? id) // 100
        {

            return Details(id, "Edit");
        }

        // Posting the Updated Id
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent any Request Outside My Application from Any Tool Or Any Outside Application
        public IActionResult Edit([FromRoute] int? id, Employee model) // 100
        {
            try
            {
                if (id != model.Id) return BadRequest(); //400

                if (ModelState.IsValid)
                {
                    var count = _employeeRepository.Update(model);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception Ex)
            {
                //1. Log Exeption
                //2. Friendly Message
                ModelState.AddModelError(string.Empty, Ex.Message);
            }
            return View(model);

        }


        //------------------Delete ------------------//

        [HttpGet]
        public IActionResult Delete(int? id) // 100
        {
            

            return Details(id, "Delete");

        }



        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent any Request Outside My Application from Any Tool Or Any Outside Application
        public IActionResult Delete([FromRoute] int? id, Employee model) // 100
        {
            try
            {
                if (id != model.Id) return BadRequest(); // 400

                if (ModelState.IsValid) // Server Side Validation
                {
                    var count = _employeeRepository.Delete(model);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception Ex)
            {
                //1. Log Exeption
                //2. Friendly Message
                ModelState.AddModelError(string.Empty, Ex.Message);
            }
            return View(model);

        }

    }
}
