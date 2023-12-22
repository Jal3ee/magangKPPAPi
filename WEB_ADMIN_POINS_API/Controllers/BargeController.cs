using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_ADMIN_POINS_API.Models;

namespace WEB_ADMIN_POINS_API.Controllers
{
    [RoutePrefix("api/Barge")]
    public class BargeController : ApiController
    {
        POINSDataContext db = new POINSDataContext();

        [HttpPost]
        [Route("GetBarge")]
        public IHttpActionResult GetBarge()
        {
            try
            {
                var data = db.VW_BARGEs;//u.getListUser();

                return Ok(new { Data = data, Total = data.Count(), Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Data = "", Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
        }

        [HttpPost]
        [Route("GetBargeByID")]
        public IHttpActionResult GetBargeByID(int id)
        {
            try
            {
                var data = db.VW_BARGEs.Where(t => t.ID == id).FirstOrDefault();//u.getListUser();

                return Ok(new { Data = data, Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Data = "", Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
        }
        [HttpPost]
        [Route("SaveBarge")]
        public IHttpActionResult SaveBarge(ClsBarge brg)
        {
            try
            {
                brg.SaveBarge();
                return Ok(new { Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
        }

        [HttpPost]
        [Route("DeleteBarge")]
        public IHttpActionResult DeleteBarge(ClsBarge brg)
        {
            try
            {
                brg.DeleteBarge();
                return Ok(new { Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
        }
    }
}
