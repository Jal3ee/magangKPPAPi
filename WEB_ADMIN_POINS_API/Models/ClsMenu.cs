using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WEB_ADMIN_POINS_API.Models;

namespace WEB_ADMIN_POINS_API.Models
{
    public class ClsMenu
    {
        POINSDataContext db = new POINSDataContext();
        public string ICON { get; set; }
        public string NAMA { get; set; }
        public string LINK { get; set; }
    }
}