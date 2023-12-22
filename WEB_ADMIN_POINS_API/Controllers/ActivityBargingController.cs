using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_ADMIN_POINS_API.Models;

namespace WEB_ADMIN_POINS_API.Controllers
{
    [RoutePrefix("api/ActivityBarging")]
    public class ActivityBargingController : ApiController
    {
        POINSDataContext db = new POINSDataContext();
      //  BeltproDataContext beltpro = new BeltproDataContext();

        
        [HttpPost]
        [Route("GetDataActivityBarging")]
        public IHttpActionResult GetDataActivityBarging()
        {
            try
            {
               
                var dataBargingDetail = db.cusp_get_progress_barging_web().OrderByDescending(x => x.Kode_Jetty).FirstOrDefault();
                //var dataBargingProgress = db.cusp_get_active_bargingProgress(dataBargingDetail.ClientTransId).FirstOrDefault();

                return Ok(new { Data = new { bargingDetail = dataBargingDetail}, Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Data = "", Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
            
        }

        [HttpPost]
        [Route("GetActiveBargingRowData")]
        public IHttpActionResult GetActiveBargingRowData()
        {

            try
            {
                //var data = db.cusp_get_active_bargingData().OrderByDescending(x => x.ID);
                //var dataMaterial = db.cufn_getActiveBargingData().OrderByDescending(x => x.id);
                List<cusp_get_progress_barging_webResult> list = new List<cusp_get_progress_barging_webResult>();

                var dataMaterial = db.cusp_get_progress_barging_web().ToList();
                foreach (var keyItem in dataMaterial)
                {
                    list.Add(new cusp_get_progress_barging_webResult
                    {
                        Kode_Jetty = keyItem.Kode_Jetty,
                        WeightPercentage = keyItem.WeightPercentage,
                        Progress = keyItem.Progress,
                        TPH = keyItem.TPH,
                        Customer = keyItem.Customer,
                        Target_Barging = keyItem.Target_Barging,
                        Speed = keyItem.Speed,
                        Progress_RataRata = keyItem.Progress_RataRata,
                        Status = keyItem.Status,
                        KodeStatus = keyItem.KodeStatus,
                        Kode = keyItem.Kode,
                        Barge = keyItem.Barge,
                        TugBoat = keyItem.TugBoat,
                        Jetty = keyItem.Jetty

                    });

                    //        //list.Add(dataMaterial);


                    //        //List<cusp_getBargingDwellingTimeDataResult> listDT = new List<cusp_getBargingDwellingTimeDataResult>();
                    //        //foreach (var keyDT in data)
                    //        //{
                    //        //    var dataDT = db.cusp_getBargingDwellingTimeData(keyDT.id).ToList();
                    //        //    foreach (var keyItem in dataDT)
                    //        //    {
                    //        //        listDT.Add(new cusp_getBargingDwellingTimeDataResult
                    //        //        {
                    //        //            id = keyItem.id,
                    //        //            barging_id = keyItem.barging_id,
                    //        //            jetty_id = keyItem.jetty_id,
                    //        //            time = keyItem.time,
                    //        //            status = keyItem.status,
                    //        //            description = keyItem.description,
                    //        //            user_id = keyItem.user_id,
                    //        //            jetty = keyItem.jetty,
                    //        //            customer = keyItem.customer,
                    //        //            statusDesc = keyItem.statusDesc,
                    //        //            datee = keyItem.datee,
                    //        //            timee = keyItem.timee,
                    //        //            duration = keyItem.duration,
                    //        //            descriptionn = keyItem.descriptionn,
                    //        //            durasii = keyItem.durasii
                    //        //        });
                    //        //    }
                    //        //    //list.Add(dataMaterial);
                    //        //}

                    return Ok(new { Data = dataMaterial = list, dataMaterial= list, Total = dataMaterial.Count(), Remarks = true, Message = "Success" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Data = "", Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
            return Ok(new { Data = "", Remarks = false, Message = "Unknown error occurred." });
        }

        [HttpPost]
        [Route("GetActiveBargingMaterialByBargingID")]
        public IHttpActionResult GetActiveBargingMaterialByBargingID()
        {
            try
            {
                var data = db.cusp_get_progress_barging_web();

                return Ok(new { Data = data, Total = data.Count(), Remarks = true, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Ok(new { Data = "", Remarks = false, Message = "Error : " + ex.Message.ToString() });
            }
        }

        // GET api/<controller>
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