using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Apex.Web.Controllers
{
	[Authorize]
	[RoutePrefix("dashboard")]
    public class DashboardController : ApiController
    {
    }
}
