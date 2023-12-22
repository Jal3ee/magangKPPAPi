using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using WEB_ADMIN_POINS_API.Models;
using System.IO;

namespace WEB_ADMIN_POINS_API.Controllers
{
    [RoutePrefix("api/DashboardMenu")]
    public class DashboardMenuController : ApiController
    {
        POINSDataContext db = new POINSDataContext();

        [HttpGet]
        [Route("GetDashboardMenu")]
        public IHttpActionResult GetDashboardMenu()
        {
            try
            {
                var data = db.TBL_M_MENU_DASHBOARDs.ToList();

                if (data == null)
                {
                    return Content(HttpStatusCode.BadRequest, new { Status = false, Message = "Menu Tidak ada!!!" });
                }

                return Ok(new { Data = data, Status = true, Message = "Data Berhasil Diambil!!!", Total = data.Count() });
            }
            catch(Exception e)
            {
                return Content(HttpStatusCode.BadRequest, new { Message = e.Message });
            }
        }

        [Route("Create_Menu")]
        [HttpPost]
        public IHttpActionResult CreateMenu(ClsMenu menu)
        {
            try
            {
                var requestUrl = HttpContext.Current.Request.Url;
                var uriBuilder = new UriBuilder(requestUrl)
                {
                    Scheme = Uri.UriSchemeHttps
                };
                var url = uriBuilder.Uri;

                string base64 = menu.ICON.Substring(menu.ICON.IndexOf(',') + 1);
                base64 = base64.Trim('\0');
                string strDateTime = DateTime.Now.ToString("ddMmyyyHHMMss");
                string fileName = menu.NAMA.Replace(" ", "_") + ".png";
                byte[] imageBytes = Convert.FromBase64String(base64);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                string physicalPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Images/Menu/" + fileName);

                var path = System.Web.Hosting.HostingEnvironment.MapPath("~/Images/Menu/");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                image.Save(physicalPath, System.Drawing.Imaging.ImageFormat.Png);

                Guid i_guid_pid = System.Guid.NewGuid();

                TBL_M_MENU_DASHBOARD table_data = new TBL_M_MENU_DASHBOARD();
                table_data.ICON = $"{url.Scheme}://{url.Authority}/Images/Menu/{fileName}";
                table_data.NAMA = menu.NAMA;

                db.TBL_M_MENU_DASHBOARDs.InsertOnSubmit(table_data);
                db.SubmitChanges();

                return Ok(new { Status = true, Message = "Data berhasil dimasukkan !!!" });
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, new { Status = false, Message = e.Message });
            }
        }
    }
}
