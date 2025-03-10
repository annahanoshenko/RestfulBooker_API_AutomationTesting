# RestfulBooker_API_AutomationTesting

Restful Booker API Testing

This repository contains automated test cases for the Restful Booker API, an API that allows users to create, update, retrieve, and delete hotel bookings. The tests are written in C# using the NUnit testing framework and utilize RestSharp for making HTTP requests to interact with the API.

I created drag-and-drop positive and negative test cases to test the Recycling, Deleting, Zooming, and Closing of images. 
For zooming, I created an array ImageWidget[] imageWidgets, and, using Dictionary<string, string>, I can work with different manipulations on a specific image.

**Features

Test Scenarios: -Create Booking (POST): Verifying the correct creation of a new booking with the required parameters. -Update Booking (PUT): Ensuring bookings can be updated successfully. -Partial Update (PATCH): Testing partial updates to booking data and validating responses. -Delete Booking (DELETE): Testing deletion of bookings, including scenarios for non-existent bookings. -Health Check (GET /ping): Verifying the API’s availability with a simple ping request.

**Tested Error Handling: Validation of different HTTP response codes such as 200 OK, 400 Bad Request, 404 Not Found, Method Not Allowed, etc. Ensuring the API responds with appropriate error messages for invalid or incomplete requests.

**Authorization: All requests include proper authorization using Basic Authentication and Cookie Tokens as necessary.

**Technologies: -C# for the test scripts. -RestSharp for sending HTTP requests. -NUnit for running automated tests. -Newtonsoft.Json (Json.NET) is used to parse and validate JSON responses.

**Usage: 1.Clone the Repository: To clone the repository to your local machine:

git clone <repository_url> cd <repository_folder>

2.Set up the Environment: Ensure you have Visual Studio or any compatible C# IDE installed.

3.Install the NUnit and RestSharp NuGet packages. You can do this through the NuGet Package Manager or by using the NuGet CLI:

-Install-Package NUnit -Install-Package RestSharp -Install-Package Newtonsoft.Json

4.Running the Tests: -Open the solution in your IDE. -Make sure that NUnit is configured as the test runner. -Build the solution and run the tests using the built-in test explorer.

Alternatively, you can run the tests from the command line using the dotnet test command: dotnet test

**For NUnit Console Runner: First, install NUnit Console Runner:

dotnet tool install --global NUnit.ConsoleRunner Run the tests and generate a report:

nunit3-console --result=TestResult.xml <path_to_test_assembly>.dll

Convert the result to an HTML report using ReportUnit:

report unit TestResult.xml TestResult.html

After running the tests, you will find the results in the generated report files, which you can review for any failed tests or issues.
