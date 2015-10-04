using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DisplayBoardDataUpdate.Models;

namespace DisplayBoardDataUpdate.Mappers
{
    public class LTUpdatesMapper
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


    }
}