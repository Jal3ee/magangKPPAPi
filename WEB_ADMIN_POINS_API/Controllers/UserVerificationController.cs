using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_ADMIN_POINS_API.Models;

namespace WEB_ADMIN_POINS_API.Controllers
{
    [RoutePrefix("api/UserVerification")]
    public class UserVerificationController : ApiController
    {
        POINSDataContext db = new POINSDataContext();

        [HttpGet]
        [Route("GetDataUnverifiedUser")]
        public IHttpActionResult GetDataUnverifiedUser()
        {
            ClsVerificationUser clsVerificationUser = new ClsVerificationUser();
            var data = clsVerificationUser.GetDataUnverifiedUser();

            if (data == null)
            {
                return Ok(new { Remarks = false, Message = "Data not found !", Data = data });
            }

            return Ok(new { Remarks = true, Message = "Success", Data = data });
        }

        [HttpPost]
        [Route("UpdateVerificationStatus")]
        public IHttpActionResult UpdateVerificationStatus(int ID, bool OPTION)
        {
            ClsVerificationUser clsVerificationUser = new ClsVerificationUser() { id = ID, option = OPTION };

            var result = clsVerificationUser.SaveDataVerificationStatus();
            if (result != "")
            {
                return Ok(new { Remarks = false, Message = "System Error : " + result });
            }

            return Ok(new { Remarks = true, Message = "Berhasil Update!" });
        }
    }
}
