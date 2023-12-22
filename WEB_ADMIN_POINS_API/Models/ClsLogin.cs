using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_ADMIN_POINS_API.Models;
using FormsAuth;

namespace WEB_ADMIN_POINS_API.Models
{

    public class ClsLogin
    {
        POINSDataContext db = new POINSDataContext();

        public string nrp { get; set; }
        public string pass { get; set; }

        public string nama { get; set; }
        public string district { get; set; }

        public ClsLogin checkUserData()
        {

            if (nrp.Count() > 7) {
                nrp = nrp.Substring(1);
            }

            var data_user = db.VW_KARYAWAN_ALLs.Where(x => x.EMPLOYEE_ID == nrp).SingleOrDefault();
            if (data_user != null && pass == "testpoins")
            {
                ClsLogin dataLogin = new ClsLogin()
                {
                    nrp = data_user.NRP,
                    nama = data_user.NAME,
                    district = data_user.DSTRCT_CODE,
                };

                return dataLogin;
            }

            return null;
        }

        public bool checkValidUser()
        {
            bool iReturn = false;

            try
            {
                //var ldap = new LdapAuthentication("LDAP://KPPMINING:389");
                //iReturn = ldap.IsAuthenticated("KPPMINING", nrp, pass);

                if (nrp != null) //UNTUK TEST
                {
                    if (pass == "")
                    {
                        iReturn = false;
                    }
                    else
                    {
                        iReturn = true;
                    }
                }
            }
            catch (Exception ex)
            {
                var asd = ex.ToString();
                iReturn = false;
            }

            return iReturn;
        }

    }
}