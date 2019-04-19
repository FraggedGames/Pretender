using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pretender.Server.Pages
{
    public class RoutesModel : PageModel
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public RoutesModel(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public List<RouteInfo> Routes { get; set; }

        public void OnGet()
        {
            Routes = _actionDescriptorCollectionProvider.ActionDescriptors.Items
                    .Select(x => new RouteInfo
                    {
                        Action = x.RouteValues["Action"],
                        Controller = x.RouteValues["Controller"],
                        Name = x.AttributeRouteInfo.Name,
                        Template = x.AttributeRouteInfo.Template,
                        Constraint = x.ActionConstraints == null ? "" : JsonConvert.SerializeObject(x.ActionConstraints)
                    })
                .OrderBy(r => r.Template)
                .ToList();
        }

        public class RouteInfo
        {
            public String Template { get; set; }
            public String Name { get; set; }
            public String Controller { get; set; }
            public String Action { get; set; }
            public String Constraint { get; set; }
        }
    }
}