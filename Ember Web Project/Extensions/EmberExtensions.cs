using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace System.Web.Mvc.Html
{
    public static class EmberExtensions
    {
        /// <summary>
        /// Wraps a partial view in a script tag for use by Ember.js as view template.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="viewName"></param>
        /// <returns>
        /// Returns the partial view wrapped in a script like:
        /// &lt;script type="text/x-handlebars" data-template-name="header"&gt;
        ///  ... (partial view's contents) ...
        /// &lt;/script&gt;
        /// </returns>
        public static MvcHtmlString EmberTemplate(this HtmlHelper htmlHelper, string viewName)
        {
                var innerHtml = htmlHelper.Partial("Templates/" + viewName);
                var wrapperTag = new TagBuilder("script");
                wrapperTag.MergeAttributes(
                        new Dictionary<string, string>
                            {
                                { "type", "text/x-handlebars" },
                                { "data-template-name", viewName.ToCamelCase() }
                            }
                        );
                
                using(var writer = new StringWriter())
                {
                    writer.Write(wrapperTag.ToString(TagRenderMode.StartTag));
                    writer.Write(Environment.NewLine);
                    writer.Write(innerHtml);
                    writer.Write(Environment.NewLine);
                    writer.Write(wrapperTag.ToString(TagRenderMode.EndTag));
                    return new MvcHtmlString(writer.ToString());
                }
        }

        /// <summary>
        /// Returns the string with the first letter made lowercase.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String ToCamelCase(this String str)
        {
            var chars = str.ToCharArray();
            chars[0] = Char.ToLower(chars[0], CultureInfo.CurrentCulture);
            return new String(chars);
        }
    }
}