using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace NHG.Plugins.DeveloperTest
{
 
    public class UpdateContactExternal : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            #region Retrieve the execution context, organization service proxy and tracing service
           IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
           IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
           IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
           ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            #endregion

            #region Return Calling Entity from context.InputParameters


            #endregion

            // example XML
            //<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
            //      <entity name='account'>
            //        <attribute name='name' />
            //        <attribute name='accountid' />
            //        <order attribute='name' descending='false' />
            //        <filter type='and'>
            //          <condition attribute='name' operator='eq' value='Camden Council' />
            //        </filter>
            //      </entity>
            //    </fetch>
        }
    }
}
