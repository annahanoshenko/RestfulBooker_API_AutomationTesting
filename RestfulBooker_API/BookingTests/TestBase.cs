using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulBooker_API.BookingTests
{
    internal class TestBase
    {
        public RestClient client;
        public RestRequest request;
        public RestResponse response;

        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://restful-booker.herokuapp.com");
        }

        [TearDown]
        public void Teardown()
        {
            client.Dispose();
        }
    }
}
