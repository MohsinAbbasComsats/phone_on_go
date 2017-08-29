
using DeviceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceManagement.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        DeviceManagementDBContext DBContext = new DeviceManagementDBContext();
        
        public ActionResult Index(long device_id)
        {
            Session[MySession.Selected_Device_Id] = device_id;
            Session[MySession.Selected_Service] = "Messages";
            ViewBag.selectDevice = device_id;
            return View();
        }
        public PartialViewResult ReceivedSMS()
        {
            long device_id = (long)Session[MySession.Selected_Device_Id];
            var smslist = DBContext.sms.Where(row => row.sms_type_id == 1 && row.device_id == device_id );
            return PartialView(smslist.ToList());
        }
        public PartialViewResult SentSMS()
        {
            long device_id = (long)Session[MySession.Selected_Device_Id];
            var smslist = DBContext.sms.Where(row => row.sms_type_id == 2 && row.device_id == device_id);
            return PartialView(smslist.ToList());
        }
        public PartialViewResult DraftSMS()
        {
            long device_id = (long)Session[MySession.Selected_Device_Id];
            var smslist = DBContext.sms.Where(row => row.sms_type_id == 3 && row.device_id == device_id);
            return PartialView(smslist.ToList());
        }
    }
}