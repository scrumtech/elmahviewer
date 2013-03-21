namespace ElmahViewer.Controllers
{
    using System.Web.Mvc;

    public class ElmahViewerController : Controller
    {
        public ActionResult Index(string applicationId, string errorId, int index = 0, int size = 15)
        {
            return View("Index");
        }
    }
}
