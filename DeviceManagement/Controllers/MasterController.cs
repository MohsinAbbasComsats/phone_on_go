using DeviceManagement.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DeviceManagement.Controllers
{
    public class MasterController : Controller
    {
        DeviceManagementDBContext DBContext = new DeviceManagementDBContext();
        // GET: Master
        public ActionResult Index()
        {
            if (Session[MySession.UserName] != null)
            {
                //redirect to Message Controller
                return RedirectToAction("Dashboard", "Master");
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            if (Session[MySession.UserName] != null)
            {
                ViewBag.selected = "Dashboard";
                Session[MySession.Selected_Device_Id] = "Dashboard";
                long userid = (long)Session[MySession.UserId];
                var devices = DBContext.devices.Where(dev => dev.user_id == userid);
                return View(devices.ToList());
            }
            return RedirectToAction("Index", "Master");           
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            List<user> UserList = (List<user>)DBContext.users.Where(u => u.username == email && u.userpassword == password).ToList();
            if(UserList.Count>0)
            {
                user User = UserList[0];
                Session[MySession.UserName] = email;
                Session[MySession.UserId] = User.user_id;
                return RedirectToAction("Dashboard", "Master");
            }
            return RedirectToAction("Index", "Master");
        }
        public ActionResult Logout()
        {
            Session[MySession.UserName] = null;
            return RedirectToAction("Index", "Master");
        }
        public PartialViewResult Header()
        {
            long userid = (long)Session[MySession.UserId];
            List<user> UserList = (List<user>)DBContext.users.Where(u => u.user_id == userid).ToList();
            if (UserList.Count > 0)
            {
                user User = UserList[0];
                return PartialView(User);
            }
            return PartialView();
        }
        public PartialViewResult LeftNavigation()
        {
            long userid = (long)Session[MySession.UserId];
            var Devices = DBContext.devices.Where(d => d.user_id == userid);
            return PartialView(Devices.ToList());
        }
        public PartialViewResult ToolBar()
        {
            long userid = (long)Session[MySession.UserId];
            var sub_services = (from serv in DBContext.services
                                join user_subs in DBContext.subscriptions
                                    on serv.service_id equals user_subs.service_id
                                where user_subs.user_id == userid && user_subs.active == true
                                select new
                                {
                                    service_id = serv.service_id,
                                    service_title = serv.service_title,
                                    service_controller = serv.service_controller,
                                    service_price = serv.service_price,
                                    isdeleted = serv.isdeleted,
                                    icon = serv.icon
                                });
            List<services> serviceList = new List<services>();
            foreach(var serv in sub_services.ToList())
            {
                serviceList.Add(new services { service_id = serv.service_id, service_title = serv.service_title,
                                               service_controller = serv.service_controller,service_price = serv.service_price,
                                               isdeleted = serv.isdeleted,icon = serv.icon});
            }
            if(serviceList.Count>0)
                return PartialView(serviceList);
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddDevice(string deviceTitle)
        {
            device dev = new device();
            dev.device_title = deviceTitle;
            DateTime now = DateTime.Now;
            dev.timestamp = BitConverter.GetBytes(now.Ticks);
            //DateTime myDateTime = DateTime.FromBinary(BitConverter.ToInt64(dev.timestamp, 0));
            dev.activation_code = Guid.NewGuid().ToString();
            dev.user_id = (long)Session[MySession.UserId];
            dev.isactive = false;
            DBContext.devices.Add(dev);
            if(DBContext.SaveChanges()>0)
            {
                //success
                return RedirectToAction("Dashboard","Master");
            }
            else
            {
                //failure
            }
            return PartialView();
            
        }
    }
}