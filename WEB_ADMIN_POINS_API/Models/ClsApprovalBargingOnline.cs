using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_ADMIN_POINS_API.Models;
using System.Net.Mail;
using System.IO;

namespace WEB_ADMIN_POINS_API.Models
{
    public class ClsApprovalBargingOnline
    {
        POINSDataContext db = new POINSDataContext();

        public int id { get; set; }
        public String jetty { get; set; }
        public String company { get; set; }
        public String tug_boat { get; set; }
        public String barge { get; set; }
        public int? capacity { get; set; }
        public int? process_time { get; set; }
        public Nullable<DateTime> date_booking { get; set; }
        public int? start_time { get; set; }
        public String nama { get; set; }
        public int? finish_time { get; set; }
        public Nullable<DateTime> finish_booking { get; set; }
        public String status { get; set; }
        public String vessel { get; set; }

        public int option { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<cusp_get_barging_onlineResult> GetDataBargingOnline()
        {
            var dataBargingOnline = db.cusp_get_barging_online().ToList();

            return dataBargingOnline;
        }

        public ClsApprovalBargingOnline GetDetailData()
        {
            var formBargingOnline = db.VW_BARGING_ONLINEs.Where(x => x.ID == id).FirstOrDefault();

            if (formBargingOnline == null)
            {
                return null;
            }

            ClsApprovalBargingOnline dataBargingOnlineReturn = new ClsApprovalBargingOnline()
            {
                jetty = formBargingOnline.JETTY,
                company = formBargingOnline.CUSTOMER,
                tug_boat = formBargingOnline.TUG_BOAT,
                barge = formBargingOnline.BARGE,
                capacity = formBargingOnline.CAPACITY,
                process_time = formBargingOnline.PROCESS_TIME,
                date_booking = formBargingOnline.DATE_BOOKING,
                start_time = formBargingOnline.START_TIME,
                nama = formBargingOnline.NAMA,
                finish_time = formBargingOnline.FINISH_TIME,
                finish_booking = formBargingOnline.FINISH_BOOKING,
                status = formBargingOnline.STATUS,
                vessel = formBargingOnline.VESSEL,
            };

            return dataBargingOnlineReturn;
        }

        public List<cusp_get_list_jettyResult> GetListJetty()
        {
            var listJetty = db.cusp_get_list_jetty().ToList();

            if (listJetty == null)
            {
                return null;
            }

            return listJetty;
        }
        public List<VW_JETTY> GetCapacity()
        {
            var listJetty = db.VW_JETTies.Where(x => x.NAME == jetty).ToList();

            if (listJetty == null)
            {
                return null;
            }

            return listJetty;
        }

        public int? GetDuration()
        {
            var data = db.VW_JETTies.Where(x => x.NAME == jetty && x.CAPACITY == capacity).FirstOrDefault();
            var currDuration = data.DURATION;

            if (currDuration == null)
            {
                return null;
            }

            return currDuration;
        }

        public String SaveDataBargingOnline()
        {
            try
            {
                // Set FinishTime automatically based on StartTime and ProcessTime
                int? finishTime = start_time.Value + process_time;
                DateTime? finishBooking = null;

                #region oldLogic
                //if (finishTime > 24)
                //{
                //    finishTime -= 24;
                //    finishBooking = date_booking.Value.AddDays(1);
                //}

                //// Check for booking conflicts
                //var conflictingBooking = db.VW_BARGING_ONLINEs.FirstOrDefault(b =>
                //    ((b.DATE_BOOKING == date_booking && b.FINISH_BOOKING == null) ||
                //    (b.DATE_BOOKING == date_booking.Value.AddDays(1) && b.FINISH_BOOKING != null)) &&
                //    ((b.START_TIME >= start_time && b.START_TIME < finishTime) ||
                //    (b.FINISH_TIME > start_time && b.FINISH_TIME <= finishTime) ||
                //    (b.START_TIME <= start_time && b.FINISH_TIME >= finishTime))
                //);

                //if (conflictingBooking != null && conflictingBooking.ID != id)
                //{
                //    return "Terjadi bentrokan waktu booking!";
                //}
                #endregion
                ///////
                if (finishTime > 24)
                {
                    finishTime -= 24;
                    finishBooking = date_booking.Value.AddDays(1);

                    // Check for booking conflicts
                    var conflictingBooking = db.VW_BARGING_ONLINEs.FirstOrDefault
                        (b => ((b.DATE_BOOKING == date_booking) || (b.DATE_BOOKING == date_booking.Value.AddDays(1))) && ((b.START_TIME >= start_time && b.DATE_BOOKING == date_booking) || (b.START_TIME < finishTime && b.DATE_BOOKING == date_booking.Value.AddDays(1))) || /*++*/ ((b.FINISH_TIME > start_time && b.DATE_BOOKING == date_booking) || (b.FINISH_TIME <= finishTime && b.DATE_BOOKING == date_booking.Value.AddDays(1))));

                    if (conflictingBooking != null)
                    {
                        return "Terjadi bentrokan waktu booking!";
                    }
                }
                else
                {
                    // Check for booking conflicts
                    var conflictingBooking = db.VW_BARGING_ONLINEs.FirstOrDefault
                        (b => (b.DATE_BOOKING == date_booking) && ((b.START_TIME >= start_time && b.START_TIME < finishTime) || (b.FINISH_TIME > start_time && b.FINISH_TIME <= finishTime)));

                    if (conflictingBooking != null)
                    {
                        return "Terjadi bentrokan waktu booking!";
                    }
                }

                db.cusp_update_barging_online(id, jetty, capacity, process_time, date_booking, start_time, finishBooking, finishTime, vessel);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        public String ApprovalBargingOnline()
        {
            try
            {
                var dataBargin = db.VW_BARGING_ONLINEs.Where(x => x.ID == id).FirstOrDefault();

                
                db.cusp_NotifikasiEmail(option, dataBargin.NAMA, dataBargin.JETTY, dataBargin.CUSTOMER, dataBargin.TUG_BOAT, dataBargin.BARGE, dataBargin.CAPACITY, dataBargin.DATE_BOOKING);
                db.cusp_insertDataForInAppNotificationPOINS(dataBargin.ID, option);
                db.cusp_NotifikasiWhatsApp(option, dataBargin.TELEPON);
                db.cusp_approval_barging_online(id, option);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
    }
}