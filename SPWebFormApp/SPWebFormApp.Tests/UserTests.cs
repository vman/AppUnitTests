using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SPWebFormAppWeb;
using System.Web;
using System.Net;

namespace SPWebFormApp.Tests
{
    [TestClass]
    public class UserTests
    {
        private string spHostUrl = "https://vrdman.sharepoint.com/";
        string requestUrl;

        [TestInitialize()]
        public void Initialize()
        {
            requestUrl = SPWebFormApp.Tests.TokenHelper.GetAppContextTokenRequestUrl(spHostUrl, spHostUrl);
        }

        [TestCleanup()]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void GetTitleTest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }
    }
}
