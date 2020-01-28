using AlloyTraining.Models.Pages;
using System.Web.Mvc;
using EPiServer.Web.Mvc;
using AlloyTraining.Models.ViewModels;

namespace AlloyTraining.Controllers
{
    public class ProductPartialPageController
    : PartialContentController<ProductPage>
    {
        public override ActionResult Index(ProductPage currentPage)
        {
            return PartialView(PageViewModel.Create(currentPage));
        }
    }
}