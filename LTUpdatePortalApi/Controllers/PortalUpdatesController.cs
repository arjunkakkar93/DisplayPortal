
using LTUpdatePortalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using System.Web.Script.Services;


namespace LTUpdatePortalApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PortalUpdatesController : ApiController
    {
        private LTUpdatesEntities dataContext;

        public PortalUpdatesController()
        {
            dataContext = new LTUpdatesEntities();

        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [ActionName("GeneralUpdates")]
        
        public IQueryable<PortalUpdate> GetPortalUpdate()
        {
            var result = dataContext.PortalUpdates.ToList();
            return result.AsQueryable<PortalUpdate>();
        }



    }
}