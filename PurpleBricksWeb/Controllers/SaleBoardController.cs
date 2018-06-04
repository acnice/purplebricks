using PurpleBricksWeb.Models;
using System.Web.Mvc;

namespace PurpleBricksWeb.Controllers
{
    public class SaleBoardController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View("SaleBorad", new SaleBoradModel());
        }

        public JsonResult CheckPrice(SaleBoradModel salsesOrder)
        {
            salsesOrder.GetPrice();
            return Json(salsesOrder, JsonRequestBehavior.AllowGet);
        }
    }
}