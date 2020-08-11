using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Linq;
using System.Web;

namespace ProdTracking.Website.Hubs
{
    public class HubCallerContext
    {
        /// <summary>
        /// Gets the connection id of the calling client.
        /// </summary>
        public string ConnectionId { get; private set; }

        /// <summary>
        /// Gets the cookies for the request.
        /// </summary>
        public IDictionary<string, Cookie> RequestCookies
        {
            get
            {
                return Request.Cookies;
            }
        }

        /// <summary>
        /// Gets the headers for the request.
        /// </summary>
       

        /// <summary>
        /// Gets the <see cref="IPrincipal"/> for the request.
        /// </summary>
        public IPrincipal User
        {
            get
            {
                return Request.User;
            }
        }

        /// <summary>
        /// Gets the <see cref="IRequest"/> for the current HTTP request.
        /// </summary>
        public IRequest Request { get; private set; }

        public HubCallerContext(IRequest request, string connectionId)
        {
            ConnectionId = connectionId;
            Request = request;
        }
    }
}