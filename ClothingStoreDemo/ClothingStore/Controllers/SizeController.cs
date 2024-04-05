using ClothingStore.Models;
using ClothingStore.Repositories.Sizes;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    public class SizeController : Controller
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeController(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        // GET: SizeController
        public ActionResult Index()
        {
            return View(_sizeRepository.GetAll());
        }


        // GET: SizeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SizeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Size size)
        {
            try
            {
                _sizeRepository.Add(size);

                TempData["addSize"] = "Datos Guardados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(size);
            }
        }

        // GET: SizeController/Edit/5
        public ActionResult Edit(int id)
        {
            var size = _sizeRepository.GetById(id);

            if (size == null)
            {
                return NotFound();
            }

            return View(size);
        }

        // POST: SizeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Size size)
        {
            try
            {
                _sizeRepository.Edit(size);

                TempData["editSize"] = "Datos Editados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(size);
            }
        }

        // GET: SizeController/Delete/5
        public ActionResult Delete(int id)
        {
            var size = _sizeRepository.GetById(id);

            if (size == null)
            {
                return NotFound();
            }

            return View(size);
        }

        // POST: SizeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Size size)
        {
            try
            {
                _sizeRepository.Delete(size.Id);

                TempData["deleteSize"] = "Datos Eliminados con exito";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(size);
            }
        }
    }
}
