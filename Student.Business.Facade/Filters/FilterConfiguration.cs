using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace Student.Business.Facade.Filters
{
    public class FilterConfiguration
    {
        public static List<ExceptionFilterAttribute> Filters()
        {
            var filters = new List<ExceptionFilterAttribute>();
            filters.Add(new DatabaseFilter());
            filters.Add(new BusinessFilter());
            return filters;
        }
    }
}