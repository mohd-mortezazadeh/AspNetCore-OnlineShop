using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filters
{
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor actionDescriptor)
        {
            if (routeContext.HttpContext.Request.Headers != null &&
              routeContext.HttpContext.Request.Headers.ContainsKey("X-Requested-With") &&
              routeContext.HttpContext.Request.Headers.TryGetValue("X-Requested-With", out StringValues requestedWithHeader))
            {
                if (requestedWithHeader.Contains("XMLHttpRequest"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
