﻿using ChimesPortal.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Core;

namespace ChimesPortal
{
    public class CustomApplicationEventHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}