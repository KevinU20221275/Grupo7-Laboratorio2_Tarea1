using ClothingStore.Models;
using ClothingStore.Repositories.Sales;
using ClothingStore.Services.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.X509;

namespace ClothingStore.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;
        private readonly SelectList _customersList;
        private readonly SelectList _employeesList;
        private readonly SelectList _productsList;

        private readonly IEmailService _emailService;

        public SaleController(ISaleRepository saleRepository, IEmailService emailService)
        {
            _saleRepository = saleRepository;

            _emailService = emailService;

            _customersList = new SelectList(
                    _saleRepository.GetAllCustomers(),
                    nameof(Customer.Id),
                    nameof(Customer.CustomerName)
                );

            _employeesList = new SelectList(
                    _saleRepository.GetAllEmployees(),
                    nameof(Employee.Id),
                    nameof(Employee.EmployeeName)
                );

            _productsList = new SelectList(
                    _saleRepository.GetAllProducts(),
                    nameof(Product.Id),
                    nameof(Product.ProductInfo),
                    nameof(Product.Price)
                );
        }
        // GET: SaleController
        public ActionResult Index()
        {
            return View(_saleRepository.GetAll());
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            ViewBag.Customers = _customersList;
            ViewBag.Employees = _employeesList;
            ViewBag.Products = _productsList;

            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sale sale)
        {
            try
            {
                _saleRepository.Add(sale);

                TempData["addSale"] = "Datos Guardados con exito";

                // trae datos para el mensaje de correo electronico
                var customer = _saleRepository.GetCustomerById(sale.CustomerId);
                var product = _saleRepository.GetProductById(sale.ProductId);


                Dictionary<string, string> data = new Dictionary<string, string>
                {
                    { "Subject", "Factura de Compra" },
                    { "ProductName", product.ProductName.ToString() },
                    { "SaleDate", sale.SaleDate.ToString() },
                    { "Quantity", sale.Quantity.ToString() },
                    { "Total", (product.Price * sale.Quantity).ToString() },
                    { "RecepientName", customer.CustomerFirstName.ToString() },
                    { "EmailTo", customer.Email.ToString() },
                    { "Address", customer.Address.ToString() }

                };

                _emailService.SendEmail(data);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Customers = _customersList;
                ViewBag.Employees = _employeesList;
                ViewBag.Products = _productsList;

                return View(sale);
            }
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            var sale = _saleRepository.GetById(id);

            if (sale == null)
            {
                return NotFound();
            }

            ViewBag.Customers = _customersList;
            ViewBag.Employees = _employeesList;
            ViewBag.Products = _productsList;

            return View(sale);
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sale sale)
        {
            try
            {
                _saleRepository.Edit(sale);

                TempData["editSale"] = "Datos Editados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Customers = _customersList;
                ViewBag.Employees = _employeesList;
                ViewBag.Products = _productsList;

                return View(sale);
            }
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            var sale = _saleRepository.GetById(id);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Sale sale)
        {
            try
            {
                _saleRepository.Delete(sale.Id);

                TempData["deleteSale"] = "Datos eliminados con exito";

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
