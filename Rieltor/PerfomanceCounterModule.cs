using System;
using System.Diagnostics;
using System.Web;
using Rieltor.Models;
using System.Web.UI;
using System.Collections.Generic;

namespace Rieltor
{
    public class PerfomanceCounterModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
      
        public void Dispose()
        {
            //clean-up code here.
        }

       
        public CounterViews counter = new CounterViews();
        public void Init(HttpApplication context)
        { 
            context.EndRequest += HandleEndRequest;
        }

        private void HandleEndRequest(object src, EventArgs args)
        {
            var request = HttpContext.Current.Request;
            var link =request.QueryString["slug"];
            
            if (!string.IsNullOrEmpty(link)) 
            {
                Views view = new Views {ViewsId = Guid.NewGuid().ToString(), IpAddress = request.UserHostAddress, VisitData = DateTime.Now };
               
                counter.AddCount(view, link);
            }
           
        }
    }
}
