// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE in the project root for license information.
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OutlookPayments
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Override default JSON serialization settings
            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            // Omit null values
            formatter.SerializerSettings.NullValueHandling = 
                Newtonsoft.Json.NullValueHandling.Ignore;

            // Use camelCase
            formatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
        }
    }
}
