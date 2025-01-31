using RestSharp;
using System.Net;

namespace RestfulBooker_API.BookingTests
{
    [TestFixture]
    internal class DeleteBooking : TestBase
    {
        [Test]
        public void DELETE_Booking_Returns200OK()
        {
            int bookingId = 3;
            request = new RestRequest($"/booking/{bookingId}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");
            
            response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Content, Is.EqualTo("Created"));
        }

        [Test]
        public void DELETE_NonExistentBooking_Returns405MethodNotAllowed()
        {
            int nonExistetntBookingId = 999999999;
            request = new RestRequest($"/booking/{nonExistetntBookingId}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");

            response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
            Assert.That(response.Content, Is.EqualTo("Method Not Allowed"));
        }

    }
}
