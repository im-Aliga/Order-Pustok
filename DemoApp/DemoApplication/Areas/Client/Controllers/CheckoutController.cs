using DemoApplication.Areas.Client.ViewModels.Checkout;
using DemoApplication.Database;
using DemoApplication.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemoApplication.Areas.Client.Controllers
{

    [Area("client")]
    [Route("checkout")]
    public class CheckoutController : Controller
    {
        private readonly DataContext _dbContext;
        

        public CheckoutController(DataContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        [HttpGet("list", Name = "checkout-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = new ProductListItemViewModel
            {

                Products = await _dbContext.BasketProducts.Include(bp => bp.Book)
                .Select(bp => new ProductListItemViewModel.ListItem(bp.Book.Title, bp.Quantity, bp.Book.Price, bp.Book.Price * bp.Quantity))
                .ToListAsync()

            };

            return View(model);
        }
        [HttpPost("placeOrder", Name = "place-order-add")]
        public ActionResult Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _dbContext.Books.Add(new Book
            {
                Title = model.Title,
                //Author = model.Author,
                Price = model.Price.Value,
            });

            return RedirectToAction(nameof(List));
        }


    }
}
