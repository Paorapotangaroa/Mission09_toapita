using Microsoft.AspNetCore.Mvc;
using Mission09_toapita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Components
{
    public class CartSummaryViewComponent: ViewComponent
        {
            private Cart cart;
            public CartSummaryViewComponent(Cart cartService)
            {
                cart = cartService;
            }
            public IViewComponentResult Invoke()
            {
                return View(cart);
            }
        
    }
}

