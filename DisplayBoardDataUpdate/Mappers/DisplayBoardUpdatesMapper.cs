using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DisplayBoardDataUpdate.Models;
using DisplayBoardDataUpdate.Models.ViewModels;

namespace DisplayBoardDataUpdate.Mappers
{
    public class DisplayBoardUpdatesMapper
    {
        
        public static LT_Updates ltUpdateMapper(ltUpdatesVM ltupdatevm)
        {
            LT_Updates ltupdate = new LT_Updates { 
             Title=ltupdatevm.Title,
             Description=ltupdatevm.Description,
             ID=ltupdatevm.ID,
             Content_URL=ltupdatevm.Content_URL.FileName,
             CreatedBy=ltupdatevm.CreatedBy
            };

            return ltupdate;
        }

        public static PDRM_Updates pdrmUpdateMapper(PdrmUpdatesVM pdrmupdatevm)
        {
            PDRM_Updates pdrmupdate = new PDRM_Updates
            {
                Title = pdrmupdatevm.Title,
                Description = pdrmupdatevm.Description.FileName,
                ID = pdrmupdatevm.ID,
                CreatedBy = pdrmupdatevm.CreatedBy
            };

            return pdrmupdate;
        }

        public static Update updateMapper(updatesVM updatevm)
        {
           Update update = new Update
            {
                Title = updatevm.Title,
                Description = updatevm.Description.FileName,
                UpdateID = updatevm.UpdateID,
                CreatedBy = updatevm.CreatedBy
            };

            return update;
        }

        public static PortalUpdate portalUpdateMapper(portalUpdatesVM portalupdatevm)
        {
            PortalUpdate portalUpdate = new PortalUpdate
            {
                Title = portalupdatevm.Title,
                Description = portalupdatevm.Description,
                ID = portalupdatevm.ID,
                CreatedBy = portalupdatevm.CreatedBy,
                ContentImage = portalupdatevm.ContentImage.FileName
            };

            return portalUpdate;
        }


    }
}