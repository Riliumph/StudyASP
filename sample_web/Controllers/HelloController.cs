using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sample_web.Models;

namespace sample_web.Controllers
{
  public class HelloController : Controller
  {
    // GET: Hello
    public ActionResult PageName()
    {
      return View("PageName");
    }

    [HttpPost]
    public ActionResult HelloView(HelloModel hello)
    {
      ModelState.Clear();
      hello.str1 = "Hello";
      hello.str2 = "World";
      return View("HelloView"/*cshtml*/, hello);
    }
  }
}