
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
    public class FetchUpdatesController : ApiController
    {
        private LTUpdatesEntities dataContext;
                
        public FetchUpdatesController()
        {
            dataContext = new LTUpdatesEntities();
            
        }
        
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        [ActionName("AllLTUpdates")]
        public IQueryable<LT_Updates> GetLTUpdates()
        {
            var result = dataContext.LT_Updates.ToList();

            return result.AsQueryable<LT_Updates>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [ActionName("LTUpdate")]
        public LT_Updates GetLTUpdateById(int id)
        {
            return dataContext.LT_Updates.Find(id);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [ActionName("AllUpdates")]
        public IQueryable<Update> GetUpdates()
        {
            var result = dataContext.Updates.ToList();
            return result.AsQueryable<Update>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [ActionName("Update")]
        public Update GetUpdateById(int id)
        {
            return dataContext.Updates.Find(id);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [ActionName("AllPDRMUpdates")]
        public IQueryable<PDRM_Updates> GetPDRMUpdates()
        {
            var result = dataContext.PDRM_Updates.ToList();
            return result.AsQueryable<PDRM_Updates>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [ActionName("PDRMUpdate")]
        public PDRM_Updates GetPDRMUpdateById(int id)
        {
            return dataContext.PDRM_Updates.Find(id);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [ActionName("AllFlashUpdates")]
        public IQueryable<Flash_Updates> GetFLashUpdates()
        {
            var result = dataContext.Flash_Updates.ToList();
            return result.AsQueryable<Flash_Updates>();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [ActionName("FlashUpdate")]
        public Flash_Updates GetFlashUpdateById(int id)
        {
            return dataContext.Flash_Updates.Find(id);
        }

        
    }
}