using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisplayBoardDataUpdate.Models.ViewModels
{
    public class portalUpdatesVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public HttpPostedFileBase ContentImage { get; set; }
    }
}