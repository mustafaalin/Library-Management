using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesseract;


namespace WebApplication1.Controllers
{


    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Result = false;
            ViewBag.Title = "OCR ASP.NET MVC Example";
            return View();
        }

        public ActionResult submit(HttpPostedFileBase file)
        {
            if(file==null || file.ContentLength==0)
            {
                ViewBag.Result = true;
                ViewBag.res = "File not Found";
                return View("Index");
            }
            using (var engine = new TesseractEngine(Server.MapPath(@"~/tessdata"), "eng", EngineMode.Default))
            {
                using (var image = new System.Drawing.Bitmap(file.InputStream))
                {
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = engine.Process(pix))
                        {
                            ViewBag.Result = true;
                            char[] c;
                            int a = page.GetText().Length;
                            c = page.GetText().ToCharArray(0, a);
                            int isbn = page.GetText().IndexOf("ISBN");
                            for(int i=isbn+4; i<a; i++)
                            {
                                if (Char.IsDigit(c[i].ToString(), 0))
                                {
                                    if(ViewBag.res != null)
                                    {
                                        ViewBag.res = ViewBag.res.ToString() + c[i].ToString();
                                        if (ViewBag.res.Length == 13)
                                        {
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        ViewBag.res = c[i];
                                    }
                                    
                                }
                            }
                            ViewBag.mean = String.Format("{0:p}", page.GetMeanConfidence());
                            return View("Index");
                        }
                    }
                }
            }            

                return View();
        }
    }
}