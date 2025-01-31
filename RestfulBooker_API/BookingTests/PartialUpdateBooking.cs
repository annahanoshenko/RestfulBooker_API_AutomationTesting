using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBooker_API.BookingTests
{
    [TestFixture]
    internal class PartialUpdateBooking : TestBase
    {
        [Test]
        public void PATCH_PartialUpdateBooking_200OK()
        {
            int bookingId = 1;
            var body = new
            {
                firstname = "James",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            };

            request = new RestRequest($"/booking/{bookingId}", Method.Patch);
            request.AddBody(body);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
            response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var _response = JsonConvert.DeserializeObject<BookingCreateModel>(response.Content);

            Assert.That(_response.firstname, Is.EqualTo(body.firstname));
            Assert.That(_response.lastname, Is.EqualTo(body.lastname));
            Assert.That(_response.totalprice, Is.EqualTo(body.totalprice));
            Assert.That(_response.depositpaid, Is.EqualTo(body.depositpaid));
            Assert.That(_response.bookingdates.checkin, Is.EqualTo(body.bookingdates.checkin));
            Assert.That(_response.bookingdates.checkout, Is.EqualTo(body.bookingdates.checkout));
            Assert.That(_response.additionalneeds, Is.EqualTo(body.additionalneeds));
        }

        [Test]
        public void PATCH_PartialUpdateBooking_InvalidData_Returns405MethodNotAllowed()
        {
            int nonExistentBookingId = 999999999;
            var body = new
            {
                  firstname = "James",
                  lastname = "Brown"
            };

            request = new RestRequest($"/booking/{nonExistentBookingId}", Method.Patch);
            request.AddBody(body);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
            response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
            Assert.That(response.Content, Is.EqualTo("Method Not Allowed"));
            
        }
    }
}
