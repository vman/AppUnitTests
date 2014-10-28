using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SPAppMVCTestWeb.Controllers;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SPAppMVCTest.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        Mock<HttpServerUtilityBase> server;
        Mock<HttpResponseBase> response;
        Mock<HttpRequestBase> request;
        Mock<HttpSessionStateBase> session;
        Mock<HttpContextBase> context;

        NameValueCollection formData, queryString;

        string remoteSiteUrl = "https://localhost:44303/";
        string hostWebUrl = "https://vrdman.sharepoint.com/sites/dev";

        string contextToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI1MDcwZjY4NC1iZjZiLTQ2N2UtYTg0My1iZjVjMmU0YTNhNTgvbG9jYWxob3N0OjQ0MzAzQDI3MTA0MTMwLTgxY2QtNGFlYy1hOGM5LTNiYjYzZTBiYzk1NyIsImlzcyI6IjAwMDAwMDAxLTAwMDAtMDAwMC1jMDAwLTAwMDAwMDAwMDAwMEAyNzEwNDEzMC04MWNkLTRhZWMtYThjOS0zYmI2M2UwYmM5NTciLCJuYmYiOjE0MTQ1MjM1ODIsImV4cCI6MTQxNDU2Njc4MiwiYXBwY3R4c2VuZGVyIjoiMDAwMDAwMDMtMDAwMC0wZmYxLWNlMDAtMDAwMDAwMDAwMDAwQDI3MTA0MTMwLTgxY2QtNGFlYy1hOGM5LTNiYjYzZTBiYzk1NyIsImFwcGN0eCI6IntcIkNhY2hlS2V5XCI6XCJ2cDlibThBR2Y1KzB3V3JsU3FkaWY5c0RGYzV3ZHV4ODZpN3B0L0VUdlR3PVwiLFwiU2VjdXJpdHlUb2tlblNlcnZpY2VVcmlcIjpcImh0dHBzOi8vYWNjb3VudHMuYWNjZXNzY29udHJvbC53aW5kb3dzLm5ldC90b2tlbnMvT0F1dGgvMlwifSIsInJlZnJlc2h0b2tlbiI6IklBQUFBS3lHYzdnWE1oUV80cDhmd0FFd0xBbENmQ2g0OTNKSUktQjNTYXdhcVNsaW11UWx6SEgxSWdMT3l3VVpSZV8xRzhzVGNPZEk2S2o3M3J2YmhqVi1zNmpVUDBkV0tYZ1kwQ2pDQ0RveVRfNGlYcXI0V3NTSkFuQVlqWGRLekExd0Z2dmx2MU0yUU5hMFZZSmxxbGJJaTg4bmxVeEJycjN3aEpsaXRhRm9zaHF5VmQ5T2lNVDBxeDdZakRuTDg2Q3g2NlRYY0JTalB0SnNJbVNyWVNSQTJraGNpUXhrV1VyVW1qNHp3Y05waFlMODJDOWNNdmVqTEtwUmFTMFI4YmNZdDV1amVfQ2ZyaGFyVmdJb2xPb3dTRXZJeWtoVHJ2Z0RkNlNIMVZwazJDU2ZfdFVOc09PMUxRRjB4LXpDZm44MVN3IiwiaXNicm93c2VyaG9zdGVkYXBwIjoidHJ1ZSJ9.nbWAtuf7e8-5CWTwWpsxWu7aGxbhXCBEH-il0rfb0xI";
        
        [TestInitialize]
        public void SetUp()
        {
            server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            
            response = new Mock<HttpResponseBase>(MockBehavior.Default);

            request = new Mock<HttpRequestBase>(MockBehavior.Strict);

            request.Setup(r => r.Url).Returns(new Uri(remoteSiteUrl));
            
            formData = new NameValueCollection();

            formData.Add("SPAppToken", contextToken);
            
            request.Setup(r => r.Form).Returns(formData);

            queryString = new NameValueCollection();
            queryString.Add("SPHostUrl", hostWebUrl);
            queryString.Add("SPLanguage", "en-US");
            queryString.Add("SPClientTag", "0");
            queryString.Add("SPProductNumber", "16.0.3403.1219");

            request.Setup(r => r.QueryString).Returns(queryString);

            session = new Mock<HttpSessionStateBase>();

            context = new Mock<HttpContextBase>();
            
            context.SetupGet(c => c.Request).Returns(request.Object);
            context.SetupGet(c => c.Response).Returns(response.Object);
            context.SetupGet(c => c.Server).Returns(server.Object);
            context.SetupGet(c => c.Session).Returns(session.Object);

        }

        [TestCleanup]
        public void TearDown()
        {
          
        }

        [TestMethod]
        public void GetHostWebTitle()
        {
            // Arrange
            HomeController controller = new HomeController();
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);

            // Act
            string result = controller.GetHostWebTitle();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Developer Site", result);
        }

        [TestMethod]
        public void GetCurrentUserTitle()
        {
            // Arrange
            HomeController controller = new HomeController();
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);

            // Act
            string result = controller.GetCurrentUserTitle();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Vardhaman Deshpande", result);
        }

        
    }
}
