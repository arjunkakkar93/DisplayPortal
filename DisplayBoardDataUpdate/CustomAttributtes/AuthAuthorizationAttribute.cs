using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DisplayBoardDataUpdate.CustomAttributtes
{
    public class AuthAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public bool Authorized { get; set; }
        void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
        {
            
            string userName = HttpContext.Current.User.Identity.Name;
            string[] userArray = userName.Split('\\');

            DirectoryEntry entry = new DirectoryEntry("GC://corp.microsoft.com");
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            mySearcher.Filter = "(&(objectClass=user)(SAMAccountName=" + userArray[1] + "))";
            mySearcher.PropertiesToLoad.Add("cn");
            mySearcher.PropertiesToLoad.Add("memberof");
            //mySearcher.Filter = "(&(objectClass=user)(anr=test*))";                    
            SearchResultCollection result = mySearcher.FindAll();
            StringBuilder groupsList = new StringBuilder();
            if (result != null)
            {
                var groupCount = result[0].Properties["memberOf"].Count;

                for (int counter = 0; counter < groupCount; counter++)
                {
                    groupsList.Append((string)result[0].Properties["memberOf"][counter]);
                    groupsList.Append("|");
                }
            }
            string groups = groupsList.ToString();

            if (groups.Contains("DBUG"))
            {
                Authorized = true;
            }
            else
            {
                filterContext.Result = new ViewResult { ViewName = "Error" };
            }
        }
    }
}