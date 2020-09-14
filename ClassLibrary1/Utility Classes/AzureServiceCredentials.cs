using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHG.Plugins.DeveloperTest
{
    public class AzureServiceCredentials
    {

        public string AzureService ()
        {     
                string codekey = "123W1gzjHaQkJ7Xid19fRPaLCBSxbS0/107645AscDbJ5STVvrz3mjh4A==";
                string serviceUrl = "https://mycrmtestfunapp.azurewebsites.net/api/CRM_Contact_Information?code=" + codekey;
                
                return serviceUrl;

        }

    }
}
