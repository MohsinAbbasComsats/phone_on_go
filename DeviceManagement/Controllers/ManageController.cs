using DeviceManagement.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceManagement.Controllers
{
    public class ManageController : Controller
    {
        DeviceManagementDBContext DBContext = new DeviceManagementDBContext();
        // GET: Manage
        public ActionResult Index(long device_id)
        {
            Session[MySession.Selected_Device_Id] = device_id;
            Session[MySession.Selected_Service] = "Manage";

            ViewBag.selectDevice = device_id;
            return View();
        }
        public PartialViewResult Services()
        {
            var user_srv = (from subs in DBContext.subscriptions
                            join srv in DBContext.services on subs.service_id equals srv.service_id
                            select new { srv.service_id, srv.service_title,srv.icon, subs.active }
                            );
            List<UserSubstribedServicesViewModel> user_sub_srvList = new List<UserSubstribedServicesViewModel>();
            foreach (var item in user_srv.ToList())
                user_sub_srvList.Add(new UserSubstribedServicesViewModel {service_id = item.service_id,service_title = item.service_title,service_icon = item.icon,active=(bool)item.active});
                   
            return PartialView(user_sub_srvList);
        }

        [HttpPost]
        public ActionResult SyncServices(List<UserSubstribedServicesViewModel> userSubSrv)
        {
            long device_id = (long)Session[MySession.Selected_Device_Id];
            return RedirectToAction("Index","Manage",new {device_id = device_id });
        }
    }
}