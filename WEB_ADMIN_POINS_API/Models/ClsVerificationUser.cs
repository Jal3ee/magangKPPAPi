using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_ADMIN_POINS_API.Models;
using System.Net.Mail;
using System.IO;

namespace WEB_ADMIN_POINS_API.Models
{
    public class ClsVerificationUser
    {
        POINSDataContext db = new POINSDataContext();

        public int id { get; set; }
        public bool option { get; set; }

        public List<VW_USER> GetDataUnverifiedUser()
        {
            var dataUnverifiedUser = db.VW_USERs.Where(x => x.VERIFICATION_STATUS == null).ToList();

            return dataUnverifiedUser;
        }

        public String SaveDataVerificationStatus()
        {
            try
            {
                string res = "";
                var dataUser = db.VW_USERs.Where(x => x.ID == id).FirstOrDefault();

                if (option == true) {
                    res = "true";
                    db.cusp_NotifikasiEmail_Verification(0, dataUser.EMAIL);
                    db.cusp_NotifikasiWhatsApp_Verification(0, dataUser.TELEPON);
                }
                else
                {
                    res = "false";
                    db.cusp_NotifikasiEmail_Verification(1, dataUser.EMAIL);
                    db.cusp_NotifikasiWhatsApp_Verification(1, dataUser.TELEPON);
                }

                db.cusp_update_user_verification(id, res);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
    }
}