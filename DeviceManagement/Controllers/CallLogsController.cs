using DeviceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DeviceManagement.Controllers
{
    public class CallLogsController : Controller
    {
        DeviceManagementDBContext DBContext = new DeviceManagementDBContext();
        // GET: CallLogs
        public ActionResult Index(long device_id)
        {
            Session[MySession.Selected_Device_Id] = device_id;
            Session[MySession.Selected_Service] = "Call Logs";
            ViewBag.selectDevice = device_id;
            return View();
        }
        public PartialViewResult ReceivedCalls()
        {
            long device_id = (long)Session[MySession.Selected_Device_Id];
            var calllogs = DBContext.calllogs.Where(row => row.calllog_type_id == 1 && row.device_id == device_id);
            return PartialView(calllogs.ToList());
        }
        public PartialViewResult DialedCalls()
        {
            long device_id = (long)Session[MySession.Selected_Device_Id];
            var calllogs = DBContext.calllogs.Where(row => row.calllog_type_id == 2 && row.device_id == device_id);
            return PartialView(calllogs.ToList());
        }
        public PartialViewResult MissedCalls()
        {
            long device_id = (long)Session[MySession.Selected_Device_Id];
            var calllogs = DBContext.calllogs.Where(row => row.calllog_type_id == 3 && row.device_id == device_id);
            return PartialView(calllogs.ToList());
        }
    }
}