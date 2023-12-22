using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_ADMIN_POINS_API.Models
{
    public class ClsTugboat
    {
        POINSDataContext db = new POINSDataContext();

        public int id { get; set; }
        public string tugboat { get; set; }
    }
}