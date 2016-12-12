using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace eBlast_mvc.Common
{
    public class ebCommon
    {
        public static string GetReleaseType()
        {
            return WebConfigurationManager.AppSettings["ReleaseType"];

        }
    }
}