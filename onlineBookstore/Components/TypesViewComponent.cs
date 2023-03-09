using Microsoft.AspNetCore.Mvc;
using onlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineBookstore.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IOnlineBookstoreRepository repo { get; set; }

        public TypesViewComponent (IOnlineBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["category"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
