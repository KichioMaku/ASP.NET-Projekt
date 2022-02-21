using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.TagHelpers
{
       [HtmlTargetElement("alert")]
    public class AlertTagHelper : TagHelper
    {
        public string Color { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var className = "alert";
            if (Color == null)
            {
                className += " alert-primary";
            }
            else
            {
                className += $" alert-{Color}";
            }



            output.TagName = "div";
            output.Attributes.Add("class", className);
        }
    }
}
