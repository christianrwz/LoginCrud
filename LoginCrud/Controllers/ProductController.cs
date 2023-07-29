using LoginCrud.Common;
using LoginCrud.Contracts;
using LoginCrud.Data;
using Microsoft.AspNetCore.Mvc;

namespace LoginCrud.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IBaseRepository<Product> _repository;
        public ProductController(IBaseRepository<Product> repository) {
            _repository = repository;
        }
        public async Task<IActionResult> Index(PaginatedRequest request)
        {
            var products = await _repository.GetPaginated(request.PageNumber, PaginatedRequest.ITEMS_PER_PAGE);
            return View(products);
        }

        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _repository.Create(product);

            TempData["Message"] = $"Successfully! added product {product.Name}";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id) {
            var entity = await _repository.GetOne(id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _repository.Update(product.Id, new { product.Name, product.Description });

            TempData["Message"] = $"Successfully! updated product {product.Name}";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetOne(id);
            if (entity == null) { return NotFound(); }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmedDelete(int id)
        {
            await _repository.Delete(id);

            TempData["Message"] = $"Successfully! deleted product {id}";

            return RedirectToAction("Index");
        }
    }
}
