using Microsoft.AspNetCore.Mvc;
using onlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineBookstore.Views.Shared.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;

        public CartSummaryViewComponent (Basket basketService)
        {
            basket = basketService;
        }

        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
