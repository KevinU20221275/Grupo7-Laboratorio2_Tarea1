using ClothingStore.Models;
using ClothingStore.Repositories.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothingStore.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;
        private SelectList _customersList;
        private SelectList _employeesList;
        private SelectList _productsList;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;

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

                TempData["editProduct"] = "Datos Editados con exito";

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
            catch (Exception ex)
            {
                TempData["message"] = "No se pudo eliminar el registro";

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
