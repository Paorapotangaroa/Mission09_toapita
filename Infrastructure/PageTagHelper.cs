using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission09_toapita.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "link-maker")]
    public class PageTagHelper : TagHelper
    {
        // get access to the IUrlHelperFactory
        public PageTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        private IUrlHelperFactory uhf;

        //Create ViewContext
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }
        //Get access to the PageDetails Class
        public PageDetails LinkMaker {get;set;}

        //Following along with Bootstrap section
        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Create a url helper
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            //Create the finished tag
            TagBuilder finishedProduct = new TagBuilder("div");

            for(int i = 0; i < LinkMaker.TotalPages; i++)
            {
                //Create a tags
                TagBuilder tagBuilder = new TagBuilder("a");
                //Set their attribute
                tagBuilder.Attributes["href"] = uh.Action(PageAction, new { pageNum = i + 1 });
                //Toggling colors
                if (PageClassesEnabled)
                {
                    tagBuilder.AddCssClass(PageClass);
                    tagBuilder.AddCssClass(i+1 == LinkMaker.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
                //Add the number as the text on screen
                tagBuilder.InnerHtml.Append((i+1).ToString());
                //Add the finished tag to the html of the final product
                finishedProduct.InnerHtml.AppendHtml(tagBuilder);
            }

            //Set the output's innerhtml to the finished product's inner htmld
            output.Content.AppendHtml(finishedProduct.InnerHtml);
        }
    }
}
