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
        [TestInitialize]
        public void SetUp()
        {
          
        }
        [TestCleanup]
        public void TearDown()
        {
          
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            var server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            var response = new Mock<HttpResponseBase>(MockBehavior.Loose);

            var cookies = new HttpCookieCollection();

            response.Setup(r => r.Cookies).Returns(cookies);

            var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
            //request.Setup(r => r.UserHostAddress).Returns("127.0.0.1");
            request.Setup(r => r.Url).Returns(new Uri("https://localhost:44303/"));
            var formData = new NameValueCollection();
            formData.Add("AccessToken", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI3OGE2ZTMwMC1iMWUyLTQyNDgtYWU0Mi04M2ExOGRlNDdlMjQvbG9jYWxob3N0OjQ0MzAzQDI3MTA0MTMwLTgxY2QtNGFlYy1hOGM5LTNiYjYzZTBiYzk1NyIsImlzcyI6IjAwMDAwMDAxLTAwMDAtMDAwMC1jMDAwLTAwMDAwMDAwMDAwMEAyNzEwNDEzMC04MWNkLTRhZWMtYThjOS0zYmI2M2UwYmM5NTciLCJuYmYiOjE0MTQ0OTg3MDgsImV4cCI6MTQxNDU0MTkwOCwiYXBwY3R4c2VuZGVyIjoiMDAwMDAwMDMtMDAwMC0wZmYxLWNlMDAtMDAwMDAwMDAwMDAwQDI3MTA0MTMwLTgxY2QtNGFlYy1hOGM5LTNiYjYzZTBiYzk1NyIsImFwcGN0eCI6IntcIkNhY2hlS2V5XCI6XCJKZU10WnRPN3hQSUpaQVpKR2JBZ2lFcWt4eEhJSkVXbThhR0I4ZDRUZXZVPVwiLFwiU2VjdXJpdHlUb2tlblNlcnZpY2VVcmlcIjpcImh0dHBzOi8vYWNjb3VudHMuYWNjZXNzY29udHJvbC53aW5kb3dzLm5ldC90b2tlbnMvT0F1dGgvMlwifSIsInJlZnJlc2h0b2tlbiI6IklBQUFBTGZzTnRLcTNZcmZCMEJJR3BIZDRUNmwtc1RrN3hCT3hXdTI2M3YzS2pCenZ3MmcwUGNpYnBUZ0RVVWFncU1lczh2SzY4S28tcWNSS0ZqSTMtQWZ4aUFCNmMxS1hMSHF2MEt5WDhtQ0M4ck1ENllsbkl5TDlQdUpoeUpmUTY4UUdJT0IxSnc4cExoWkU0bDVGeDJOV2FmdVdySEt4RkhFVDZnYmpUdE9taVlwbDdsVFBaSHM1NFpnZHVpQ0NDZ04zcC1tVU9KbWhjeEJpRG9pUVJWdWRxcHVfdmJEYU5UTHNFVWpJNUhITVNpdTNFUE5GdTRlaTF0QjczS1FyeXlXRmtmMkh6TXZueWtleUJuU3U2dVlOekFxVHV4N2thb1dDeVp4b09RMGxjRHRfTGtIT0tfWXRpV0Jqd2ttTUV0cElxUVNvTGtjUE1HOHdvakRkS2gtd3dBIiwiaXNicm93c2VyaG9zdGVkYXBwIjoidHJ1ZSJ9.Bm4s4LuPesyqW8icaIwpJxjh8IFlBtzVUTn1Wck28vg");
            //formData.Add("AccessToken", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6ImtyaU1QZG1Cdng2OHNrVDgtbVBBQjNCc2VlQSJ9.eyJhdWQiOiIwMDAwMDAwMy0wMDAwLTBmZjEtY2UwMC0wMDAwMDAwMDAwMDAvY2FuZGMzNjUuc2hhcmVwb2ludC5jb21AMjcxMDQxMzAtODFjZC00YWVjLWE4YzktM2JiNjNlMGJjOTU3IiwiaXNzIjoiMDAwMDAwMDEtMDAwMC0wMDAwLWMwMDAtMDAwMDAwMDAwMDAwQDI3MTA0MTMwLTgxY2QtNGFlYy1hOGM5LTNiYjYzZTBiYzk1NyIsIm5iZiI6MTQxNDUwMjc4OCwiZXhwIjoxNDE0NTQ1OTg4LCJuYW1laWQiOiIxMDAzMDAwMDg5NjQzNDU3IiwiYWN0b3IiOiI3OGE2ZTMwMC1iMWUyLTQyNDgtYWU0Mi04M2ExOGRlNDdlMjRAMjcxMDQxMzAtODFjZC00YWVjLWE4YzktM2JiNjNlMGJjOTU3IiwiaWRlbnRpdHlwcm92aWRlciI6InVybjpmZWRlcmF0aW9uOm1pY3Jvc29mdG9ubGluZSJ9.LhFSffpSXV9fnQgNQLCwfS3UI98EvgltAvfN4Wc4Edyj9kBgpBvnpnca_ufvLph6lHHyA6tN6oyYYwcess0VUtiZ_wkcSYMrr4QZbSLaWO-DF9cPiE1cGgOnlbFRr0wqRw3zfube9-LEiLBzdWThwtOHx_H0o834Egducl32tfBppe8RUh8lfLddu9ufZFQcKoL985Gz8Tx2lATABm1-N4VZ7LsMHjYlJ9OrsoS1pb4eH54nYzFlbHo7xRur5uggd-nYBCxX_WiI4MYCd_viCFZe6451lM2iu95l9rgzx-0Q6vrpUthaG0-kQ2sUK0rIJraGPlX14l_OHMYkunmNLg");
            request.Setup(r => r.Form).Returns(formData);
            
            var qs = new NameValueCollection();
            qs.Add("SPHostUrl", "https://candc365.sharepoint.com/sites/dev");
            qs.Add("SPLanguage", "en-US");
            qs.Add("SPClientTag", "0");
            qs.Add("SPProductNumber", "16.0.3403.1216");

            request.Setup(r => r.QueryString).Returns(qs);

            var session = new Mock<HttpSessionStateBase>();
            session.Setup(s => s.SessionID).Returns(Guid.NewGuid().ToString());

           // var spContext = 
            //session.Setup(s => s["SPContext"]).Returns(spContext);

            var context = new Mock<HttpContextBase>();
            context.SetupGet(c => c.Request).Returns(request.Object);
            context.SetupGet(c => c.Response).Returns(response.Object);
            context.SetupGet(c => c.Server).Returns(server.Object);
            context.SetupGet(c => c.Session).Returns(session.Object);

            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
           // Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
