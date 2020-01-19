using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sample_web.Models;

namespace sample_web.Controllers
{
  public class UserInfoController : Controller
  {
    UserInfoModel data = new UserInfoModel();
    // GET: UserInfo
    [HttpPost]
    public ActionResult UserInfo()
    {
      return View(data.view_model);
    }
  }
}