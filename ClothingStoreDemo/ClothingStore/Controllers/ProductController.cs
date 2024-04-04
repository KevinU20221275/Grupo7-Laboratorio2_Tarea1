using ClothingStore.Models;
using ClothingStore.Repositories.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClothingStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        private SelectList _categoriesLits;
        private SelectList _sizesList;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            _categoriesLits = new SelectList(
                    _productRepository.GetAllCategories(),
                    nameof(Category.Id),
                    nameof(Category.CategoryName)
                );

            _sizesList = new SelectList(
                    _productRepository.GetAllSizes(),
                    nameof(Size.Id),
                    nameof(Size.SizeDescription)
                );
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productRepository.GetAll());
        }


        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _categoriesLits;
            ViewBag.Sizes = _sizesList;

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                _productRepository.Add(product);

                TempData["message"] = "Datos Guardados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message; 

                ViewBag.Categories = _categoriesLits;
                ViewBag.Sizes = _sizesList;

                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _categoriesLits;
            ViewBag.Sizes = _sizesList;

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                _productRepository.Edit(product);

                TempData["message"] = "Datos Editados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                ViewBag.Categories = _categoriesLits;
                ViewBag.Sizes = _sizesList;

                return View(product);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                _productRepository.Delete(product.Id);

                TempData["message"] = "Datos eliminados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(product);
            }
        }
    }
}
