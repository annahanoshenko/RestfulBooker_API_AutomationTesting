using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBooker_API
{
    internal class BookingCreateModel
    {
        public string firstname {  get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public BookingDates bookingdates { get; set; }
        public string additionalneeds {  get; set; }

    }

}
