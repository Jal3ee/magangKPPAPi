using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_ADMIN_POINS_API.Models;

namespace WEB_ADMIN_POINS_API.Controllers
{
    [RoutePrefix("api/MasterData")]
    public class MasterDataController : ApiController
    {
        // GET api/<controller>
        POINSDataContext db = new POINSDataContext();

        [HttpPost]
        [Route("GetMasterBarge")]
        public IHttpActionResult GetMasterBarge()
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
        [Route("GetMasterBargeByID")]
        public IHttpActionResult GetMasterBargeByID(int ID)
        {
            try
            {
                
                var data = db.VW_BARGEs.Where(t => t.ID == ID).FirstOrDefault() ;//u.getListUser();

                return Ok(new { Data = data, Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Data = "", Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
        }

        [HttpPost]
        [Route("SaveMasterBarge")]
        public IHttpActionResult SaveMasterBarge(ClsMasterData.MasterBarge brg)
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
        [Route("DeleteMasterBarge")]
        public IHttpActionResult DeleteMasterBarge(ClsMasterData.MasterBarge brg)
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

        [HttpPost]
        [Route("GetMasterTugBoat")]
        public IHttpActionResult GetMasterTugBoat()
        {
            try
            {
                var data = db.VW_TUGBOATs;//u.getListUser();

                return Ok(new { Data = data, Total = data.Count(), Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Data = "", Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
        }
        [HttpPost]
        [Route("GetMasterTugBoatByID")]
        public IHttpActionResult GetMasterTugBoatByID(int ID)
        {
            try
            {

                var data = db.VW_TUGBOATs.Where(t => t.ID == ID).FirstOrDefault();//u.getListUser();

                return Ok(new { Data = data, Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Data = "", Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
        }

        [HttpPost]
        [Route("SaveMasterTugBoat")]
        public IHttpActionResult SaveMasterTugBoat(ClsMasterData.MasterTugBoat tgb)
        {
            try
            {
                tgb.SaveTugBoat();
                return Ok(new { Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
        }

        [HttpPost]
        [Route("DeleteMasterTugBoat")]
        public IHttpActionResult DeleteMasterTugBoat(ClsMasterData.MasterTugBoat tgb)
        {
            try
            {
                tgb.DeleteTugBoat();
                return Ok(new { Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
        }


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}