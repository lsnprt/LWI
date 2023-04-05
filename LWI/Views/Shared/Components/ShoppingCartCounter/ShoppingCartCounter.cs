using LWI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LWI.Views.Shared.Components.ShoppingCartCounter
{
    public class ShoppingCartCounter : ViewComponent
    {
        StateService service;
        public ShoppingCartCounter(StateService service)
        {
            this.service = service;
        }
        public IViewComponentResult Invoke()
        {
            ShoppingCartCounterVM model = new() {Items = int.Parse(service.NoOfCartItems()) };
            return View(model);
        }
    }
}
