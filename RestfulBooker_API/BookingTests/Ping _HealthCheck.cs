using RestSharp;
using System.Net;

namespace RestfulBooker_API.BookingTests
{
    [TestFixture]
    internal class Ping_HealthCheck : TestBase
    {
        [Test]
        public void GET_Ping_Response201_Created()
        {
            request = new RestRequest("/ping", Method.Get);
            response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Content, Is.EqualTo("Created"));
        }

        [Test]
        public void POST_Ping_404NotFound()
        {
            request = new RestRequest("/ping", Method.Post);
            response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(response.Content, Does.Contain("Not Found"));
        }
        
    }
}

