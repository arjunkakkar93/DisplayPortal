using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisplayBoardDataUpdate.Models.ViewModels
{
    public class PdrmUpdatesVM
    {
        public int ID { get; set; }
        public HttpPostedFileBase Description { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
    }
}