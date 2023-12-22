using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_ADMIN_POINS_API.Models;

namespace WEB_ADMIN_POINS_API.Controllers
{
    [RoutePrefix("api/ApprovalBargingOnline")]
    public class ApprovalBargingOnlineController : ApiController
    {
        POINSDataContext db = new POINSDataContext();

        [HttpGet]
        [Route("GetDataBargingOnline")]
        public IHttpActionResult GetDataBargingOnline()
        {
            ClsApprovalBargingOnline clsApprovalBargingOnline = new ClsApprovalBargingOnline();
            var data = clsApprovalBargingOnline.GetDataBargingOnline();

            if (data == null)
            {
                return Ok(new { Remarks = false, Message = "Data not found !", Data = data });
            }

            return Ok(new { Remarks = true, Message = "Success", Data = data });
        }

        [HttpGet]
        [Route("DetailBargingOnline")]
        public IHttpActionResult DetailBargingOnline(int id)
        {
            ClsApprovalBargingOnline clsFormBargingOnline = new ClsApprovalBargingOnline() { id = id };
            ClsApprovalBargingOnline responseData = new ClsApprovalBargingOnline();

            responseData = clsFormBargingOnline.GetDetailData();
            if (responseData == null)
            {
                return Ok(new { Remarks = false, Message = "Error : Data tidak ditemukan", Data = responseData });
            }

            return Ok(new { Remarks = true, Message = "Success", Data = responseData });
        }

        [HttpPost]
        [Route("GetJetty")]
        public IHttpActionResult GetJetty()
        {
            ClsApprovalBargingOnline clsApprovalBargingOnline = new ClsApprovalBargingOnline();
            var listJetty = clsApprovalBargingOnline.GetListJetty();

            if (listJetty == null)
            {
                return Ok(new { Remarks = false, Data = listJetty });
            }

            return Ok(new { Remarks = true, Data = listJetty });
        }

        [HttpPost]
        [Route("GetJettyCapacity")]
        public IHttpActionResult GetJettyCapacity(string JETTY)
        {
            ClsApprovalBargingOnline clsFormBargingOnline = new ClsApprovalBargingOnline() { jetty = JETTY };
            var responseData = clsFormBargingOnline.GetCapacity();

            if (responseData == null)
            {
                return Ok(new { Remarks = false, Data = responseData });
            }

            return Ok(new { Remarks = true, Data = responseData });
        }

        [HttpGet]
        [Route("GetJettyDuration")]
        public IHttpActionResult GetJettyDuration(string JETTY, int CAPACITY)
        {
            ClsApprovalBargingOnline clsFormBargingOnline = new ClsApprovalBargingOnline() { jetty = JETTY, capacity = CAPACITY };
            var duration = clsFormBargingOnline.GetDuration();

            if (duration == null)
            {
                return Ok(new { Remarks = false, Data = duration });
            }

            return Ok(new { Remarks = true, Data = duration });
        }

        [HttpPost]
        [Route("UpdateBargingOnline")]
        public IHttpActionResult UpdateBargingOnline([FromBody] ClsApprovalBargingOnline clsApprovalBargingOnline)
        {
            var result = clsApprovalBargingOnline.SaveDataBargingOnline();
            if (result != "")
            {
                return Ok(new { Remarks = false, Message = "System Error : " + result });
            }

            return Ok(new { Remarks = true, Message = "Berhasil Update!" });
        }

        [HttpPost]
        [Route("Approval")]
        public IHttpActionResult Approval(int ID, int OPTION)
        {
            ClsApprovalBargingOnline clsFormBargingOnline = new ClsApprovalBargingOnline() { id = ID, option = OPTION };
            var result = clsFormBargingOnline.ApprovalBargingOnline();
            if (result != "")
            {
                return Ok(new { Remarks = false, Message = "System Error : " + result });
            }

            return Ok(new { Remarks = true, Message = "Berhasil Update!" });
        }
    }
}
