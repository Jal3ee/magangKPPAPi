using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_ADMIN_POINS_API.Models;

namespace WEB_ADMIN_POINS_API.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        POINSDataContext db = new POINSDataContext();

        [HttpPost]
        [Route("GetLogin")]
        public IHttpActionResult Get_Login([FromBody] ClsLogin param)
        {
            try
            {
                ClsLogin responseData = new ClsLogin();

                bool cek = param.checkValidUser();

                if (cek == true)
                {
                    responseData = param.checkUserData();

                    if (responseData != null)
                    {
                        return Ok(new { Status = true, Data = responseData });
                    }
                    else
                    {
                        return Ok(new { Status = false, Message = "Username/Password Salah" });
                    }
                }
                else
                {
                    return Ok(new { Status = false, Message = "Username/Password Salah"});
                }

            }
            catch (Exception ex)
            {
                return Ok(new { Status = false, Message = ex.Message });
            }
        }
    }
}
