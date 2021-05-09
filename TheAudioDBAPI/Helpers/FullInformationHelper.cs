using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TheAudioDBAPI.Helpers
{
    public static class FullInformationHelper
    {
        public static MvcHtmlString Full(this HtmlHelper htmlHelper, string partialview)
        {            

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(htmlHelper.Partial(partialview));            

            return new MvcHtmlString(stringBuilder.ToString());
        }

    }
}