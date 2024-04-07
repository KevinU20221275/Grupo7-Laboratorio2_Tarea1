using ClothingStore.Models;
using ClothingStore.Repositories.Customers;
using ClothingStore.Services.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothingStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IEmailService _emailService;

        public CustomerController(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;

            _emailService = emailService;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_customerRepository.GetAll());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _customerRepository.Add(customer);

                TempData["addCustomer"] = "Datos Guardados con exito";

                Dictionary<string, string> data = new Dictionary<string, string>
                {
                    { "Subject", "Registro de Cliente" },
                    { "RecepientName", customer.CustomerFirstName.ToString() },
                    { "EmailTo", customer.Email.ToString() }
                };

                _emailService.SendEmail(data);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(customer);
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                _customerRepository.Edit(customer);

                TempData["editCustomer"] = "Datos Editados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(customer);
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customer customer)
        {
            try
            {
                _customerRepository.Delete(customer.Id);

                TempData["deleteCustomer"] = "Datos eliminados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = "No se pudo eliminar el registro";

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
