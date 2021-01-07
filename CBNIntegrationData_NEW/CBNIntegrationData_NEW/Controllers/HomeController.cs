// Decompiled with JetBrains decompiler
// Type: CBNIntegration_NEW.Controllers.HomeController
// Assembly: CBNIntegration_NEW, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6C724E3B-F2BD-4CEF-A0DE-A413F9617FBB
// Assembly location: C:\Users\Ayodele.Bamgboye\Downloads\CBN INTEGRATION\CBN INTEGRATION\CBNServiceIntegration\bin\CBNIntegration_NEW.dll

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CBNIntegration_NEW.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
