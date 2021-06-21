using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Helper
{
    public class CustomEmailTagHelper : TagHelper
    {
        public string Email { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //corresponding to which tagname you want to create the custom tag
            output.TagName = "a";
            //set value to an attribute
            output.Attributes.SetAttribute("href", $"mailto:{Email}");
            //set value to an attribute
            output.Attributes.Add("id", "my-email");
            //set default content to your custom attribute
            output.Content.SetContent("Mail Us");
        }
    }
}
