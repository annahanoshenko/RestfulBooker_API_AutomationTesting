using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBooker_API
{
    internal class BookingModel
    {
        public int bookingid { get; set; }
        public BookingCreateModel booking { get; set; }
    }

}
