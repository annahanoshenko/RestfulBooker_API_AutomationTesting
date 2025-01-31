using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace RestfulBooker_API.BookingTests
{
    [TestFixture]
    internal class GetBookingIds : TestBase
    {
        [Test]
        public void GET_AllBookingIds_Returns200ok()
        {
            request = new RestRequest("/booking", Method.Get);
            request.AddHeader("Accept", "application/json");

            response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Empty);   

            var bookingId = JsonConvert.DeserializeObject<List<BookingModel>>(response.Content);
            Assert.That(bookingId, Is.Not.Empty);
        }
        [Test]
        public void GET_SpecificBookingId_Return200OK()
        {
            int bookingId = 2435;

            request = new RestRequest($"/booking/{bookingId}", Method.Get);
            request.AddHeader("Accept", "application/json");

            response = client.Execute(request);
            
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var booking = JsonConvert.DeserializeObject<BookingCreateModel>(response.Content);

            BookingCreateModel? booking_Id = booking;
            Assert.That(booking_Id.firstname, Is.EqualTo("Anna"));
            Assert.That(booking_Id.lastname, Is.EqualTo("Braun"));
            Assert.That(booking_Id.totalprice, Is.EqualTo(111));
            Assert.That(booking_Id.depositpaid, Is.EqualTo(true));
            Assert.That(booking_Id.bookingdates.checkin, Is.EqualTo("2018-01-01"));
            Assert.That(booking_Id.bookingdates.checkout, Is.EqualTo("2019-01-01"));
            Assert.That(booking_Id.additionalneeds, Is.EqualTo("Breakfast"));
        }

        [Test]
        public void GET_InvalidEndpoint_Returns404NotFound()
        {
            request = new RestRequest("/invalid-endpoint", Method.Get);
            request.AddHeader("Accept", "application/json");

            response = client.Execute(request);
           
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(response.Content, Contains.Substring("Not Found"));
        }

        [Test]
        public void GET_InvalidBookingID_Returns404NotFound()
        {
            int invalidBookingId = 9999999;

            request = new RestRequest($"/booking/{invalidBookingId}", Method.Get);
            request.AddHeader("Accept", "application/json");

            response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(response.Content, Contains.Substring("Not Found"));
        }
    }
}
