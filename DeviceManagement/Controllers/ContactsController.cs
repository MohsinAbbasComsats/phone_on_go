using DeviceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceManagement.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index(long device_id)
        {
            Session[MySession.Selected_Device_Id] = device_id;
            Session[MySession.Selected_Service] = "Contacts";
            ViewBag.selectDevice = device_id;
            return View();
        }
        public ActionResult ContactsTemplates()
        {
            return View();
        }
    }
}