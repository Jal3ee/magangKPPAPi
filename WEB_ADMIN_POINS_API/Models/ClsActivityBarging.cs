using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;


namespace WEB_ADMIN_POINS_API.Models
{
    public class ClsActivityBarging
    {
        POINSDataContext db = new POINSDataContext();

        public class ClsBargingMaterial
        {
            public float? WeightPercentage { get; set; }
            public int Progress { get; set; }
            public int? TPH { get; set; }
            public int? Speed { get; set; }
            public int? Progress_RataRata { get; set; }
            public int? Target_Barging { get; set; }
            public string Kode { get; set; }
            public string Customer { get; set; }
            public string Barge { get; set; }
            public string TugBoat { get; set; }
            public string Jetty { get; set; }
            public string Status { get; set; }
            public int? KodeStatus {  get; set; }
        }
        //BeltproDataContext beltpro = new BeltproDataContext();
        // GET api/<controller>

        //public int? clienttransid { get; set; }
        //public int? nodeid { get; set; }
        //public string transno { get; set; }
        //public DateTime startdate { get; set; }
        //public string nodetrans { get; set; }
        //public DateTime enddate { get; set; }
        //public float? startweight { get; set; }
        //public float? endweight { get; set; }
        //public string kode { get; set; }
        //public float? weight { get; set; }
        //public float? weightplan { get; set; }
        //public float? tph { get; set; }
        //public int? shift { get; set; }
        //public string companyname { get; set; }
        //public string bargename { get; set; }
        //public string boatname { get; set; }

        //public int GetVolumeByBucketCtrlAttribute()
        //{
        //    string sql = "SELECT (SUM(volume_progress) / 1000) AS v FROM barging_materials WHERE barging_id = ?";
        //    return 'Select(sql, this.id)[0].v';
        //}


        //public List<cusp_get_progressResult> GetProgress()
        //{
        //    var progress = db.cusp_get_progress().ToList();

        //    if (progress == null)
        //    {
        //        return null;
        //    }

        //    return progress;
        //}



    }
}