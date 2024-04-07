using ClothingStore.Repositories.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClothingStore.Repositories.Employees;
using ClothingStore.Models;

namespace ClothingStore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(_employeeRepository.GetAll());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _employeeRepository.Add(employee);

                TempData["addEmployee"] = "Datos Guardados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(employee);
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                _employeeRepository.Edit(employee);

                TempData["editEmployee"] = "Datos Guardados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(employee);
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                _employeeRepository.Delete(employee.Id);

                TempData["deleteEmployee"] = "Datos Guardados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["message"] = "No se pudo eliminar el registro";

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
