using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AlloyTraining.Business.ExtensionMethods
{
    public static class ContentRecommendationExtensions
    {
        public static IHtmlString OpenGraphMetaTags(
            this HtmlHelper html,
            ContentReference contentLink = null)
        {
            UrlResolver urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            IContentLoader contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            RequestContext requestContext = html.ViewContext.RequestContext;
            if (contentLink == null) contentLink = requestContext.GetContentLink();

            if (contentLoader.TryGet<PageData>(contentLink, out PageData pageData))
            {
                // in Alloy it should find MetaTitle first
                string title = pageData.GetFirstMatchingProperty(
                    new[] { "OgTitle", "MetaTitle", "PageName" });

                // in Alloy it won't find any of these
                string type = pageData.GetFirstMatchingProperty(
                    new[] { "OgType", "MetaPageType" });

                // in Alloy it should find PageImage and use it if set
                string imageRef = pageData.GetFirstMatchingProperty(
                    new[] { "OgImage", "PageImage", "Image" });

                string image = urlResolver.GetUrl(ContentReference.Parse(imageRef));

                string url = urlResolver.GetUrl(contentLink);

                string titleTag = $"<meta property=\"og:title\" content=\"{title}\" />";
                string typeTag = $"<meta property=\"og:type\" content=\"{type}\" />";
                string imageTag = $"<meta property=\"og:image\" content=\"{image}\" />";
                string urlTag = $"<meta property=\"og:url\" content=\"{url}\" />";

                return new MvcHtmlString($"{titleTag}{typeTag}{urlTag}{imageTag}");
            }
            else
            {
                return MvcHtmlString.Empty;
            }
        }

        private static string GetFirstMatchingProperty(this IContentData data, string[] names)
        {
            foreach (string name in names)
            {
                if (data.Property[name] != null)
                {
                    if (data.Property[name].Value != null)
                    {
                        return data.Property[name].Value.ToString();
                    }
                }
            }
            return string.Empty;
        }
    }
}