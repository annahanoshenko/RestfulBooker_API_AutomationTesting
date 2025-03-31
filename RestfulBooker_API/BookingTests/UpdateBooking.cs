
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace RestfulBooker_API.BookingTests
{
    [TestFixture]
    internal class UpdateBooking : TestBase
    {
        [Test]
        public void PUT_UpdateBooking_Returns200OK()
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

            request = new RestRequest($"/booking/{bookingId}", Method.Put);
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
        public void PUT_UpdateBooking_MissingLastName_Returns400BadRequest()
        {
            int bookingId = 1;
            var body = new
            {
                firstname = "James",
            };

            request = new RestRequest($"/booking/{bookingId}", Method.Put);
            request.AddBody(body);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
            response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
         
            Assert.That(response.Content, Is.EqualTo("Bad Request"));

        }
    }
}
