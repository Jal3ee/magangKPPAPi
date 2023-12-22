using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_ADMIN_POINS_API.Models
{
    public class ClsBarge
    {
        POINSDataContext db = new POINSDataContext();
        
        public int id { get; set; }
        public string barge { get; set; }

        public void SaveBarge()
        {
            var query = db.VW_BARGEs.Where(t => t.ID == id).FirstOrDefault();
            if (query  != null)
            {
                query.BARGE = barge;
            }
            else
            {
                VW_BARGE bargee = new VW_BARGE();
                bargee.BARGE = barge;

                db.VW_BARGEs.InsertOnSubmit(bargee);
            }
            db.SubmitChanges();
        }
        public void DeleteBarge()
        {
            var query = db.VW_BARGEs.Where(t =>t.ID == id).FirstOrDefault();
            db.VW_BARGEs.DeleteOnSubmit(query);
            db.SubmitChanges();
        }
    }
}