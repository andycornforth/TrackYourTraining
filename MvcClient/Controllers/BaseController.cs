using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingApi.Wrapper;

namespace MvcClient.Controllers
{
    public class BaseController : Controller
    {
        protected IApiWrapper apiLibrary;

        public BaseController()
        {
            var url = "http://localhost:31687/";
            this.apiLibrary = new ApiWrapper(url);
        }
    }
}