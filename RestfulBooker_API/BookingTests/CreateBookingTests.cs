using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestfulBooker_API.BookingTests
{
    [TestFixture]
    internal class CreateBookingTests : TestBase
    {
        [Test]
        public void POST_SuccessfulBookingCreation_Returns200ok()
        {
            var body = new BookingCreateModel
            {
                firstname = "Anna",
                lastname = "Braun",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new BookingDates
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            };
            request = new RestRequest("/booking", Method.Post);
            request.AddJsonBody(body);
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            base.response = client.Execute(request);
            Assert.That(base.response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            BookingModel? _response = JsonConvert.DeserializeObject<BookingModel>(response.Content);

            Assert.That(_response, Is.Not.Null, "Response should not be null");
            Assert.That(_response.booking.firstname, Is.EqualTo(body.firstname));
            Assert.That(_response.booking.lastname, Is.EqualTo(body.lastname));
            Assert.That(_response.booking.totalprice, Is.EqualTo(body.totalprice));
            Assert.That(_response.booking.depositpaid, Is.EqualTo(body.depositpaid));
            Assert.That(_response.booking.bookingdates.checkin, Is.EqualTo(body.bookingdates.checkin));
            Assert.That(_response.booking.bookingdates.checkout, Is.EqualTo(body.bookingdates.checkout));
            Assert.That(_response.booking.additionalneeds, Is.EqualTo(body.additionalneeds));
        }

        [Test]
        public void POST_MissingFirstname_Returns500InternalServerError()
        {
            var body = new
            {
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new BookingDates
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            };
            request = new RestRequest("/booking", Method.Post);
            request.AddJsonBody(body);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(response.Content, Is.Not.Empty, "Error response should contain a message");
        }



    }
}
