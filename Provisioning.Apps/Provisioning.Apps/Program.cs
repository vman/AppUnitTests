using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Provisioning.Apps
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ClientContext clientContext = new ClientContext("https://vrdmn.sharepoint.com/sites/pub"))
            {
                SecureString passWord = new SecureString();

                foreach (char c in "yourpassword".ToCharArray()) passWord.AppendChar(c);

                clientContext.Credentials = new SharePointOnlineCredentials("vrd@vrdmn.onmicrosoft.com", passWord);

                var isSideLoadingEnabled = AppCatalog.IsAppSideloadingEnabled(clientContext);

                clientContext.ExecuteQuery();

                Web web = clientContext.Web;

                //clientContext.Site.Features.Add(new Guid("AE3A1339-61F5-4f8f-81A7-ABD2DA956A7D"), false, FeatureDefinitionScope.None);
                
                //clientContext.ExecuteQuery();

                Stream package = System.IO.File.OpenRead(@"C:\MySampleApp.app");
                
                AppInstance appInstance = web.LoadAndInstallApp(package);

                clientContext.ExecuteQuery();
                
                clientContext.Site.Features.Remove(new Guid("AE3A1339-61F5-4f8f-81A7-ABD2DA956A7D"), false);

                clientContext.ExecuteQuery();

                Console.WriteLine("Done");

                Console.ReadKey();
            }
        }
    }
}
