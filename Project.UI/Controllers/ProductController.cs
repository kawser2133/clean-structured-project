using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project.Core.Entities.General;
using Project.Core.Interfaces.IServices;

namespace Project.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _productService.GetProducts();
                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving products");
                return StatusCode(500, ex.Message);
            }

        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var data = await _productService.GetProduct(id);
                return View(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the product");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.IsExists("Name", model.Name))
                {
                    ModelState.AddModelError("Exists", $"The product name- '{model.Name}' already exists");
                    return View(model);
                }

                if (await _productService.IsExists("Code", model.Code))
                {
                    ModelState.AddModelError("Exists", $"The product code- '{model.Code}' already exists");
                    return View(model);
                }

                try
                {
                    var data = await _productService.Create(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while adding the product");
                    ModelState.AddModelError("Error", $"An error occurred while adding the product- " + ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var data = await _productService.GetProduct(id);
                return View(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the product");
                return StatusCode(500, ex.Message);
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.IsExistsForUpdate(model.Id, "Name", model.Name))
                {
                    ModelState.AddModelError("Exists", $"The product name- '{model.Name}' already exists");
                    return View(model);
                }

                if (await _productService.IsExistsForUpdate(model.Id, "Code", model.Code))
                {
                    ModelState.AddModelError("Exists", $"The product code- '{model.Code}' already exists");
                    return View(model);
                }

                try
                {
                    await _productService.Update(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while updating the product");
                    ModelState.AddModelError("Error", $"An error occurred while updating the product- " + ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // Get: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the product");
                return View("Error");
            }
        }
    }
}
