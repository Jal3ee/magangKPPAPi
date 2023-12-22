using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WEB_ADMIN_POINS_API.Models
{
    public class ClsMasterData
    {
        
        public class MasterBarge
        {
            POINSDataContext db = new POINSDataContext();
            public int ID { get; set; }
            public string BARGE { get; set; }
            public string SaveBarge()
            {
                try {
                    var data = db.VW_BARGEs.Where(t => t.ID == ID).FirstOrDefault();
                    if (data != null)
                    {
                        db.cusp_update_barge(ID, BARGE);
                    }
                    else
                    {
                        db.cusp_insert_barge(BARGE);
                    }
                }
                
                
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return "";
            }
            public string DeleteBarge()
            {
                try
                {
                    db.cusp_delete_barge(ID);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return "";
            }
            //public string UpdateBarge()
            //{
            //    try
            //    {
            //        db.cusp_update_barge(ID, BARGE);
            //    }
            //    catch(Exception ex)
            //    {
            //        return ex.Message;
            //    }
            //    return "";

            //}

        }
        public class MasterTugBoat
        {
            POINSDataContext db = new POINSDataContext();
            public int ID { get; set; }
            public string TUG_BOAT { get; set; }
            public string SaveTugBoat()
            {
                try
                {
                    var data = db.VW_TUGBOATs.Where(t => t.ID == ID).FirstOrDefault();
                    if (data != null)
                    {
                        db.cusp_update_tugboat(ID, TUG_BOAT);
                    }
                    else
                    {
                        db.cusp_insert_tugboat(TUG_BOAT);
                    }
                }


                catch (Exception ex)
                {
                    return ex.Message;
                }
                return "";
            }
            public string DeleteTugBoat()
            {
                try
                {
                    db.cusp_delete_tugboat(ID);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return "";
            }

        }

    }
}