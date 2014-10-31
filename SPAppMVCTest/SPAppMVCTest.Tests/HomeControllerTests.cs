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

        string contextToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI0Mzc5ZTM1MC01NTQ2LTRhNWMtYjVhYy1iNDcyZjM5ZWE3MzYvbG9jYWxob3N0OjQ0MzAzQDI3MTA0MTMwLTgxY2QtNGFlYy1hOGM5LTNiYjYzZTBiYzk1NyIsImlzcyI6IjAwMDAwMDAxLTAwMDAtMDAwMC1jMDAwLTAwMDAwMDAwMDAwMEAyNzEwNDEzMC04MWNkLTRhZWMtYThjOS0zYmI2M2UwYmM5NTciLCJuYmYiOjE0MTQ3NjQ2MjIsImV4cCI6MTQxNDgwNzgyMiwiYXBwY3R4c2VuZGVyIjoiMDAwMDAwMDMtMDAwMC0wZmYxLWNlMDAtMDAwMDAwMDAwMDAwQDI3MTA0MTMwLTgxY2QtNGFlYy1hOGM5LTNiYjYzZTBiYzk1NyIsImFwcGN0eCI6IntcIkNhY2hlS2V5XCI6XCJhNWZhTVJnMGZKRTQzS2hRZ0JHZktmRkpDQTM5RmVlczU3b0l2U3pLZGF3PVwiLFwiU2VjdXJpdHlUb2tlblNlcnZpY2VVcmlcIjpcImh0dHBzOi8vYWNjb3VudHMuYWNjZXNzY29udHJvbC53aW5kb3dzLm5ldC90b2tlbnMvT0F1dGgvMlwifSIsInJlZnJlc2h0b2tlbiI6IklBQUFBT1N0cFlHUEVvZlF6V0N0c3RSSHJxQzBOWVNmU2RtMUZTYTZpdVZMdzFjd01oaUlJV256WHFkSzBXQUxEZUhVTGtoQW1pTFlKRkxFNVVUdlhhUHFVVG5MVHZpekVyRVpBMlJUNWxHWDhQSkhQODlzN0JxOGVGbHVZbmg4d0ZKZ3J1Rnl3QW12am8yaERWS21QQ3Z0cU14WWdEcGIxYnVMWU5MSmpoWWRDdUxpck83cU5kdl95aS1RUENmcm9yVjhULVNvODNyb25LM0xvXzhlMnc0cC1kQUd0MVNCemlrZGhSV253a2JhSjlHTVNSLUxQRkdYLXZxRC1Sd0Njdmd3ZGZKRGN3YlA3bDZyQnlEWFk1TmRTc3o4YmtZNHNia2V4QTgwU09OT2dPY2o0WTRyNFJyZEEwTHhHa09mRWYzcmllU1UxMzE3eVpSSmtzQmVrSmVPdkdVIiwiaXNicm93c2VyaG9zdGVkYXBwIjoidHJ1ZSJ9.vUGwFeabL0kx9D9-kZW-7PGASdcwjd6NBQI00IOLUnY";


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

        [TestMethod]
        public void GetAppOnlyCurrentUserTitle()
        {
            // Arrange
            HomeController controller = new HomeController();
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);

            // Act
            string result = controller.GetAppOnlyCurrentUserTitle();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("SharePoint App", result);
        }
    }
}
