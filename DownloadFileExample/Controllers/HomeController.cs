using System.IO;
using System.Text;
using System.Web.Mvc;

namespace DownloadFileExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Hello(string name)
        {
            var message = string.Format("Hello {0}", name);
            return PartialView("_Hello", message);

        }

        [HttpPost]
        public FileResult DownloadFile()
        {
            var textToReturn = "This is a test!";
            var byteArray = Encoding.ASCII.GetBytes(textToReturn);
            var stream = new MemoryStream(byteArray);


            var cd = new System.Net.Mime.ContentDisposition()
            {
                FileName = "test.txt",
                Inline = false
            };

            stream.Flush();
            stream.Position = 0;



            Response.AddHeader("Content-Disposition", cd.ToString());
            return File(stream, "text/plain");


        }
    }
}