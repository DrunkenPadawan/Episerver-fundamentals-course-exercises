﻿using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "Start",
        // your code will have a random GUID here
        GroupName = SiteGroupNames.Specialized, Order = 10,
        Description = "The home page for a website with an area for blocks and partial pages.")]
    [SiteStartIcon]
    [AvailableContentTypes(Include = new[] { typeof(StandardPage) })]
    public class StartPage : SitePageData
    {
        [CultureSpecific]
        [Display(Name = "Heading", Description =
        "If the Heading is not set, the page falls back to showing the Name.",
        GroupName = SystemTabNames.Content, Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(Name = "Main body",
        Description = "The main body uses the XHTML-editor so you can insert, for example text, images, and tables.",
        GroupName = SystemTabNames.Content, Order = 20)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(Name = "Footer text",
        Description = "The footer text will be shown at the bottom of every page.",
        GroupName = SiteTabNames.SiteSettings, Order = 10)]
        public virtual string FooterText { get; set; }

        public virtual decimal Price { get; set; }

        [CultureSpecific]
        [Display(Name = "Main content area",
        Description = "Drag and drop iamges, blocks, and pages with påartial templates.",
        GroupName = SystemTabNames.Content, Order = 30)]
        [AllowedTypes(typeof(StandardPage), typeof(BlockData), typeof(ImageData))]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(Name = "Search page",
 Description = "If you add a Search page to the site, set this property to reference it to enable search from every page.",
 GroupName = SiteTabNames.SiteSettings,
 Order = 40)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageLink { get; set; }
    }
}